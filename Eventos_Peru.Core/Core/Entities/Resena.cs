using System;
using System.Collections.Generic;

namespace Eventos_Peru.Core.Core.Entities;

public partial class Resena
{
    public int IdResena { get; set; }

    public int IdUsuario { get; set; }

    public int IdEvento { get; set; }

    public byte Calificacion { get; set; }

    public string Comentario { get; set; } = null!;

    public DateTime FechaPublicacion { get; set; }

    public DateTime? FechaModificacion { get; set; }

    public virtual Evento IdEventoNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
