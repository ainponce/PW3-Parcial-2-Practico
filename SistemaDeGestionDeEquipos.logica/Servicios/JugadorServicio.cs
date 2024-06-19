using Microsoft.EntityFrameworkCore;
using SistemaDeGestionDeEquipos.datos.EF;
using System.Collections.Generic;
using System.Linq;

namespace SistemaDeGestionDeEquipos.Logica.Servicios
{
    public class JugadorServicio
    {
        private readonly Pw3dbContext _context;

        public JugadorServicio(Pw3dbContext context)
        {
            _context = context;
        }

        public IEnumerable<Equipo> ObtenerEquiposParticipantes()
        {
            return _context.Equipos.Where(e => e.ParticipaEnTorneo).OrderBy(e => e.NombreEquipo).ToList();
        }

        public void CrearJugador(Jugador jugador)
        {
            _context.Jugadores.Add(jugador);
            _context.SaveChanges();
        }

        public List<Jugador> Listar()
        {
            return _context.Jugadores.ToList();

        }

        public List<Jugador> ListarJugadoresPorEquipo(int idEquipo)
        {
            return _context.Jugadores
            .Where(e => e.IdEquipo == idEquipo &&
                e.IdEquipoNavigation.ParticipaEnTorneo)
            .ToList();
        }

        public IEnumerable<Jugador> ObtenerJugadores()
        {
            return _context.Jugadores.ToList();
        }
    }
}
