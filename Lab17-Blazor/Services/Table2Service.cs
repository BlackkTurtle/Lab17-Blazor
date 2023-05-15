using Lab17_Blazor.Data;
using Lab17_Blazor.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab17_Blazor.Services
{
    public class Table2Service
    {
        private IDbContextFactory<TablesContext> _dbContextFactory;
        public Table2Service(IDbContextFactory<TablesContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<ActionResult<IEnumerable<Table2>>> GetAllTable2Async()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var results = await context.table2s.ToListAsync();
                return results;
            }
        }
        public async Task<ActionResult<Table2>> GetTable2ByIdAsync(int id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var entity = await context.table2s.Where(e => e.Id == id).SingleOrDefaultAsync();
                return entity;
            }
        }
        public async Task PostTable2Async(Table2 fullentity)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var entity = new Table2()
                {
                    Name = fullentity.Name,
                    Table1Id=fullentity.Table1Id
                };
                await context.table2s.AddAsync(entity);
                await context.SaveChangesAsync();
            }
        }
        public async Task UpdateTable2Async(int id, Table2 updatedentity)
        {
            using (var context = _dbContextFactory.CreateDbContext()) {
                var entity = await context.table2s.Where(e => e.Id == id).SingleOrDefaultAsync();
                entity.Name = updatedentity.Name;
                entity.Table1Id = updatedentity.Table1Id;
                await context.SaveChangesAsync();
            }
        }
        public async Task DeleteTable2ByIdAsync(int id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var entity = await context.table2s.Where(e => e.Id == id).SingleOrDefaultAsync();

                context.table2s.Remove(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}
