using System.Collections;
using System.ComponentModel;
using Lab17_Blazor.Data;
using Lab17_Blazor.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Lab17_Blazor.Services
{
    public class Table1Service
    {
        private IDbContextFactory<TablesContext> _dbContextFactory;
        public Table1Service(IDbContextFactory<TablesContext> dbContextFactory)
        {
            _dbContextFactory = dbContextFactory;
        }
        public async Task<List<Table1>> GetAllTable1Async()
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var results = await context.table1s.ToListAsync();
                return results;
            }
        }
        public async Task<ActionResult<Table1>> GetTable1ByIdAsync(int id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var entity = await context.table1s.Where(e => e.Id == id).SingleOrDefaultAsync();
                return entity;
            }
        }
        public async Task PostTable1Async(Table1 fullentity)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var entity = new Table1()
                {
                    Name = fullentity.Name
                };
                await context.table1s.AddAsync(entity);
                await context.SaveChangesAsync();
            }
        }
        public async Task UpdateTable1Async(int id, Table1 updatedentity)
        {
            using (var context = _dbContextFactory.CreateDbContext()) {
                var entity = await context.table1s.Where(e => e.Id == id).SingleOrDefaultAsync();
                entity.Name = updatedentity.Name;
                await context.SaveChangesAsync();
            }
        }
        public async Task DeleteTable1ByIdAsync(int id)
        {
            using (var context = _dbContextFactory.CreateDbContext())
            {
                var entity = await context.table1s.Where(e => e.Id == id).SingleOrDefaultAsync();

                context.table1s.Remove(entity);
                await context.SaveChangesAsync();
            }
        }
    }
}
