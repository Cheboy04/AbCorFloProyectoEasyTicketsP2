using Microsoft.EntityFrameworkCore;
using AbCorFloProyectoEasyTicketsP2API.Data;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.OpenApi;
using ProyectoEasyTicket.Models;
namespace AbCorFloProyectoEasyTicketsP2API.Controllers;

public static class ReviewsEndpoints
{
    public static void MapReviewsEndpoints (this IEndpointRouteBuilder routes)
    {
        var group = routes.MapGroup("/api/Reviews").WithTags(nameof(Reviews));

        group.MapGet("/", async (AbCorFloProyectoEasyTicketsP2APIContext db) =>
        {
            return await db.Reviews.ToListAsync();
        })
        .WithName("GetAllReviews")
        .WithOpenApi();

        group.MapGet("/{id}", async Task<Results<Ok<Reviews>, NotFound>> (int reviewid, AbCorFloProyectoEasyTicketsP2APIContext db) =>
        {
            return await db.Reviews.AsNoTracking()
                .FirstOrDefaultAsync(model => model.ReviewID == reviewid)
                is Reviews model
                    ? TypedResults.Ok(model)
                    : TypedResults.NotFound();
        })
        .WithName("GetReviewsById")
        .WithOpenApi();

        group.MapPut("/{id}", async Task<Results<Ok, NotFound>> (int reviewid, Reviews reviews, AbCorFloProyectoEasyTicketsP2APIContext db) =>
        {
            var affected = await db.Reviews
                .Where(model => model.ReviewID == reviewid)
                .ExecuteUpdateAsync(setters => setters
                    .SetProperty(m => m.ReviewID, reviews.ReviewID)
                    .SetProperty(m => m.Comentario, reviews.Comentario)
                    .SetProperty(m => m.Calificacion, reviews.Calificacion)
                    .SetProperty(m => m.Fecha, reviews.Fecha)
                    .SetProperty(m => m.TicketID, reviews.TicketID)
                    );
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("UpdateReviews")
        .WithOpenApi();

        group.MapPost("/", async (Reviews reviews, AbCorFloProyectoEasyTicketsP2APIContext db) =>
        {
            db.Reviews.Add(reviews);
            await db.SaveChangesAsync();
            return TypedResults.Created($"/api/Reviews/{reviews.ReviewID}",reviews);
        })
        .WithName("CreateReviews")
        .WithOpenApi();

        group.MapDelete("/{id}", async Task<Results<Ok, NotFound>> (int reviewid, AbCorFloProyectoEasyTicketsP2APIContext db) =>
        {
            var affected = await db.Reviews
                .Where(model => model.ReviewID == reviewid)
                .ExecuteDeleteAsync();
            return affected == 1 ? TypedResults.Ok() : TypedResults.NotFound();
        })
        .WithName("DeleteReviews")
        .WithOpenApi();
    }
}
