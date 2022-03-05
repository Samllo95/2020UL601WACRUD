using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _2020UL601WACRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace _2020UL601WACRUD.Controllers
{
    public class MarcasController : ControllerBase
    {

        private readonly EquiposContext _contexto;

        public MarcasController(EquiposContext mycontext)
        {
            this._contexto=mycontext;
        }

        //CONSULTA GENERAL

        [HttpGet]
        [Route("api/marcas")]
        public IActionResult Get()
        {
            IEnumerable<Marcas> marcalist = from e in _contexto.marcas select e;

            if (marcalist.Count()>0)
            {
                return Ok(marcalist);
            }

            return NotFound();
        }

        //CONSULTA FILTRADA

        [HttpGet]
        [Route("api/marcas/{id}")]
        public IActionResult Get(int id)
        {

            Marcas marcaslist = (from e in _contexto.marcas where e.id_marcas==id select e).FirstOrDefault();

            if (marcaslist!=null)
            {
                return Ok(marcaslist);
            }

            return NotFound();
        }


        //AGREGAR EQUIPO

        [HttpPost]
        [Route("api/marcas/")]
        public IActionResult agregarMarcas([FromBody] Marcas marcasNew)
        {

            _contexto.marcas.Add(marcasNew);
            _contexto.SaveChanges();

            return Ok(marcasNew);
        }

        //EDITAR EQUIPO

        [HttpPut]
        [Route("api/marcas/")]
        public IActionResult editarMarcas([FromBody] Marcas marcasUpdate)
        {

            Marcas marcasExist = (from e in _contexto.marcas
                                  where e.id_marcas==marcasUpdate.id_marcas
                                  select e).FirstOrDefault();

            if (marcasExist is null)
            {
                return NotFound();
            }

            marcasExist.nombre_marca=marcasUpdate.nombre_marca;
            marcasExist.estados=marcasUpdate.estados;

            _contexto.Entry(marcasExist).State=EntityState.Modified;
            _contexto.SaveChanges();

            return Ok(marcasExist);
        }

    }
}
