using System; 
using System.Text;
using System.Data.SqlClient;
using System.Collections.Generic; 
using System.Data;
using Maticsoft.DBUtility;
namespace Maticsoft.DAL  
{
	 	//sysUser
		public partial class sysUser
	{
   		     
		public bool Exists(string UserID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from sysUser");
			strSql.Append(" where ");
			                                       strSql.Append(" UserID = @UserID  ");
                            			SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.VarChar,15)			};
			parameters[0].Value = UserID;

			return DbHelperSQL.Exists(strSql.ToString(),parameters);
		}
		
				
		
		/// <summary>
		/// 增加一条数据
		/// </summary>
		public void Add(Maticsoft.Model.sysUser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into sysUser(");			
            strSql.Append("UserID,UserName,Password,Workstation,Privilege,ID_Key");
			strSql.Append(") values (");
            strSql.Append("@UserID,@UserName,@Password,@Workstation,@Privilege,@ID_Key");            
            strSql.Append(") ");            
            		
			SqlParameter[] parameters = {
			            new SqlParameter("@UserID", SqlDbType.VarChar,15) ,            
                        new SqlParameter("@UserName", SqlDbType.VarChar,15) ,            
                        new SqlParameter("@Password", SqlDbType.VarChar,15) ,            
                        new SqlParameter("@Workstation", SqlDbType.VarChar,15) ,            
                        new SqlParameter("@Privilege", SqlDbType.VarChar,15) ,            
                        new SqlParameter("@ID_Key", SqlDbType.Decimal,9)             
              
            };
			            
            parameters[0].Value = model.UserID;                        
            parameters[1].Value = model.UserName;                        
            parameters[2].Value = model.Password;                        
            parameters[3].Value = model.Workstation;                        
            parameters[4].Value = model.Privilege;                        
            parameters[5].Value = model.ID_Key;                        
			            DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
            			
		}
		
		
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.sysUser model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update sysUser set ");
			                        
            strSql.Append(" UserID = @UserID , ");                                    
            strSql.Append(" UserName = @UserName , ");                                    
            strSql.Append(" Password = @Password , ");                                    
            strSql.Append(" Workstation = @Workstation , ");                                    
            strSql.Append(" Privilege = @Privilege , ");                                    
            strSql.Append(" ID_Key = @ID_Key  ");            			
			strSql.Append(" where UserID=@UserID  ");
						
SqlParameter[] parameters = {
			            new SqlParameter("@UserID", SqlDbType.VarChar,15) ,            
                        new SqlParameter("@UserName", SqlDbType.VarChar,15) ,            
                        new SqlParameter("@Password", SqlDbType.VarChar,15) ,            
                        new SqlParameter("@Workstation", SqlDbType.VarChar,15) ,            
                        new SqlParameter("@Privilege", SqlDbType.VarChar,15) ,            
                        new SqlParameter("@ID_Key", SqlDbType.Decimal,9)             
              
            };
						            
            parameters[0].Value = model.UserID;                        
            parameters[1].Value = model.UserName;                        
            parameters[2].Value = model.Password;                        
            parameters[3].Value = model.Workstation;                        
            parameters[4].Value = model.Privilege;                        
            parameters[5].Value = model.ID_Key;                        
            int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		
		/// <summary>
		/// 删除一条数据
		/// </summary>
		public bool Delete(string UserID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from sysUser ");
			strSql.Append(" where UserID=@UserID ");
						SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.VarChar,15)			};
			parameters[0].Value = UserID;


			int rows=DbHelperSQL.ExecuteSql(strSql.ToString(),parameters);
			if (rows > 0)
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
				
		
		/// <summary>
		/// 得到一个对象实体
		/// </summary>
		public Maticsoft.Model.sysUser GetModel(string UserID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select UserID, UserName, Password, Workstation, Privilege, ID_Key  ");			
			strSql.Append("  from sysUser ");
			strSql.Append(" where UserID=@UserID ");
						SqlParameter[] parameters = {
					new SqlParameter("@UserID", SqlDbType.VarChar,15)			};
			parameters[0].Value = UserID;

			
			Maticsoft.Model.sysUser model=new Maticsoft.Model.sysUser();
			DataSet ds=DbHelperSQL.Query(strSql.ToString(),parameters);
			
			if(ds.Tables[0].Rows.Count>0)
			{
																model.UserID= ds.Tables[0].Rows[0]["UserID"].ToString();
																																model.UserName= ds.Tables[0].Rows[0]["UserName"].ToString();
																																model.Password= ds.Tables[0].Rows[0]["Password"].ToString();
																																model.Workstation= ds.Tables[0].Rows[0]["Workstation"].ToString();
																																model.Privilege= ds.Tables[0].Rows[0]["Privilege"].ToString();
																												if(ds.Tables[0].Rows[0]["ID_Key"].ToString()!="")
				{
					model.ID_Key=decimal.Parse(ds.Tables[0].Rows[0]["ID_Key"].ToString());
				}
																														
				return model;
			}
			else
			{
				return null;
			}
		}
		
		
		/// <summary>
		/// 获得数据列表
		/// </summary>
		public DataSet GetList(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select * ");
			strSql.Append(" FROM sysUser ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return DbHelperSQL.Query(strSql.ToString());
		}
		
		/// <summary>
		/// 获得前几行数据
		/// </summary>
		public DataSet GetList(int Top,string strWhere,string filedOrder)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select ");
			if(Top>0)
			{
				strSql.Append(" top "+Top.ToString());
			}
			strSql.Append(" * ");
			strSql.Append(" FROM sysUser ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return DbHelperSQL.Query(strSql.ToString());
		}

   
	}
}

