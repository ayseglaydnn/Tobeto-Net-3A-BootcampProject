using Core.CrossCuttingConcerns.Rules;
using Core.Exceptions.Types;
using DataAccess.Abstracts;
using Entities.Concretes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Rules
{
    public class ApplicationStateBusinessRules : BaseBusinessRules
    {
        private readonly IApplicationStateRepository _applicationStateRepository;

        public ApplicationStateBusinessRules(IApplicationStateRepository applicationStateRepository)
        {
            _applicationStateRepository = applicationStateRepository;
        }

        public async Task CheckIfApplicationStateExists(ApplicationState? applicationState)
        {
            if (applicationState is null) throw new NotFoundException("ApplicationState not found.");
        }

    }
}
