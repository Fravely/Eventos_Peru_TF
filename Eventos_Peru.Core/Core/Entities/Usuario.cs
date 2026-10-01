using System;
using System.Collections.Generic;

namespace Eventos_Peru.Core.Core.Entities;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public string Apellido { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public DateTime FechaRegistro { get; set; }

    public string Estado { get; set; } = null!;

    public virtual ICollection<Compra> Compra { get; set; } = new List<Compra>();

    public virtual ICollection<Evento> Evento { get; set; } = new List<Evento>();

    public virtual ICollection<Moderacion> ModeracionIdAdministradorNavigation { get; set; } = new List<Moderacion>();

    public virtual ICollection<Moderacion> ModeracionIdUsuarioAfectadoNavigation { get; set; } = new List<Moderacion>();

    public virtual ICollection<Notificacion> Notificacion { get; set; } = new List<Notificacion>();

    public virtual ICollection<Resena> Resena { get; set; } = new List<Resena>();

    public virtual ICollection<UsuarioInteres> UsuarioInteres { get; set; } = new List<UsuarioInteres>();

    public virtual ICollection<UsuarioRol> UsuarioRol { get; set; } = new List<UsuarioRol>();
}
