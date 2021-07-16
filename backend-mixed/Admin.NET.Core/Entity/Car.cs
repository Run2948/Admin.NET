using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Admin.NET.Core
{
    /// <summary>
    /// 车辆信息（测试通用增删查改）
    /// </summary>
    [Table("test_car")]
    [Comment("车辆信息")]
    public class Car : DEntityBase
    {
        /// <summary>
        /// 车名
        /// </summary>
        [Comment("车名")]
        [Required, MaxLength(64)]
        public string CarName { get; set; }

        /// <summary>
        /// 车号
        /// </summary>
        [Comment("车号")]
        [Required, MaxLength(32)]
        public string CarNo { get; set; }
    }
}