using System;
using System.Data;
using System.IO;
using System.Text;
using System.Xml;

namespace ZhuifengLib.XML
{

    public class XmlControl
    {
      
        protected string StrXmlFile;
        protected XmlDocument ObjXmlDoc = new XmlDocument();

        /// <summary>
        /// ///实例应用：
        /// string strXmlFile = Server.MapPath("TestXml.xml");
        /// XmlControl xmlTool = new XmlControl(strXmlFile);
        /// </summary>
        /// <param name="xmlFile"></param>
        public XmlControl(string xmlFile)
        {
            //
            // TODO: 在这里加入建构函式的程序代码
            //
            try
            {
                ObjXmlDoc.Load(xmlFile);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            StrXmlFile = xmlFile;
        }

        /// <summary>
        /// /// 数据显视
        /// dgList.DataSource = xmlTool.GetData("Book/Authors[ISBN=\"0002\"]");
        /// dgList.DataBind();
        /// </summary>
        /// <param name="xmlPathNode"></param>
        /// <returns></returns>
        public DataView GetData(string xmlPathNode)
        {
            //查找数据。返回一个DataView
            var ds = new DataSet();
            var read = new StringReader(ObjXmlDoc.SelectSingleNode(xmlPathNode).OuterXml);
            ds.ReadXml(read);
            return ds.Tables[0].DefaultView;
        }

        /// <summary>
        /// /// 更新元素内容
        /// xmlTool.Replace("Book/Authors[ISBN=\"0002\"]/Content","ppppppp");
        /// xmlTool.Save();
        /// </summary>
        /// <param name="xmlPathNode"></param>
        /// <param name="content"></param>
        public void Replace(string xmlPathNode, string content)
        {
            //更新节点内容。
            ObjXmlDoc.SelectSingleNode(xmlPathNode).InnerText = content;
        }

        /// <summary>
        /// /// 删除一个指定节点的所有内容和属性
        /// xmlTool.Delete("Book/Author[ISBN=\"0004\"]");
        /// xmlTool.Save();
        /// </summary>
        /// <param name="node"></param>
        public void Delete(string node)
        {
            //删除一个节点。
            var mainNode = node.Substring(0, node.LastIndexOf("/"));
            ObjXmlDoc.SelectSingleNode(mainNode).RemoveChild(ObjXmlDoc.SelectSingleNode(node));
        }

        /// <summary>
        /// /// 添加一个新节点
        /// xmlTool.InsertNode("Book","Author","ISBN","0004");
        /// xmlTool.InsertElement("Book/Author[ISBN=\"0004\"]","Content","aaaaaaaaa");
        /// xmlTool.InsertElement("Book/Author[ISBN=\"0004\"]","Title","Sex","man","iiiiiiii");
        /// xmlTool.Save();
        /// </summary>
        /// <param name="mainNode"></param>
        /// <param name="childNode"></param>
        /// <param name="element"></param>
        /// <param name="content"></param>
        public void InsertNode(string mainNode, string childNode, string element, string content)
        {
            //插入一节点和此节点的一子节点。
            var objRootNode = ObjXmlDoc.SelectSingleNode(mainNode);
            var objChildNode = ObjXmlDoc.CreateElement(childNode);
            objRootNode.AppendChild(objChildNode);
            var objElement = ObjXmlDoc.CreateElement(element);
            objElement.InnerText = content;
            objChildNode.AppendChild(objElement);
        }

        public void InsertElement(string mainNode, string element, string attrib, string attribContent, string content)
        {
            //插入一个节点，带一属性。
            var objNode = ObjXmlDoc.SelectSingleNode(mainNode);
            var objElement = ObjXmlDoc.CreateElement(element);
            objElement.SetAttribute(attrib, attribContent);
            objElement.InnerText = content;
            objNode.AppendChild(objElement);
        }

        public void InsertElement(string mainNode, string element, string content)
        {
            //插入一个节点，不带属性。
            var objNode = ObjXmlDoc.SelectSingleNode(mainNode);
            var objElement = ObjXmlDoc.CreateElement(element);
            objElement.InnerText = content;
            objNode.AppendChild(objElement);
        }

        public void Save()
        {
            //保存文檔。
            try
            {
                ObjXmlDoc.Save(StrXmlFile);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            ObjXmlDoc = null;
        }


        //将xml对象内容字符串转换为DataSet
        public  DataSet ConvertXmlToDataSet(string xmlData)
        {
            StringReader stream = null;
            XmlTextReader reader = null;
            try
            {
                var xmlDs = new DataSet();
                stream = new StringReader(xmlData);
                //从stream装载到XmlTextReader
                reader = new XmlTextReader(stream);
                xmlDs.ReadXml(reader);
                return xmlDs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        //将xml文件转换为DataSet
        public  DataSet ConvertXmlFileToDataSet(string xmlFile)
        {
            StringReader stream = null;
            XmlTextReader reader = null;
            try
            {
                var xmld = new XmlDocument();
                xmld.Load(xmlFile);

                var xmlDs = new DataSet();
                stream = new StringReader(xmld.InnerXml);
                //从stream装载到XmlTextReader
                reader = new XmlTextReader(stream);
                xmlDs.ReadXml(reader);
                //xmlDS.ReadXml(xmlFile);
                return xmlDs;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (reader != null)
                    reader.Close();
            }
        }

        //将DataSet转换为xml对象字符串
        public  string ConvertDataSetToXml(DataSet xmlDs)
        {
            MemoryStream stream = null;
            XmlTextWriter writer = null;

            try
            {
                stream = new MemoryStream();
                //从stream装载到XmlTextReader
                writer = new XmlTextWriter(stream, Encoding.Unicode);

                //用WriteXml方法写入文件.
                xmlDs.WriteXml(writer);
                var count = (int)stream.Length;
                var arr = new byte[count];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(arr, 0, count);

                var utf = new UnicodeEncoding();
                return utf.GetString(arr).Trim();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }

        //将DataSet转换为xml文件
        public  void ConvertDataSetToXmlFile(DataSet xmlDs, string xmlFile)
        {
            MemoryStream stream = null;
            XmlTextWriter writer = null;

            try
            {
                stream = new MemoryStream();
                //从stream装载到XmlTextReader
                writer = new XmlTextWriter(stream, Encoding.Unicode);

                //用WriteXml方法写入文件.
                xmlDs.WriteXml(writer);
                var count = (int)stream.Length;
                var arr = new byte[count];
                stream.Seek(0, SeekOrigin.Begin);
                stream.Read(arr, 0, count);

                //返回Unicode编码的文本
                var utf = new UnicodeEncoding();
                var sw = new StreamWriter(xmlFile);
                sw.WriteLine("<?xml version=\"1.0\" encoding=\"utf-8\"?>");
                sw.WriteLine(utf.GetString(arr).Trim());
                sw.Close();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (writer != null)
                    writer.Close();
            }
        }
    }

    
}
