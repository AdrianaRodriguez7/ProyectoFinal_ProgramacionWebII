using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatosGastos.Data.Entidades
{
    public class TipoTransaccion
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public ICollection<Transaccion> Transacciones { get; set; }
    }
}
