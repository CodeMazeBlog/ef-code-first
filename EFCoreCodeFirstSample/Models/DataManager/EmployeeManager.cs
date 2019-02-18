using System.Collections.Generic;
using System.Linq;
using EFCoreCodeFirstSample.Models.Repository;

namespace EFCoreCodeFirstSample.Models.DataManager
{
    public class EmployeeManager : IDataRepository<Employee>
    {
        readonly EmployeeContext _employeeContext;

        public EmployeeManager(EmployeeContext context)
        {
            _employeeContext = context;
        }

        public IEnumerable<Employee> GetAll()
        {
            return _employeeContext.Employees.ToList();
        }

        public Employee Get(long id)
        {
            return _employeeContext.Employees.FirstOrDefault(e => e.EmployeeId == id);
        }

        public void Add(Employee entity)
        {
            _employeeContext.Employees.Add(entity);
            _employeeContext.SaveChanges();
        }

        public void Update(Employee employee, Employee entity)
        {
            employee.FirstName = entity.FirstName;
            employee.LastName = entity.LastName;
            employee.Email = entity.Email;
            employee.DateOfBirth = entity.DateOfBirth;
            employee.PhoneNumber = entity.PhoneNumber;

            _employeeContext.SaveChanges();
        }

        public void Delete(Employee employee)
        {
            _employeeContext.Employees.Remove(employee);
            _employeeContext.SaveChanges();
        }
    }
}
