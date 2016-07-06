using System;
using System.Data;
using System.Text;
using System.Data.SqlClient;

namespace Maticsoft.DAL
{
	/// <summary>
	/// 数据访问类:UserInfo
	/// </summary>
	public partial class UserInfo
	{
		public UserInfo()
		{}
		#region  Method

        MCP_DBUitility.DbHelperSQL dbs = new MCP_DBUitility.DbHelperSQL();


		/// <summary>
		/// 是否存在该记录
		/// </summary>
		public bool Exists(decimal USI_ID)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) from tb_UserInfo");
			strSql.Append(" where USI_ID=@USI_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@USI_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = USI_ID;

			return dbs.Exists(strSql.ToString(),parameters);
		}

        /// <summary>
        /// 获取字段不重复记录
        /// </summary>
        /// <param name="_Value">字段名</param>
        /// <returns></returns>
        public DataSet Get_Distinct_List(string _Value)
        {
            DataSet ds = new DataSet();
            try
            {
                if (_Value.Trim() != "")
                {
                    StringBuilder strSql = new StringBuilder();
                    strSql.Append(" SELECT DISTINCT ");
                    strSql.Append(_Value);
                    strSql.Append(" FROM tb_UserInfo ");
                    ds = dbs.Query(strSql.ToString());
                }
            }
            catch { ds = null; };
            return ds;
        }

		/// <summary>
		/// 增加一条数据
		/// </summary>
		public decimal Add(Maticsoft.Model.UserInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("insert into tb_UserInfo(");
			strSql.Append("Workstation,Job_Title,Is_Job,Job_Num,Name,Age,Sex,IsWedding,Politics,ID_Card,Nation,Native_Place,Degree,Major,School,Date_Of_Birth,Entry_Date,Termination_Date,QQ,Email_Address,Phone,Present_Assress,Emergency_Contact,Resume,Remark)");
			strSql.Append(" values (");
			strSql.Append("@Workstation,@Job_Title,@Is_Job,@Job_Num,@Name,@Age,@Sex,@IsWedding,@Politics,@ID_Card,@Nation,@Native_Place,@Degree,@Major,@School,@Date_Of_Birth,@Entry_Date,@Termination_Date,@QQ,@Email_Address,@Phone,@Present_Assress,@Emergency_Contact,@Resume,@Remark)");
			strSql.Append(";select @@IDENTITY");
			SqlParameter[] parameters = {
					new SqlParameter("@Workstation", SqlDbType.VarChar,50),
					new SqlParameter("@Job_Title", SqlDbType.VarChar,50),
					new SqlParameter("@Is_Job", SqlDbType.VarChar,10),
					new SqlParameter("@Job_Num", SqlDbType.VarChar,30),
					new SqlParameter("@Name", SqlDbType.VarChar,30),
					new SqlParameter("@Age", SqlDbType.VarChar,10),
					new SqlParameter("@Sex", SqlDbType.VarChar,10),
					new SqlParameter("@IsWedding", SqlDbType.VarChar,10),
					new SqlParameter("@Politics", SqlDbType.VarChar,20),
					new SqlParameter("@ID_Card", SqlDbType.VarChar,50),
					new SqlParameter("@Nation", SqlDbType.VarChar,20),
					new SqlParameter("@Native_Place", SqlDbType.VarChar,255),
					new SqlParameter("@Degree", SqlDbType.VarChar,20),
					new SqlParameter("@Major", SqlDbType.VarChar,50),
					new SqlParameter("@School", SqlDbType.VarChar,50),
					new SqlParameter("@Date_Of_Birth", SqlDbType.DateTime),
					new SqlParameter("@Entry_Date", SqlDbType.DateTime),
					new SqlParameter("@Termination_Date", SqlDbType.DateTime),
					new SqlParameter("@QQ", SqlDbType.VarChar,20),
					new SqlParameter("@Email_Address", SqlDbType.VarChar,30),
					new SqlParameter("@Phone", SqlDbType.VarChar,30),
					new SqlParameter("@Present_Assress", SqlDbType.VarChar,255),
					new SqlParameter("@Emergency_Contact", SqlDbType.Text),
					new SqlParameter("@Resume", SqlDbType.Text),
					new SqlParameter("@Remark", SqlDbType.Text)};
			parameters[0].Value = model.Workstation;
			parameters[1].Value = model.Job_Title;
			parameters[2].Value = model.Is_Job;
			parameters[3].Value = model.Job_Num;
			parameters[4].Value = model.Name;
			parameters[5].Value = model.Age;
			parameters[6].Value = model.Sex;
			parameters[7].Value = model.IsWedding;
			parameters[8].Value = model.Politics;
			parameters[9].Value = model.ID_Card;
			parameters[10].Value = model.Nation;
			parameters[11].Value = model.Native_Place;
			parameters[12].Value = model.Degree;
			parameters[13].Value = model.Major;
			parameters[14].Value = model.School;
			parameters[15].Value = model.Date_Of_Birth;
			parameters[16].Value = model.Entry_Date;
			parameters[17].Value = model.Termination_Date;
			parameters[18].Value = model.QQ;
			parameters[19].Value = model.Email_Address;
			parameters[20].Value = model.Phone;
			parameters[21].Value = model.Present_Assress;
			parameters[22].Value = model.Emergency_Contact;
			parameters[23].Value = model.Resume;
			parameters[24].Value = model.Remark;

			object obj = dbs.GetSingle(strSql.ToString(),parameters);
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToDecimal(obj);
			}
		}
		/// <summary>
		/// 更新一条数据
		/// </summary>
		public bool Update(Maticsoft.Model.UserInfo model)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("update tb_UserInfo set ");
			strSql.Append("Workstation=@Workstation,");
			strSql.Append("Job_Title=@Job_Title,");
			strSql.Append("Is_Job=@Is_Job,");
			strSql.Append("Job_Num=@Job_Num,");
			strSql.Append("Name=@Name,");
			strSql.Append("Age=@Age,");
			strSql.Append("Sex=@Sex,");
			strSql.Append("IsWedding=@IsWedding,");
			strSql.Append("Politics=@Politics,");
			strSql.Append("ID_Card=@ID_Card,");
			strSql.Append("Nation=@Nation,");
			strSql.Append("Native_Place=@Native_Place,");
			strSql.Append("Degree=@Degree,");
			strSql.Append("Major=@Major,");
			strSql.Append("School=@School,");
			strSql.Append("Date_Of_Birth=@Date_Of_Birth,");
			strSql.Append("Entry_Date=@Entry_Date,");
			strSql.Append("Termination_Date=@Termination_Date,");
			strSql.Append("QQ=@QQ,");
			strSql.Append("Email_Address=@Email_Address,");
			strSql.Append("Phone=@Phone,");
			strSql.Append("Present_Assress=@Present_Assress,");
			strSql.Append("Emergency_Contact=@Emergency_Contact,");
			strSql.Append("Resume=@Resume,");
			strSql.Append("Remark=@Remark");
			strSql.Append(" where USI_ID=@USI_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@Workstation", SqlDbType.VarChar,50),
					new SqlParameter("@Job_Title", SqlDbType.VarChar,50),
					new SqlParameter("@Is_Job", SqlDbType.VarChar,10),
					new SqlParameter("@Job_Num", SqlDbType.VarChar,30),
					new SqlParameter("@Name", SqlDbType.VarChar,30),
					new SqlParameter("@Age", SqlDbType.VarChar,10),
					new SqlParameter("@Sex", SqlDbType.VarChar,10),
					new SqlParameter("@IsWedding", SqlDbType.VarChar,10),
					new SqlParameter("@Politics", SqlDbType.VarChar,20),
					new SqlParameter("@ID_Card", SqlDbType.VarChar,50),
					new SqlParameter("@Nation", SqlDbType.VarChar,20),
					new SqlParameter("@Native_Place", SqlDbType.VarChar,255),
					new SqlParameter("@Degree", SqlDbType.VarChar,20),
					new SqlParameter("@Major", SqlDbType.VarChar,50),
					new SqlParameter("@School", SqlDbType.VarChar,50),
					new SqlParameter("@Date_Of_Birth", SqlDbType.DateTime),
					new SqlParameter("@Entry_Date", SqlDbType.DateTime),
					new SqlParameter("@Termination_Date", SqlDbType.DateTime),
					new SqlParameter("@QQ", SqlDbType.VarChar,20),
					new SqlParameter("@Email_Address", SqlDbType.VarChar,30),
					new SqlParameter("@Phone", SqlDbType.VarChar,30),
					new SqlParameter("@Present_Assress", SqlDbType.VarChar,255),
					new SqlParameter("@Emergency_Contact", SqlDbType.Text),
					new SqlParameter("@Resume", SqlDbType.Text),
					new SqlParameter("@Remark", SqlDbType.Text),
					new SqlParameter("@USI_ID", SqlDbType.Decimal,9)};
			parameters[0].Value = model.Workstation;
			parameters[1].Value = model.Job_Title;
			parameters[2].Value = model.Is_Job;
			parameters[3].Value = model.Job_Num;
			parameters[4].Value = model.Name;
			parameters[5].Value = model.Age;
			parameters[6].Value = model.Sex;
			parameters[7].Value = model.IsWedding;
			parameters[8].Value = model.Politics;
			parameters[9].Value = model.ID_Card;
			parameters[10].Value = model.Nation;
			parameters[11].Value = model.Native_Place;
			parameters[12].Value = model.Degree;
			parameters[13].Value = model.Major;
			parameters[14].Value = model.School;
			parameters[15].Value = model.Date_Of_Birth;
			parameters[16].Value = model.Entry_Date;
			parameters[17].Value = model.Termination_Date;
			parameters[18].Value = model.QQ;
			parameters[19].Value = model.Email_Address;
			parameters[20].Value = model.Phone;
			parameters[21].Value = model.Present_Assress;
			parameters[22].Value = model.Emergency_Contact;
			parameters[23].Value = model.Resume;
			parameters[24].Value = model.Remark;
			parameters[25].Value = model.USI_ID;

			int rows=dbs.ExecuteSql(strSql.ToString(),parameters);
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
		public bool Delete(decimal USI_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_UserInfo ");
			strSql.Append(" where USI_ID=@USI_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@USI_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = USI_ID;

			int rows=dbs.ExecuteSql(strSql.ToString(),parameters);
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
		/// 批量删除数据
		/// </summary>
		public bool DeleteList(string USI_IDlist )
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("delete from tb_UserInfo ");
			strSql.Append(" where USI_ID in ("+USI_IDlist + ")  ");
			int rows=dbs.ExecuteSql(strSql.ToString());
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
		public Maticsoft.Model.UserInfo GetModel(decimal USI_ID)
		{
			
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select  top 1 USI_ID,Workstation,Job_Title,Is_Job,Job_Num,Name,Age,Sex,IsWedding,Politics,ID_Card,Nation,Native_Place,Degree,Major,School,Date_Of_Birth,Entry_Date,Termination_Date,QQ,Email_Address,Phone,Present_Assress,Emergency_Contact,Resume,Remark from tb_UserInfo ");
			strSql.Append(" where USI_ID=@USI_ID");
			SqlParameter[] parameters = {
					new SqlParameter("@USI_ID", SqlDbType.Decimal)
			};
			parameters[0].Value = USI_ID;

			Maticsoft.Model.UserInfo model=new Maticsoft.Model.UserInfo();
			DataSet ds=dbs.Query(strSql.ToString(),parameters);
			if(ds.Tables[0].Rows.Count>0)
			{
				if(ds.Tables[0].Rows[0]["USI_ID"]!=null && ds.Tables[0].Rows[0]["USI_ID"].ToString()!="")
				{
					model.USI_ID=decimal.Parse(ds.Tables[0].Rows[0]["USI_ID"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Workstation"]!=null && ds.Tables[0].Rows[0]["Workstation"].ToString()!="")
				{
					model.Workstation=ds.Tables[0].Rows[0]["Workstation"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Job_Title"]!=null && ds.Tables[0].Rows[0]["Job_Title"].ToString()!="")
				{
					model.Job_Title=ds.Tables[0].Rows[0]["Job_Title"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Is_Job"]!=null && ds.Tables[0].Rows[0]["Is_Job"].ToString()!="")
				{
					model.Is_Job=ds.Tables[0].Rows[0]["Is_Job"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Job_Num"]!=null && ds.Tables[0].Rows[0]["Job_Num"].ToString()!="")
				{
					model.Job_Num=ds.Tables[0].Rows[0]["Job_Num"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Name"]!=null && ds.Tables[0].Rows[0]["Name"].ToString()!="")
				{
					model.Name=ds.Tables[0].Rows[0]["Name"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Age"]!=null && ds.Tables[0].Rows[0]["Age"].ToString()!="")
				{
					model.Age=ds.Tables[0].Rows[0]["Age"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Sex"]!=null && ds.Tables[0].Rows[0]["Sex"].ToString()!="")
				{
					model.Sex=ds.Tables[0].Rows[0]["Sex"].ToString();
				}
				if(ds.Tables[0].Rows[0]["IsWedding"]!=null && ds.Tables[0].Rows[0]["IsWedding"].ToString()!="")
				{
					model.IsWedding=ds.Tables[0].Rows[0]["IsWedding"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Politics"]!=null && ds.Tables[0].Rows[0]["Politics"].ToString()!="")
				{
					model.Politics=ds.Tables[0].Rows[0]["Politics"].ToString();
				}
				if(ds.Tables[0].Rows[0]["ID_Card"]!=null && ds.Tables[0].Rows[0]["ID_Card"].ToString()!="")
				{
					model.ID_Card=ds.Tables[0].Rows[0]["ID_Card"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Nation"]!=null && ds.Tables[0].Rows[0]["Nation"].ToString()!="")
				{
					model.Nation=ds.Tables[0].Rows[0]["Nation"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Native_Place"]!=null && ds.Tables[0].Rows[0]["Native_Place"].ToString()!="")
				{
					model.Native_Place=ds.Tables[0].Rows[0]["Native_Place"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Degree"]!=null && ds.Tables[0].Rows[0]["Degree"].ToString()!="")
				{
					model.Degree=ds.Tables[0].Rows[0]["Degree"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Major"]!=null && ds.Tables[0].Rows[0]["Major"].ToString()!="")
				{
					model.Major=ds.Tables[0].Rows[0]["Major"].ToString();
				}
				if(ds.Tables[0].Rows[0]["School"]!=null && ds.Tables[0].Rows[0]["School"].ToString()!="")
				{
					model.School=ds.Tables[0].Rows[0]["School"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Date_Of_Birth"]!=null && ds.Tables[0].Rows[0]["Date_Of_Birth"].ToString()!="")
				{
					model.Date_Of_Birth=DateTime.Parse(ds.Tables[0].Rows[0]["Date_Of_Birth"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Entry_Date"]!=null && ds.Tables[0].Rows[0]["Entry_Date"].ToString()!="")
				{
					model.Entry_Date=DateTime.Parse(ds.Tables[0].Rows[0]["Entry_Date"].ToString());
				}
				if(ds.Tables[0].Rows[0]["Termination_Date"]!=null && ds.Tables[0].Rows[0]["Termination_Date"].ToString()!="")
				{
					model.Termination_Date=DateTime.Parse(ds.Tables[0].Rows[0]["Termination_Date"].ToString());
				}
				if(ds.Tables[0].Rows[0]["QQ"]!=null && ds.Tables[0].Rows[0]["QQ"].ToString()!="")
				{
					model.QQ=ds.Tables[0].Rows[0]["QQ"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Email_Address"]!=null && ds.Tables[0].Rows[0]["Email_Address"].ToString()!="")
				{
					model.Email_Address=ds.Tables[0].Rows[0]["Email_Address"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Phone"]!=null && ds.Tables[0].Rows[0]["Phone"].ToString()!="")
				{
					model.Phone=ds.Tables[0].Rows[0]["Phone"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Present_Assress"]!=null && ds.Tables[0].Rows[0]["Present_Assress"].ToString()!="")
				{
					model.Present_Assress=ds.Tables[0].Rows[0]["Present_Assress"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Emergency_Contact"]!=null && ds.Tables[0].Rows[0]["Emergency_Contact"].ToString()!="")
				{
					model.Emergency_Contact=ds.Tables[0].Rows[0]["Emergency_Contact"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Resume"]!=null && ds.Tables[0].Rows[0]["Resume"].ToString()!="")
				{
					model.Resume=ds.Tables[0].Rows[0]["Resume"].ToString();
				}
				if(ds.Tables[0].Rows[0]["Remark"]!=null && ds.Tables[0].Rows[0]["Remark"].ToString()!="")
				{
					model.Remark=ds.Tables[0].Rows[0]["Remark"].ToString();
				}
				return model;
			}
			else
			{
				return null;
			}
		}

        /// <summary>
        /// 得到一个对象实体
        /// </summary>
        public Maticsoft.Model.UserInfo GetModel(string jobNum)
        {

            StringBuilder strSql = new StringBuilder();
            strSql.Append("select  top 1 USI_ID,Workstation,Job_Title,Is_Job,Job_Num,Name,Age,Sex,IsWedding,Politics,ID_Card,Nation,Native_Place,Degree,Major,School,Date_Of_Birth,Entry_Date,Termination_Date,QQ,Email_Address,Phone,Present_Assress,Emergency_Contact,Resume,Remark from tb_UserInfo ");
            strSql.Append(" where Job_Num=@Job_Num");
            SqlParameter[] parameters = {
					new SqlParameter("@Job_Num", SqlDbType.VarChar, 30)
			};
            parameters[0].Value = jobNum;

            Maticsoft.Model.UserInfo model = new Maticsoft.Model.UserInfo();
            DataSet ds = dbs.Query(strSql.ToString(), parameters);
            if (ds.Tables[0].Rows.Count > 0)
            {
                if (ds.Tables[0].Rows[0]["USI_ID"] != null && ds.Tables[0].Rows[0]["USI_ID"].ToString() != "")
                {
                    model.USI_ID = decimal.Parse(ds.Tables[0].Rows[0]["USI_ID"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Workstation"] != null && ds.Tables[0].Rows[0]["Workstation"].ToString() != "")
                {
                    model.Workstation = ds.Tables[0].Rows[0]["Workstation"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Job_Title"] != null && ds.Tables[0].Rows[0]["Job_Title"].ToString() != "")
                {
                    model.Job_Title = ds.Tables[0].Rows[0]["Job_Title"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Is_Job"] != null && ds.Tables[0].Rows[0]["Is_Job"].ToString() != "")
                {
                    model.Is_Job = ds.Tables[0].Rows[0]["Is_Job"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Job_Num"] != null && ds.Tables[0].Rows[0]["Job_Num"].ToString() != "")
                {
                    model.Job_Num = ds.Tables[0].Rows[0]["Job_Num"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Name"] != null && ds.Tables[0].Rows[0]["Name"].ToString() != "")
                {
                    model.Name = ds.Tables[0].Rows[0]["Name"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Age"] != null && ds.Tables[0].Rows[0]["Age"].ToString() != "")
                {
                    model.Age = ds.Tables[0].Rows[0]["Age"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Sex"] != null && ds.Tables[0].Rows[0]["Sex"].ToString() != "")
                {
                    model.Sex = ds.Tables[0].Rows[0]["Sex"].ToString();
                }
                if (ds.Tables[0].Rows[0]["IsWedding"] != null && ds.Tables[0].Rows[0]["IsWedding"].ToString() != "")
                {
                    model.IsWedding = ds.Tables[0].Rows[0]["IsWedding"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Politics"] != null && ds.Tables[0].Rows[0]["Politics"].ToString() != "")
                {
                    model.Politics = ds.Tables[0].Rows[0]["Politics"].ToString();
                }
                if (ds.Tables[0].Rows[0]["ID_Card"] != null && ds.Tables[0].Rows[0]["ID_Card"].ToString() != "")
                {
                    model.ID_Card = ds.Tables[0].Rows[0]["ID_Card"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Nation"] != null && ds.Tables[0].Rows[0]["Nation"].ToString() != "")
                {
                    model.Nation = ds.Tables[0].Rows[0]["Nation"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Native_Place"] != null && ds.Tables[0].Rows[0]["Native_Place"].ToString() != "")
                {
                    model.Native_Place = ds.Tables[0].Rows[0]["Native_Place"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Degree"] != null && ds.Tables[0].Rows[0]["Degree"].ToString() != "")
                {
                    model.Degree = ds.Tables[0].Rows[0]["Degree"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Major"] != null && ds.Tables[0].Rows[0]["Major"].ToString() != "")
                {
                    model.Major = ds.Tables[0].Rows[0]["Major"].ToString();
                }
                if (ds.Tables[0].Rows[0]["School"] != null && ds.Tables[0].Rows[0]["School"].ToString() != "")
                {
                    model.School = ds.Tables[0].Rows[0]["School"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Date_Of_Birth"] != null && ds.Tables[0].Rows[0]["Date_Of_Birth"].ToString() != "")
                {
                    model.Date_Of_Birth = DateTime.Parse(ds.Tables[0].Rows[0]["Date_Of_Birth"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Entry_Date"] != null && ds.Tables[0].Rows[0]["Entry_Date"].ToString() != "")
                {
                    model.Entry_Date = DateTime.Parse(ds.Tables[0].Rows[0]["Entry_Date"].ToString());
                }
                if (ds.Tables[0].Rows[0]["Termination_Date"] != null && ds.Tables[0].Rows[0]["Termination_Date"].ToString() != "")
                {
                    model.Termination_Date = DateTime.Parse(ds.Tables[0].Rows[0]["Termination_Date"].ToString());
                }
                if (ds.Tables[0].Rows[0]["QQ"] != null && ds.Tables[0].Rows[0]["QQ"].ToString() != "")
                {
                    model.QQ = ds.Tables[0].Rows[0]["QQ"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Email_Address"] != null && ds.Tables[0].Rows[0]["Email_Address"].ToString() != "")
                {
                    model.Email_Address = ds.Tables[0].Rows[0]["Email_Address"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Phone"] != null && ds.Tables[0].Rows[0]["Phone"].ToString() != "")
                {
                    model.Phone = ds.Tables[0].Rows[0]["Phone"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Present_Assress"] != null && ds.Tables[0].Rows[0]["Present_Assress"].ToString() != "")
                {
                    model.Present_Assress = ds.Tables[0].Rows[0]["Present_Assress"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Emergency_Contact"] != null && ds.Tables[0].Rows[0]["Emergency_Contact"].ToString() != "")
                {
                    model.Emergency_Contact = ds.Tables[0].Rows[0]["Emergency_Contact"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Resume"] != null && ds.Tables[0].Rows[0]["Resume"].ToString() != "")
                {
                    model.Resume = ds.Tables[0].Rows[0]["Resume"].ToString();
                }
                if (ds.Tables[0].Rows[0]["Remark"] != null && ds.Tables[0].Rows[0]["Remark"].ToString() != "")
                {
                    model.Remark = ds.Tables[0].Rows[0]["Remark"].ToString();
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
			strSql.Append("select USI_ID,Workstation,Job_Title,Is_Job,Job_Num,Name,Age,Sex,IsWedding,Politics,ID_Card,Nation,Native_Place,Degree,Major,School,Date_Of_Birth,Entry_Date,Termination_Date,QQ,Email_Address,Phone,Present_Assress,Emergency_Contact,Resume,Remark ");
			strSql.Append(" FROM tb_UserInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			return dbs.Query(strSql.ToString());
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
			strSql.Append(" USI_ID,Workstation,Job_Title,Is_Job,Job_Num,Name,Age,Sex,IsWedding,Politics,ID_Card,Nation,Native_Place,Degree,Major,School,Date_Of_Birth,Entry_Date,Termination_Date,QQ,Email_Address,Phone,Present_Assress,Emergency_Contact,Resume,Remark ");
			strSql.Append(" FROM tb_UserInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			strSql.Append(" order by " + filedOrder);
			return dbs.Query(strSql.ToString());
		}

		/// <summary>
		/// 获取记录总数
		/// </summary>
		public int GetRecordCount(string strWhere)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("select count(1) FROM tb_UserInfo ");
			if(strWhere.Trim()!="")
			{
				strSql.Append(" where "+strWhere);
			}
			object obj = dbs.GetSingle(strSql.ToString());
			if (obj == null)
			{
				return 0;
			}
			else
			{
				return Convert.ToInt32(obj);
			}
		}
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetListByPage(string strWhere, string orderby, int startIndex, int endIndex)
		{
			StringBuilder strSql=new StringBuilder();
			strSql.Append("SELECT * FROM ( ");
			strSql.Append(" SELECT ROW_NUMBER() OVER (");
			if (!string.IsNullOrEmpty(orderby.Trim()))
			{
				strSql.Append("order by T." + orderby );
			}
			else
			{
				strSql.Append("order by T.USI_ID desc");
			}
			strSql.Append(")AS Row, T.*  from tb_UserInfo T ");
			if (!string.IsNullOrEmpty(strWhere.Trim()))
			{
				strSql.Append(" WHERE " + strWhere);
			}
			strSql.Append(" ) TT");
			strSql.AppendFormat(" WHERE TT.Row between {0} and {1}", startIndex, endIndex);
			return dbs.Query(strSql.ToString());
		}

		/*
		/// <summary>
		/// 分页获取数据列表
		/// </summary>
		public DataSet GetList(int PageSize,int PageIndex,string strWhere)
		{
			SqlParameter[] parameters = {
					new SqlParameter("@tblName", SqlDbType.VarChar, 255),
					new SqlParameter("@fldName", SqlDbType.VarChar, 255),
					new SqlParameter("@PageSize", SqlDbType.Int),
					new SqlParameter("@PageIndex", SqlDbType.Int),
					new SqlParameter("@IsReCount", SqlDbType.Bit),
					new SqlParameter("@OrderType", SqlDbType.Bit),
					new SqlParameter("@strWhere", SqlDbType.VarChar,1000),
					};
			parameters[0].Value = "tb_UserInfo";
			parameters[1].Value = "USI_ID";
			parameters[2].Value = PageSize;
			parameters[3].Value = PageIndex;
			parameters[4].Value = 0;
			parameters[5].Value = 0;
			parameters[6].Value = strWhere;	
			return dbs.RunProcedure("UP_GetRecordByPage",parameters,"ds");
		}*/

		#endregion  Method
	}
}

