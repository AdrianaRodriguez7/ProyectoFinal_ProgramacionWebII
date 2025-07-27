using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnlaceGastos.Services.Interfaces
{
    public interface IAnalisisFinancieroStrategy
    {
        string Evaluar(decimal ingresos, decimal egresos);
    }
}
