using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Model.Entity
{
    [Table("T_SysUser")]
    [Description("系统账户表")]
    public class SysUserEntity : BaseEntity
    {

        [Required]
        [MaxLength(50)]
        [Description("密码")]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        [Description("管理员手机号")]
        public string Phone { get; set; }


        [MaxLength(300)]
        [Description("管理员权限集合")]
        public string RoleIDList { get; set; }

        [MaxLength(200)]
        [Description("管理员头像")]
        public string HeadPicUrl { get; set; }
    }
}
