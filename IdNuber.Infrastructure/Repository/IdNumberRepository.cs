using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Salary.Infrastructure;

namespace IdNuber.Infrastructure.Repository
{
    public class IdNumberRepository : IIdNumberRepository
    {
        private readonly IdNumberContext _context;

        public IUnitOfWork UnitOfWork
        {
            get
            {
                return _context;
            }
        }


        public IdNumberRepository(IdNumberContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));

        }

        public IdNumber Add(IdNumber idNumber)
        {
            return _context.IdNumber.Add(idNumber).Entity;

        }

        public void Delete(int id)
        {
            var idNumber = _context.IdNumber.Find(id);
            _context.IdNumber.Remove(idNumber);
        }

        public async Task<IdNumber> GetAsync(int idNumberId)
        {
            var idNumber = await _context.IdNumber.FindAsync(idNumberId);
            if (idNumber != null)
            {
                await _context.Entry(idNumber).Reference(i => i.days).LoadAsync();
            }

            return idNumber;
        }

        public void Update(IdNumber idNumber)
        {
            _context.Entry(idNumber).State = EntityState.Modified;

        }

    }
}
