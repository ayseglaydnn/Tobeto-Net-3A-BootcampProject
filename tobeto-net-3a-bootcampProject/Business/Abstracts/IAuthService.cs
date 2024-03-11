using Business.Dtos.Applicant;
using Business.Dtos.Employee;
using Business.Dtos.Instructor;
using Core.Utilities.Results;
using Core.Utilities.Security.Dtos;
using Core.Utilities.Security.Entities;
using Core.Utilities.Security.JWT;

namespace Business.Abstracts;

public interface IAuthService
{
    Task<DataResult<AccessToken>> Login(UserLoginDto userLoginDto);
    Task<DataResult<AccessToken>> CreateAccessToken(User user);
}
