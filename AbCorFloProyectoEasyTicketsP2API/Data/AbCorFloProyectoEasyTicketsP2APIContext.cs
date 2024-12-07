using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoEasyTicket.Models;

namespace AbCorFloProyectoEasyTicketsP2API.Data
{
    public class AbCorFloProyectoEasyTicketsP2APIContext : DbContext
    {
        public AbCorFloProyectoEasyTicketsP2APIContext (DbContextOptions<AbCorFloProyectoEasyTicketsP2APIContext> options)
            : base(options)
        {
        }

        public DbSet<ProyectoEasyTicket.Models.Ticket> Ticket { get; set; } = default!;
        public DbSet<ProyectoEasyTicket.Models.Reviews> Reviews { get; set; } = default!;
    }
}
