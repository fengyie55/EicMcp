using System; 
using System.Text;
using System.Collections.Generic; 
using System.Data;
namespace Maticsoft.Model{
	 	//sysUser
		public class sysUser
	{
   		     
      	/// <summary>
		/// UserID
        /// </summary>		
		private string _userid;
        public string UserID
        {
            get{ return _userid; }
            set{ _userid = value; }
        }        
		/// <summary>
		/// UserName
        /// </summary>		
		private string _username;
        public string UserName
        {
            get{ return _username; }
            set{ _username = value; }
        }        
		/// <summary>
		/// Password
        /// </summary>		
		private string _password;
        public string Password
        {
            get{ return _password; }
            set{ _password = value; }
        }        
		/// <summary>
		/// Workstation
        /// </summary>		
		private string _workstation;
        public string Workstation
        {
            get{ return _workstation; }
            set{ _workstation = value; }
        }        
		/// <summary>
		/// Privilege
        /// </summary>		
		private string _privilege;
        public string Privilege
        {
            get{ return _privilege; }
            set{ _privilege = value; }
        }        
		/// <summary>
		/// ID_Key
        /// </summary>		
		private decimal _id_key;
        public decimal ID_Key
        {
            get{ return _id_key; }
            set{ _id_key = value; }
        }        
		   
	}
}

