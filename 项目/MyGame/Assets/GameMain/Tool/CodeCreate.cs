using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text;
using System;
using System.IO;
using System.Text.RegularExpressions;

namespace MyGameFrameWork
{

    public static class CodeCreate
    {
        static Dictionary<string, int> NormalTypeDic = new Dictionary<string, int>()
    {
        {"int",0},
        {"string",1},
        {"char",2},
        {"float",3},
        {"double",4},
        {"bool",5},
    };



        /// <summary>
        /// 用于无关联表生成
        /// </summary>
        /// <param name="arr_type_list">类型</param>
        /// <param name="arr_name_list">属性名称</param>
        /// <param name="temp_lists">值列</param>
        /// <param name="name">文件名称</param>
        /// <returns></returns>
        public static string NoLineGenertion(string[] arr_type_list, string[] arr_name_list, List<string[]> temp_lists, string name)
        {
            if (arr_type_list == null || arr_name_list == null || temp_lists == null)
            {
                return "!可能存在空特殊行";
            }
            if (arr_type_list.Length == 0 || arr_name_list.Length == 0 || temp_lists.Count == 0)
            {
                return "!可能存在空行";
            }
            if (arr_type_list.Length != arr_name_list.Length)
            {
                return "!存在特殊行长度不一致";
            }
            for (int i = 0; i < temp_lists.Count; i++)
            {
                if (temp_lists[i].Length != arr_type_list.Length)
                {
                    return "!存在key: " + temp_lists[i][0] + "特殊行长度与属性长度不一致";
                }
            }
            if (arr_type_list[0] == " " || (arr_type_list[0][0] != '!' && arr_type_list[0][0] != '@') ||
               arr_name_list[0] == " " || (arr_name_list[0][0] != '!' && arr_name_list[0][0] != '@'))
            {
                return "!存在特殊标识符不正确";
            }
            if (arr_name_list[0][0] != arr_type_list[0][0])
            {
                return "!存在特殊标识符不匹配";
            }
            for (int i = 1; i < arr_type_list.Length; i++)
            {
                if (!NormalTypeDic.ContainsKey(arr_type_list[i]))
                {
                    return "!存在类型不准确";
                }
            }
            for (int i = 1; i < arr_name_list.Length; i++)
            {
                if (!isVaileName(arr_name_list[i]))
                {
                    return "!存在命名不准确";
                }
            }

            StringBuilder sb = new StringBuilder(400);

            sb.Append("using System.Collections;\nusing System.Collections.Generic;\n\n");
            sb.Append("//CreateTime：" + DateTime.Now.ToString() + "\n");
            sb.Append("namespace DataCs\n{\n\tpublic static class Data_" + name + "\n\t{\n");

            for (int i = 0; i < temp_lists.Count; i++)
            {
                for (int j = 1; j < temp_lists[i].Length; j++)
                {
                    if (arr_type_list[j] == "string")
                    {
                        sb.Append("\t\tpublic static " + arr_type_list[j]
                        + " " + temp_lists[i][0]
                        + "_" + arr_name_list[j]
                        + " = \"" + temp_lists[i][j]
                        + "\";\n");
                    }
                    else if (arr_type_list[j] == "char")
                    {
                        sb.Append("\t\tpublic static " + arr_type_list[j]
                        + " " + temp_lists[i][0]
                        + "_" + arr_name_list[j]
                        + " = \'" + temp_lists[i][j]
                        + "\';\n");
                    }
                    else
                    {
                        sb.Append("\t\tpublic static " + arr_type_list[j]
                        + " " + temp_lists[i][0]
                        + "_" + arr_name_list[j]
                        + " = " + temp_lists[i][j]
                        + ";\n");
                    }
                }
                sb.Append("\n");
            }
            sb.Append("\t}\n}\n");
            return sb.ToString();
        }

        /// <summary>
        /// 用于无关联表生成
        /// </summary>
        /// <param name="arr_type_list">类型</param>
        /// <param name="arr_name_list">属性名称</param>
        /// <param name="temp_lists">值列</param>
        /// <param name="name">文件名称</param>
        /// <returns></returns>
        public static string LineGenertion(string[] arr_type_list, string[] arr_name_list, List<string[]> temp_lists, string name)
        {
            if (arr_type_list == null || arr_name_list == null || temp_lists == null)
            {
                return "!可能存在空特殊行";
            }
            if (arr_type_list.Length == 0 || arr_name_list.Length == 0 || temp_lists.Count == 0)
            {
                return "!可能存在空特殊行";
            }
            if (arr_type_list.Length != arr_name_list.Length)
            {
                return "!存在特殊行长度不一致";
            }
            for (int i = 0; i < temp_lists.Count; i++)
            {
                if (temp_lists[i].Length != arr_type_list.Length)
                {
                    return "!存在Key:" + temp_lists[i][0] + "特殊行长度与属性长度不一致";
                }
            }

            if (arr_type_list[0] == " " || (arr_type_list[0][0] != '!' && arr_type_list[0][0] != '@') ||
               arr_name_list[0] == " " || (arr_name_list[0][0] != '!' && arr_name_list[0][0] != '@'))
            {
                return "!存在特殊标识符不正确";
            }
            if (arr_name_list[0][0] != arr_type_list[0][0])
            {
                return "!存在特殊标识符不匹配";
            }
            for (int i = 1; i < arr_type_list.Length; i++)
            {
                if (!NormalTypeDic.ContainsKey(arr_type_list[i]))
                {
                    return "!存在类型不准确";
                }
            }
            for (int i = 1; i < arr_name_list.Length; i++)
            {
                if (!isVaileName(arr_name_list[i]))
                {
                    return "!存在" + arr_name_list[i] + "命名不准确";
                }
            }


            StringBuilder sb = new StringBuilder(400);

            sb.Append("using System.Collections;\n");
            sb.Append("using System.Collections.Generic;\n\n");
            sb.Append("//CreateTime：" + DateTime.Now.ToString() + "\n");
            sb.Append("namespace DataCs\n{\n");
            sb.Append("\tpublic struct Data_" + name + "_Struct\n");
            sb.Append("\t{\n");
            sb.Append("\t\tpublic string key;\n");

            for (int i = 1; i < arr_type_list.Length; i++)
            {
                sb.Append("\t\tpublic " + arr_type_list[i] + " " + arr_name_list[i] + ";\n");
            }

            sb.Append("\n");
            sb.Append("\t\tpublic Data_" + name + "_Struct(string _key");


            for (int i = 1; i < arr_type_list.Length; i++)
            {
                sb.Append(", " + arr_type_list[i] + " _" + arr_name_list[i]);
            }
            sb.Append(")\n");
            sb.Append("\t\t{\n");
            sb.Append("\t\t\tkey = _key;\n");

            for (int i = 1; i < arr_name_list.Length; i++)
            {
                sb.Append("\t\t\t" + arr_name_list[i] + " = _" + arr_name_list[i] + ";\n");
            }

            sb.Append("\t\t}\n");
            sb.Append("\t}\n\n");

            sb.Append("\tpublic static class Data_" + name + "\n");
            sb.Append("\t{\n");
            sb.Append("\t\tpublic static Dictionary<string, Data_");
            sb.Append(name);
            sb.Append("_Struct> Dic = new Dictionary<string, Data_" + name + "_Struct>()\n");
            sb.Append("\t\t{\n");

            for (int i = 0; i < temp_lists.Count; i++)
            {
                sb.Append("\t\t\t{\"" + temp_lists[i][0] + "\",new Data_" + name + "_Struct(\"" + temp_lists[i][0] + "\"");
                for (int j = 1; j < temp_lists[i].Length; j++)
                {
                    // Debug.LogError(j);
                    if (arr_type_list[j] == "string")
                    {
                        sb.Append(",\"" + temp_lists[i][j] + "\"");
                    }
                    else if (arr_type_list[j] == "char")
                    {
                        sb.Append(",\'" + temp_lists[i][j] + "\'");
                    }
                    else
                    {
                        sb.Append("," + temp_lists[i][j]);
                    }
                }
                sb.Append(")},\n");
            }

            sb.Append("\t\t};");
            sb.Append("\n");

            for (int i = 0; i < temp_lists.Count; i++)
            {
                sb.Append("\t\tpublic static string key_");
                sb.Append(temp_lists[i][0]);
                sb.Append(" = \"");
                sb.Append(temp_lists[i][0]);
                sb.Append("\";\n");
            }

            sb.Append("\t}\n}\n");
            return sb.ToString();

        }

        /// <summary>
        /// 生成UI界面主代码
        /// </summary>
        /// <param name="button_list"></param>
        /// <param name="class_name"></param>
        /// <returns></returns>
        public static string UIFormGenertion(List<string> button_list, string class_name)
        {
            if (class_name == "")
            {
                return "!类名为空";
            }

            StringBuilder sb = new StringBuilder(400);

            sb.Append("using System.Collections;\n");
            sb.Append("using System.Collections.Generic;\n");
            sb.Append("using UnityEngine;\n");
            sb.Append("using MyGameFrameWork;\n");
            sb.Append("using UnityEngine.UI;\n\n");
            sb.Append("//CreateTime：" + DateTime.Now.ToString() + "\n");

            sb.Append("public partial class ");
            sb.Append(class_name);
            sb.Append(" : UIForm\n");
            sb.Append("{\n");

            sb.Append("\tpublic override void Awake()\n");
            sb.Append("\t{\n");
            sb.Append("\t\tbase.Awake();\n");
            sb.Append("\t\tInitComponent(); \n");
            sb.Append("\t}\n\n");

            sb.Append("\tpublic override void OnOpen(System.Object obj)\n");
            sb.Append("\t{\n");
            sb.Append("\t\tbase.OnOpen(obj);\n");
            sb.Append("\t\tRegisterEvent(); \n");
            sb.Append("\t}\n\n");

            sb.Append("\tpublic override void OnClose()\n");
            sb.Append("\t{\n");
            sb.Append("\t\tbase.OnClose();\n");
            sb.Append("\t\tReleaseEvent(); \n");
            sb.Append("\t}\n\n");


            sb.Append("\tprivate void RegisterEvent()\n");
            sb.Append("\t{\n");
            if (button_list != null && button_list.Count != 0)
            {
                for (int i = 0; i < button_list.Count; i++)
                {
                    sb.Append("\t\t");
                    sb.Append(button_list[i]);
                    sb.Append(".onClick.AddListener(OnBtn");
                    sb.Append(button_list[i].Substring(5));
                    sb.Append(");\n");
                }
            }
            else
            {
                sb.Append("\t\t\n");
            }
            sb.Append("\t}\n\n");

            sb.Append("\tprivate void ReleaseEvent()\n");
            sb.Append("\t{\n");
            if (button_list != null && button_list.Count != 0)
            {
                for (int i = 0; i < button_list.Count; i++)
                {
                    sb.Append("\t\t");
                    sb.Append(button_list[i]);
                    sb.Append(".onClick.RemoveListener(OnBtn");
                    sb.Append(button_list[i].Substring(5));
                    sb.Append(");\n");
                }
            }
            else
            {
                sb.Append("\t\t\n");
            }
            sb.Append("\t}\n\n");

            if (button_list != null && button_list.Count != 0)
            {
                for (int i = 0; i < button_list.Count; i++)
                {
                    sb.Append("\tprivate void OnBtn");
                    sb.Append(button_list[i].Substring(5));
                    sb.Append("()\n");
                    sb.Append("\t{\n");
                    sb.Append("\t\t\n");
                    sb.Append("\t}\n");
                }
            }

            sb.Append("\n}\n");

            return sb.ToString();
        }

        /// <summary>
        /// 生成UI界面绑定代码
        /// </summary>
        /// <param name="name_list"></param>
        /// <param name="type_list"></param>
        /// <param name="class_name"></param>
        /// <returns></returns>
        public static string UIFormBindGenertion(List<string> name_list, List<string> type_list, string class_name)
        {
            if (name_list == null || type_list == null)
            {
                return "!列表为null";
            }
            if (name_list.Count == 0 || type_list.Count == 0)
            {
                return "!列表为空";
            }
            if (class_name == "")
            {
                return "!类名为空";
            }

            StringBuilder sb = new StringBuilder(400);

            sb.Append("using System.Collections;\n");
            sb.Append("using System.Collections.Generic;\n");
            sb.Append("using UnityEngine;\n");
            sb.Append("using MyGameFrameWork;\n");
            sb.Append("using UnityEngine.UI;\n\n");
            sb.Append("//CreateTime：" + DateTime.Now.ToString() + "\n");

            sb.Append("public partial class " + class_name + "\n");
            sb.Append("{\n");
            sb.Append("\tprivate AutoBind autoBind;\n");
            for (int i = 0; i < name_list.Count; i++)
            {
                sb.Append("\tprivate " + type_list[i] + " " + name_list[i] + ";\n");
            }

            sb.Append("\n\tprivate void InitComponent()\n");
            sb.Append("\t{\n");
            sb.Append("\t\tautoBind = GetComponent<AutoBind>();\n");
            for (int i = 0; i < name_list.Count; i++)
            {
                sb.Append("\t\t" + name_list[i] + " = autoBind.itemList[");
                sb.Append(i.ToString());
                sb.Append("].obj.GetComponent<");
                sb.Append(type_list[i]);
                sb.Append(">();\n");
            }

            sb.Append("\t}\n}\n");
            return sb.ToString();
        }

        /// <summary>
        /// xlua热更界面
        /// </summary>
        /// <param name="button_list"></param>
        /// <param name="class_name"></param>
        /// <returns></returns>
        public static string XLUAUIFormGenertion(List<string> button_list, string class_name)
        {
            if (class_name == "")
            {
                return "!类名为空";
            }

            StringBuilder sb = new StringBuilder(400);

            sb.Append("using System.Collections;\n");
            sb.Append("using System.Collections.Generic;\n");
            sb.Append("using UnityEngine;\n");
            sb.Append("using MyGameFrameWork;\n");
            sb.Append("using UnityEngine.UI;\n");
            sb.Append("using XLua;\n");
            sb.Append("using System;\n\n");
            sb.Append("//CreateTime：" + DateTime.Now.ToString() + "\n");

            sb.Append("[LuaCallCSharp]\n");
            sb.Append("public partial class ");
            sb.Append(class_name);
            sb.Append(" : UIForm\n");
            sb.Append("{\n");

            sb.Append("\tpublic TextAsset luaScript;\n");
            sb.Append("\tinternal static LuaEnv luaEnv = new LuaEnv();\n");
            sb.Append("\tinternal static float lastGCTime = 0;\n");
            sb.Append("\tinternal const float GCInterval = 1;\n");
            sb.Append("\tprivate Action<System.Object> luaOnOpen;\n");
            sb.Append("\tprivate Action luaUpdate;\n");
            sb.Append("\tprivate Action luaOnClose;\n");
            sb.Append("\tprivate LuaTable scriptEnv;\n");

            sb.Append("\tpublic override void Awake()\n");
            sb.Append("\t{\n");
            sb.Append("\t\tbase.Awake();\n");
            sb.Append("\t\tInitComponent(); \n");
            sb.Append("\t\tif(luaScript == null)");
            sb.Append("\t\t{");
            sb.Append("\t\t\tDebug.LogError(\"请绑定热更脚本代码\");");
            sb.Append("\t\t\treturn;");
            sb.Append("\t\t}");
            sb.Append("\t\tscriptEnv = luaEnv.NewTable();\n");
            sb.Append("\t\tLuaTable meta = luaEnv.NewTable();\n");
            sb.Append("\t\tmeta.Set(\"__index\", luaEnv.Global);\n");
            sb.Append("\t\tscriptEnv.SetMetaTable(meta);\n");
            sb.Append("\t\tmeta.Dispose();\n");
            sb.Append("\t\tAddLua();\n");
            sb.Append("\t\tluaEnv.DoString(luaScript.text, \"TestForm\", scriptEnv);\n");
            sb.Append("\t\tAction luaAwake = scriptEnv.Get<Action>(\"Awake\");\n");
            sb.Append("\t\tscriptEnv.Get(\"OnOpen\", out luaOnOpen);\n");
            sb.Append("\t\tscriptEnv.Get(\"Update\", out luaUpdate);\n");
            sb.Append("\t\tscriptEnv.Get(\"OnClose\", out luaOnClose);\n");
            sb.Append("\t\tif (luaAwake != null)\n");
            sb.Append("\t\t{\n");
            sb.Append("\t\t\tluaAwake();\n");
            sb.Append("\t\t}\n");
            sb.Append("\t}\n\n");

            sb.Append("\tpublic override void OnOpen(System.Object obj)\n");
            sb.Append("\t{\n");
            sb.Append("\t\tbase.OnOpen(obj);\n");
            sb.Append("\t\tRegisterEvent(); \n");
            sb.Append("\t\tif (luaOnOpen != null)\n");
            sb.Append("\t\t{\n");
            sb.Append("\t\t\tluaOnOpen(obj);\n");
            sb.Append("\t\t}\n");
            sb.Append("\t}\n\n");

            sb.Append("\tpublic override void OnClose()\n");
            sb.Append("\t{\n");
            sb.Append("\t\tbase.OnClose();\n");
            sb.Append("\t\tReleaseEvent(); \n");
            sb.Append("\t\tif (luaOnClose != null)\n");
            sb.Append("\t\t{\n");
            sb.Append("\t\t\tluaOnClose();\n");
            sb.Append("\t\t}\n");
            sb.Append("\t}\n\n");

            sb.Append("\tpublic override void Update()\n");
            sb.Append("\t{\n");
            sb.Append("\t\tbase.Update();\n");
            sb.Append("\t\tif (luaUpdate != null)\n");
            sb.Append("\t\t{\n");
            sb.Append("\t\t\tluaUpdate();\n");
            sb.Append("\t\t}\n");
            sb.Append("\t\tif (Time.time - lastGCTime > GCInterval)\n");
            sb.Append("\t\t{\n");
            sb.Append("\t\t\tluaEnv.Tick();\n");
            sb.Append("\t\t\tlastGCTime = Time.time;\n");
            sb.Append("\t\t}\n");
            sb.Append("\t}\n");


            sb.Append("\tprivate void RegisterEvent()\n");
            sb.Append("\t{\n");
            sb.Append("\t\t\n");
            sb.Append("\t}\n\n");

            sb.Append("\tprivate void ReleaseEvent()\n");
            sb.Append("\t{\n");
            sb.Append("\t\t\n");
            sb.Append("\t}\n\n");
            sb.Append("}\n");

            return sb.ToString();
        }


        /// <summary>
        /// xlua热更界面绑定
        /// </summary>
        /// <param name="button_list"></param>
        /// <param name="class_name"></param>
        /// <returns></returns>
        public static string XLUAUIFormBindGenertion(List<string> name_list, List<string> type_list, string class_name)
        {
            if (name_list == null || type_list == null)
            {
                return "!列表为null";
            }
            if (name_list.Count == 0 || type_list.Count == 0)
            {
                return "!列表为空";
            }
            if (class_name == "")
            {
                return "!类名为空";
            }

            StringBuilder sb = new StringBuilder(400);

            sb.Append("using System.Collections;\n");
            sb.Append("using System.Collections.Generic;\n");
            sb.Append("using UnityEngine;\n");
            sb.Append("using MyGameFrameWork;\n");
            sb.Append("using UnityEngine.UI;\n\n");
            sb.Append("//CreateTime：" + DateTime.Now.ToString() + "\n");

            sb.Append("public partial class " + class_name + "\n");
            sb.Append("{\n");
            sb.Append("\tprivate AutoBind autoBind;\n");
            for (int i = 0; i < name_list.Count; i++)
            {
                sb.Append("\tprivate " + type_list[i] + " " + name_list[i] + ";\n");
            }

            sb.Append("\n\tprivate void InitComponent()\n");
            sb.Append("\t{\n");
            sb.Append("\t\tautoBind = GetComponent<AutoBind>();\n");
            for (int i = 0; i < name_list.Count; i++)
            {
                sb.Append("\t\t" + name_list[i] + " = autoBind.itemList[");
                sb.Append(i.ToString());
                sb.Append("].obj.GetComponent<");
                sb.Append(type_list[i]);
                sb.Append(">();\n");
            }

            sb.Append("\t}\n");

            sb.Append("\tprivate void AddLua()\n");
            sb.Append("\t{\n");
            for (int i = 0; i < name_list.Count; i++)
            {
                sb.Append("\t\tscriptEnv.Set(\"");
                sb.Append(name_list[i]);
                sb.Append("\", ");
                sb.Append(name_list[i]);
                sb.Append("); \n");
            }
            sb.Append("\t}\n");

            sb.Append("}\n");
            return sb.ToString();
        }


        /// <summary>
        /// xluaUI界面主代码
        /// </summary>
        /// <param name="name_list"></param>
        /// <param name="type_list"></param>
        /// <param name="class_name"></param>
        /// <returns></returns>
        public static string XLUAUIFormTXTGenertion(List<string> button_list, string class_name)
        {
            if (class_name == "")
            {
                return "!类名为空";
            }

            StringBuilder sb = new StringBuilder(400);

            sb.Append("--normal function\n");

            sb.Append("function Awake()\n");
            if (button_list != null && button_list.Count != 0)
            {
                for (int i = 0; i < button_list.Count; i++)
                {
                    sb.Append("\t");
                    sb.Append(button_list[i]);
                    sb.Append(".onClick:AddListener(OnBtn");
                    sb.Append(button_list[i].Substring(5));
                    sb.Append(")\n");
                }
            }
            else
            {
                sb.Append("\n");
            }
            sb.Append("end\n\n");

            sb.Append("function OnOpen(obj)\n");
            sb.Append("\t\n");
            sb.Append("end\n\n");

            sb.Append("function Update()\n");
            sb.Append("\t\n");
            sb.Append("end\n\n");

            sb.Append("function OnClose()\n");
            sb.Append("\t\n");
            sb.Append("end\n\n");

            sb.Append("--btn function\n");
            if (button_list != null && button_list.Count != 0)
            {
                for (int i = 0; i < button_list.Count; i++)
                {
                    sb.Append("function OnBtn");
                    sb.Append(button_list[i].Substring(5));
                    sb.Append("()\n");
                    sb.Append("\t\n");
                    sb.Append("end\n\n");
                }
            }

            return sb.ToString();
        }

        /// <summary>
        /// 生成UI界面主代码
        /// </summary>
        /// <param name="button_list"></param>
        /// <param name="class_name"></param>
        /// <returns></returns>
        public static string UIItemGenertion(List<string> button_list, string class_name)
        {
            if (class_name == "")
            {
                return "!类名为空";
            }

            StringBuilder sb = new StringBuilder(400);

            sb.Append("using System.Collections;\n");
            sb.Append("using System.Collections.Generic;\n");
            sb.Append("using UnityEngine;\n");
            sb.Append("using MyGameFrameWork;\n");
            sb.Append("using UnityEngine.UI;\n\n");
            sb.Append("//CreateTime：" + DateTime.Now.ToString() + "\n");

            sb.Append("public partial class ");
            sb.Append(class_name);
            sb.Append(" : UIItem\n");
            sb.Append("{\n");

            sb.Append("\tpublic override void Awake()\n");
            sb.Append("\t{\n");
            sb.Append("\t\tbase.Awake();\n");
            sb.Append("\t\tInitComponent(); \n");
            sb.Append("\t}\n\n");

            sb.Append("\tpublic override void OnOpen(System.Object obj)\n");
            sb.Append("\t{\n");
            sb.Append("\t\tbase.OnOpen(obj);\n");
            sb.Append("\t\tRegisterEvent(); \n");
            sb.Append("\t}\n\n");

            sb.Append("\tpublic override void OnClose()\n");
            sb.Append("\t{\n");
            sb.Append("\t\tbase.OnClose();\n");
            sb.Append("\t\tReleaseEvent(); \n");
            sb.Append("\t}\n\n");


            sb.Append("\tprivate void RegisterEvent()\n");
            sb.Append("\t{\n");
            if (button_list != null && button_list.Count != 0)
            {
                for (int i = 0; i < button_list.Count; i++)
                {
                    sb.Append("\t\t");
                    sb.Append(button_list[i]);
                    sb.Append(".onClick.AddListener(OnBtn");
                    sb.Append(button_list[i].Substring(5));
                    sb.Append(");\n");
                }
            }
            else
            {
                sb.Append("\t\t\n");
            }
            sb.Append("\t}\n\n");

            sb.Append("\tprivate void ReleaseEvent()\n");
            sb.Append("\t{\n");
            if (button_list != null && button_list.Count != 0)
            {
                for (int i = 0; i < button_list.Count; i++)
                {
                    sb.Append("\t\t");
                    sb.Append(button_list[i]);
                    sb.Append(".onClick.RemoveListener(OnBtn");
                    sb.Append(button_list[i].Substring(5));
                    sb.Append(");\n");
                }
            }
            else
            {
                sb.Append("\t\t\n");
            }
            sb.Append("\t}\n\n");

            if (button_list != null && button_list.Count != 0)
            {
                for (int i = 0; i < button_list.Count; i++)
                {
                    sb.Append("\tprivate void OnBtn");
                    sb.Append(button_list[i].Substring(5));
                    sb.Append("()\n");
                    sb.Append("\t{\n");
                    sb.Append("\t\t\n");
                    sb.Append("\t}\n");
                }
            }

            sb.Append("\n}\n");

            return sb.ToString();
        }

        /// <summary>
        /// 生成UI界面绑定代码
        /// </summary>
        /// <param name="name_list"></param>
        /// <param name="type_list"></param>
        /// <param name="class_name"></param>
        /// <returns></returns>
        public static string UIItemBindGenertion(List<string> name_list, List<string> type_list, string class_name)
        {
            if (name_list == null || type_list == null)
            {
                return "!列表为null";
            }
            if (name_list.Count == 0 || type_list.Count == 0)
            {
                return "!列表为空";
            }
            if (class_name == "")
            {
                return "!类名为空";
            }

            StringBuilder sb = new StringBuilder(400);

            sb.Append("using System.Collections;\n");
            sb.Append("using System.Collections.Generic;\n");
            sb.Append("using UnityEngine;\n");
            sb.Append("using MyGameFrameWork;\n"); ;
            sb.Append("using UnityEngine.UI;\n\n");
            sb.Append("//CreateTime：" + DateTime.Now.ToString() + "\n");

            sb.Append("public partial class " + class_name + "\n");
            sb.Append("{\n");
            sb.Append("\tprivate AutoBind autoBind;\n");
            for (int i = 0; i < name_list.Count; i++)
            {
                sb.Append("\tprivate " + type_list[i] + " " + name_list[i] + ";\n");
            }

            sb.Append("\n\tprivate void InitComponent()\n");
            sb.Append("\t{\n");
            sb.Append("\t\tautoBind = GetComponent<AutoBind>();\n");
            for (int i = 0; i < name_list.Count; i++)
            {
                sb.Append("\t\t" + name_list[i] + " = autoBind.itemList[");
                sb.Append(i.ToString());
                sb.Append("].obj.GetComponent<");
                sb.Append(type_list[i]);
                sb.Append(">();\n");
            }

            sb.Append("\t}\n}\n");
            return sb.ToString();
        }

        public static string EventArgsGenertion(List<string> name_list, List<string> type_list, string class_name)
        {
            if (name_list == null || type_list == null)
            {
                return "!存在空行";
            }
            if (class_name == null)
            {
                return "!存在类名为空！";
            }
            if (!isVaileName(class_name))
            {
                return "!类名不符合要求";
            }

            for (int i = 0; i < type_list.Count; i++)
            {
                if (!NormalTypeDic.ContainsKey(type_list[i]))
                {
                    return "!存在类型不准确";
                }
            }

            for (int i = 0; i < name_list.Count; i++)
            {
                if (!isVaileName(name_list[i]))
                {
                    return "!存在参数命名不准确";
                }
            }

            StringBuilder sb = new StringBuilder(400);

            sb.Append("using System.Collections;\n");
            sb.Append("using System.Collections.Generic;\n");
            sb.Append("using UnityEngine;\n");
            sb.Append("using MyGameFrameWork;\n");
            sb.Append("//CreateTime：" + DateTime.Now.ToString() + "\n");

            sb.Append("public class ");
            sb.Append(class_name);
            sb.Append("EventArgs : IEventArgs\n");

            sb.Append("{\n");
            for (int i = 0; i < name_list.Count; i++)
            {
                sb.Append("\tpublic ");
                sb.Append(type_list[i]);
                sb.Append(" ");
                sb.Append(name_list[i]);
                sb.Append(";\n");
            }

            sb.Append("\tpublic ");
            sb.Append(class_name);
            sb.Append("EventArgs(");
            for (int i = 0; i < name_list.Count; i++)
            {
                sb.Append(type_list[i]);
                sb.Append(" _");
                sb.Append(name_list[i]);
                if (i < name_list.Count - 1)
                {
                    sb.Append(", ");
                }
            }
            sb.Append(")\n");
            sb.Append("\t{\n");
            for (int i = 0; i < name_list.Count; i++)
            {
                sb.Append("\t\t");
                sb.Append(name_list[i]);
                sb.Append(" = _");
                sb.Append(name_list[i]);
                sb.Append(";\n");
            }
            sb.Append("\t}\n\n");

            sb.Append("\tpublic static ");
            sb.Append(class_name);
            sb.Append("EventArgs Create(");
            for (int i = 0; i < name_list.Count; i++)
            {
                sb.Append(type_list[i]);
                sb.Append(" ");
                sb.Append(name_list[i]);
                if (i < name_list.Count - 1)
                {
                    sb.Append(", ");
                }
            }
            sb.Append(")\n");
            sb.Append("\t{\n");
            sb.Append("\t\treturn new ");
            sb.Append(class_name);
            sb.Append("EventArgs(");
            for (int i = 0; i < name_list.Count; i++)
            {
                sb.Append(name_list[i]);
                if (i < name_list.Count - 1)
                {
                    sb.Append(", ");
                }
            }
            sb.Append(");\n");
            sb.Append("\t}\n");
            sb.Append("}\n");

            return sb.ToString();
        }

        /// <summary>
        /// 判断名称是否规范
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        private static bool isVaileName(string name)
        {
            if (name == "")
            {
                return false;
            }
            if (!((name[0] >= 'a' && name[0] <= 'z') || (name[0] >= 'A' && name[0] <= 'Z') || name[0] == '_'))
            {
                return false;
            }
            for (int i = 1; i < name.Length; i++)
            {
                if (!((name[i] >= 'a' && name[i] <= 'z') || (name[i] >= 'A' && name[i] <= 'Z') || name[i] == '_' || (name[i] > '0' && name[i] < '9')))
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// 向指定路径写文件
        /// </summary>
        /// <param name="path">保存路径</param>
        /// <param name="name">文件名，需要后缀</param>
        /// <param name="info">文件内容</param>
        /// <param name="model">书写模式，0表示覆盖写，1表示若有重复则不写</param>
        public static void CreateORwriteConfigFile(string path, string name, string info, int model = 0)
        {
            if (info.Length == 0)
            {
                Debug.LogError("Create " + name + " error!");
                return;
            }
            if (info[0] == '!')
            {
                Debug.LogError("Create " + name + " error!\n" + info);
                return;
            }


            FileInfo t = new FileInfo(path + "//" + name);

            if (t.Exists && model == 1)
            {
                return;
            }

            StreamWriter sw;
            if (!t.Exists)
            {
                sw = t.CreateText();
            }
            else
            {
                t.Delete();
                sw = t.CreateText();
            }
            Regex reg = new Regex(@"(?i)\\[uU]([0-9a-f]{4})");
            string str = reg.Replace(info, delegate (Match m) { return ((char)Convert.ToInt32(m.Groups[1].Value, 16)).ToString(); });
            sw.WriteLine(str);
            sw.Close();
            sw.Dispose();
        }

        public static bool TestFileExists(string path, string name)
        {
            FileInfo t = new FileInfo(path + "//" + name);

            if (t.Exists)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }

}