using Abogado.Domain.Entities;
using Abogado.Domain.Ports;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Abogado.Infrastructure.Persistencia
{
    public class RepositorySQL : IRepository
    {
        private readonly AbogadoContext context;

        public RepositorySQL(AbogadoContext context)
        {
            this.context = context;
        }

        public bool Exists<T>(Expression<Func<T, bool>> expression) where T : Entity
        {
            try
            {
                return context.Set<T>().AsQueryable().Any(expression);
            }
            catch (Exception e)
            {

                throw new Exception($"no se completo la operacion {e.Message}");
            }
        }

        public async Task<T> Get<T>(string id) where T : Entity
        {
            try
            {
                return await context.Set<T>().FirstOrDefaultAsync(x => x.Id.ToString() == id);
            }
            catch (Exception e)
            {
                throw new Exception($"no se completo la operacion: {e.Message}");
            }
        }

        public async Task<T> Get<T>(Expression<Func<T, bool>> expression) where T : Entity
        {
            try
            {
                return await context.Set<T>().FirstOrDefaultAsync(expression);
            }
            catch (Exception e)
            {
                throw new Exception($"no se completo la operacion: {e.Message}");
            }
        }

        public async Task<List<T>> GetAll<T>() where T : Entity
        {
            try
            {
                return await context.Set<T>().ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"no se completo la operacion: {e.Message}");
            }
        }

        public async Task Save<T>(T obj) where T : Entity
        {
            try
            {
                var entity = await context.Set<T>().AddAsync(obj);

                //confirma que se añadio el objeto
                if (await context.SaveChangesAsync() < 0)
                    throw new Exception($"no se completo la operacion: {obj.GetType()}");
            }
            catch (Exception e)
            {
                throw new Exception($"{e.Message}");
            }
        }

        public async Task Update<T>(T obj) where T : Entity
        {
            try
            {
                context.Entry(await context.Set<T>()
                    .FirstOrDefaultAsync(x => x.Id == obj.Id))
                    .CurrentValues.SetValues(obj);

                if (await context.SaveChangesAsync() < 0)
                    throw new Exception($"no se pudo actualizar: {obj.GetType()}");
            }
            catch (Exception e)
            {
                throw new Exception($"no se completo la operacion: {e.Message}");
            }
        }

        public async Task<List<T>> GetAll<T>(
            Expression<Func<T, bool>> expression) where T : Entity
        {
            try
            {
                return await context.Set<T>()
                    .Where(expression)
                    .ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"no se completo la operacion: {e.Message}");
            }
        }

        public async Task<List<T>> GetNested<T>(string nested) where T : Entity
        {
            try
            {
                return await context.Set<T>()
                    .Include(nested)
                    .ToListAsync();
            }

            catch (Exception e)
            {
                throw new Exception($"{e.Message}");
            }
        }
    }
}
