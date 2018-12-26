using Schaf.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Schaf.Services
{
    interface IAblammService
    {
        IEnumerable<Ablamm2018> getAblamm(string sql);
    }
}
