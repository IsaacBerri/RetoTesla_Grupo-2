using System;
using System.ComponentModel.DataAnnotations;

namespace TeslaReto.Data.Models;

public class Usuarios : BaseEntity<int>
{
    [Required]
    public string NombreDeUsuarios { get; set; } = "";

    [Required]
    public string Password { get; set; } = "";

    public Roles Rol { get; set; }

    
}

public enum Roles
{
    Admin,
    User
}


