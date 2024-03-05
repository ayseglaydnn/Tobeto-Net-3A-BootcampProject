using AutoMapper;
using Business.Abstracts;
using Business.Rules;
using Business.Requests.Blacklists;
using Business.Responses.Applications;
using Business.Responses.Blacklists;
using Core.Utilities.Results;
using DataAccess.Abstracts;
using DataAccess.Concretes.Repositories;
using Entities.Concretes;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;
using Business.Constants;

namespace Business.Concretes
{
    public class BlacklistManager : IBlacklistService
    {
        private readonly IBlacklistRepository _blacklistRepository;
        private readonly IMapper _mapper;
        private readonly BlacklistBusinessRules _blacklistBusinessRules;


        public BlacklistManager(IBlacklistRepository blacklistRepository, IMapper mapper, BlacklistBusinessRules blacklistBusinessRules)
        {
            _blacklistRepository = blacklistRepository;
            _mapper = mapper;
            _blacklistBusinessRules = blacklistBusinessRules;
        }

        public async Task<IDataResult<CreateBlacklistResponse>> AddAsync(CreateBlacklistRequest request)
        {
            await _blacklistBusinessRules.CheckIfApplicantIdInBlacklist(request.ApplicantId);

            Blacklist blacklist = _mapper.Map<Blacklist>(request);

            await _blacklistRepository.AddAsync(blacklist);

            var response = _mapper.Map<CreateBlacklistResponse>(blacklist);

            return new SuccessDataResult<CreateBlacklistResponse>(response, BlacklistMessages.Added);

        }

        public async Task<IDataResult<DeleteBlacklistResponse>> DeleteAsync(DeleteBlacklistRequest request)
        {
            var blacklist = await _blacklistRepository.GetByIdAsync(predicate: blacklist => blacklist.Id == request.Id);

            await _blacklistBusinessRules.CheckIfBlacklistExists(blacklist);

            await _blacklistRepository.DeleteAsync(blacklist);

            var response = _mapper.Map<DeleteBlacklistResponse>(blacklist);

            return new SuccessDataResult<DeleteBlacklistResponse>(response, BlacklistMessages.Deleted);
        }

        public async Task<IDataResult<List<GetAllBlacklistResponse>>> GetAllAsync()
        {
            List<Blacklist> blacklists = await _blacklistRepository.GetAllAsync(include: x => x.Include(x => x.Applicant));

            List<GetAllBlacklistResponse> responses = _mapper.Map<List<GetAllBlacklistResponse>>(blacklists);

            return new SuccessDataResult<List<GetAllBlacklistResponse>>(responses, BlacklistMessages.Listed);
        }

        public async Task<IDataResult<GetByIdBlacklistResponse>> GetByIdAsync(GetByIdBlacklistRequest request)
        {
            var blacklist = await _blacklistRepository.GetByIdAsync(predicate: blacklist => blacklist.Id == request.Id);

            await _blacklistBusinessRules.CheckIfBlacklistExists(blacklist);

            var response = _mapper.Map<GetByIdBlacklistResponse>(blacklist);

            return new SuccessDataResult<GetByIdBlacklistResponse>(response, BlacklistMessages.Showed);
        }

        public async Task<IDataResult<UpdateBlacklistResponse>> UpdateAsync(UpdateBlacklistRequest request)
        {
            var blacklist = await _blacklistRepository.GetByIdAsync(predicate: blacklist => blacklist.Id == request.Id);

            await _blacklistBusinessRules.CheckIfBlacklistExists(blacklist);

            _mapper.Map(request, blacklist); 

            await _blacklistRepository.UpdateAsync(blacklist);

            var response = _mapper.Map<UpdateBlacklistResponse>(blacklist);

            return new SuccessDataResult<UpdateBlacklistResponse>(response, BlacklistMessages.Updated);
        }
    }
}
