using System;

namespace ObservablePipelines.Test.ShowCase.Abstractions;

public interface IUserRepository
{
    string GetUserName(Guid Id);
}
