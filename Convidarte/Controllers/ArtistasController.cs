using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Convidarte.Entidades;
using Entidades;
using Logica;

namespace Convidarte.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArtistasController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ArtistasController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: api/Artistas
        [HttpGet]
        public async Task<IActionResult> GetArtistas()
        {
            try
            {
                List<Artista> lstArtistas = LArtista.ConsultarArtistasActivos(_context);
                return Json(new { success = true, message = lstArtistas });
            }
            catch (Exception exc)
            {
                string ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException.Message : exc.GetBaseException().Message;
                return Json(new { success = false, message = "Error!. " + ErrorMsg });
            }
        }

        // GET: api/Artistas/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetArtista([FromRoute] int id)
        {
            try
            {
                Artista artista = LArtista.ConsultarArtistaPorId(id, _context);

                if(artista == null)
                {
                    return Json(new { success = false, message = "Artista no encontrado" });
                }

                return Json(new { success = true, message = artista });
            }
            catch (Exception exc)
            {
                string ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException.Message : exc.GetBaseException().Message;
                return Json(new { success = false, message = "Error!. " + ErrorMsg });
            }
        }

        // PUT: api/Artistas/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutArtista([FromRoute] int id, [FromBody] Artista artista)
        {
            try
            {

                if (artista.Id != id)
                {
                    return Json(new { success = false, message = "No se pude editar el id del artista" });
                }

                return Json(new { success = true, message = "Artista editado correctamente" });
            }
            catch (Exception exc)
            {
                string ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException.Message : exc.GetBaseException().Message;
                return Json(new { success = false, message = "Error!. " + ErrorMsg });
            }
        }

        // POST: api/Artistas
        [HttpPost]
        public async Task<IActionResult> PostArtista([FromBody] Artista artista)
        {
            try
            {
                LArtista.GuardarArtista(artista, _context);
                return Json(new { success = true, message = "Artista guardado correctamente" });
            }
            catch (Exception exc)
            {
                string ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException.Message : exc.GetBaseException().Message;
                return Json(new { success = false, message = "Error!. " + ErrorMsg });
            }
        }

        // DELETE: api/Artistas/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArtista([FromRoute] int id)
        {
            try
            {
                LArtista.EliminarArtista(id, _context);
                return Json(new { success = true, message = "Artista eliminado correctamente" });
            }
            catch (Exception exc)
            {
                string ErrorMsg = exc.GetBaseException().InnerException != null ? exc.GetBaseException().InnerException.Message : exc.GetBaseException().Message;
                return Json(new { success = false, message = "Error!. " + ErrorMsg });
            }
        }
 
    }
}