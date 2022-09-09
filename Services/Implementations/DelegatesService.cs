using application_api.DataAccess;
using application_api.Models;
using application_api.Services.Interfaces;
using CSharpFunctionalExtensions;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Delegate = application_api.Models.Delegate;

namespace application_api.Services.Implementations
{
    public class DelegateService : IDelegateService
    {
        private readonly ApplicationDbContext _context;
        public DelegateService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<Delegate>> GetAsync() =>
            await _context.Delegates.ToListAsync().ConfigureAwait(false);

        public async Task<Result<Delegate>> CreateAsync(Delegate delegateSelected)
        {
            var model = new Delegate()
            {
                FirstName = delegateSelected.FirstName,
                LastName = delegateSelected.LastName,
                PhoneNumber = delegateSelected.PhoneNumber,
                Email = delegateSelected.Email,
                DietaryRequirement = delegateSelected.DietaryRequirement,
                CompanyName = delegateSelected.CompanyName,
                DelegatePhysicalAddress = delegateSelected.DelegatePhysicalAddress,
                DelegatePostalAddress = delegateSelected.DelegatePostalAddress
            };

            _context.Delegates.Add(model);
            await _context.SaveChangesAsync();

            return CSharpFunctionalExtensions.Result.Success(model);
        }
        public async Task<Result<Delegate>> UpdateAsync(int id, Delegate delegateSelected)
        {
            var model = await _context.Delegates.FindAsync(id);

            if (model == null)
            {
                return CSharpFunctionalExtensions.Result.Failure<Delegate>($"Delegate not found for ID {id}");
            }

            model.FirstName = delegateSelected.FirstName;
            model.LastName = delegateSelected.LastName;
            model.PhoneNumber = delegateSelected.PhoneNumber;
            model.Email = delegateSelected.Email;
            model.DietaryRequirement = delegateSelected.DietaryRequirement;
            model.CompanyName = delegateSelected.CompanyName;
            model.DelegatePhysicalAddress = delegateSelected.DelegatePhysicalAddress;
            model.DelegatePostalAddress = delegateSelected.DelegatePostalAddress;

            _context.Delegates.Update(model);
            await _context.SaveChangesAsync();

            return CSharpFunctionalExtensions.Result.Success(model);
        }
        public async Task<Result<Delegate>> DeleteAsync(int id)
        {
            var model = await _context.Delegates.FindAsync(id);

            if (model == null)
            {
                return CSharpFunctionalExtensions.Result.Failure<Delegate>($"Delegate not found for ID {id}");
            }

            _context.Delegates.Remove(model);
            await _context.SaveChangesAsync();

            return CSharpFunctionalExtensions.Result.Success(model);
        }
    }
}
