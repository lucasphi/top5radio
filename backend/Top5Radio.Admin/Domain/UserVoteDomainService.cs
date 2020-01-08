using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Top5Radio.Admin.Domain.Models;

namespace Top5Radio.Admin.Domain
{
    public class UserVoteDomainService : IUserVoteDomainService
    {
        public IEnumerable<User> ConsolidateUserVotes(IEnumerable<UserVote> musics)
        {
            var users = new Dictionary<string, User>();

            if (musics != null)
            {
                foreach (var music in musics)
                {
                    foreach (var userWhoVoted in music.Users)
                    {
                        if (!users.ContainsKey(userWhoVoted))
                        {
                            users.Add(userWhoVoted, new User() { Username = userWhoVoted, TotalVotes = 1 });
                        }
                        else
                        {
                            users[userWhoVoted].TotalVotes += 1;
                        }
                    }
                }
            }

            return users.Values.ToList();
        }
    }
}
