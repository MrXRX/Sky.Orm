using Sky.Data.Interface;
using Sky.IRepository;
using Sky.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Repository
{
    public class UserAccountRepository : BaseRepository<UserAccountEntity>, IUserAccountRepository
    {
        public UserAccountRepository(IDbContextFactory dbContextFactory)
            : base(dbContextFactory)
        {

        }
    }
}
