using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;
using DataAccess.Concretes.Repositories;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class EmployeeBusinessRules : BaseBusinessRules
    {
        private readonly IEmployeeRepository _employeeRepository;

        public EmployeeBusinessRules(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository;
        }

        public void CheckIfEmployeeExists(Employee? employee)
        {
            if (employee is null) throw new NotFoundException("Employee not found.");
        }

        public void CheckIfEmailRegistered(string? email)
        {
            var employee = _employeeRepository.GetById(predicate: employee => employee.Email == email);

            if (employee is not null) throw new BusinessException("There is already an employee with this email."); ;
        }
    }
}
