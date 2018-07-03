﻿using Sky.Data.Interface;
using Sky.IRepository;
using Sky.Model.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Repository
{
    public class SysRoleRepository : BaseRepository<SysRoleEntity>, ISysRoleRepository
    {
        public SysRoleRepository(IDbContextFactory dbContextFactory)
            : base(dbContextFactory)
        {

        }
    }
}