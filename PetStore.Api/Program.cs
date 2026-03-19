using PetStore.Api.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
    });
});

var app = builder.Build();

app.UseCors();
app.UseDefaultFiles();
app.UseStaticFiles();

// In-memory pet store data
var pets = new List<Pet>
{
    new Pet { Id = 1, Name = "Fluffy", Species = "Cat", Emoji = "🐱", Description = "A soft and cuddly kitten who loves to purr and play with yarn!", Price = 50, Color = "#FFB6C1", IsAdopted = false },
    new Pet { Id = 2, Name = "Buddy", Species = "Dog", Emoji = "🐶", Description = "A playful golden puppy who loves to fetch and give hugs!", Price = 75, Color = "#FFD700", IsAdopted = false },
    new Pet { Id = 3, Name = "Tweety", Species = "Bird", Emoji = "🐦", Description = "A cheerful yellow bird who loves to sing happy songs!", Price = 30, Color = "#87CEEB", IsAdopted = false },
    new Pet { Id = 4, Name = "Bubbles", Species = "Fish", Emoji = "🐠", Description = "A colorful tropical fish who loves to swim and blow bubbles!", Price = 20, Color = "#00CED1", IsAdopted = false },
    new Pet { Id = 5, Name = "Hoppy", Species = "Bunny", Emoji = "🐰", Description = "A fluffy white bunny who loves to hop around and eat carrots!", Price = 45, Color = "#98FB98", IsAdopted = false },
    new Pet { Id = 6, Name = "Spike", Species = "Turtle", Emoji = "🐢", Description = "A wise old turtle who moves slowly but gives the best advice!", Price = 35, Color = "#90EE90", IsAdopted = false },
    new Pet { Id = 7, Name = "Zippy", Species = "Hamster", Emoji = "🐹", Description = "An energetic hamster who loves running on her wheel all day!", Price = 25, Color = "#DEB887", IsAdopted = false },
    new Pet { Id = 8, Name = "Goldie", Species = "Fish", Emoji = "🐡", Description = "A shiny goldfish who loves to swim in circles and make wishes!", Price = 15, Color = "#FFA500", IsAdopted = false },
};

var adoptions = new List<object>();

// GET all available pets
app.MapGet("/api/pets", () => pets.Where(p => !p.IsAdopted).ToList());

// GET all pets (including adopted)
app.MapGet("/api/pets/all", () => pets);

// GET single pet
app.MapGet("/api/pets/{id}", (int id) =>
{
    var pet = pets.FirstOrDefault(p => p.Id == id);
    return pet is not null ? Results.Ok(pet) : Results.NotFound();
});

// POST adopt a pet
app.MapPost("/api/pets/{id}/adopt", (int id) =>
{
    var pet = pets.FirstOrDefault(p => p.Id == id);
    if (pet is null) return Results.NotFound();
    if (pet.IsAdopted) return Results.BadRequest("This pet has already been adopted!");

    pet.IsAdopted = true;
    var adoption = new { PetId = id, PetName = pet.Name, AdoptedAt = DateTime.UtcNow, Message = $"Congratulations! You adopted {pet.Name} the {pet.Species}! 🎉" };
    adoptions.Add(adoption);
    return Results.Ok(adoption);
});

// GET adoption history
app.MapGet("/api/adoptions", () => adoptions);

app.Run();
