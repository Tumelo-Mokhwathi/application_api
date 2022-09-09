using application_api.DataAccess;
using application_api.Models;
using application_api.Services.Interfaces;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace application_api.Services.Implementations
{
    public class CoursesService : ICoursesService
    {
        private readonly ApplicationDbContext _context;
        public CoursesService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<ActiveCourse>> GetAsync() =>
            await _context.ActiveCourses.ToListAsync().ConfigureAwait(false);

        public async Task<Result<ActiveCourse>> CreateAsync(ActiveCourse course)
        {
            var model = new ActiveCourse()
            {
                CourseCode = course.CourseCode,
                CourseName = course.CourseName,
                CourseDescription = course.CourseDescription,
                TrainingVenueSelected = course.TrainingVenueSelected,
                isTrainingFreeOrPaid = course.isTrainingFreeOrPaid
            };

            _context.ActiveCourses.Add(model);
            await _context.SaveChangesAsync();

            return CSharpFunctionalExtensions.Result.Success(model);
        }
        public async Task<Result<ActiveCourse>> UpdateAsync(int id, ActiveCourse course)
        {
            var model = await _context.ActiveCourses.FindAsync(id);

            if (model == null)
            {
                return CSharpFunctionalExtensions.Result.Failure<ActiveCourse>($"Course not found for ID {id}");
            }

            model.CourseCode = course.CourseCode;
            model.CourseDescription = course.CourseDescription;
            model.CourseName = course.CourseName;
            model.TrainingVenueSelected = course.TrainingVenueSelected;
            model.isTrainingFreeOrPaid = course.isTrainingFreeOrPaid;

            _context.ActiveCourses.Update(model);
            await _context.SaveChangesAsync();

            return CSharpFunctionalExtensions.Result.Success(model);
        }
        public async Task<Result<ActiveCourse>> DeleteAsync(int id)
        {
            var model = await _context.ActiveCourses.FindAsync(id);

            if (model == null)
            {
                return CSharpFunctionalExtensions.Result.Failure<ActiveCourse>($"Course not found for ID {id}");
            }

            _context.ActiveCourses.Remove(model);
            await _context.SaveChangesAsync();

            return CSharpFunctionalExtensions.Result.Success(model);
        }
    }
}
