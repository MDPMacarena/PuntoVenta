using System;
using System.Collections.Generic;

namespace PuntoVenta.Models;

public partial class Usuarios
{
    public int Id { get; set; }

    public string Usuario { get; set; } = null!;

    public string Rol { get; set; } = null!;

    public string Nombre { get; set; } = null!;

    public string Password { get; set; } = null!;
}
