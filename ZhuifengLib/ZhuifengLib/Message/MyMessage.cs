using System.Windows.Forms;

namespace ZhuifengLib
{
    /// <summary>
    /// 消息提示类
    /// </summary>
    public static class MyMessage 
    {
        /// <summary>
        /// 显示信息
        /// </summary>
        /// <param name="_Msg"></param>
        public static void MessageInfo(string msg)
        {
            MessageBox.Show(msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        /// <summary>
        /// 显示错误提示
        /// </summary>
        /// <param name="_Msg"></param>
        public static void MessageErr(string msg)
        {
            MessageBox.Show(msg, "系统提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        /// <summary>
        /// 显示错误提示，并返回用户是否按下了OK按键
        /// </summary>
        /// <param name="_Msg"></param>
        /// <returns></returns>
        public static void MessageErr(string msg, ref bool ok)
        {
            if (MessageBox.Show(msg, "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Error) == DialogResult.OK)
                ok = true;
            else ok = false;
        }

        public static bool IsOkMessage(string msg)
        {
            if (MessageBox.Show(msg, "系统提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Exclamation) == DialogResult.OK)
               return true;
            return false;
        }
    }
}
