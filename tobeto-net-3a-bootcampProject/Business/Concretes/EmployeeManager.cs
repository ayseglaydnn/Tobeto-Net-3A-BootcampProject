using AutoMapper;
using Azure;
using Business.Abstracts;
using Business.Dtos.Employee;
using Business.Requests.Employees;
using Business.Responses.Applicants;
using Business.Responses.Employees;
using Business.Rules;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstracts;
using Entities.Concretes;

namespace Business.Concretes
{
    public class EmployeeManager : IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        private readonly IMapper _mapper;
        private readonly EmployeeBusinessRules _employeeBusinessRules;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IAuthService _authService;

        public EmployeeManager(IEmployeeRepository employeeRepository, IMapper mapper, EmployeeBusinessRules employeeBusinessRules, AuthBusinessRules authBusinessRules)
        {
            _employeeRepository = employeeRepository;
            _mapper = mapper;
            _employeeBusinessRules = employeeBusinessRules;
            _authBusinessRules = authBusinessRules;
        }

        //public IDataResult<AddEmployeeResponse> Add(AddEmployeeRequest request)
        //{
        //    Employee employee = _mapper.Map<Employee>(request);

        //    _employeeBusinessRules.CheckIfEmailRegistered(request.Email);

        //    _employeeRepository.Add(employee);

        //    AddEmployeeResponse response = _mapper.Map<AddEmployeeResponse>(employee);

        //    return new SuccessDataResult<AddEmployeeResponse>(response, "Added Successfully.");
        //}
        public async Task<DataResult<AccessToken>> Register(EmployeeRegisterDto employeeRegisterDto)
        {
            await _authBusinessRules.UserEmailShouldBeNotExists(employeeRegisterDto.Email);
            await _authBusinessRules.UsernameShouldBeNotExists(employeeRegisterDto.UserName);
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(employeeRegisterDto.Password, out passwordHash, out passwordSalt);
            var employee = new Employee
            {
                UserName = employeeRegisterDto.UserName,
                Email = employeeRegisterDto.Email,
                FirstName = employeeRegisterDto.FirstName,
                LastName = employeeRegisterDto.LastName,
                DateOfBirth = employeeRegisterDto.DateOfBirth,
                NationalIdentity = employeeRegisterDto.NationalIdentity,
                Position = employeeRegisterDto.Position,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            await _employeeRepository.AddAsync(employee);
            var createAccessToken = await _authService.CreateAccessToken(employee);
            return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Employee Register Success");
        }

        public IDataResult<DeleteEmployeeResponse> Delete(DeleteEmployeeRequest request)
        {
            Employee deleteToEmployee = _employeeRepository.GetById(predicate: employee => employee.Id == request.Id);

            _employeeBusinessRules.CheckIfEmployeeExists(deleteToEmployee);

            var deletedEmployee = _employeeRepository.Delete(deleteToEmployee);

            var response = _mapper.Map<DeleteEmployeeResponse>(deletedEmployee);

            return new SuccessDataResult<DeleteEmployeeResponse>(response, "Deleted Successfully.");

        }

        public IDataResult<List<GetAllEmployeeResponse>> GetAll()
        {
            List<Employee> employees = _employeeRepository.GetAll();

            List<GetAllEmployeeResponse> responses = _mapper.Map<List<GetAllEmployeeResponse>>(employees);

            return new SuccessDataResult<List<GetAllEmployeeResponse>>(responses, "Listed Successfully.");
        }

        public IDataResult<GetEmployeeByIdResponse> GetById(GetEmployeeByIdRequest request)
        {
            Employee employee = _employeeRepository.GetById(predicate: employee => employee.Id == request.Id);

            _employeeBusinessRules.CheckIfEmployeeExists(employee);

            GetEmployeeByIdResponse response = _mapper.Map<GetEmployeeByIdResponse>(employee);

            return new SuccessDataResult<GetEmployeeByIdResponse>(response,"Showed Successfully.");

        }

        public IDataResult<UpdateEmployeeResponse> Update(UpdateEmployeeRequest request)
        {
            Employee updateToEmployee = _employeeRepository.GetById(predicate: employee => employee.Id == request.Id);

            _employeeBusinessRules.CheckIfEmployeeExists(updateToEmployee);

            _mapper.Map(request, updateToEmployee);

            _employeeRepository.Update(updateToEmployee);

            var response = _mapper.Map<UpdateEmployeeResponse>(updateToEmployee);

            return new SuccessDataResult<UpdateEmployeeResponse>(response, "Updated Successfully");

        }
    }
}
