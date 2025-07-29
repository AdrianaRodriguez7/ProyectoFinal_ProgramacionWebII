using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace DatosGastos.Data.Entidades
{
    public class Transaccion
    {
        public int Id { get; set; }

        [Precision(18, 2)]
        [Required(ErrorMessage = "El monto es obligatorio")]
        public decimal Monto { get; set; }

        public string Descripcion { get; set; }
        [Required(ErrorMessage = "La fecha es obligatoria")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Debes seleccionar una categoría")]
        public int CategoriaId { get; set; }
        public Categoria Categoria { get; set; }

        [Required(ErrorMessage = "Debes seleccionar un tipo")]
        public int TipoTransaccionId { get; set; }
        public TipoTransaccion TipoTransaccion { get; set; }

        public bool Eliminado { get; set; } = false;

    }
}
