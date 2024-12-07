using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbCorFloProyectoEasyTicketsP2APP.Models
{
    internal class Ticket
    {
        public int TicketID { get; set; }
        [Required]
        public string? Evento { get; set; }
        public DateTime? Fecha { get; set; }
        public string? Lugar { get; set; }
        public string? ButacaSeccion { get; set; }
        public decimal? Precio { get; set; }

        public string? Telefono { get; set; }
        public bool Vendido { get; set; }
        public string? Contrasenia { get; set; }

        public List<Reviews>? Reviewss { get; set; }
    }
}
