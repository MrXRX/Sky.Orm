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
    public class SysRoleSysMenuMapService : BaseService<SysRoleSysMenuMapEntity, ISysRoleSysMenuMapRepository>, ISysRoleSysMenuMapService
    {
        public SysRoleSysMenuMapService(ISysRoleSysMenuMapRepository dal)
            : base(dal)
        {

        }
    }
}