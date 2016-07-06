using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    class My_MessageBox
    {
        /// <summary>
        /// 消息提示
        /// </summary>
        /// <param name="_Message"></param>
        public static void My_MessageBox_Message(string _Message)
        {
            MessageBox.Show(""+_Message+"", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk, MessageBoxDefaultButton.Button1);
        }

        /// <summary>
        /// 错误提示
        /// </summary>
        /// <param name="_Message"></param>
        public static void My_MessageBox_Erry(string _Message)
        {
            MessageBox.Show("" + _Message + "", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button2);
        }

        public static void My_MessageBox_Query(string _Message)
        {
            MessageBox.Show("" + _Message + "", "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2);
        }
    }
}
