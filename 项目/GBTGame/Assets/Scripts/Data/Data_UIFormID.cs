using System.Collections;
using System.Collections.Generic;

//CreateTime：2023/2/4 12:39:30
namespace DataCs
{
	public struct Data_UIFormID_Struct
	{
		public string key;
		public int ID;
		public string path;
		public int root;

		public Data_UIFormID_Struct(string _key, int _ID, string _path, int _root)
		{
			key = _key;
			ID = _ID;
			path = _path;
			root = _root;
		}
	}

	public static class Data_UIFormID
	{
		public static Dictionary<string, Data_UIFormID_Struct> Dic = new Dictionary<string, Data_UIFormID_Struct>()
		{
			{"StartGameForm",new Data_UIFormID_Struct("StartGameForm",1000,"ZKW/StartGameForm",1)},
			{"MainForm",new Data_UIFormID_Struct("MainForm",1001,"ZKW/MainForm",1)},
			{"DeveloperForm",new Data_UIFormID_Struct("DeveloperForm",1002,"ZKW/DeveloperForm",1)},
			{"MenuForm",new Data_UIFormID_Struct("MenuForm",1003,"ZKW/MenuForm",1)},
			{"GameOverForm",new Data_UIFormID_Struct("GameOverForm",1004,"ZKW/GameOverForm",1)},
			{"SkillForm",new Data_UIFormID_Struct("SkillForm",1005,"ZKW/SkillTreeForm",1)},
			{"HelperForm",new Data_UIFormID_Struct("HelperForm",1006,"ZKW/HelperForm",1)},
			{"AllGameStartForm",new Data_UIFormID_Struct("AllGameStartForm",1007,"ZKW/AllGameStartForm",1)},
			{"AllGameOverForm",new Data_UIFormID_Struct("AllGameOverForm",1008,"ZKW/AllGameOverForm",1)},
			{"TestPanel",new Data_UIFormID_Struct("TestPanel",1009,"ZKW/TestPanel/TestPanel",1)},
			{"HandleForm",new Data_UIFormID_Struct("HandleForm",2001,"GX/HandleForm",1)},
			{"ToolForm",new Data_UIFormID_Struct("ToolForm",1010,"ZKW/ToolForm",3)},
			{"HUDForm",new Data_UIFormID_Struct("HUDForm",1011,"ZKW/HUDForm",3)},
		};
		public static string key_StartGameForm = "StartGameForm";
		public static string key_MainForm = "MainForm";
		public static string key_DeveloperForm = "DeveloperForm";
		public static string key_MenuForm = "MenuForm";
		public static string key_GameOverForm = "GameOverForm";
		public static string key_SkillForm = "SkillForm";
		public static string key_HelperForm = "HelperForm";
		public static string key_AllGameStartForm = "AllGameStartForm";
		public static string key_AllGameOverForm = "AllGameOverForm";
		public static string key_TestPanel = "TestPanel";
		public static string key_HandleForm = "HandleForm";
		public static string key_ToolForm = "ToolForm";
		public static string key_HUDForm = "HUDForm";
	}
}

