using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EnlaceGastos.Services.Interfaces;

namespace EnlaceGastos.Services.Estrategias
{
    public class AnalizadorFinanciero
    {
        private readonly IAnalisisFinancieroStrategy _estrategia;

        public AnalizadorFinanciero(IAnalisisFinancieroStrategy estrategia)
        {
            _estrategia = estrategia;
        }

        public string EjecutarAnalisis(decimal ingresos, decimal egresos)
        {
            return _estrategia.Evaluar(ingresos, egresos);
        }
    }
}
