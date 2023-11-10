using System;
using System.Collections.Generic;

namespace PracticaCrud.Models;

public partial class Cliente
{
    public int Id { get; set; }

    public string? Nombre { get; set; }

    public string? Apellidos { get; set; }

    public string? Dirección { get; set; }

    public string? Email { get; set; }

    public string? Password { get; set; }

    public virtual ICollection<ClienteArticulo> ClienteArticulos { get; set; } = new List<ClienteArticulo>();
}
