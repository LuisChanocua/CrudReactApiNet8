using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using CruedReactApiNet8.Models;
using Microsoft.EntityFrameworkCore;

namespace CruedReactApiNet8.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpleadoController : ControllerBase
    {
        private readonly DbacrudReactnetapi8Context dbcontext;

        public EmpleadoController(DbacrudReactnetapi8Context _dbcontext)
        {
            dbcontext = _dbcontext;
        }

        #region GETS
        //GetEmpleados
        [HttpGet]
        [Route("empleados")]
        public async Task<ActionResult> getEmpleados()
        {
            try
            {
                var listaEmpleados = await dbcontext.Empleados.ToListAsync();
                return StatusCode(StatusCodes.Status200OK, listaEmpleados);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    new
                    {
                        message = ex.Message + " No se puedo consultar los empleados",
                        succes = false,
                    });
            }
        }

        //GetEmpleado
        [HttpGet]
        [Route("empleado/{idempleado:int}")]
        public async Task<ActionResult> getEmpleado(int idEmpleado)
        {
            try
            {
                var empleadoData = await dbcontext.Empleados.FirstOrDefaultAsync(x => x.IdEmpleado == idEmpleado);
                return StatusCode(StatusCodes.Status200OK, empleadoData);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    new
                    {
                        message = ex.Message + " No se puedo consultar el empleado",
                        succes = false,
                    });
            }
        }
        #endregion


        #region POST
        //PostEmpleado: Agregar nuevo usuario
        [HttpPost]
        [Route("agregarempleado")]
        public async Task<ActionResult> nuevoEmpleado([FromBody] Empleado empleadoData)
        {

            try
            {
                await dbcontext.Empleados.AddAsync(empleadoData);
                await dbcontext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        message = "Empleado agreado",
                        success = true
                    });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    new
                    {
                        message = ex.Message + " No se puedo agregar el empleado",
                        succes = false,
                    });
            }
        }
        #endregion

        #region PUT
        //PutEmpleado: Actualizar usuario
        [HttpGet]
        [Route("editarempleado")]
        public async Task<ActionResult> actualizarEmpleado([FromBody] Empleado empleadoData)
        {
            try
            {
                dbcontext.Empleados.Update(empleadoData);
                await dbcontext.SaveChangesAsync();
                return StatusCode(StatusCodes.Status200OK,
                    new
                    {
                        message = "Empleado actualizado",
                        success = true
                    });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                    new
                    {
                        message = ex.Message + " No se puedo actualizar el empleado",
                        succes = false,
                    });
            }
        }
        #endregion

        #region DELETE
        //DeleteEmpleado: Eliminar usuario
        [HttpDelete]
        [Route("deleteempleado/{idempleado:int}")]
        public async Task<ActionResult> deleteEmpleado(int idEmpleado)
        {
            try
            {
                var empleado = await dbcontext.Empleados.FirstOrDefaultAsync(x=> x.IdEmpleado == idEmpleado);
                dbcontext.Empleados.Remove(empleado);
                await dbcontext.SaveChangesAsync();

                return StatusCode(StatusCodes.Status200OK,
                                    new
                                    {
                                        message = "Empleado eliminado",
                                        succes = false,
                                    });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status404NotFound,
                                    new
                                    {
                                        message = ex.Message + " No se puedo eliminar el empleado",
                                        succes = false,
                                    });
            }
        }

        #endregion
    }
}
