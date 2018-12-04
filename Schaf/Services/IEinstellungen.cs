using Schaf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schaf.Services
{
    public interface IEinstellungen
    {
        IEnumerable<Einstellungen> GetAll(string sql);
        Einstellungen GetEinstellungById(int id);
        void UpdateEinstellungen(Einstellungen einstellungen);
        void Insert(string sql);
        Einstellungen Update(Einstellungen currentEinstellungen);
    }
}
