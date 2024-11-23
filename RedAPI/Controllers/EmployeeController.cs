using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RedAPI.Data;
using RedAPI.Entities;
using RedArborAPI.ViewModels;

namespace RedAPI.Controllers
{
    [ApiController]
    [Route("api/redarbor")]
    public class EmployeeController : ControllerBase
    {
        private readonly AppDbContext contexto;

        public EmployeeController(AppDbContext context)
        {
            contexto = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Employee>>> Get()
        {
            try
            {
                List<Employee> employees = await contexto.Employee.ToListAsync();
                return Ok(employees);
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Success = false,
                    Message = ex.Message
                };
                return BadRequest(errorResponse);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Employee>> GetById(int id)
        {
            try
            {
                var employee = await contexto.Employee.FindAsync(id);

                if (employee == null)
                {
                    return NotFound(new ErrorResponse
                    {
                        Success = false,
                        Message = $"Empleado con Id {id} no encontrado."
                    });
                }
                return Ok(employee);
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Success = false,
                    Message = ex.Message
                };
                return BadRequest(errorResponse);
            }
        }

        [HttpPost]
        public async Task<ActionResult<Employee>> Create(CreateEmployeeViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new
                    {
                        Success = false,
                        Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                    });
                }

                var employee = new Employee
                {
                    CompanyId = viewModel.CompanyId,
                    Email = viewModel.Email,
                    Password = viewModel.Password,
                    PortalId = viewModel.PortalId,
                    RoleId = viewModel.RoleId,
                    StatusId = viewModel.StatusId,
                    Username = viewModel.Username,
                    Name = viewModel.Name,
                    Telephone = viewModel.Telephone,
                    Fax = viewModel.Fax,
                    LastLogin = viewModel.LastLogin,
                    CreatedOn = viewModel.CreatedOn,
                    UpdatedOn = viewModel.UpdatedOn,
                    DeletedOn = viewModel.DeletedOn,
                };

                contexto.Employee.Add(employee);
                var sav = await contexto.SaveChangesAsync();
                return Ok(employee);
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Success = false,
                    Message = ex.Message
                };
                return BadRequest(errorResponse);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Employee>> Update(int id, CreateEmployeeViewModel viewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(new
                    {
                        Success = false,
                        Errors = ModelState.Values.SelectMany(v => v.Errors).Select(e => e.ErrorMessage)
                    });
                }

                // Buscar el empleado existente por id
                var employee = await contexto.Employee.FindAsync(id);

                if (employee == null)
                {
                    return NotFound(new { Success = false, Message = "Empleado no encontrado." });
                }

                // Actualizar los campos del empleado con los datos del viewModel
                employee.CompanyId = viewModel.CompanyId;
                employee.Email = viewModel.Email;
                employee.Password = viewModel.Password;
                employee.PortalId = viewModel.PortalId;
                employee.RoleId = viewModel.RoleId;
                employee.StatusId = viewModel.StatusId;
                employee.Username = viewModel.Username;
                employee.Name = viewModel.Name;
                employee.Telephone = viewModel.Telephone;
                employee.Fax = viewModel.Fax;
                employee.LastLogin = viewModel.LastLogin;
                employee.CreatedOn = viewModel.CreatedOn;
                employee.UpdatedOn = viewModel.UpdatedOn;
                employee.DeletedOn = viewModel.DeletedOn;

                // Guardar los cambios
                await contexto.SaveChangesAsync();

                return Ok(employee);
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Success = false,
                    Message = ex.Message
                };
                return BadRequest(errorResponse);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            try
            {
                var employee = await contexto.Employee.FindAsync(id);

                if (employee == null)
                {
                    return NotFound(new ErrorResponse { Success = false, Message = "Empleado no encontrado." });
                }

                contexto.Employee.Remove(employee);
                await contexto.SaveChangesAsync();

                return Ok(new { Success = true, Message = "Empleado eliminado con éxito." });
            }
            catch (Exception ex)
            {
                var errorResponse = new ErrorResponse
                {
                    Success = false,
                    Message = ex.Message
                };
                return BadRequest(errorResponse);
            }
        }
    }
}
