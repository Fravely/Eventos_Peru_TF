using System;
using System.Collections.Generic;

namespace Eventos_Peru.Core.Core.Entities;

public partial class CheckIn
{
    public int IdCheckIn { get; set; }

    public int IdEntrada { get; set; }

    public DateTime FechaHora { get; set; }

    public virtual Entrada IdEntradaNavigation { get; set; } = null!;
}
