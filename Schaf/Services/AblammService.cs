using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Schaf.Models;

namespace Schaf.Services
{
    public class AblammService : IAblammService
    {
        private AblammContext _context;

        public AblammService(AblammContext context)
        {
            _context = context;
        }

        public IEnumerable<Ablamm2018> getAblamm(string sql)
        {
            var result = _context.Ablamm2018.FromSql(sql).ToList();
            return result;
        }
    }
}
