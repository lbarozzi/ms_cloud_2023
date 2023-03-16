using Microsoft.EntityFrameworkCore;
using Day10Lab1;
using Day10Lab1c;
namespace Day10Lab1.Controllers;

public static class ToDoItemEndpoints
{
    public static void MapToDoItemEndpoints (this IEndpointRouteBuilder routes)
    {
        routes.MapGet("/api/ToDoItem", async (DataContext db) =>
        {
            return await db.ToDoItems.ToListAsync();
        })
        .WithName("GetAllToDoItems")
        .Produces<List<ToDoItem>>(StatusCodes.Status200OK);

        routes.MapGet("/api/ToDoItem/{id}", async (int ToDoItemID, DataContext db) =>
        {
            return await db.ToDoItems.FindAsync(ToDoItemID)
                is ToDoItem model
                    ? Results.Ok(model)
                    : Results.NotFound();
        })
        .WithName("GetToDoItemById")
        .Produces<ToDoItem>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        routes.MapPut("/api/ToDoItem/{id}", async (int ToDoItemID, ToDoItem toDoItem, DataContext db) =>
        {
            var foundModel = await db.ToDoItems.FindAsync(ToDoItemID);

            if (foundModel is null)
            {
                return Results.NotFound();
            }

            db.Update(toDoItem);

            await db.SaveChangesAsync();

            return Results.NoContent();
        })
        .WithName("UpdateToDoItem")
        .Produces(StatusCodes.Status404NotFound)
        .Produces(StatusCodes.Status204NoContent);

        routes.MapPost("/api/ToDoItem/", async (ToDoItem toDoItem, DataContext db) =>
        {
            db.ToDoItems.Add(toDoItem);
            await db.SaveChangesAsync();
            return Results.Created($"/ToDoItems/{toDoItem.ToDoItemID}", toDoItem);
        })
        .WithName("CreateToDoItem")
        .Produces<ToDoItem>(StatusCodes.Status201Created);

        routes.MapDelete("/api/ToDoItem/{id}", async (int ToDoItemID, DataContext db) =>
        {
            if (await db.ToDoItems.FindAsync(ToDoItemID) is ToDoItem toDoItem)
            {
                db.ToDoItems.Remove(toDoItem);
                await db.SaveChangesAsync();
                return Results.Ok(toDoItem);
            }

            return Results.NotFound();
        })
        .WithName("DeleteToDoItem")
        .Produces<ToDoItem>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);
    }
}
