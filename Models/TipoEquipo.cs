using System.ComponentModel.DataAnnotations;

namespace _2020UL601WACRUD.Models
{
    public class TipoEquipo
    {

        [Key]
        public int id_tipoequipo { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }

    }
}
