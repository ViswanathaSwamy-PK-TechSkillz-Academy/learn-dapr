using System.ComponentModel.DataAnnotations;

namespace eStoresCookies.Data.Entities;

public class OrderItem
{
    [Required]
    public string? ProductCode { get; set; }

    public int Quantity { get; set; }
}
