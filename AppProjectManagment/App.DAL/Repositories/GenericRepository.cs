using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using App.DAL.DataContext;
using App.DAL.Models;
using App.DAL.Repositories.Contracts;
using Microsoft.EntityFrameworkCore;

namespace App.DAL.Repositories
{
    public class GenericRepository<TModel> : IGenericRepository<TModel> where TModel : class
    {


        private readonly PmdbContext _dbContext;
        public GenericRepository(PmdbContext dbContext)
        {
            _dbContext = dbContext;
        }



        public async Task<List<TModel>> GetAll()
        {
            try
            {
                return await _dbContext.Set<TModel>().ToListAsync();
            }
            catch
            {
                throw;
            }
        }
        public async Task<TModel> GetById(object id)
        {
       
                return await _dbContext.Set<TModel>().FindAsync(id);
            
            //return _dbContext.Set<TModel>().FirstOrDefaultAsync(x => x.id == TModel.Id);
        }

        public async Task<int> Insert(TModel entity)
        {
            _dbContext.Set<TModel>().Add(entity);
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Update(TModel entity)
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            return await _dbContext.SaveChangesAsync();
        }

        public async Task<int> Delete(object id)
        {
            var entity = await _dbContext.Set<TModel>().FindAsync(id);
            if (entity != null)
            {
                _dbContext.Set<TModel>().Remove(entity);
                return await _dbContext.SaveChangesAsync();
            }
            return 0; // No entity found with the given id
        }

        public async Task<object> GetId(TModel entity)
        {
            var entityEntry = _dbContext.Entry(entity);
            var key = entityEntry.Metadata.FindPrimaryKey();
            return key.Properties.Select(p => entityEntry.Property(p.Name).CurrentValue).FirstOrDefault();
        }



    }
}
