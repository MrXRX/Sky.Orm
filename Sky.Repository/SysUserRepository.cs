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
    public class SysUserRepository : BaseRepository<SysUserEntity>, ISysUserRepository
    {
        public SysUserRepository(IDbContextFactory dbContextFactory)
            : base(dbContextFactory)
        {

        }
    }
}