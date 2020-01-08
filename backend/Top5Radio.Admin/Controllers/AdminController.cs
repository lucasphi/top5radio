using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Top5Radio.Admin.Domain;
using Top5Radio.Admin.Domain.Models;
using Top5Radio.Admin.Persistance.Data;
using Top5Radio.Admin.Persistance.Repository.Interfaces;

namespace Top5Radio.Admin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly IUserVoteDomainService _userVoteDomainService;
        private readonly IUserVoteRepository _userVoteRepository;
        private readonly IMapper _mapper;

        public AdminController(IUserVoteDomainService userVoteDomainService,
                               IUserVoteRepository userVoteRepository,
                               IMapper mapper)
        {
            _userVoteDomainService = userVoteDomainService;
            _userVoteRepository = userVoteRepository;
            _mapper = mapper;
        }

        [HttpGet("topsongs")]
        public async Task<IActionResult> CalculateTopSongs()
        {
            IEnumerable<UserVoteData> top5 = (await _userVoteRepository.Filter(f => f.Voted > 0)).OrderByDescending(f => f.Voted).Take(5);
            return Ok(top5);
        }

        [HttpGet("usercontribution")]
        public async Task<IActionResult> CalculateUserContribution()
        {
            IEnumerable<UserVoteData> top5 = (await _userVoteRepository.Filter(f => f.Voted > 0)).OrderByDescending(f => f.Voted).Take(5);

            var userVotes = _mapper.Map<List<UserVote>>(top5);
            var users = _userVoteDomainService.ConsolidateUserVotes(userVotes);

            return Ok(users);
        }
    }
}
