using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _2020UL601WACRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace _2020UL601WACRUD.Controllers
{
    public class EstadosEquiposController : ControllerBase
    {

        private readonly EquiposContext _contexto;

        public EstadosEquiposController(EquiposContext mycontext)
        {
            this._contexto=mycontext;
        }

        //CONSULTA GENERAL

        [HttpGet]
        [Route("api/estadosEquipos")]
        public IActionResult Get()
        {
            IEnumerable<EstadosEquipos> estadolist = from e in _contexto.estadosEquipos select e;

            if (estadolist.Count()>0)
            {
                return Ok(estadolist);
            }

            return NotFound();
        }

        //CONSULTA FILTRADA

        [HttpGet]
        [Route("api/estadosEquipos/{id}")]
        public IActionResult Get(int id)
        {

            EstadosEquipos estadolist = (from e in _contexto.estadosEquipos where e.id_estadoequipos==id select e).FirstOrDefault();

            if (estadolist!=null)
            {
                return Ok(estadolist);
            }

            return NotFound();
        }


        //AGREGAR EQUIPO

        [HttpPost]
        [Route("api/estadosEquipos/")]
        public IActionResult agregarEstadosEquipos([FromBody] EstadosEquipos estadNew)
        {

            _contexto.estadosEquipos.Add(estadNew);
            _contexto.SaveChanges();

            return Ok(estadNew);
        }

        //EDITAR EQUIPO

        [HttpPut]
        [Route("api/estadosEquipos/")]
        public IActionResult editarEstadosEquipos([FromBody] EstadosEquipos estadUpdate)
        {

            EstadosEquipos estadExist = (from e in _contexto.estadosEquipos
                                  where e.id_estadoequipos==estadUpdate.id_estadoequipos
                                  select e).FirstOrDefault();

            if (estadExist is null)
            {
                return NotFound();
            }

            estadExist.descripcion=estadUpdate.descripcion;
            estadExist.estado=estadUpdate.estado;

            _contexto.Entry(estadExist).State=EntityState.Modified;
            _contexto.SaveChanges();

            return Ok(estadExist);
        }

    }
}
