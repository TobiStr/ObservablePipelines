using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.VisualBasic;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;
using NUnit.Framework;
using ObservablePipelines.Test.ShowCase.Abstractions;
using ObservablePipelines.Test.ShowCase.Model;
using ObservablePipelines.Test.ShowCase.Pipes;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading.Tasks;

namespace ObservablePipelines.Test.ShowCase
{
    [TestFixture]
    internal class ShowCase
    {
        private IPipelineBuilder pipelineBuilder;

        private IObservable<ChatMessage> chatMessages;

        private IServiceProvider serviceProvider;

        private ILogger<ShowCase> logger;

        [SetUp]
        public void SetUp() {
            var services = new ServiceCollection();

            ConfigureServices(services);

            serviceProvider = services
                .BuildServiceProvider();

            pipelineBuilder = serviceProvider
                .GetRequiredService<IPipelineBuilder>();

            logger = serviceProvider
                .GetRequiredService<ILogger<ShowCase>>();

            chatMessages = GetTestMessages().ToObservable();
        }

        private void ConfigureServices(IServiceCollection services) {
            var userRepositoryMock = new Mock<IUserRepository>();
            userRepositoryMock.SetReturnsDefault("TestSender");

            services
                .AddLogging(builder => builder
                    .AddConsole()
                    .AddDebug()
                );

            services
                .AddObservablePipelines()
                .AddTransient(_ => userRepositoryMock.Object)
                .AddSingleton(new TestContainer(5))
                ;
        }

        [Test]
        public async Task TestShowCase() {
            await Task.Yield();

            var pipeline = pipelineBuilder
                .ConfigureOptions(builder => builder
                    .Add(new MessageFilterPipeOptions(Guid.Empty))
                )
                .ConfigurePipeline(builder => builder
                    .AddSource(chatMessages)
                    .AddStep<LoggerPipe, ChatMessage>()
                    .AddStep<MessageFilterPipe, ChatMessage>()
                    .AddStep<MessageTransformPipe, IdentifiedChatMessage>()
                    .AddStep(new ConsoleLoggerPipe())
                )
                .Build();

            pipeline.Subscribe(m =>
                logger.LogInformation($"New Message from {m.SenderName}: {m.Message}.")
            );

            await Task.Delay(TimeSpan.FromSeconds(1));

            //Output:
            //Pipes.LoggerPipe: Information: Pipeline triggered for message: 'Hello'.
            //Pipes.MessageFilterPipe: Information: Filter let message: 'Hello' pass through.
            //Pipes.MessageTransformPipe: Information: Identified sender: 'TestSender'.
            //ShowCase: Information: New Message from 'TestSender': Hello.
            //Pipes.LoggerPipe: Information: Pipeline triggered for message: ShouldBeFilteredOut.
            //Pipes.LoggerPipe: Information: Pipeline triggered for message: How are you?.
            //Pipes.MessageFilterPipe: Information: Filter let message: 'How are you?' pass through.
            //Pipes.MessageTransformPipe: Information: Identified sender: 'TestSender'.
            //ShowCase: Information: New Message from 'TestSender': How are you?.
        }

        [Test]
        public async Task SingletonNotDuplicatedTest() {
            await Task.Yield();

            var container = serviceProvider.GetRequiredService<TestContainer>();

            Assert.That(container.Number == 5);

            var pipeline = pipelineBuilder
                .ConfigureOptions(builder => builder
                    .Add(new MessageFilterPipeOptions(Guid.Empty))
                )
                .ConfigurePipeline(builder => builder
                    .AddSource(chatMessages)
                    .AddStep<LoggerPipe, ChatMessage>()
                    .AddStep<ContainerTransformPipe, ChatMessage>()
                    .AddStep<MessageFilterPipe, ChatMessage>()
                    .AddStep<MessageTransformPipe, IdentifiedChatMessage>()
                    .AddStep(new ConsoleLoggerPipe())
                )
                .Build();

            pipeline.Subscribe(m =>
                logger.LogInformation($"New Message from {m.SenderName}: {m.Message}.")
            );

            await Task.Delay(TimeSpan.FromSeconds(1));

            Assert.That(container.Number == 2);
        }

        private IEnumerable<ChatMessage> GetTestMessages() {
            return new ChatMessage[] {
                new(
                  Message: "Hello",
                  SenderId: Guid.NewGuid(),
                  ReceiverId: Guid.Empty,
                  SendDate: DateTime.Now
                ),
                new(
                  Message: "ShouldBeFilteredOut",
                  SenderId: Guid.NewGuid(),
                  ReceiverId: Guid.NewGuid(),
                  SendDate: DateTime.Now
                ),
                new(
                  Message: "How are you?",
                  SenderId: Guid.NewGuid(),
                  ReceiverId: Guid.Empty,
                  SendDate: DateTime.Now
                )
            };
        }
    }
}