using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Maticsoft.Model
{
  public  class SPC_Config
    {
        private string _name;
        private string _trad_name;
        private string _parameter;
        private string _upper_limit_usl;
        private string _centre_limit_usl;
        private string _lower_limit_usl;
        private string _units;
        private string _department;
        private string _machine_name;
        private string _opname;
        private string _samplingmethod;

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get { return _name; } set { _name = value; } }

        /// <summary>
        /// 品名
        /// </summary>
        public string Trad_Name { get { return _trad_name; } set { _trad_name = value; } }

        /// <summary>
        /// 参数
        /// </summary>
        public string Parameter { get { return _parameter; } set { _parameter = value; } }
        
        /// <summary>
        /// USL 上限
        /// </summary>
        public string Upper_Limit_USL { get { return _upper_limit_usl; } set { _upper_limit_usl = value; } }

        /// <summary>
        /// USL 中心限
        /// </summary>
        public string Center_Limit_USL { get { return _centre_limit_usl; } set { _centre_limit_usl = value; } }

        /// <summary>
        /// USL下限
        /// </summary>
        public string Lower_Limit_USL { get { return _lower_limit_usl; } set { _lower_limit_usl = value; } }

        /// <summary>
        /// 单位
        /// </summary>
        public string Units { get { return _units; } set { _units = value; } }
        
        /// <summary>
        /// 制造部门
        /// </summary>
        public string Department { get { return _department; } set { _department = value; } }

        /// <summary>
        /// 机器名
        /// </summary>
        public string MachineName { get { return _machine_name; } set { _machine_name = value; } }

        /// <summary>
        /// 操作员名称
        /// </summary>
        public string OP_Name { get { return _opname; } set { _opname = value; } }

        /// <summary>
        /// 抽样方法
        /// </summary>
        public string SamplingMethod { get { return _samplingmethod; } set { _samplingmethod = value; } }
    }
}
