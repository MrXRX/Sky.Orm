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
    [Table("T_UserAccount")]
    [Description("用户账户表")]
    public class UserAccountEntity : BaseEntity
    {
        [Required]
        [MaxLength(50)]
        [Description("密码")]
        public string Password { get; set; }

        [Required]
        [MaxLength(50)]
        [Description("手机号")]
        public string Phone { get; set; }

    }
}
