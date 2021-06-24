using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace examenDesarrollo.Models
{
    public class Producto
    {
        [Key]
        public int id { get; set; }
        public int usuarioid { get; set; }
        public Usuario usuario { get; set; }
        public string nombre { get; set; }
        public decimal precio { get; set; }
        public string descripcion { get; set; }
        public string marca { get; set; }
        public int estado { get; set; }
    }
}
