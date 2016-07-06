using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;
using System.IO;



namespace MCP_DBUitility
{
    /// <summary>
    /// 数据库操作类
    /// </summary>
 public  class cls_Operate
    {
        /// <summary>
        /// 操作数据库，执行各种SQL语句
        /// </summary>
        /// <param name="strSql">Sql语句</param>
        /// <param name="conn"></param>
        /// <returns>操作受影响的行数</returns>
        public int OperateData(string strSql , SqlConnection conn)
        {
            conn.Open();                                                      //打开数据库
            SqlCommand cmd = new SqlCommand(strSql, conn);                    //实例化Sqlcommand对象
            int i = (int)cmd.ExecuteNonQuery();                               //执行命令 并获取操作受影响的行
            conn.Close();                                                     //关闭连接
            return i;                                                         //返回操作受影响的行数
        }
     

        /// <summary>
        /// 返回DataSet
        /// </summary>
        /// <param name="sql">sql语句</param>
        /// <param name="conn">数据连接</param>
        /// <returns>DataSet</returns>
        public DataSet GetTable(string sql, SqlConnection conn)//返回dataset
        {
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            ds.Dispose();
            return ds;
        }


        /// <summary>
        /// 绑定DataGridView控件
        /// </summary>
        /// <param name="dgv">DataGridView</param>
        /// <param name="sql">sql语句</param>
        /// <param name="conn">连接字符串</param>
        public void BindDataGridView(DataGridView dgv, string sql , SqlConnection conn)
        {
            SqlDataAdapter sda = new SqlDataAdapter(sql, conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            dgv.DataSource = ds.Tables[0];
            ds.Dispose();          
        }
     
      
        /// <summary>
        /// 绑定下拉列表
        /// </summary>
        /// <param name="strTable">数据表</param>
        /// <param name="cb">控件</param>
        /// <param name="i">列</param>
        /// <param name="conn">连接字符</param>
        public void BindDropdownlist(string strTable, ComboBox cb, int i ,SqlConnection conn)
        {
            conn.Open();
            SqlCommand cmd = new SqlCommand("select * from " + strTable, conn);
            SqlDataReader sdr = cmd.ExecuteReader();
            while (sdr.Read())
            {
                cb.Items.Add(sdr[i].ToString());
            }
            conn.Close();
        }

        
        #region 图片操作

        /// <summary>
        /// 显示选择的图片
        /// </summary>
        /// <param name="openF">选择对话框</param>
        /// <param name="MyImage">PictureBox</param>
        public void Read_Image(OpenFileDialog openF, PictureBox MyImage)  //显示选择的图片
        {
            openF.Filter = "*.jpg|*.jpg|*.bmp|*.bmp";   //指定OpenFileDialog控件打开的文件格式
            if (openF.ShowDialog() == DialogResult.OK)  //如果打开了图片文件
            {
                try
                {
                    MyImage.Image = System.Drawing.Image.FromFile(openF.FileName);  //将图片文件存入到PictureBox控件中
                }
                catch
                {
                    MessageBox.Show("您选择的图片不能被读取或文件类型不对！", "错误", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }


        /// <summary>
        /// 将物料图片存入数据库
        /// </summary>
        /// <param name="MaterialID">料号</param>
        /// <param name="openF">包含图片信息的OpenFileDialog</param>
        public void SaveImage(string MaterialID, OpenFileDialog openF)
        {
            SqlConnection conn = Cls_DBConnection.MyConnection_MCP();
            string strimg = openF.FileName.ToString();  //记录图片的所在路径
            FileStream fs = new FileStream(strimg, FileMode.Open, FileAccess.Read); //将图片以文件流的形式进行保存
            BinaryReader br = new BinaryReader(fs);
            byte[] imgBytesIn = br.ReadBytes((int)fs.Length);  //将流读入到字节数组中
            conn.Open();
            StringBuilder strSql = new StringBuilder();
            strSql.Append("update tb_MaterialInfo Set MaterialPhoto=@Photo where employeeID=" + MaterialID);
            SqlCommand cmd = new SqlCommand(strSql.ToString(), conn);
            cmd.Parameters.Add("@Photo", SqlDbType.Binary).Value = imgBytesIn;
            cmd.ExecuteNonQuery();
            conn.Close();
        }


        /// <summary>
        /// 将物料图片从数据库中取出
        /// </summary>
        /// <param name="_MaterialID">物料编号</param>
        /// <param name="pb">PictureBox</param>
        public void Get_Image(string _MaterialID, PictureBox pb)
        {
            SqlConnection conn = Cls_DBConnection.MyConnection_MCP();
            byte[] imagebytes = null;
            conn.Open();
            SqlCommand com = new SqlCommand("select * from tb_MaterialInfo where MaterialID='" + _MaterialID + "'", conn);
            SqlDataReader dr = com.ExecuteReader();
            while (dr.Read())
            {
                imagebytes = (byte[])dr.GetValue(4);
            }
            dr.Close();
            conn.Close();
            MemoryStream ms = new MemoryStream(imagebytes);
            Bitmap bmpt = new Bitmap(ms);
            pb.Image = bmpt;
        }
        #endregion

    }

    /***************************************************  END   */ 
}
