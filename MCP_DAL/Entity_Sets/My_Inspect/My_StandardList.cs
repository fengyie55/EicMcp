using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace Maticsoft.DAL 
{
    public  class My_StandardList   
    {
        //----------------------------------------------------------------------------------------------------------
        //    *  本方法生成Pigtail检测的标准数组 此数组可作为查询条件供查询语句组合使用
        //    * 
        //    *  使用此标准数组的 条码类型 必须为 Demo：2130000001-1 
        //    *  标准数组与 Demo中的 01 编号进行比较
        //    * 
        //    *  如果与多芯配组的条码类型进行比较 需要测试数据对自身进行处理 Demo:2130100001-01-1
        //    *  提取 最后面的 Pigtail编号
        //    * 
        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 返回检测Pigtail标准数组——Pigtail
        /// </summary>
        /// <returns></returns>
        public ArrayList Pigtail_Standard_pigtailNum(Maticsoft.Model.E_InspectMethod _inspectMethod)   //返回包装线号 标准数组
        {         
           //配组线材类型 检测 1-8 
            if (_inspectMethod == Maticsoft.Model.E_InspectMethod.配组_二十四芯 ||
                _inspectMethod == Maticsoft.Model.E_InspectMethod.配组_四十八芯 ||
                _inspectMethod == Maticsoft.Model.E_InspectMethod.配组_九十六芯 ||
                _inspectMethod == Maticsoft.Model.E_InspectMethod.八芯检测
                )
            {
                return PigtailList(8);
            }
            //其它类型需要个性定制接头标准数组
            else
            {
                switch (_inspectMethod)
                {
                    case Maticsoft.Model.E_InspectMethod.双并检测:
                        {
                            ArrayList Tem = new ArrayList();//初始化数组
                            Tem.Add("A1");
                            Tem.Add("A2");
                            Tem.Add("B1");
                            Tem.Add("B2");
                            return Tem;
                        }
                    //此类型为 24个接头 处理方式应该与 配组的处理方式相同 
                    //此线材类型的条码存出来的最终条码 接头Ａ Demo:2013000001-01-1 　接头B Demo:2013000001-02-1 
                    case Maticsoft.Model.E_InspectMethod.TFK十二芯检测x2:
                        {
                            ArrayList Tem = new ArrayList();//初始化数组
                            //01端                            
                            Tem.Add("01-1");
                            Tem.Add("01-2");
                            Tem.Add("01-3");
                            Tem.Add("01-4");
                            Tem.Add("01-5");
                            Tem.Add("01-6");
                            Tem.Add("01-7");
                            Tem.Add("01-8");
                            Tem.Add("01-9");
                            Tem.Add("01-10");
                            Tem.Add("01-11");
                            Tem.Add("01-12");
                            //02端
                            Tem.Add("02-1");
                            Tem.Add("02-2");
                            Tem.Add("02-3");
                            Tem.Add("02-4");
                            Tem.Add("02-5");
                            Tem.Add("02-6");
                            Tem.Add("02-7");
                            Tem.Add("02-8");
                            Tem.Add("02-9");
                            Tem.Add("02-10");
                            Tem.Add("02-11");
                            Tem.Add("02-12");
                            return Tem;
                        }
                    //此类型为 24个接头 处理方式应该与 配组的处理方式相同 
                    //此线材类型的条码存出来的最终条码 接头Ａ Demo:2013000001-01-1 　接头B Demo:2013000001-02-1 
                    case Maticsoft.Model.E_InspectMethod.TFK二十四芯检测x2:
                        {
                            ArrayList Tem = new ArrayList();//初始化数组
                            //01端                            
                            Tem.Add("01-1");
                            Tem.Add("01-2");
                            Tem.Add("01-3");
                            Tem.Add("01-4");
                            Tem.Add("01-5");
                            Tem.Add("01-6");
                            Tem.Add("01-7");
                            Tem.Add("01-8");
                            Tem.Add("01-9");
                            Tem.Add("01-10");
                            Tem.Add("01-11");
                            Tem.Add("01-12");
                            Tem.Add("01-13");
                            Tem.Add("01-14");
                            Tem.Add("01-15");
                            Tem.Add("01-16");
                            Tem.Add("01-17");
                            Tem.Add("01-18");
                            Tem.Add("01-19");
                            Tem.Add("01-20");
                            Tem.Add("01-21");
                            Tem.Add("01-22");
                            Tem.Add("01-23");
                            Tem.Add("01-24");
                            //02端
                            Tem.Add("02-1");
                            Tem.Add("02-2");
                            Tem.Add("02-3");
                            Tem.Add("02-4");
                            Tem.Add("02-5");
                            Tem.Add("02-6");
                            Tem.Add("02-7");
                            Tem.Add("02-8");
                            Tem.Add("02-9");
                            Tem.Add("02-10");
                            Tem.Add("02-11");
                            Tem.Add("02-12");
                            Tem.Add("02-13");
                            Tem.Add("02-14");
                            Tem.Add("02-15");
                            Tem.Add("02-16");
                            Tem.Add("02-17");
                            Tem.Add("02-18");
                            Tem.Add("02-19");
                            Tem.Add("02-20");
                            Tem.Add("02-21");
                            Tem.Add("02-22");
                            Tem.Add("02-23");
                            Tem.Add("02-24");
                            return Tem;
                        }

                    case Model.E_InspectMethod.TFK一芯检测x2:       { return PigtailList(2); }
                    case Maticsoft.Model.E_InspectMethod.FFOS_四芯: { return PigtailList(5); }
                    case Maticsoft.Model.E_InspectMethod.FFOS_八芯: { return PigtailList(9); }
                    case Maticsoft.Model.E_InspectMethod.FFOS_二十四芯: { return PigtailList(25); }
                    case Maticsoft.Model.E_InspectMethod.FFOS_十六芯: { return PigtailList(17); }
                    case Maticsoft.Model.E_InspectMethod.FFOS_三十二芯: { return PigtailList(33); }
                    case Maticsoft.Model.E_InspectMethod.FFOS32_三十二芯双头: { return PigtailList(34); }
                    case Maticsoft.Model.E_InspectMethod.四芯检测: { return PigtailList(4); }
                    case Maticsoft.Model.E_InspectMethod.八芯检测: { return PigtailList(8); }
                    case Maticsoft.Model.E_InspectMethod.一码一签_跳线: { return PigtailList(2); }
                    case Maticsoft.Model.E_InspectMethod.二十四芯检测: { return PigtailList(24); }
                    case Maticsoft.Model.E_InspectMethod.四十八芯检测: { return PigtailList(48); } 
                    case Maticsoft.Model.E_InspectMethod.MPO检测: { return PigtailList(4); }
                    case Maticsoft.Model.E_InspectMethod.十二芯检测: { return PigtailList(12); }                   
                    case Maticsoft.Model.E_InspectMethod.一码一签: { return PigtailList(1); }
                    case Maticsoft.Model.E_InspectMethod.配组_八芯_SAMHALL: { return PigtailList(1); }
                    case Maticsoft.Model.E_InspectMethod.配组_二十四芯_SAMHALL: { return PigtailList(1); }
                    case Maticsoft.Model.E_InspectMethod.配组_四十八芯_SAMHALL: { return PigtailList(1); }
                    case Model.E_InspectMethod.配组_九十六芯_SAMHALL: { return PigtailList(1); }
                    default:
                        return null;
                }
            }
        }




        //----------------------------------------------------------------------------------------------------------
        //  名称：返回ClientSN 标准比对数组
        //----------------------------------------------------------------------------------------------------------
        /// <summary>
        /// 返回ClientSN的线材编号标准数组
        /// </summary>
        /// <param name="_inspectMethod">线材类型</param>
        /// <returns></returns>
        public ArrayList Client_Standard_ClientNum(Maticsoft.Model.E_InspectMethod _inspectMethod)
        {
            ArrayList _temList = new ArrayList();
            _temList.Clear();
            switch (_inspectMethod)
            {
                case Maticsoft.Model.E_InspectMethod.配组_二十四芯:
                    {
                        _temList.Add("01");
                        _temList.Add("02");
                        _temList.Add("03");
                        return _temList;     //01、02、03         
                    }
                case Maticsoft.Model.E_InspectMethod.配组_四十八芯:
                    {
                        _temList.Add("01");
                        _temList.Add("02");
                        _temList.Add("03");
                        _temList.Add("04");
                        _temList.Add("05");
                        _temList.Add("06");
                        return _temList;     //01、02、03、04、05、06
                    }
                case Maticsoft.Model.E_InspectMethod.配组_九十六芯:
                    {
                        _temList.Add("01");
                        _temList.Add("02");
                        _temList.Add("03");
                        _temList.Add("04");
                        _temList.Add("05");
                        _temList.Add("06");
                        _temList.Add("07");
                        _temList.Add("08");
                        _temList.Add("09");
                        _temList.Add("10");
                        _temList.Add("11");
                        _temList.Add("12");
                        return _temList;    //01、02、03、04、05、06、07、08、09、10、11、12
                    }
                case Maticsoft.Model.E_InspectMethod.配组_八芯_SAMHALL:
                    {
                        _temList.Add("1");
                        _temList.Add("2");
                        _temList.Add("3");
                        _temList.Add("4");
                        _temList.Add("5");
                        _temList.Add("6");
                        _temList.Add("7");
                        _temList.Add("8");                     
                        return _temList;    //1、2、3、4、5、6、7、8
                    }
                case Maticsoft.Model.E_InspectMethod.配组_九十六芯_SAMHALL:
                    {
                        for (int i = 1; i <= 96; i++)
                        {
                            _temList.Add(i.ToString());
                        }
                        return _temList;   //1、2、3、4、5、6、7、8 ..... 46、47、48
                    }
                case Model.E_InspectMethod.配组_四十八芯_SAMHALL:
                    {
                        for (int i = 1; i <= 48; i++)
                        {
                            _temList.Add(i.ToString());
                        }
                        return _temList;   //1、2、3、4、5、6、7、8 ..... 46、47、48
                    }
                case Model.E_InspectMethod.配组_二十四芯_SAMHALL:
                    {
                        for (int i = 1; i <= 24; i++)
                        {
                            _temList.Add(i.ToString());
                        }
                        return _temList;   //1、2、3、4、5、6、7、8 ..... 46、47、48
                    }
                default:
                    return null;            //未知检测类型请添加
            }
        }

        /// <summary>
        /// 生成序列数组
        /// </summary>
        /// <param name="PigtailCount">Pigtail数量</param>
        /// <returns></returns>
        private ArrayList PigtailList(int PigtailCount)
        {
            ArrayList Tem = new ArrayList();//初始化数组
            for (int i = 1; i <= PigtailCount; i++)
            {
                Tem.Add(i.ToString());
            }
            return Tem;
        }
    }
}
