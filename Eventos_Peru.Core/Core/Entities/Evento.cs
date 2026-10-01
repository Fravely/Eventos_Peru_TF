using System;
using System.Collections.Generic;

namespace Eventos_Peru.Core.Core.Entities;

public partial class Evento
{
    public int IdEvento { get; set; }

    public int IdOrganizador { get; set; }

    public int IdCategoria { get; set; }

    public string Nombre { get; set; } = null!;

    public string? Descripcion { get; set; }

    public DateTime FechaHoraInicio { get; set; }

    public DateTime FechaHoraFin { get; set; }

    public string Ubicacion { get; set; } = null!;

    public int AforoMaximo { get; set; }

    public decimal Precio { get; set; }

    public string Estado { get; set; } = null!;

    public DateTime FechaCreacion { get; set; }

    public virtual ICollection<DetalleCompra> DetalleCompra { get; set; } = new List<DetalleCompra>();

    public virtual Categoria IdCategoriaNavigation { get; set; } = null!;

    public virtual Usuario IdOrganizadorNavigation { get; set; } = null!;

    public virtual ICollection<Moderacion> Moderacion { get; set; } = new List<Moderacion>();

    public virtual ICollection<Notificacion> Notificacion { get; set; } = new List<Notificacion>();

    public virtual ICollection<Resena> Resena { get; set; } = new List<Resena>();
}
