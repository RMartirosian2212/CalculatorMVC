using CalculatorMVC.Models;
using CalculatorMVC_DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorMVC_DataAccess.Repositories
{
    public class CalculatorRepository : IRepository<Calculator, int>
    {
        private readonly ApplicationDbContext _db;
        public CalculatorRepository(ApplicationDbContext db)
        {
             _db = db;
        }
        public IEnumerable<Calculator> GetAll()
        {
            return _db.Calculators.ToList();
        }
        public Calculator GetByID(int id)
        {
            return _db.Calculators.Find(id);
        }
        public Calculator Insert(Calculator entity)
        {
            _db.Add(entity);
            return entity;
        }
        public void Update(Calculator entity)
        {
            _db.Update(entity);
        }
        public void Delete(int id)
        {
            Calculator calculator = _db.Calculators.Find(id);
            if (calculator != null)
            {
                _db.Calculators.Remove(calculator);
            }
        }  
        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
