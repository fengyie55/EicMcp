using System.Collections.Generic;

namespace ZhuifengLib
{
   public class JudgeOddOrEven
    {

        /// <summary>
        /// 根据输入的值 返回数组 此数组包括奇偶两个值
        /// </summary>
        public List<long> Get_TwoList(string value)
        {
            var temList = new List<long>(); //初始化数组
            long _Value = 0;                       //初始化long长度的第一个值
            long.TryParse(value,out _Value);
            temList.Add(_Value);
            //判断奇偶并赋值到数组
            if (_Value % 2 == 0)
            {
                temList.Add((_Value - 1));
            }
            else
            {
                temList.Add((_Value + 1));
            }

            return temList;
        }

        /// <summary>
        /// 判断是否为奇数
        /// </summary>
        public bool IsOdd(string value)
        {           
            long _Value = 0;                       //初始化long长度的第一个值
            long.TryParse(value, out _Value);
            //判断奇偶并赋值到数组
            if (_Value % 2 == 0)
            {
                return false;
            }
            return true;
        }

        public string Get_Odd_OR_Even(string value)
        {
            var temList = new List<long>(); //初始化数组
            long _Value = 0;                       //初始化long长度的第一个值
            long.TryParse(value, out _Value);
            //判断奇偶并赋值到数组
            if (_Value % 2 == 0)
            {
                return (_Value - 1).ToString();
            }
            return (_Value + 1).ToString();
        }

    }
}
