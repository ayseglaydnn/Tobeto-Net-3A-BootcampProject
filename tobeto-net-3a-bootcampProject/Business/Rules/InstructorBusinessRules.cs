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
    public class InstructorBusinessRules : BaseBusinessRules
    {
        private readonly IInstructorRepository _instructorRepository;

        public InstructorBusinessRules(IInstructorRepository instructorRepository)
        {
            _instructorRepository = instructorRepository;
        }

        public void CheckIfInstructorExists(Instructor? instructor)
        {
            if (instructor is null) throw new NotFoundException("Instructor not found.");
        }

        public void CheckIfEmailRegistered(string? email)
        {
            var instructor = _instructorRepository.GetById(predicate: instructor => instructor.Email == email);

            if (instructor is not null) throw new BusinessException("There is already an instructor with this email."); ;
        }
    }
}
