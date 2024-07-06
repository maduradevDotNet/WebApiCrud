using WebApiCrud.Model;

namespace WebApiCrud.Service
{
    public interface IEmployeeService
    {
        List<Employee> GetEmployees(int employeeId);

        Employee GetEmployeeById(int employeeId);

        Employee AddEmployee(Employee employee);

        void DeleteEmployee(Employee employee);

        Employee UpdateEmployee(Employee employee);


        List<Employee> GetEmployees();

    }
}
