using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _2020UL601WACRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace _2020UL601WACRUD.Controllers
{
    public class TipoEquipoController : ControllerBase
    {

        private readonly EquiposContext _contexto;

        public TipoEquipoController(EquiposContext mycontext)
        {
            this._contexto=mycontext;
        }

        //CONSULTA GENERAL

        [HttpGet]
        [Route("api/tipoequipo")]
        public IActionResult Get()
        {
            IEnumerable<TipoEquipo> tipolist = from e in _contexto.tipoEquipo select e;

            if (tipolist.Count()>0)
            {
                return Ok(tipolist);
            }

            return NotFound();
        }

        //CONSULTA FILTRADA

        [HttpGet]
        [Route("api/tipoequipo/{id}")]
        public IActionResult Get(int id)
        {

            TipoEquipo tipolist = (from e in _contexto.tipoEquipo where e.id_tipoequipo==id select e).FirstOrDefault();

            if (tipolist!=null)
            {
                return Ok(tipolist);
            }

            return NotFound();
        }


        //AGREGAR EQUIPO

        [HttpPost]
        [Route("api/tipoequipo/")]
        public IActionResult agregarTipoEquipo([FromBody] TipoEquipo tipoNew)
        {

            _contexto.tipoEquipo.Add(tipoNew);
            _contexto.SaveChanges();

            return Ok(tipoNew);
        }

        //EDITAR EQUIPO

        [HttpPut]
        [Route("api/tipoequipo/")]
        public IActionResult editarTipoEquipo([FromBody] TipoEquipo tipoUpdate)
        {

            TipoEquipo tipoExist = (from e in _contexto.tipoEquipo
                                  where e.id_tipoequipo==tipoUpdate.id_tipoequipo
                                  select e).FirstOrDefault();

            if (tipoExist is null)
            {
                return NotFound();
            }

            tipoExist.descripcion=tipoUpdate.descripcion;
            tipoExist.estado=tipoUpdate.estado;

            _contexto.Entry(tipoExist).State=EntityState.Modified;
            _contexto.SaveChanges();

            return Ok(tipoExist);
        }


    }
}
