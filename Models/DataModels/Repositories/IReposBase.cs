using DataModels.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataModels.Repositories
{
    public interface IReposBase<TTable> where TTable : class
    {
        IQueryable<TTable> Items { get; }
        //IQueryable<TTable?> GetAllItemsAsync();
        //Task<Collection<Apps>?> GetAllItemsById(object item);
        //Task<Collection<Apps>?> GetAllItems();
        Task<TTable?> GetItemByIdAsync(Guid id);
        Task<int> UpdateAsync(TTable table);
        Task<int> DeleteAsync(Guid id);
    }
}
