using Business.Dtos.Employee;
using Business.Requests.Employees;
using Business.Responses.Employees;
using Core.Utilities.Results;
using Core.Utilities.Security.JWT;


namespace Business.Abstracts
{
    public interface IEmployeeService
    {
        Task<DataResult<AccessToken>> Register(EmployeeRegisterDto employeeRegisterDto);
        public IDataResult<UpdateEmployeeResponse> Update(UpdateEmployeeRequest request);
        public IDataResult<DeleteEmployeeResponse> Delete(DeleteEmployeeRequest request);
        public IDataResult<List<GetAllEmployeeResponse>> GetAll();
        public IDataResult<GetEmployeeByIdResponse> GetById(GetEmployeeByIdRequest request);
    }
}
