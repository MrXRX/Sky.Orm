using Autofac;
using Autofac.Integration.Mvc;
using Sky.Data.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Compilation;
using System.Web.Mvc;

namespace Sky.Admin.App_Start
{
    public class DependencyConfig
    {
        public static void DependencyRegister()
        {
            //创建autofac管理注册类的容器实例
            var builder = new ContainerBuilder();

            //下面就需要为这个容器注册它可以管理的类型
            //1：使用Autofac提供的RegisterControllers扩展方法来对程序集中所有的Controller一次性的完成注册
            var assemblyList = BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToArray();
            builder.RegisterControllers(assemblyList);
            //2：注册所有继承Dependency的接口
            var baseType = typeof(IDependency);
            builder.RegisterAssemblyTypes(assemblyList)
              .Where(f => baseType.IsAssignableFrom(f) && f != baseType)
              .AsImplementedInterfaces().InstancePerLifetimeScope();

            //生成具体的实例
            var container = builder.Build();
            //下面就是使用MVC的扩展 更改了MVC中的注入方式.

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

        }
    }
}