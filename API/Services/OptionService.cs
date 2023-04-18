using API.Data;
using API.Entities;
using API.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace API.Services
{
    public class OptionService : IOptionService
    {
        private readonly DataContext context;

        public OptionService(DataContext _context)
        {
            context = _context;
        }

        public async Task<bool> AddOption(Option Option)
        {
            var result = false;
            try
            {
                if (Option is not null)
                {
                    await context.Options!.AddAsync(Option);
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public async Task<bool> DeleteOption(int id)
        {
            var result = false;
            try
            {
                var delete = await context.Options!.FirstOrDefaultAsync(q => q.Id == id);
                if (delete is not null)
                {
                    context.Options!.Remove(delete);
                    context.SaveChanges();
                    result = true;
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }

        public async Task<Option> GetOption(int id)
        {
            var Option = new Option();
            try
            {
                Option = await context.Options!.Include(o => o.Question).FirstOrDefaultAsync(q => q.Id == id);
            }
            catch (Exception)
            {
                Option = null!;
            }
            return Option!;
        }

        public async Task<List<Option>> GetOptions()
        {
            var Options = new List<Option>();
            try
            {
                Options = await context.Options!.ToListAsync();
            }
            catch (Exception)
            {
                Options = null!;
            }
            return Options!;
        }

        public async Task<bool> UpdateOption(Option Option)
        {
            var result = false;
            try
            {
                var update = await context.Options!.FirstOrDefaultAsync(q => q.Id == Option.Id);
                if (update is not null)
                {
                    update.OptionValue = Option.OptionValue;
                    update.IsAnswer = Option.IsAnswer; 
                    await context.SaveChangesAsync();
                    result = true;
                }
            }
            catch (Exception)
            {
                result = false;
            }
            return result;
        }
    }
}
