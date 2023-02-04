using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;

namespace MyGameFrameWork
{
    public static class AttrSystemModel
    {
        public static int list_init_length = 16;//默认列表初始长度为16
        public static int table_init_length = 4;//表的默认数量
        public static int attr_model_str_length = 16;//默认模型输出长长度
    }

    public interface IAttr
    {

    }

    public class Attr2<T1, T2> : IAttr
    {
        public T1 a;
        public T2 b;

        public Attr2(T1 a, T2 b)
        {
            this.a = a;
            this.b = b;
        }

        public override string ToString()
        {
            return a + " " + b;
        }
    }
    public class Attr3<T1, T2, T3> : IAttr
    {
        public T1 a;
        public T2 b;
        public T3 c;

        public Attr3(T1 a, T2 b, T3 c)
        {
            this.a = a;
            this.b = b;
            this.c = c;
        }

        public override string ToString()
        {
            return a + " " + b + " " + c;
        }
    }
    public class Attr4<T1, T2, T3, T4> : IAttr
    {
        public T1 a;
        public T2 b;
        public T3 c;
        public T4 d;

        public Attr4(T1 a, T2 b, T3 c, T4 d)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
        }

        public override string ToString()
        {
            return a + " " + b + " " + c + " " + d;
        }
    }
    public class Attr5<T1, T2, T3, T4, T5> : IAttr
    {
        public T1 a;
        public T2 b;
        public T3 c;
        public T4 d;
        public T5 e;

        public Attr5(T1 a, T2 b, T3 c, T4 d, T5 e)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.e = e;
        }

        public override string ToString()
        {
            return a + " " + b + " " + c + " " + d + " " + e;
        }
    }
    public class Attr6<T1, T2, T3, T4, T5, T6> : IAttr
    {
        public T1 a;
        public T2 b;
        public T3 c;
        public T4 d;
        public T5 e;
        public T6 f;

        public Attr6(T1 a, T2 b, T3 c, T4 d, T5 e, T6 f)
        {
            this.a = a;
            this.b = b;
            this.c = c;
            this.d = d;
            this.e = e;
            this.f = f;
        }

        public override string ToString()
        {
            return a + " " + b + " " + c + " " + d + " " + e + " " + f;
        }
    }

    public class AttrList : IAttr
    {
        public List<string> Attrs;

        public AttrList()
        {
            this.Attrs = new List<string>();
        }

        public override string ToString()
        {
            string temp = "";
            for(int i=0;i< Attrs.Count;i++)
            {
                temp += Attrs[i] + " ";
            }
            return temp;
        }
    }

    /// <summary>
    /// 双值
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    public class AttrModel2<T1, T2>
    {
        public List<T1> list1;
        public List<T2> list2;
        public string tablename;
        Dictionary<T1, int> main_id_index_dic;//主键索引
        StringBuilder sb = new StringBuilder(AttrSystemModel.attr_model_str_length);//字符串输出

        public AttrModel2(string name)
        {
            tablename = name;
            list1 = new List<T1>(AttrSystemModel.list_init_length);
            list2 = new List<T2>(AttrSystemModel.list_init_length);
            main_id_index_dic = new Dictionary<T1, int>(AttrSystemModel.list_init_length);
        }
        /// <summary>
        /// 查找第一个值所对的
        /// </summary>
        /// <param name="main_id"></param>
        /// <returns></returns>
        public Attr2<T1, T2> FindMain(T1 main_id)
        {
            if (main_id_index_dic.ContainsKey(main_id))
            {
                return new Attr2<T1, T2>(list1[main_id_index_dic[main_id]], list2[main_id_index_dic[main_id]]);
            }
            return null;
        }
        /// <summary>
        /// 添加值
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        public void Add(T1 a, T2 b)
        {
            if (!main_id_index_dic.ContainsKey(a))
            {
                main_id_index_dic.Add(a, list1.Count);
                list1.Add(a);
                list2.Add(b);

                sb.Append(a.ToString());
                sb.Append("\t\t");
                sb.Append(b.ToString());
                sb.Append("\n");
            }
            else
            {
                Debug.Log(a + "主键重复");
            }
        }

        /// <summary>
        /// 获取列数
        /// </summary>
        /// <returns></returns>
        public int GetColNum()
        {
            return list1.Count;
        }

        public override string ToString()
        {
            return sb.ToString();
        }
    }
    /// <summary>
    /// 三值
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    public class AttrModel3<T1, T2, T3>
    {
        public List<T1> list1;
        public List<T2> list2;
        public List<T3> list3;
        public string table_name;
        Dictionary<T1, int> main_id_index_dic;//主键索引
        StringBuilder sb = new StringBuilder(AttrSystemModel.attr_model_str_length);//字符串输出

        public AttrModel3(string name)
        {
            table_name = name;
            list1 = new List<T1>(AttrSystemModel.list_init_length);
            list2 = new List<T2>(AttrSystemModel.list_init_length);
            list3 = new List<T3>(AttrSystemModel.list_init_length);
            main_id_index_dic = new Dictionary<T1, int>(AttrSystemModel.list_init_length);
        }
        /// <summary>
        /// 查找第一个值所对的
        /// </summary>
        /// <param name="main_id"></param>
        /// <returns></returns>
        public Attr3<T1, T2, T3> FindMain(T1 main_id)
        {
            if (main_id_index_dic.ContainsKey(main_id))
            {
                return new Attr3<T1, T2, T3>(list1[main_id_index_dic[main_id]], list2[main_id_index_dic[main_id]], list3[main_id_index_dic[main_id]]);
            }
            return null;
        }
        /// <summary>
        /// 添加值
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        public void Add(T1 a, T2 b, T3 c)
        {
            if (!main_id_index_dic.ContainsKey(a))
            {
                main_id_index_dic.Add(a, list1.Count);
                list1.Add(a);
                list2.Add(b);
                list3.Add(c);
                sb.Append(a.ToString());
                sb.Append("\t\t");
                sb.Append(b.ToString());
                sb.Append("\t\t");
                sb.Append(c.ToString());
                sb.Append("\n");
            }
            else
            {
                Debug.Log(a + "主键重复");
            }
        }
        /// <summary>
        /// 获取列数
        /// </summary>
        /// <returns></returns>
        public int GetColNum()
        {
            return list1.Count;
        }

        public override string ToString()
        {
            return sb.ToString();
        }
    }
    /// <summary>
    /// 四值
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    public class AttrModel4<T1, T2, T3, T4>
    {
        public List<T1> list1;
        public List<T2> list2;
        public List<T3> list3;
        public List<T4> list4;
        public string table_name;
        Dictionary<T1, int> main_id_index_dic;//主键索引
        StringBuilder sb = new StringBuilder(AttrSystemModel.attr_model_str_length);//字符串输出

        public AttrModel4(string name)
        {
            table_name = name;
            list1 = new List<T1>(AttrSystemModel.list_init_length);
            list2 = new List<T2>(AttrSystemModel.list_init_length);
            list3 = new List<T3>(AttrSystemModel.list_init_length);
            list4 = new List<T4>(AttrSystemModel.list_init_length);
            main_id_index_dic = new Dictionary<T1, int>(AttrSystemModel.list_init_length);
        }
        /// <summary>
        /// 查找第一个值所对的
        /// </summary>
        /// <param name="main_id"></param>
        /// <returns></returns>
        public Attr4<T1, T2, T3, T4> FindMain(T1 main_id)
        {
            if (main_id_index_dic.ContainsKey(main_id))
            {
                return new Attr4<T1, T2, T3, T4>(list1[main_id_index_dic[main_id]], list2[main_id_index_dic[main_id]], list3[main_id_index_dic[main_id]],
                    list4[main_id_index_dic[main_id]]);
            }
            return null;
        }
        /// <summary>
        /// 添加值
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        public void Add(T1 a, T2 b, T3 c, T4 d)
        {
            if (!main_id_index_dic.ContainsKey(a))
            {
                main_id_index_dic.Add(a, list1.Count);
                list1.Add(a);
                list2.Add(b);
                list3.Add(c);
                list4.Add(d);

                sb.Append(a.ToString());
                sb.Append("\t\t");
                sb.Append(b.ToString());
                sb.Append("\t\t");
                sb.Append(c.ToString());
                sb.Append("\t\t");
                sb.Append(d.ToString());
                sb.Append("\n");
            }
            else
            {
                Debug.Log(a + "主键重复");
            }
        }
        /// <summary>
        /// 获取列数
        /// </summary>
        /// <returns></returns>
        public int GetColNum()
        {
            return list1.Count;
        }

        public override string ToString()
        {
            return sb.ToString();
        }
    }
    /// <summary>
    /// 五值
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    public class AttrModel5<T1, T2, T3, T4, T5>
    {
        public List<T1> list1;
        public List<T2> list2;
        public List<T3> list3;
        public List<T4> list4;
        public List<T5> list5;
        public string table_name;
        Dictionary<T1, int> main_id_index_dic;//主键索引
        StringBuilder sb = new StringBuilder(AttrSystemModel.attr_model_str_length);//字符串输出

        public AttrModel5(string name)
        {
            table_name = name;
            list1 = new List<T1>(AttrSystemModel.list_init_length);
            list2 = new List<T2>(AttrSystemModel.list_init_length);
            list3 = new List<T3>(AttrSystemModel.list_init_length);
            list4 = new List<T4>(AttrSystemModel.list_init_length);
            list5 = new List<T5>(AttrSystemModel.list_init_length);
            main_id_index_dic = new Dictionary<T1, int>(AttrSystemModel.list_init_length);
        }
        /// <summary>
        /// 查找第一个值所对的
        /// </summary>
        /// <param name="main_id"></param>
        /// <returns></returns>
        public Attr5<T1, T2, T3, T4, T5> FindMain(T1 main_id)
        {
            if (main_id_index_dic.ContainsKey(main_id))
            {
                return new Attr5<T1, T2, T3, T4, T5>(list1[main_id_index_dic[main_id]], list2[main_id_index_dic[main_id]], list3[main_id_index_dic[main_id]],
                    list4[main_id_index_dic[main_id]], list5[main_id_index_dic[main_id]]);
            }
            return null;
        }
        /// <summary>
        /// 添加值
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        public void Add(T1 a, T2 b, T3 c, T4 d, T5 e)
        {
            if (!main_id_index_dic.ContainsKey(a))
            {
                main_id_index_dic.Add(a, list1.Count);
                list1.Add(a);
                list2.Add(b);
                list3.Add(c);
                list4.Add(d);
                list5.Add(e);

                sb.Append(a.ToString());
                sb.Append("\t\t");
                sb.Append(b.ToString());
                sb.Append("\t\t");
                sb.Append(c.ToString());
                sb.Append("\t\t");
                sb.Append(d.ToString());
                sb.Append("\t\t");
                sb.Append(e.ToString());
                sb.Append("\n");
            }
            else
            {
                Debug.Log(a + "主键重复");
            }
        }

        /// <summary>
        /// 获取列数
        /// </summary>
        /// <returns></returns>
        public int GetColNum()
        {
            return list1.Count;
        }
        public override string ToString()
        {
            return sb.ToString();
        }
    }
    /// <summary>
    /// 六值
    /// </summary>
    /// <typeparam name="T1"></typeparam>
    /// <typeparam name="T2"></typeparam>
    /// <typeparam name="T3"></typeparam>
    /// <typeparam name="T4"></typeparam>
    /// <typeparam name="T5"></typeparam>
    /// <typeparam name="T6"></typeparam>
    public class AttrModel6<T1, T2, T3, T4, T5, T6>
    {
        public List<T1> list1;
        public List<T2> list2;
        public List<T3> list3;
        public List<T4> list4;
        public List<T5> list5;
        public List<T6> list6;
        public string table_name;
        Dictionary<T1, int> main_id_index_dic;//主键索引
        StringBuilder sb = new StringBuilder(AttrSystemModel.attr_model_str_length);//字符串输出

        public AttrModel6(string name)
        {
            table_name = name;
            list1 = new List<T1>(AttrSystemModel.list_init_length);
            list2 = new List<T2>(AttrSystemModel.list_init_length);
            list3 = new List<T3>(AttrSystemModel.list_init_length);
            list4 = new List<T4>(AttrSystemModel.list_init_length);
            list5 = new List<T5>(AttrSystemModel.list_init_length);
            list6 = new List<T6>(AttrSystemModel.list_init_length);
            main_id_index_dic = new Dictionary<T1, int>(AttrSystemModel.list_init_length);
        }
        /// <summary>
        /// 查找第一个值所对的
        /// </summary>
        /// <param name="main_id"></param>
        /// <returns></returns>
        public Attr6<T1, T2, T3, T4, T5, T6> FindMain(T1 main_id)
        {
            if (main_id_index_dic.ContainsKey(main_id))
            {
                return new Attr6<T1, T2, T3, T4, T5, T6>(list1[main_id_index_dic[main_id]], list2[main_id_index_dic[main_id]], list3[main_id_index_dic[main_id]],
                    list4[main_id_index_dic[main_id]], list5[main_id_index_dic[main_id]], list6[main_id_index_dic[main_id]]);
            }
            return null;
        }
        /// <summary>
        /// 添加值
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <param name="d"></param>
        /// <param name="e"></param>
        /// <param name="f"></param>
        public void Add(T1 a, T2 b, T3 c, T4 d, T5 e, T6 f)
        {
            if (!main_id_index_dic.ContainsKey(a))
            {
                main_id_index_dic.Add(a, list1.Count);
                list1.Add(a);
                list2.Add(b);
                list3.Add(c);
                list4.Add(d);
                list5.Add(e);
                list6.Add(f);

                sb.Append(a.ToString());
                sb.Append("\t\t");
                sb.Append(b.ToString());
                sb.Append("\t\t");
                sb.Append(c.ToString());
                sb.Append("\t\t");
                sb.Append(d.ToString());
                sb.Append("\t\t");
                sb.Append(e.ToString());
                sb.Append("\t\t");
                sb.Append(f.ToString());
                sb.Append("\n");
            }
            else
            {
                Debug.Log(a + "主键重复");
            }
        }
            /// <summary>
            /// 获取列数
            /// </summary>
            /// <returns></returns>
        public int GetColNum()
        {
            return list1.Count;
        }
        public override string ToString()
        {
            return sb.ToString();
        }
    }

    public class AttrModelList
    {
        public List<List<string>> AttrModels;
        public string table_name;
        Dictionary<string, int> main_id_index_dic;//主键索引
        StringBuilder sb = new StringBuilder(AttrSystemModel.attr_model_str_length);//字符串输出

        public AttrModelList(string name,int listNum)
        {
            AttrModels = new List<List<string>>();
            table_name = name;
            for(int i=0;i< listNum;i++)
            {
               var temp = new List<string>(AttrSystemModel.list_init_length);
                AttrModels.Add(temp);
            }
            main_id_index_dic = new Dictionary<string, int>(AttrSystemModel.list_init_length);
        }
        /// <summary>
        /// 查找第一个值所对的
        /// </summary>
        /// <param name="main_id"></param>
        /// <returns></returns>
        public AttrList FindMain(string main_id)
        {
            if (main_id_index_dic.ContainsKey(main_id))
            {
                var temp = new AttrList();
                for(int i=0;i< AttrModels.Count;i++)
                {
                    temp.Attrs.Add(AttrModels[i][main_id_index_dic[main_id]]);
                }
                return temp;
            }
            return null;
        }
        public void Add(List<string> list)
        {
            if (list.Count==0)
            {
                return;
            }
            if (list[0] != ""&&!main_id_index_dic.ContainsKey(list[0]))
            {
                

                main_id_index_dic.Add(list[0], AttrModels[0].Count);
                for(int i=0;i< list.Count;i++)
                {
                    AttrModels[i].Add(list[i]);
                }
                for (int j = 0; j < list.Count; j++)
                {
                    sb.Append(list[j]);
                    sb.Append("\t\t");
                }
                sb.Append("\n");
            }
            else if(list[0]!="")
            {
                Debug.Log(list[0] + "主键重复");
            }
        }
        /// <summary>
        /// 获取列数
        /// </summary>
        /// <returns></returns>
        public int GetColNum()
        {
            return AttrModels.Count;
        }
        public override string ToString()
        {
            return sb.ToString();
        }
    }
}


