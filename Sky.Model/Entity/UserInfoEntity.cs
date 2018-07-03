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
    [Table("T_UserInfo")]
    [Description("用户信息表")]
    public class UserInfoEntity : BaseEntity
    {
        [MaxLength(50)]
        [Description("真实姓名")]
        public string RealName { get; set; }

        [MaxLength(50)]
        [Description("用户昵称")]
        public string NickName { get; set; }
    }
}
