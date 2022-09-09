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
    public class TrainingsService : ITrainingsService
    {
        private readonly ApplicationDbContext _context;
        public TrainingsService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Training>> GetAsync() =>
            await _context.Trainings.ToListAsync()
            .ConfigureAwait(false);

        public async Task<Result<Training>> CreateAsync(Training training)
        {
            var model = new Training()
            {
                TrainingName = training.TrainingName,
                TrainingDate = training.TrainingDate,
                TrainingVenue = training.TrainingVenue,
                NoOfSeatLeft = training.NoOfSeatLeft,
                ClosingDate = training.ClosingDate,
                TrainingCost = training.TrainingCost
            };

            _context.Trainings.Add(model);
            await _context.SaveChangesAsync();

            return CSharpFunctionalExtensions.Result.Success(model);
        }
        public async Task<Result<Training>> UpdateAsync(int id, Training training)
        {
            var model = await _context.Trainings.FindAsync(id);

            if (model == null)
            {
                return CSharpFunctionalExtensions.Result.Failure<Training>($"Training not found for ID {id}");
            }

            model.TrainingName = training.TrainingName;
            model.TrainingDate = training.TrainingDate;
            model.TrainingVenue = training.TrainingVenue;
            model.NoOfSeatLeft = training.NoOfSeatLeft;
            model.ClosingDate = training.ClosingDate;
            model.TrainingCost = training.TrainingCost;

            _context.Trainings.Update(model);
            await _context.SaveChangesAsync();

            return CSharpFunctionalExtensions.Result.Success(model);
        }
        public async Task<Result<Training>> DeleteAsync(int id)
        {
            var model = await _context.Trainings.FindAsync(id);

            if (model == null)
            {
                return CSharpFunctionalExtensions.Result.Failure<Training>($"Training not found for ID {id}");
            }

            _context.Trainings.Remove(model);
            await _context.SaveChangesAsync();

            return CSharpFunctionalExtensions.Result.Success(model);
        }
    }
}
