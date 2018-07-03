using Sky.IRepository;
using Sky.IService;
using Sky.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Service
{
    public class UserAccountService : BaseService<UserAccountEntity, IUserAccountRepository>, IUserAccountService
    {
        public UserAccountService(IUserAccountRepository dal)
            : base(dal)
        {

        }
    }
}
