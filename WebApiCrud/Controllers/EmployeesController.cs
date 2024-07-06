using AutoMapper;
using Azure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApiCrud.Data;
using WebApiCrud.Model;
using WebApiCrud.Service;
using static Azure.Core.HttpHeader;

namespace WebApiCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {

        private readonly IEmployeeService _employeeService;
        private readonly IMapper _mapper;
        private readonly ResponseDto _response;

        public EmployeesController(IEmployeeService employeeService,IMapper mapper)
        {
            _employeeService = employeeService;
            _mapper=mapper;
            _response=new ResponseDto();
           
        }

        // GET: api/employees
        [HttpGet]
        public ActionResult<ResponseDto> GetEmployees()
        {
            try
            {
                var employees = _employeeService.GetEmployees();
                _response.Result = _mapper.Map<IEnumerable<EmployeeDto>>(employees);

            }
            catch (Exception ex)
            {
                _response.ISSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }




        // GET: api/employees/{id}
        [HttpGet("{id}")]
        public ActionResult<ResponseDto> GetEmployeeById(int id)
        {
            try
            {

                Employee obj = _employeeService.GetEmployeeById(id);
                _response.Result = _mapper.Map<EmployeeDto>(obj);
            }
            catch (Exception ex)
            {
                _response.ISSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }




        // POST: api/employees
        [HttpPost]
        public ActionResult<ResponseDto> AddEmployee(EmployeeDto employeeDto)
        {

            try
            {

                var employee = new Employee { Id = employeeDto.Id, Name = employeeDto.Name };
                var createdEmployee = _employeeService.AddEmployee(employee);
                _response.Result = _mapper.Map<EmployeeDto>(createdEmployee);
            }
            catch (Exception ex)
            {
                _response.ISSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;


         
        }

        // PUT: api/employees/{id}
        [HttpPut("{id}")]
        public ActionResult<ResponseDto> UpdateEmployee(int id, EmployeeDto employeeDto)
        {
            if (id != employeeDto.Id)
            {
                return BadRequest(new ResponseDto
                {
                    ISSuccess = false,
                    Message = "ID mismatch"
                });
            }

            try
            {

                var employee = new Employee { Id = employeeDto.Id, Name = employeeDto.Name };
                var updatedEmployee = _employeeService.UpdateEmployee(employee);
                _response.Result = _mapper.Map<EmployeeDto>(updatedEmployee);
            }
            catch (Exception ex)
            {
                _response.ISSuccess = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        // DELETE: api/employees/{id}
        [HttpDelete("{id}")]
        public ActionResult<ResponseDto> DeleteEmployee(int id)
        {
            var employee = _employeeService.GetEmployeeById(id);
            if (employee == null)
            {
                return NotFound(new ResponseDto
                {
                    ISSuccess = false,
                    Message = "Employee not found"
                });
            }
            _employeeService.DeleteEmployee(employee);
            var response = new ResponseDto
            {
                ISSuccess = true,
                Message = "Employee deleted successfully"
            };
            return Ok(response);
        }

        // GET: api/employees/specific/{employeeId}
        [HttpGet("specific/{employeeId}")]
        public ActionResult<ResponseDto> GetEmployeesByCriterion(int employeeId)
        {
            var employees = _employeeService.GetEmployees(employeeId);
            var response = new ResponseDto
            {
                Result = employees.Select(e => new EmployeeDto { Id = e.Id, Name = e.Name }),
                ISSuccess = true,
                Message = "Employees retrieved successfully"
            };
            return Ok(response);
        }




    }
}
