using System.Collections.Generic;

namespace Furion.Extras.Admin.NET.Service
{
    /// <summary>
    /// 代码生成参数类
    /// </summary>
    public class CodeGenModel
    {
        /// <summary>
        /// 代码生成器Id
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// 作者姓名
        /// </summary>
        public string AuthorName { get; set; }

        /// <summary>
        /// 命名空间
        /// </summary>
        public string NameSpace { get; set; }

        /// <summary>
        /// 程序集
        /// </summary>
        public string ProName
        {
            get { return NameSpace.TrimEnd(new char[] { '.', 'A', 'p', 'p', 'l', 'i', 'c', 'a', 't', 'i', 'o', 'n' }); }
        }

        /// <summary>
        /// 类名
        /// </summary>
        public string ClassName { get; set; }

        /// <summary>
        /// 前端查询条件集合
        /// </summary>
        public List<Service.CodeGenConfig> QueryWhetherList { get; set; }

        /// <summary>
        /// 表字段集合
        /// </summary>
        public List<Service.CodeGenConfig> TableField { get; set; }

        /// <summary>
        /// 是否移除表前缀
        /// </summary>
        public string TablePrefix { get; set; }

        /// <summary>
        /// 生成方式
        /// </summary>
        public string GenerateType { get; set; }

        /// <summary>
        /// 数据库名
        /// </summary>
        public string DatabaseName { get; set; }

        /// <summary>
        /// 数据库表名
        /// </summary>
        public string TableName { get; set; }

        /// <summary>
        /// 包名
        /// </summary>
        public string PackageName { get; set; }

        /// <summary>
        /// 业务名（业务代码包名称）
        /// </summary>
        public string BusName { get; set; }

        /// <summary>
        /// 功能名（数据库表名称）
        /// </summary>
        public string TableComment { get; set; }

        /// <summary>
        /// 菜单应用分类（应用编码）
        /// </summary>
        public string MenuApplication { get; set; }

        /// <summary>
        /// 菜单父级
        /// </summary>
        public long MenuPid { get; set; }
    }
}