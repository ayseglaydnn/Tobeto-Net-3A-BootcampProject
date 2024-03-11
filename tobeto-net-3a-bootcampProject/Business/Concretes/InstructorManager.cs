﻿using AutoMapper;
using Business.Abstracts;
using Business.Dtos.Instructor;
using Business.Requests.Instructors;
using Business.Responses.Instructors;
using Business.Rules;
using Core.Utilities.Results;
using Core.Utilities.Security.Hashing;
using Core.Utilities.Security.JWT;
using DataAccess.Abstracts;
using Entities.Concretes;


namespace Business.Concretes
{
    public class InstructorManager : IInstructorService
    {
        private readonly IInstructorRepository _instructorRepository;
        private readonly IMapper _mapper;
        private readonly InstructorBusinessRules _instructorBusinessRules;
        private readonly AuthBusinessRules _authBusinessRules;
        private readonly IAuthService _authService;

        public InstructorManager(IInstructorRepository instructorRepository, IMapper mapper, InstructorBusinessRules instructorBusinessRules, AuthBusinessRules authBusinessRules, IAuthService authService)
        {
            _instructorRepository = instructorRepository;
            _mapper = mapper;
            _instructorBusinessRules = instructorBusinessRules;
            _authBusinessRules = authBusinessRules;
            _authService = authService;
        }

        //public IDataResult<AddInstructorResponse> Add(AddInstructorRequest request)
        //{
        //    Instructor instructor = _mapper.Map<Instructor>(request);

        //    _instructorBusinessRules.CheckIfEmailRegistered(request.Email);

        //    _instructorRepository.Add(instructor);

        //    AddInstructorResponse response = _mapper.Map<AddInstructorResponse>(instructor);

        //    return new SuccessDataResult<AddInstructorResponse>(response, "Added Successfully.");
        //}

        public async Task<DataResult<AccessToken>> Register(InstructorRegisterDto instructorRegisterDto)
        {
            await _authBusinessRules.UserEmailShouldBeNotExists(instructorRegisterDto.Email);
            await _authBusinessRules.UsernameShouldBeNotExists(instructorRegisterDto.UserName);
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(instructorRegisterDto.Password, out passwordHash, out passwordSalt);
            var instructor = new Instructor
            {
                UserName = instructorRegisterDto.UserName,
                Email = instructorRegisterDto.Email,
                FirstName = instructorRegisterDto.FirstName,
                LastName = instructorRegisterDto.LastName,
                DateOfBirth = instructorRegisterDto.DateOfBirth,
                NationalIdentity = instructorRegisterDto.NationalIdentity,
                CompanyName = instructorRegisterDto.CompanyName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt
            };
            await _instructorRepository.AddAsync(instructor);
            var createAccessToken = await _authService.CreateAccessToken(instructor);
            return new SuccessDataResult<AccessToken>(createAccessToken.Data, "Instructor Register Success");
        }

        public IDataResult<DeleteInstructorResponse> Delete(DeleteInstructorRequest request)
        {
            Instructor deleteToInstructor = _instructorRepository.GetById(predicate: instructor => instructor.Id == request.Id);

            _instructorBusinessRules.CheckIfInstructorExists(deleteToInstructor);
            
            var deletedInstructor = _instructorRepository.Delete(deleteToInstructor);

            var response = new DeleteInstructorResponse { DeletedTime = deletedInstructor.DeletedDate, UserName = deletedInstructor.UserName, Id = deletedInstructor.Id };

            return new SuccessDataResult<DeleteInstructorResponse>(response, "Deleted Successfully.");
            
        }

        public IDataResult<List<GetAllInstructorResponse>> GetAll()
        {
            List<Instructor> instructors = _instructorRepository.GetAll();

            var responses = _mapper.Map<List<GetAllInstructorResponse>>(instructors);

            return new SuccessDataResult<List<GetAllInstructorResponse>>(responses, "Listed Successfully.");
        }

        public IDataResult<GetInstructorByIdResponse> GetById(GetInstructorByIdRequest request)
        {
            Instructor instructor = _instructorRepository.GetById(predicate: instructor => instructor.Id == request.Id);

            _instructorBusinessRules.CheckIfInstructorExists(instructor);
            
            GetInstructorByIdResponse response = _mapper.Map<GetInstructorByIdResponse>(instructor);

            return new SuccessDataResult<GetInstructorByIdResponse>(response, "Showed Successfully.");
           
        }

        public IDataResult<UpdateInstructorResponse> Update(UpdateInstructorRequest request)
        {
            Instructor updateToInstructor = _instructorRepository.GetById(predicate: instructor => instructor.Id == request.Id);

            _instructorBusinessRules.CheckIfInstructorExists(updateToInstructor);
            
            _mapper.Map(request, updateToInstructor);

            _instructorRepository.Update(updateToInstructor);

            var response = _mapper.Map<UpdateInstructorResponse>(updateToInstructor);

            return new SuccessDataResult<UpdateInstructorResponse>(response, "Updated Successfully");
            
        }
    }
}
