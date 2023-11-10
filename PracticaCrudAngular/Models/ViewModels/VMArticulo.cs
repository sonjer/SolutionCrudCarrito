using PracticaCrud.Models;

namespace PracticaCrud.AplicacionWeb.Models.ViewModels
{
    public class VMArticulo
    {
        public int Código { get; set; }

        public string? Descripción { get; set; }

        public decimal? Precio { get; set; }

        public byte[]? Imagen { get; set; }

        public int? Stock { get; set; }

    }
}
