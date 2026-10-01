using System;
using System.Collections.Generic;

namespace Eventos_Peru.Core.Core.Entities;

public partial class Moderacion
{
    public int IdModeracion { get; set; }

    public int IdAdministrador { get; set; }

    public int? IdUsuarioAfectado { get; set; }

    public int? IdEventoAfectado { get; set; }

    public string Accion { get; set; } = null!;

    public string Motivo { get; set; } = null!;

    public DateTime FechaAccion { get; set; }

    public virtual Usuario IdAdministradorNavigation { get; set; } = null!;

    public virtual Evento? IdEventoAfectadoNavigation { get; set; }

    public virtual Usuario? IdUsuarioAfectadoNavigation { get; set; }
}
