using System;
using System.Collections.Generic;

namespace PuntoVenta.Models;

public partial class Detalleventa
{
    public int IdDetalle { get; set; }

    public int IdVenta { get; set; }

    public int IdProducto { get; set; }

    public int Cantidad { get; set; }

    public decimal PrecioUnitario { get; set; }

    public virtual Productos IdProductoNavigation { get; set; } = null!;

    public virtual Venta IdVentaNavigation { get; set; } = null!;
}
