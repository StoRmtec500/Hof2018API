using Microsoft.EntityFrameworkCore;
using Schaf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schaf.Services
{
    public class EinstellungenService : IEinstellungen
    {
        private EinstellungenContext _context;

        public EinstellungenService(EinstellungenContext context)
        {
            _context = context;
        }

        public IEnumerable<Einstellungen> GetAll(string sql)
        {
          //  yield return _context.Einstellungen.Where(s => s.name == "Ablammtermin").FirstOrDefault();
            var result = _context.Einstellungen.FromSql(sql).ToList();
            return result;
        }

        public void UpdateEinstellungen(Einstellungen einstellungen) {
       //     _context.Einstellungen.Update(einstellungen);
         //   _context.SaveChangesAsync();
        }

        public Einstellungen Update(Einstellungen currentEinstellungen)
        {
            _context.Attach(currentEinstellungen);
            _context.Entry(currentEinstellungen).State = EntityState.Modified;
            _context.SaveChanges();
            return currentEinstellungen;
        }

        public Einstellungen GetEinstellungById(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(string sql)
        {
            _context.Database.ExecuteSqlCommand(sql);
        }

    }
}
