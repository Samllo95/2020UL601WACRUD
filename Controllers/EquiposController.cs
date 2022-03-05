using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using _2020UL601WACRUD.Models;
using Microsoft.EntityFrameworkCore;

namespace _2020UL601WACRUD.Controllers
{
    //[Route("api/[controller]")]
    [ApiController]

    public class EquiposController : ControllerBase
    {

        private readonly EquiposContext _contexto;

        public EquiposController(EquiposContext mycontext)
        {
            this._contexto=mycontext;
        }

        //CONSULTA GENERAL

        [HttpGet]
        [Route("api/equipos")]
        public IActionResult Get()
        {
            IEnumerable<Equipos> equiplist = from e in _contexto.equipos select e;

            if (equiplist.Count()>0)
            {
                return Ok(equiplist);
            }

            return NotFound();
        }

        //CONSULTA FILTRADA

        [HttpGet]
        [Route("api/equipos/{idequipo}")]
        public IActionResult Get(int idequipo)
        {

            Equipos equiplist = (from e in _contexto.equipos where e.id_equipos==idequipo select e).FirstOrDefault();

            if (equiplist!=null)
            {
                return Ok(equiplist);
            }

            return NotFound();
        }


        //AGREGAR EQUIPO

        [HttpPost]
        [Route("api/equipos/")]
        public IActionResult agregarEquipo([FromBody] Equipos equipNew)
        {

            _contexto.equipos.Add(equipNew);
            _contexto.SaveChanges();

            return Ok(equipNew);
        }

        //EDITAR EQUIPO

        [HttpPut]
        [Route("api/equipos/")]
        public IActionResult editarEquipo([FromBody] Equipos equipUpdate)
        {

            Equipos equipExist = (from e in _contexto.equipos
                                  where e.id_equipos==equipUpdate.id_equipos
                                  select e).FirstOrDefault();

            if (equipExist is null)
            {
                return NotFound();
            }

            equipExist.nombre=equipUpdate.nombre;
            equipExist.descripcion=equipUpdate.descripcion;
            equipExist.tipo_equipo_id=equipUpdate.tipo_equipo_id;
            equipExist.marca_id=equipUpdate.marca_id;
            equipExist.modelo=equipUpdate.modelo;
            equipExist.anio_compra=equipUpdate.anio_compra;
            equipExist.costo=equipUpdate.costo;
            equipExist.vida_util=equipUpdate.vida_util;
            equipExist.estado_equipo_id=equipUpdate.estado_equipo_id;
            equipExist.estado=equipUpdate.estado;

            _contexto.Entry(equipExist).State=EntityState.Modified;
            _contexto.SaveChanges();

            return Ok(equipExist);
        }

    }
}
