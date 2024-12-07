using Microsoft.EntityFrameworkCore;
using AbCorFloProyectoEasyTicketsP2API.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using ProyectoEasyTicket.Models;
namespace AbCorFloProyectoEasyTicketsP2API.Controllers;

public static class TicketEndpoints
{
    public static void MapTicketEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Ticket").WithTags(nameof(Ticket));

        group.MapGet("/", async (AbCorFloProyectoEasyTicketsP2APIContext db) =>
        {
            return await db.Ticket.ToListAsync();
        })
        .WithName("GetAllTickets")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Ticket>, NotFound>> (int ticketid, AbCorFloProyectoEasyTicketsP2APIContext db) =>
        {
            return await db.Ticket.AsNoTracking()
                .FirstOrDefaultAsync(model => model.TicketID == ticketid)
                is Ticket model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetTicketById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int ticketid, Ticket ticket, AbCorFloProyectoEasyTicketsP2APIContext db) =>
        {
            var affected = await db.Ticket
                .Where(model => model.TicketID == ticketid)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.TicketID, ticket.TicketID)
                    .SetProperty(m => m.Evento, ticket.Evento)
                    .SetProperty(m => m.Fecha, ticket.Fecha)
                    .SetProperty(m => m.Lugar, ticket.Lugar)
                    .SetProperty(m => m.ButacaSeccion, ticket.ButacaSeccion)
                    .SetProperty(m => m.Precio, ticket.Precio)
                    .SetProperty(m => m.Telefono, ticket.Telefono)
                    .SetProperty(m => m.Vendido, ticket.Vendido)
                    .SetProperty(m => m.Contrasenia, ticket.Contrasenia)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateTicket")
        .WithOpenApi();

        group.MapPost("/", async (Ticket ticket, AbCorFloProyectoEasyTicketsP2APIContext db) =>
        {
            db.Ticket.Add(ticket);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Ticket/{ticket.TicketID}",ticket);
        })
        .WithName("CreateTicket")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int ticketid, AbCorFloProyectoEasyTicketsP2APIContext db) =>
        {
            var affected = await db.Ticket
                .Where(model => model.TicketID == ticketid)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteTicket")
        .WithOpenApi();
    }
}
