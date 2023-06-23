using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace listadeVentas

{
    public class Ventas
    {
        public int Id { get; set; }
        public string Comentarios { get; set; }


        public Ventas()
        {
            Id = 0;
            Comentarios = string.Empty;
        }

    }
}