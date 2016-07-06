/**  版本信息模板在安装目录下，可自行修改。
* e_ProcessDraw.cs
*
* 功 能： N/A
* 类 名： e_ProcessDraw
*
* Ver    变更日期             负责人  变更内容
* ───────────────────────────────────
* V0.01  2014/12/25 12:45:34   N/A    初版
*
* Copyright (c) 2012 Maticsoft Corporation. All rights reserved.
*┌──────────────────────────────────┐
*│　此技术信息为本公司机密信息，未经本公司书面同意禁止向第三方披露．　│
*│　版权所有：动软卓越（北京）科技有限公司　　　　　　　　　　　　　　│
*└──────────────────────────────────┘
*/
using System;
namespace Maticsoft.Model
{
	/// <summary>
	/// e_ProcessDraw:实体类(属性说明自动提取数据库字段的描述信息)
	/// </summary>
	[Serializable]
	public partial class e_ProcessDraw
	{
		public e_ProcessDraw()
		{}
		#region Model
		private decimal _id_key;
		private string _drawnum;
		private string _processnum;
		private string _name;
		private string _model;
		private byte[] _pic;
		private string _remarks;
		/// <summary>
		/// 
		/// </summary>
		public decimal ID_Key
		{
			set{ _id_key=value;}
			get{return _id_key;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string DrawNum
		{
			set{ _drawnum=value;}
			get{return _drawnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string ProcessNum
		{
			set{ _processnum=value;}
			get{return _processnum;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Name
		{
			set{ _name=value;}
			get{return _name;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Model
		{
			set{ _model=value;}
			get{return _model;}
		}
		/// <summary>
		/// 
		/// </summary>
		public byte[] Pic
		{
			set{ _pic=value;}
			get{return _pic;}
		}
		/// <summary>
		/// 
		/// </summary>
		public string Remarks
		{
			set{ _remarks=value;}
			get{return _remarks;}
		}
		#endregion Model

	}
}

