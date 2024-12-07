using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using AbCorFloProyectoEasyTicketsP2.Data;
using ProyectoEasyTicket.Models;

namespace AbCorFloProyectoEasyTicketsP2.Controllers
{
    public class ACFReviewsController : Controller
    {
        private readonly AbCorFloProyectoEasyTicketsP2Context _context;

        public ACFReviewsController(AbCorFloProyectoEasyTicketsP2Context context)
        {
            _context = context;
        }

        // GET: ACFReviews
        public async Task<IActionResult> Index()
        {
            var abCorFloProyectoEasyTicketsP2Context = _context.Reviews.Include(r => r.Ticket);
            return View(await abCorFloProyectoEasyTicketsP2Context.ToListAsync());
        }

        // GET: ACFReviews/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews
                .Include(r => r.Ticket)
                .FirstOrDefaultAsync(m => m.ReviewID == id);
            if (reviews == null)
            {
                return NotFound();
            }

            return View(reviews);
        }

        // GET: ACFReviews/Create
        public IActionResult Create()
        {
            ViewData["TicketID"] = new SelectList(_context.Ticket, "TicketID", "Evento");
            return View();
        }

        // POST: ACFReviews/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ReviewID,Comentario,Calificacion,Fecha,TicketID")] Reviews reviews)
        {
            if (ModelState.IsValid)
            {
                _context.Add(reviews);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["TicketID"] = new SelectList(_context.Ticket, "TicketID", "Evento", reviews.TicketID);
            return View(reviews);
        }

        // GET: ACFReviews/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews.FindAsync(id);
            if (reviews == null)
            {
                return NotFound();
            }
            ViewData["TicketID"] = new SelectList(_context.Ticket, "TicketID", "Evento", reviews.TicketID);
            return View(reviews);
        }

        // POST: ACFReviews/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ReviewID,Comentario,Calificacion,Fecha,TicketID")] Reviews reviews)
        {
            if (id != reviews.ReviewID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(reviews);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ReviewsExists(reviews.ReviewID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["TicketID"] = new SelectList(_context.Ticket, "TicketID", "Evento", reviews.TicketID);
            return View(reviews);
        }

        // GET: ACFReviews/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var reviews = await _context.Reviews
                .Include(r => r.Ticket)
                .FirstOrDefaultAsync(m => m.ReviewID == id);
            if (reviews == null)
            {
                return NotFound();
            }

            return View(reviews);
        }

        // POST: ACFReviews/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var reviews = await _context.Reviews.FindAsync(id);
            if (reviews != null)
            {
                _context.Reviews.Remove(reviews);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ReviewsExists(int id)
        {
            return _context.Reviews.Any(e => e.ReviewID == id);
        }
    }
}
