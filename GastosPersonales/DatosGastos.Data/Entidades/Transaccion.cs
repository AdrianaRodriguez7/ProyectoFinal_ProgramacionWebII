using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatosGastos.Data.Entidades
{
    public class Transaccion
    {
        public int Id { get; set; }

        [Precision(18, 2)]
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
        public DateTime Fecha { get; set; }

        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        public int TipoTransaccionId { get; set; }
        public TipoTransaccion TipoTransaccion { get; set; }


    }
}
