using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoEasyTicket.Models;

namespace AbCorFloProyectoEasyTicketsP2Aapi.Data
{
    public class AbCorFloProyectoEasyTicketsP2AapiContext : DbContext
    {
        public AbCorFloProyectoEasyTicketsP2AapiContext (DbContextOptions<AbCorFloProyectoEasyTicketsP2AapiContext> options)
            : base(options)
        {
        }

        public DbSet<ProyectoEasyTicket.Models.ACFTicket> ACFTicket { get; set; } = default!;
        public DbSet<ProyectoEasyTicket.Models.ACFReviews> ACFReviews { get; set; } = default!;
    }
}
