using System.ComponentModel.DataAnnotations.Schema;

namespace MvcEventosAWS.Models
{
    public class CategoriaEvento
    {
        public int IdCategoria { get; set; }
        public string Nombre { get; set; }
    }
}
