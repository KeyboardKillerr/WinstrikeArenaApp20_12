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
    public class EfGames : IGamesRep
    {
        protected readonly DataContext Context;
        public EfGames(DataContext context) => Context = context;

        public IQueryable<Games> Items => Context.Games
            .Include(x => x.Installed)
            .Include(x => x.Users)
            .Include(x => x.GamesGenres);

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

        public async Task<Games?> GetItemByIdAsync(Guid id)
        {
            return await Items.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> UpdateAsync(Games table)
        {
            var item = await Items.FirstOrDefaultAsync(x => x.Id == table.Id);
            if (item != default) Context.Update(table);
            else await Context.AddAsync(table);
            return await Context.SaveChangesAsync();
        }
    }
}