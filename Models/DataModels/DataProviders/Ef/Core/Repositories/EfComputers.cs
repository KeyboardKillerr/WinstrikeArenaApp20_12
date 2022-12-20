using DataModels.Entities;
using DataModels.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.DataProviders.Ef.Core.Repositories
{
    public class EfComputers : IComputersRep
    {
        protected readonly DataContext Context;
        public EfComputers(DataContext context) => Context = context;

        public IQueryable<Computers> Items => Context.Computers
            .Include(x => x.InstalledApps)
            .Include(x => x.InstalledGames)
            .Include(x => x.ZoneId);

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

        public async Task<Computers?> GetItemByIdAsync(Guid id)
        {
            return await Items.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<int> UpdateAsync(Computers table)
        {
            var item = await Items.FirstOrDefaultAsync(x => x.Id == table.Id);
            if (item != default) Context.Update(table);
            else await Context.AddAsync(table);
            return await Context.SaveChangesAsync();
        }
    }
}
