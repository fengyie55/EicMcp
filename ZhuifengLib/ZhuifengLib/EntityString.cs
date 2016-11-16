using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;

namespace ZhuifengLib
{
    /// <summary>
    /// 实体类、字符串互相转换
    /// </summary>
    public class EntityString<T>
    {
        /// <summary>
        /// 将实体类通过反射组装成字符串
        /// </summary>
        /// <param name="t">实体类</param>
        /// <returns>组装的字符串</returns>
        public static string GetEntityToString(T t)
        {
            System.Text.StringBuilder sb = new StringBuilder();
            Type type = t.GetType();
            System.Reflection.PropertyInfo[] propertyInfos = type.GetProperties();
            for (int i = 0; i < propertyInfos.Length; i++)
            {
                sb.Append(propertyInfos[i].Name + ":" + propertyInfos[i].GetValue(t, null) + ",");
            }
            return sb.ToString().TrimEnd(new char[] { ',' });
        }
        /// <summary>
        /// 将反射得到字符串转换为对象
        /// </summary>
        /// <param name="str">反射得到的字符串</param>
        /// <returns>实体类</returns>
        public static T GetEntityStringToEntity(string str)
        {
            string[] array = str.Split(',');
            string[] temp = null;
            Dictionary<string, string> dictionary = new Dictionary<string, string>();
            foreach (string s in array)
            {
                temp = s.Split(':');
                dictionary.Add(temp[0], temp[1]);
            }
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetAssembly(typeof(T));
            T entry = (T)assembly.CreateInstance(typeof(T).FullName);
            System.Text.StringBuilder sb = new StringBuilder();
            Type type = entry.GetType();
            System.Reflection.PropertyInfo[] propertyInfos = type.GetProperties();
            for (int i = 0; i < propertyInfos.Length; i++)
            {
                foreach (string key in dictionary.Keys)
                {
                    if (propertyInfos[i].Name == key.ToString())
                    {
                        propertyInfos[i].SetValue(entry, GetObject(propertyInfos[i], dictionary[key]), null);
                        break;
                    }
                }
            }
            return entry;
        }
        /// <summary>
        /// 转换值的类型
        /// </summary>
        /// <param name="p"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        static object GetObject(System.Reflection.PropertyInfo p, string value)
        {
            switch (p.PropertyType.Name.ToString().ToLower())
            {
                case "int16":
                    return Convert.ToInt16(value);
                case "int32":
                    return Convert.ToInt32(value);
                case "int64":
                    return Convert.ToInt64(value);
                case "string":
                    return Convert.ToString(value);
                case "datetime":
                    return Convert.ToDateTime(value);
                case "boolean":
                    return Convert.ToBoolean(value);
                case "char":
                    return Convert.ToChar(value);
                case "double":
                    return Convert.ToDouble(value);
                default:
                    return value;
            }
        }

        static JavaScriptSerializer js = new JavaScriptSerializer();

        /// <summary>
        /// 列表转换为Json格式的字符串
        /// </summary>
        /// <param name="t"></param>
        /// <returns></returns>
        public static string GetEntityToStringJson(List<T> t)
        {
            try
            {
                return js.Serialize(t);
            }
            catch { return null; }
        }


        /// <summary>
        /// 依据输入的JSon类型的字符串 转换为实体列表
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        public static List<T> GetEntityStringToEntityJson(string str)
        {
            try
            {
                return str != null ? js.Deserialize<List<T>>(str) : null;
            }
            catch
            {
                return null;
            }
        }
    }
}
