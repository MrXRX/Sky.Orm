using System;
using System.Text;
using System.Collections.Generic;
using System.Data;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Sky.Model.Entity
{
    [Table("T_SysRole_SysMenuMap")]
    public class SysRoleSysMenuMapEntity
    {
        [Key]
        [Column(Order = 1)]
        [MaxLength(22)]
        [Required]
        [Description("主键")]
        public string LeftID { get; set; }

        [Key]
        [Column(Order = 2)]
        [MaxLength(22)]
        [Required]
        [Description("主键")]
        public string RightID { get; set; }
        /// <summary>
        /// Description
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// CreateDate
        /// </summary>
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// CreateUserId
        /// </summary>
        public string CreateUserId { get; set; }
        /// <summary>
        /// UpdateDate
        /// </summary>
        public DateTime UpdateDate { get; set; }
        /// <summary>
        /// UpdateUserId
        /// </summary>
        public string UpdateUserId { get; set; }
    }
}