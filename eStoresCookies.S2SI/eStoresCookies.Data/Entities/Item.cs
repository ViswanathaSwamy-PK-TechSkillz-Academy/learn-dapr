using System.ComponentModel.DataAnnotations;

namespace eStoresCookies.Data.Entities;

public class Item
{
    [Required]
    public string? SKU { get; set; }

    public int Quantity { get; set; }
}