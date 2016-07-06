using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.Common;
using Maticsoft.Model;
namespace Maticsoft.BLL {
	 	//sysUser
		public partial class sysUser
	{
   		     
		private readonly Maticsoft.DAL.sysUser dal=new Maticsoft.DAL.sysUser();
		public sysUser()
		{}
		
		#region  Method
		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(string UserID)
		{
			return dal.Exists(UserID);
		}

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void  Add(Maticsoft.Model.sysUser model)
		{
						dal.Add(model);
						
		}

		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.sysUser model)
		{
			return dal.Update(model);
		}

		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string UserID)
		{
			
			return dal.Delete(UserID);
		}
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.sysUser GetModel(string UserID)
		{
			
			return dal.GetModel(UserID);
		}

		/// <summary>
		/// 得到一个对象实体，从缓存中
		/// </summary>
		public Maticsoft.Model.sysUser GetModelByCache(string UserID)
		{
			
			string CacheKey = "sysUserModel-" + UserID;
			object objModel = Maticsoft.Common.DataCache.GetCache(CacheKey);
			if (objModel == null)
			{
				try
				{
					objModel = dal.GetModel(UserID);
					if (objModel != null)
					{
						int ModelCache = Maticsoft.Common.ConfigHelper.GetConfigInt("ModelCache");
						Maticsoft.Common.DataCache.SetCache(CacheKey, objModel, DateTime.Now.AddMinutes(ModelCache), TimeSpan.Zero);
					}
				}
				catch{}
			}
			return (Maticsoft.Model.sysUser)objModel;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			return dal.GetList(strWhere);
		}
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			return dal.GetList(Top,strWhere,filedOrder);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.sysUser> GetModelList(string strWhere)
		{
			DataSet ds = dal.GetList(strWhere);
			return DataTableToList(ds.Tables[0]);
		}
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public List<Maticsoft.Model.sysUser> DataTableToList(DataTable dt)
		{
			List<Maticsoft.Model.sysUser> modelList = new List<Maticsoft.Model.sysUser>();
			int rowsCount = dt.Rows.Count;
			if (rowsCount > 0)
			{
				Maticsoft.Model.sysUser model;
				for (int n = 0; n < rowsCount; n++)
				{
					model = new Maticsoft.Model.sysUser();					
																	model.UserID= dt.Rows[n]["UserID"].ToString();
																																model.UserName= dt.Rows[n]["UserName"].ToString();
																																model.Password= dt.Rows[n]["Password"].ToString();
																																model.Workstation= dt.Rows[n]["Workstation"].ToString();
																																model.Privilege= dt.Rows[n]["Privilege"].ToString();
																												if(dt.Rows[n]["ID_Key"].ToString()!="")
				{
					model.ID_Key=decimal.Parse(dt.Rows[n]["ID_Key"].ToString());
				}
																										
				
					modelList.Add(model);
				}
			}
			return modelList;
		}

		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetAllList()
		{
			return GetList("");
		}
#endregion
   
	}
}