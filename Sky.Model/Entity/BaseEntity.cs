using Sky.Common.Helper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sky.Model.Entity
{

    public class BaseEntity
    {
        [Key]
        [MaxLength(22)]
        [Required]
        [Description("主键")]
        public virtual string FID { get; set; }

        [MaxLength(100)]
        [Description("名称")]
        public virtual string Name { get; set; }

        [MaxLength(2000)]
        [Description("描述")]
        public virtual string Description { get; set; }

        private DateTime _CreateDate;
        [Required]
        [Description("创建时间")]
        public virtual DateTime CreateDate
        {
            get
            {
                if (_CreateDate == null || _CreateDate < DateTimeHelper.GetDateTimeMiniValue())
                {
                    _CreateDate = DateTime.Now;
                }
                return _CreateDate;
            }
            set
            {
                if (value != null && value >= DateTimeHelper.GetDateTimeMiniValue())
                {
                    _CreateDate = value;
                }
                else
                {
                    _CreateDate = DateTimeHelper.GetDateTimeMiniValue();
                }
            }
        }

        [Required]
        [MaxLength(22)]
        [Description("创建人")]
        public virtual string CreateUserId { get; set; }


        private DateTime? _UpdateDate;
        [Description("修改时间")]
        public virtual DateTime? UpdateDate
        {
            get
            {
                if (_UpdateDate == null || _UpdateDate < DateTimeHelper.GetDateTimeMiniValue())
                {
                    _UpdateDate = DateTime.Now;
                }
                return _UpdateDate;
            }
            set
            {
                if (value != null && value >= DateTimeHelper.GetDateTimeMiniValue())
                {
                    _UpdateDate = value;
                }
                else
                {
                    _UpdateDate = DateTimeHelper.GetDateTimeMiniValue();
                }
            }
        }


        [MaxLength(22)]
        [Description("修改人")]
        public virtual string UpdateUserId { get; set; }

    }
}
