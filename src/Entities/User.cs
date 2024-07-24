using System.ComponentModel.DataAnnotations;
using Anime_figures_backend.src.Enums;
using Microsoft.EntityFrameworkCore;

namespace Anime_figures_backend.src.Entities;

[Index(nameof(Email), IsUnique = true)] // Index is to Search by email faster. 

public class User
{
    public Guid Id { get; set; }
    [Required]
    public Role Role { get; set; } = Role.Customer;
    [Required]
    public string Name { get; set; }
    [Required, EmailAddress]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    [Required]
    public string Phone { get; set; }

    public List<Order> Orders { get; set; } // Navigation order
}