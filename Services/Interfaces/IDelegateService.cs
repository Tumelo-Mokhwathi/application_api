using application_api.Models;
using System;
using System.Collections.Generic;
using Delegate = application_api.Models.Delegate;
using System.Threading.Tasks;
using CSharpFunctionalExtensions;

namespace application_api.Services.Interfaces
{
    public interface IDelegateService
    {
        Task<IReadOnlyList<Delegate>> GetAsync();
        Task<Result<Delegate>> CreateAsync(Delegate delegateSelected);
        Task<Result<Delegate>> UpdateAsync(int id, Delegate delegateSelected);
        Task<Result<Delegate>> DeleteAsync(int id);
    }
}
