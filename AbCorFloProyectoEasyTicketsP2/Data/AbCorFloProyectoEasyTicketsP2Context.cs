﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ProyectoEasyTicket.Models;

namespace AbCorFloProyectoEasyTicketsP2.Data
{
    public class AbCorFloProyectoEasyTicketsP2Context : DbContext
    {
        public AbCorFloProyectoEasyTicketsP2Context (DbContextOptions<AbCorFloProyectoEasyTicketsP2Context> options)
            : base(options)
        {
        }

        public DbSet<ProyectoEasyTicket.Models.Ticket> Ticket { get; set; } = default!;
    }
}