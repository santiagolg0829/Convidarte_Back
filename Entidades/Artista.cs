using System.ComponentModel.DataAnnotations;

namespace Entidades
{
    public class Artista
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100), Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Descripcion { get; set; }
        [StringLength(100)]
        public string RutaFoto { get; set; }
    }
}
