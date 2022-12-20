using DataModels.Entities;
using DataModels.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DataModels.DataProviders.Ef.Core.Repositories
{
    public class EfGenres : IGenresRep
    {
        protected readonly DataContext Context;
        public EfGenres(DataContext context) => Context = context;

        public IQueryable<Genres> Items => Context.Genres
            .Include(x => x.Games);

        public async Task<int> DeleteAsync(Guid id)
        {
            var item = await Items.FirstOrDefaultAsync(x => x.Id == id);
            if (item != default)
            {
                Context.Remove(item);
                return await Context.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<Genres?> GetItemByIdAsync(Guid id)
        {
            return await Items.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> UpdateAsync(Genres table)
        {
            var item = await Items.FirstOrDefaultAsync(x => x.Id == table.Id);
            if (item != default) Context.Update(table);
            else await Context.AddAsync(table);
            return await Context.SaveChangesAsync();
        }
    }
}
