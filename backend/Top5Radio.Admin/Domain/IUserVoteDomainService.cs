using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Top5Radio.Admin.Domain.Models;

namespace Top5Radio.Admin.Domain
{
    public interface IUserVoteDomainService
    {
        IEnumerable<User> ConsolidateUserVotes(IEnumerable<UserVote> musics);
    }
}
