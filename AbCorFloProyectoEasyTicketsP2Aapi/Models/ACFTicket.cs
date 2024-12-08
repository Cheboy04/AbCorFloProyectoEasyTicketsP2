using Microsoft.AspNetCore.Mvc.ViewEngines;
using System.ComponentModel.DataAnnotations;

namespace ProyectoEasyTicket.Models
{
    public class ACFTicket
    {
        public int ACFTicketID { get; set; }
        [Required]
        public string? ACFEvento { get; set; }
        public DateTime? ACFFecha { get; set; }
        public string? ACFLugar { get; set; }
        public string? ACFButacaSeccion { get; set; }
        public decimal? ACFPrecio { get; set; }

        public string? ACFTelefono { get; set; } 
        public bool ACFVendido { get; set; }
        public string? ACFContrasenia { get; set; }
        
        public List<ACFReviews>? Reviewss {  get; set; }
    }
}
