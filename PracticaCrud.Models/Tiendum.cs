using System;
using System.Collections.Generic;

namespace PracticaCrud.Models;

public partial class Tiendum
{
    public int Id { get; set; }

    public string? Sucursal { get; set; }

    public string? Dirección { get; set; }

    public virtual ICollection<ArticuloTiendum> ArticuloTienda { get; set; } = new List<ArticuloTiendum>();
}
