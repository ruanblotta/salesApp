using System;
using System.Linq;
using salesApp.Data;
using salesApp.Models;

namespace salesApp.Services
{
    public class SeedingService
    {
        private readonly salesAppContext _context;

        public SeedingService(salesAppContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            // Verifica se já existem dados na tabela Department, por exemplo
            if (_context.Department.Any())
            {
                return; // DB has been seeded
            }

            Department d1 = new Department { Id = 1, Name = "Department1" };
            Department d2 = new Department { Id = 2, Name = "Department2" };

            _context.Department.AddRange(d1, d2);

            _context.SaveChanges();
        }
    }
}
