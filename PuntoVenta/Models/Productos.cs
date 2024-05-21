using System;
using System.Collections.Generic;

namespace PuntoVenta.Models;

public partial class Productos
{
    public int Id { get; set; }

    public string Nombre { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public decimal Precio { get; set; }

    public string? UrlImagen { get; set; }
}
