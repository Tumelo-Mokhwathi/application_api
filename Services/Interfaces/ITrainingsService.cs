using application_api.Models;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace application_api.Services.Interfaces
{
    public interface ITrainingsService
    {
        Task<IReadOnlyList<Training>> GetAsync();
        Task<Result<Training>> CreateAsync(Training training);
        Task<Result<Training>> UpdateAsync(int id, Training training);
        Task<Result<Training>> DeleteAsync(int id);
    }
}
