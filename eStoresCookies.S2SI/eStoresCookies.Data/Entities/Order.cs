using System.ComponentModel.DataAnnotations;

namespace eStoresCookies.Data.Entities;

public class Order
{
    public DateTime Date { get; set; }

    public Guid Id { get; set; }

    public string? CustomerCode { get; set; }

    [Required]
    public List<OrderItem>? Items { get; set; }
}