using System;
using System.Collections.Generic;

namespace Eventos_Peru.Core.Core.Entities;

public partial class UsuarioInteres
{
    public int IdUsuario { get; set; }

    public int IdInteres { get; set; }

    public DateTime FechaRegistro { get; set; }

    public virtual Interes IdInteresNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
