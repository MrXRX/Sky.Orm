using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sky.Admin.App_Start
{
    public class AppConfig
    {
        public static void Init()
        {
            //依赖注入
            DependencyConfig.DependencyRegister();
            //模型映射
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMissingTypeMaps = true;
            });
        }
    }
}