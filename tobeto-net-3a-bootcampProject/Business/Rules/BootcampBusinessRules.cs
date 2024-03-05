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
    public class BootcampBusinessRules : BaseBusinessRules
    {
        private readonly IBootcampRepository _bootcampRepository;

        public BootcampBusinessRules(IBootcampRepository bootcampRepository)
        {
            _bootcampRepository = bootcampRepository;
        }

        public async Task CheckIfBootcampExists(Bootcamp? bootcamp)
        {
            if (bootcamp is null) throw new NotFoundException("Bootcamp not found.");
        }

        public async Task CheckIfBootcampNameExists(string? name, int? instructorId)
        {
            var bootcamp = await _bootcampRepository
                .GetByIdAsync(predicate: bootcamp => bootcamp.InstructorId == instructorId && bootcamp.Name == name);

            if (bootcamp is not null) throw new BusinessException("There is already a bootcamp with this name."); ;
        }
    }
}
