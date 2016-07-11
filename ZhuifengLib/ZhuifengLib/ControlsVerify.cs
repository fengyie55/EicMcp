/********************************************************************************

** 作者： 张文明

** 创始时间：2015-3-18

** 修改人：

** 修改时间：

** 修改人：

** 修改时间：

** 描述：

**    主要用于验证窗体控件是否为空以及输入是否合法

*********************************************************************************/


using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ZhuifengLib.Controls
{
    public static class Verify
    {
        /// <summary>
        /// 检查非空字段
        /// </summary>
        /// <param name="isOk">是否为空</param>
        /// <param name="textboxes"></param>
        public static void CheckTextBoxNotNull(ref bool isOk, params TextBox[] textboxes)
        {
            foreach (var txtBox in textboxes)
            {
                txtBox.Background = Brushes.White;
                if (txtBox.Text.Length <= 0)
                {
                    isOk = false;
                    txtBox.Background = Brushes.Red;
                }
                else { txtBox.Background = Brushes.White; }
            }
        }

        /// <summary>
        /// 设置Button是否启用编辑
        /// </summary>
        /// <param name="_IsEnabled">是否启用编辑</param>
        /// <param name="buttions"></param>
        public static void SetButtonIsEnabled(bool isEnabled, params Button[] buttions)
        {
            foreach (var button in buttions)
            {
                button.IsEnabled = isEnabled;
            }
        }

        /// <summary>
        /// 设置TextBox是否启用编辑
        /// </summary>
        /// <param name="_IsEnabled">是否启用编辑</param>
        /// <param name="buttions"></param>
        public static void SetTextBoxIsEnabled(bool isEnabled, bool isNull, params TextBox[] buttions)
        {
            foreach (var textBox in buttions)
            {
                textBox.IsEnabled = isEnabled;
                if (isNull) textBox.Text = "";
            }
        }

        public static void SetControl(bool isEn, bool isNull, params UIElement[] controls)  
        {
            foreach(var c in controls) 
            {
                if (c is TextBox)
                {
                    c.IsEnabled = isEn;
                    if (isNull) { ((TextBox)c).Text = ""; }
                }
                if (c is ComboBox)
                {
                    c.IsEnabled = isEn;
                    if (isNull) { ((ComboBox)c).SelectedIndex = -1; }
                }
                if (c is DatePicker)
                {
                    c.IsEnabled = isEn;
                    if (isNull) { ((DatePicker)c).SelectedDate = null; }
                }
            }
        }
        /// <summary>
        /// 设置控件
        /// </summary>
        /// <param name="isEn">是否启用编辑</param>
        /// <param name="isNull">是否为空</param>
        public static void SetControl(Grid grd, bool isEn, bool isNull)
        {
            foreach (UIElement c in grd.Children)
            {
                if (c is TextBox)
                {
                    c.IsEnabled = isEn;
                    if (isNull) { ((TextBox)c).Text = ""; }
                }
                if (c is ComboBox)
                {
                    c.IsEnabled = isEn;
                    if (isNull) { ((ComboBox)c).SelectedIndex = -1; }
                }
                if (c is DatePicker)
                {
                    c.IsEnabled = isEn;
                    if (isNull) { ((DatePicker)c).SelectedDate = null; }
                }
            }
        }

        /// <summary>
        /// 设置控件
        /// </summary>
        /// <param name="isEn">是否启用编辑</param>
        /// <param name="isNull">是否为空</param>
        public static void SetControl_Button(Grid grd, bool isEn, bool isNull)
        {
            foreach (UIElement c in grd.Children)
            {
                if (c is Button)
                {
                    c.IsEnabled = isEn;
                    if (isNull)
                    { ((TextBox)c).Text = ""; }
                }
            }
        }

        public static bool CheckIsNull_TextBoxInGrid(Grid grd)
        {
            var tem = true;
            foreach (UIElement c in grd.Children)
                if (c is TextBox)
                    if (((TextBox)c).Text.IsNullOrEmpty())
                        tem = false;
            return tem;
        }
    }
}
