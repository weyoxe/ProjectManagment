using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using App.DAL.Models;
using System.Collections.Generic;

namespace App.DAL.Repositories.Contracts
{
    public interface IGenericRepository<TModel> where TModel : class
    {
        Task<List<TModel>> GetAll();
        Task<TModel> GetById(object id);
        Task<int> Insert(TModel entity);
        Task<int> Update(TModel entity);
        Task<int> Delete(object id);
    }
}
