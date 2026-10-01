using System;
using System.Collections.Generic;

namespace Eventos_Peru.Core.Core.Entities;

public partial class UsuarioRol
{
    public int IdUsuario { get; set; }

    public int IdRol { get; set; }

    public DateTime FechaAsignacion { get; set; }

    public virtual Rol IdRolNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
