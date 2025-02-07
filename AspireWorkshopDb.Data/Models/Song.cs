using System.ComponentModel.DataAnnotations;

namespace AspireWorkshopDb.Data.Models;

public class Song
{
    public int Id { get; set; }

    [Required]
    public string Artist { get; set; } = string.Empty;

    public string Name { get; set; } = string.Empty;
}