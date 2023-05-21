using Microsoft.EntityFrameworkCore;
using Slots.DAL.Interfaces;
using Slots.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using static Slots.DAL.Repositories.DrinkRepository;

namespace Slots.DAL.Repositories
{

    public class DrinkRepository : IBaseRepository<Drink>
    {
        private readonly ApplicationDbContext _db;

        public DrinkRepository(ApplicationDbContext db)
        {
            _db = db;
        }

           
        public async Task Create(Drink entity)
        {
            await _db.Drink.AddAsync(entity);
            await _db.SaveChangesAsync();
        }

        public IQueryable<Drink> GetAll()
        {
            return _db.Drink;
        }

        public async Task Delete(Drink entity)
        {
            _db.Drink.Remove(entity);
            await _db.SaveChangesAsync();
        }

        public async Task<Drink> Update(Drink entity)
        {
            _db.Drink.Update(entity);
            await _db.SaveChangesAsync();

            return entity;
        }
    }
}