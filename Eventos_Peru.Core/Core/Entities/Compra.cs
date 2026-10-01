using System;
using System.Collections.Generic;

namespace Eventos_Peru.Core.Core.Entities;

public partial class Compra
{
    public int IdCompra { get; set; }

    public int IdUsuario { get; set; }

    public Guid CodigoOperacion { get; set; }

    public DateTime FechaCompra { get; set; }

    public decimal MontoTotal { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<DetalleCompra> DetalleCompra { get; set; } = new List<DetalleCompra>();

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
