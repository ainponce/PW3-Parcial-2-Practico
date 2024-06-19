using SistemaDeGestionDeEquipos.datos.EF;

namespace SistemaDeGestionDeEquipos.Logica.Servicios
{
    public interface IEquipoServicio
    {
        List<Equipo> Listar();
    }

    public class EquipoServicio : IEquipoServicio
    {
        private Pw3dbContext _context;
        public EquipoServicio(Pw3dbContext context)
        {
            _context = context;
        }

        public List<Equipo> Listar()
        {
            return _context.Equipos
                .Where(e => e.ParticipaEnTorneo)
                .OrderBy(e => e.NombreEquipo)
                .ToList();
        }
    }
}