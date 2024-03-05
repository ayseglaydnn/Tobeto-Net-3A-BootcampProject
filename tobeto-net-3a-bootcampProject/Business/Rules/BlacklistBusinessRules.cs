using Azure.Core;
using Business.Abstracts;
using Business.Constants;
using Business.Requests.Blacklists;
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
    public class BlacklistBusinessRules : BaseBusinessRules
    {
        private readonly IBlacklistRepository _blacklistRepository;

        public BlacklistBusinessRules(IBlacklistRepository blacklistRepository)
        {
            _blacklistRepository = blacklistRepository;
        }

        public async Task CheckIfBlacklistExists(Blacklist? blacklist)
        {
            if (blacklist is null) throw new NotFoundException(BlacklistMessages.NotFound);
        }
        
        public async Task CheckIfApplicantIdInBlacklist(int? applicantId)
        {
            var blacklist = await _blacklistRepository.GetByIdAsync(predicate: blacklist => blacklist.Id == applicantId);

            if (blacklist is not null) throw new BusinessException(BlacklistMessages.AlreadyExist); ;
        }
    }
}
