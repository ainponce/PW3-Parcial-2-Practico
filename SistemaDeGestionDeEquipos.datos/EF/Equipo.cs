using System;
using System.Collections.Generic;

namespace SistemaDeGestionDeEquipos.datos.EF;

public partial class Equipo
{
    public int IdEquipo { get; set; }

    public string NombreEquipo { get; set; } = null!;

    public bool ParticipaEnTorneo { get; set; }

    public virtual ICollection<Jugador> Jugadors { get; set; } = new List<Jugador>();
}
