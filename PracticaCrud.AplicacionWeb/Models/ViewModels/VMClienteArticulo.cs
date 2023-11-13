using PracticaCrud.Models;

namespace PracticaCrud.AplicacionWeb.Models.ViewModels
{
    public class VMClienteArticulo
    {
        public int Id { get; set; }

        public int? ClienteId { get; set; }

        public int? ArticuloId { get; set; }
        public int? CantidadArticulos { get; set; }

        public DateTime? Fecha { get; set; }

        public virtual Artículo? Articulo { get; set; }

        public virtual Cliente? Cliente { get; set; }
    }
}
