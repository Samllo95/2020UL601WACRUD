using System.ComponentModel.DataAnnotations;

namespace _2020UL601WACRUD.Models
{
    public class EstadosEquipos
    {

        [Key]
        public int id_estadoequipos { get; set; }
        public string descripcion { get; set; }
        public string estado { get; set; }

    }
}
