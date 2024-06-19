using SistemaDeGestionDeEquipos.Logica.Servicios;
using SistemaDeGestionDeEquipos.datos.EF;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;

namespace SistemaDeGestionDeEquipos.Web.Controllers
{
    public class JugadorController : Controller
    {
        private readonly JugadorServicio _jugadorServicio;
        private readonly EquipoServicio _equiposServicio;

        public JugadorController(JugadorServicio jugadorServicio, EquipoServicio equipoServicio)
        {
            _jugadorServicio = jugadorServicio;
            _equiposServicio = equipoServicio;
        }

        // GET: Jugador/Create
        public ActionResult Create()
        {
            ViewBag.IdEquipo = new SelectList(_jugadorServicio.ObtenerEquiposParticipantes(), "IdEquipo", "NombreEquipo");
            return View();
        }

        // POST: Jugador/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Jugador jugador)
        {
            if (ModelState.IsValid)
            {
                return View(jugador);
            }

            _jugadorServicio.CrearJugador(jugador);
            ViewBag.IdEquipo = new SelectList(_jugadorServicio.ObtenerEquiposParticipantes(), "IdEquipo", "NombreEquipo", jugador.IdEquipo);
            return RedirectToAction("Index");
        }

        public IActionResult Index(int? idEquipo)
        {
            ViewBag.Equipos = _equiposServicio.Listar();
            ViewBag.IdEquipoElegido = idEquipo;

            if (idEquipo.HasValue)
            {
                var jugadores = _jugadorServicio.ListarJugadoresPorEquipo(idEquipo.Value);
                return View(jugadores);
            }
            else
            {
                var jugadores = _jugadorServicio.Listar();
                return View(jugadores);
            }
        }

    }
}
