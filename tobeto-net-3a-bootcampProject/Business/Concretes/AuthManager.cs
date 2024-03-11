using Business.Abstracts;
using Business.Dtos.Applicant;
using Business.Dtos.Employee;
using Business.Dtos.Instructor;
using Business.Rules;
using Core.Exceptions.Types;
using Core.Utilities.Results;
using Core.Utilities.Security.Dtos;
using Core.Utilities.Security.Entities;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstracts;
using DataAccess.Concretes.Repositories;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;

namespace Business.Concretes;

public class AuthManager : IAuthService
{
    private readonly ITokenHelper _tokenHelper;
    private readonly IUserRepository _userRepository;
    private readonly IUserService _userService;
    private readonly AuthBusinessRules _authBusinessRules;

    public AuthManager(ITokenHelper tokenHelper, IUserRepository userRepository, IUserService userService, 
        AuthBusinessRules authBusinessRules)
    {
        _tokenHelper = tokenHelper;
        _userRepository = userRepository;
        _userService = userService;
        _authBusinessRules = authBusinessRules;
    }

    public async Task<DataResult<AccessToken>> CreateAccessToken(User user)
    {
        List<OperationClaim> claims = await _userRepository.Query()
            .Include(u => u.UserOperationClaims)
            .ThenInclude(uoc => uoc.OperationClaim)
            .Where(u => u.Id == user.Id)
            .SelectMany(u => u.UserOperationClaims.Select(uoc => uoc.OperationClaim))
            .ToListAsync();

        var accessToken = _tokenHelper.CreateToken(user, claims);

        return new SuccessDataResult<AccessToken>(accessToken, "Created Token");
    }
    public async Task<DataResult<AccessToken>> Login(UserLoginDto userLoginDto)
    {
        var user = await _userService.GetByMail(userLoginDto.Email);
        await _authBusinessRules.UserShouldBeExists(user.Data);
        await _authBusinessRules.UserEmailShouldBeExists(userLoginDto.Email);
        await _authBusinessRules.UserPasswordShouldBeMatch(user.Data.Id, userLoginDto.Password);
        var createAccessToken = await CreateAccessToken(user.Data);
        return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Login Success");
    }

}
