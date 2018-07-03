using Sky.Model.Entity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Repository.Context
{
    public class SkyDbContext : DbContext
    {
        public SkyDbContext() : base("name=SkyConnection")
        {
            //是否启用延迟加载:
            //  true:   延迟加载（Lazy Loading）：获取实体时不会加载其导航属性，一旦用到导航属性就会自动加载
            //  false:  直接加载（Eager loading）：通过 Include 之类的方法显示加载导航属性，获取实体时会即时加载通过 Include 指定的导航属性
            this.Configuration.LazyLoadingEnabled = false;
            this.Configuration.AutoDetectChangesEnabled = true;  //自动监测变化，默认值为 true
            //更新数据库结构
            //new DropCreateDatabaseIfModelChanges<SkyDbContext>()
            Database.SetInitializer<SkyDbContext>(null);

        }

        #region 数据集实体
        public DbSet<UserInfoEntity> UserInfoDbSet { get; set; }
        public DbSet<UserAccountEntity> UserAccountDbSet { get; set; }
        public DbSet<SysMenuEntity> SysMenuDbSet { get; set; }
        public DbSet<SysRoleEntity> SysRoleDbSet { get; set; }
        public DbSet<SysRoleSysMenuMapEntity> SysRoleSysMenuMapDbSet { get; set; }
        public DbSet<SysUserEntity> SysUserDbSet { get; set; }
        #endregion

        #region 数据库设置

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            // 禁用一对多级联删除
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            // 禁用多对多级联删除
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            // 禁用默认表名复数形式
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        #endregion

    }
}
