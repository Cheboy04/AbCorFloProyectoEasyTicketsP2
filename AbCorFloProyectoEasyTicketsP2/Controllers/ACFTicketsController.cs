using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AbCorFloProyectoEasyTicketsP2.Data;
using ProyectoEasyTicket.Models;
using System.Diagnostics;

namespace AbCorFloProyectoEasyTicketsP2.Controllers
{
    public class ACFTicketsController : Controller
    {
        private readonly AbCorFloProyectoEasyTicketsP2Context _context;

        public ACFTicketsController(AbCorFloProyectoEasyTicketsP2Context context)
        {
            _context = context;
        }

        // GET: ACFTickets
        public async Task<IActionResult> Index()
        {
            return View(await _context.Ticket.ToListAsync());
        }

        // GET: ACFTickets/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .FirstOrDefaultAsync(m => m.ACFTicketID == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // GET: ACFTickets/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ACFTickets/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ACFTicketID,ACFEvento,ACFFecha,ACFLugar,ACFButacaSeccion,ACFPrecio,ACFTelefono,ACFVendido,ACFContrasenia")] ACFTicket ticket)
        {
            if (ModelState.IsValid)
            {
                _context.Add(ticket);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(ticket);
        }

        // GET: ACFTickets/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return View(ticket);
        }

        // POST: ACFTickets/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ACFTicketID,ACFEvento,ACFFecha,ACFLugar,ACFButacaSeccion,ACFPrecio,ACFTelefono,ACFVendido,ACFContrasenia")] ACFTicket ticket)
        {
            if (id != ticket.ACFTicketID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(ticket);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TicketExists(ticket.ACFTicketID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index", "ACFTickets");
            }
            return View(ticket);
        }

        // GET: ACFTickets/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .FirstOrDefaultAsync(m => m.ACFTicketID == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        // POST: ACFTickets/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket != null)
            {
                _context.Ticket.Remove(ticket);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TicketExists(int id)
        {
            return _context.Ticket.Any(e => e.ACFTicketID == id);
        }
        public async Task<IActionResult> ConfirmarClave(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .FirstOrDefaultAsync(m => m.ACFTicketID == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }
        // POST: Confirmar Clave
        [HttpPost]
        public async Task<IActionResult> ConfirmarClave(int id, string clave)
        {
            var ticket = _context.Ticket.Find(id);
            if (ticket == null)
            {
                return NotFound();
            }

            // Verifica la clave del ticket
            if (ticket.ACFContrasenia == clave)
            {

                var ticketParaEditar = await _context.Ticket.FindAsync(id);
                return View("Edit", ticketParaEditar);

            }

            // Clave incorrecta, muestra error
            ModelState.AddModelError("", "La clave ingresada es incorrecta. Por favor, intente nuevamente.");
            return View(ticket);
        }
        public async Task<IActionResult> ConfirmarClave2(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .FirstOrDefaultAsync(m => m.ACFTicketID == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }


        // POST: Confirmar Clave
        [HttpPost]
        public async Task<IActionResult> ConfirmarClave2(int id, string clave)
        {
            var ticket = await _context.Ticket.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }

            // Verifica la clave del ticket
            if (ticket.ACFContrasenia == clave)
            {
                TempData["ClaveValidada"] = true;
                return RedirectToAction("Delete", new { id });

            }

            // Clave incorrecta, muestra error
            ModelState.AddModelError("", "La clave ingresada es incorrecta. Por favor, intente nuevamente.");
            return View(ticket);
        }
        public async Task<IActionResult> Comprar(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var ticket = await _context.Ticket
                .FirstOrDefaultAsync(m => m.ACFTicketID == id);
            if (ticket == null)
            {
                return NotFound();
            }

            return View(ticket);
        }

        [HttpPost]
        public IActionResult Comprar(int ticketID)
        {
            Debug.WriteLine("El botón de comprar fue presionado.");

            var ticket = _context.Ticket.Find(ticketID);

            if (ticket == null)
            {
                return NotFound();
            }
            ticket.ACFVendido = true;


            _context.Update(ticket);
            _context.SaveChanges();



            TempData["SuccessMessage"] = "¡Venta exitosa! Gracias por su compra.";

            return RedirectToAction("ConfirmacionVenta");


        }

        public IActionResult ConfirmacionVenta()
        {
            return View();
        }
    }
}
