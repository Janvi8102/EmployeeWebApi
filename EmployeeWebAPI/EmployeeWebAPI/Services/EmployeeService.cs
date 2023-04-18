using EmployeeWebAPI.IServices;
using EmployeeWebAPI.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EmployeeWebAPI.Services
{
    public class EmployeeService : IEmployeeService
    {
        private readonly TestDbContext1 _context1;
        private readonly TestDbContext2 _context2;
        private readonly TestDbContext3 _context3;

        public EmployeeService(TestDbContext1 context1, TestDbContext2 context2, TestDbContext3 context3)
        {
            _context1 = context1;
            _context2 = context2;
            _context3 = context3;
        }

        public async Task<EmployeeModel> AddEmployee(EmployeeModel employee)
        {
            employee.Gender = GetGender(employee.Gender);
            _context1.Employee.Add(employee);
            await _context1.SaveChangesAsync();
            employee.Employee_PK = 0;
            _context2.Employee.Add(employee);
            await _context2.SaveChangesAsync();
            employee.Employee_PK = 0;
            _context3.Employee.Add(employee);
            await _context3.SaveChangesAsync();

            return employee;
        }

        public string GetGender(string gender)
        {
            if(gender.Contains("1"))
            {
                return EnumGender.Male.ToString();
            }
            else
            {
                return EnumGender.Female.ToString();
            }

        }

        public async Task<List<EmployeeModel>> GetAllEmployee()
        {
            var employees1 = await _context1.Employee.ToListAsync();
            var employees2 = await _context2.Employee.ToListAsync();
            var employees3 = await _context3.Employee.ToListAsync();

            var allEmployees = employees1.Union(employees2).Union(employees3).ToList();

            return allEmployees;
        }


        public async Task<bool> UpdateEmployee(int Id, EmployeeModel employee)
        {
            int[] compareArray = new int[] { 0, 0, 0 };
            var result = await Task.WhenAll(
                UpdateEmployeeContext1(Id,employee),
                UpdateEmployeeContext2(Id, employee),
                UpdateEmployeeContext3(Id, employee)
                );

            if(result.SequenceEqual(compareArray))
            {
                return false;
            }

           return true;
        }

        public async Task<int> UpdateEmployeeContext1(int Id, EmployeeModel employee)
        {
            var existingEmployee1 = _context1.Employee.SingleOrDefault(u => u.Employee_PK == Id);
            if (existingEmployee1 != null)
            {
                existingEmployee1.FirstName = employee.FirstName;
                existingEmployee1.MiddleName = employee.MiddleName;
                existingEmployee1.LastName = employee.LastName;
                existingEmployee1.EmpCode = employee.EmpCode;
                existingEmployee1.Gender = GetGender(employee.Gender);
                existingEmployee1.DoB = employee.DoB;
                existingEmployee1.Salary = employee.Salary;
                existingEmployee1.JoiningDate = employee.JoiningDate;
                existingEmployee1.ResignDate = employee.ResignDate;

                return await _context1.SaveChangesAsync();
            }
            return 0;
        }

        public async Task<int> UpdateEmployeeContext2(int Id, EmployeeModel employee)
        {
            var existingEmployee2 = _context2.Employee.SingleOrDefault(u => u.Employee_PK == Id);
            if (existingEmployee2 != null)
            {
                existingEmployee2.FirstName = employee.FirstName;
                existingEmployee2.MiddleName = employee.MiddleName;
                existingEmployee2.LastName = employee.LastName;
                existingEmployee2.EmpCode = employee.EmpCode;
                existingEmployee2.Gender = GetGender(employee.Gender);
                existingEmployee2.DoB = employee.DoB;
                existingEmployee2.Salary = employee.Salary;
                existingEmployee2.JoiningDate = employee.JoiningDate;
                existingEmployee2.ResignDate = employee.ResignDate;

                return await _context2.SaveChangesAsync();
            }

            return 0;
        }

        public async Task<int> UpdateEmployeeContext3(int Id, EmployeeModel employee)
        {
            var existingEmployee3 = _context3.Employee.SingleOrDefault(u => u.Employee_PK == Id);
            if (existingEmployee3 != null)
            {
                existingEmployee3.FirstName = employee.FirstName;
                existingEmployee3.MiddleName = employee.MiddleName;
                existingEmployee3.LastName = employee.LastName;
                existingEmployee3.EmpCode = employee.EmpCode;
                existingEmployee3.Gender = GetGender(employee.Gender);
                existingEmployee3.DoB = employee.DoB;
                existingEmployee3.Salary = employee.Salary;
                existingEmployee3.JoiningDate = employee.JoiningDate;
                existingEmployee3.ResignDate = employee.ResignDate;

                return await _context3.SaveChangesAsync();
            }
           
            return 0;
        }

        public async Task<bool> DeleteEmployee(int id)
        {
            var employee1 = await _context1.Employee.FindAsync(id);
            var employee2 = await _context2.Employee.FindAsync(id);
            var employee3 = await _context3.Employee.FindAsync(id);

            bool result;
            if (employee1 != null && employee2 != null && employee3 != null)
            {
                _context1.Employee.Remove(employee1);
                _context2.Employee.Remove(employee2);
                _context3.Employee.Remove(employee3);

                await Task.WhenAll(
                _context1.SaveChangesAsync(),
                _context2.SaveChangesAsync(),
                _context3.SaveChangesAsync()
                );

                result = true;
            }
            else
            {
                result = false;
            }

            return result;
        }
    }
}
