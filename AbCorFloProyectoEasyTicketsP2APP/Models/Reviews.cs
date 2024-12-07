﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbCorFloProyectoEasyTicketsP2APP.Models
{
    internal class Reviews
    {
        [Key]
        public int ReviewID { get; set; }
        [StringLength(500)]
        public string? Comentario { get; set; } // Comentario del usuario sobre el evento o el ticket

        [Required(ErrorMessage = "La calificación es obligatoria.")]
        [Range(1, 5)] // Establecer que la calificación debe estar entre 1 y 5 estrellas
        public int Calificacion { get; set; } // Calificación (de 1 a 5)

        [Required(ErrorMessage = "La fecha es obligatoria.")]
        public DateTime Fecha { get; set; } = DateTime.Now; // Fecha en la que se hizo la reseña

        public int TicketID { get; set; }

        public Ticket? Ticket { get; set; }
    }
}
