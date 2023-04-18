using EmployeeWebAPI.Model;

namespace EmployeeWebAPI.IServices
{
    public interface IEmployeeService
    {
        Task<EmployeeModel> AddEmployee(EmployeeModel employee);
        Task<List<EmployeeModel>> GetAllEmployee();
        Task<bool> UpdateEmployee(int Id, EmployeeModel employee);
        Task<bool> DeleteEmployee(int id);
    }
}
