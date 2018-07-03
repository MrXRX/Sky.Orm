using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Sky.Model.Entity
{
    [Table("T_SysMenu")]
    [Description("后台菜单表")]
    public class SysMenuEntity : BaseEntity
    {
        [MaxLength(100)]
        [Description("菜单地址")]
        public string URL { get; set; }

        [MaxLength(22)]
        [Description("父级ID")]
        public string ParentID { get; set; }

        /// <summary>
        /// 后台菜单等级
        /// </summary>
        public int MenuLevel { get; set; }
    }
}