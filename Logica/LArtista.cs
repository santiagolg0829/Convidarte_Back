using Convidarte.Entidades;
using Entidades;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Logica
{
    public class LArtista
    {

        public static List<Artista> ConsultarArtistasActivos(ApplicationDbContext _context)
        {
            return _context.Artistas.Where(x => x.Activo).ToList();
        }

        public static Artista ConsultarArtistaPorId(int id, ApplicationDbContext _context)
        {
            return _context.Artistas.Where(x => x.Id == id).FirstOrDefault();
        }

        public static void GuardarArtista(Artista artista, ApplicationDbContext _context)
        {
            artista.Activo = true;
            _context.Artistas.Add(artista);
            _context.SaveChanges();
        }

        public static void EditarArtista(Artista artista, ApplicationDbContext _context)
        {
            _context.Entry(artista).State = EntityState.Modified;
            _context.SaveChanges();
        }

        public static void EliminarArtista(int id, ApplicationDbContext _context)
        {
            Artista artista = ConsultarArtistaPorId(id, _context);
            artista.Activo = false;
            EditarArtista(artista, _context);
        }
    }
}
