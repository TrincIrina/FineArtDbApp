using FineArtDbApp;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<ApplicationDbContext>();
var app = builder.Build();

app.MapGet("/", () => new { message = "server is running" });
app.MapGet("/ping", () => new { message = "pong" });

// вывод всех картин
app.MapGet("/paitings", async (ApplicationDbContext db) => await db.Paintings.ToListAsync());

// вывод по id
app.MapGet(
    "/paitings/{id:int}",
    async (int id, ApplicationDbContext db) => await db.Paintings.FirstOrDefaultAsync(f => f.Id == id)
);

// добавление
app.MapPost("/paitings", async (Painting painting, ApplicationDbContext db) =>
{
    await db.Paintings.AddAsync(painting);
    await db.SaveChangesAsync();
    return painting;
});

// удаление
app.MapDelete("/paitings/{id:int}", async (int id, ApplicationDbContext db) =>
{
    Painting? deleted = await db.Paintings.FirstOrDefaultAsync(f => f.Id == id);
    if (deleted != null)
    {
        db.Paintings.Remove(deleted);
        await db.SaveChangesAsync();
    }
    return deleted;
});


// редактирование
app.MapPatch("/paitings/{id:int}", async (int id, Painting painting, ApplicationDbContext db) =>
{
    Painting? updeted = await db.Paintings.FirstOrDefaultAsync(f => f.Id == painting.Id);
    if (updeted != null)
    {
        updeted.Name = painting.Name;
        updeted.Painter = painting.Painter;
        updeted.YearWriting = painting.YearWriting;
        updeted.Genre = painting.Genre;
        updeted.Type = painting.Type;
        updeted.Technique = painting.Technique;
        await db.SaveChangesAsync();
    }
    return updeted;
});

app.Run();
