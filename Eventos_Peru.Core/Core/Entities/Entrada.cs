using System;
using System.Collections.Generic;

namespace Eventos_Peru.Core.Core.Entities;

public partial class Entrada
{
    public int IdEntrada { get; set; }

    public int IdDetalleCompra { get; set; }

    public Guid CodigoEntrada { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaGeneracion { get; set; }

    public virtual CheckIn? CheckIn { get; set; }

    public virtual DetalleCompra IdDetalleCompraNavigation { get; set; } = null!;
}
