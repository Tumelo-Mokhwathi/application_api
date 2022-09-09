using application_api.Models;
using CSharpFunctionalExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace application_api.Services.Interfaces
{
    public interface ICoursesService
    {
        Task<IReadOnlyList<ActiveCourse>> GetAsync();
        Task<Result<ActiveCourse>> CreateAsync(ActiveCourse course);
        Task<Result<ActiveCourse>> UpdateAsync(int id, ActiveCourse course);
        Task<Result<ActiveCourse>> DeleteAsync(int id);
    }
}
