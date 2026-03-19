namespace PetStore.Api.Models;

public class Pet
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Species { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string Emoji { get; set; } = string.Empty;
    public int Price { get; set; }
    public bool IsAdopted { get; set; }
    public string Color { get; set; } = string.Empty;
}
