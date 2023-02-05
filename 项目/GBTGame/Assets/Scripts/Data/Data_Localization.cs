using System.Collections;
using System.Collections.Generic;

//CreateTime：2023/2/5 12:08:20
namespace DataCs
{
	public struct Data_Localization_Struct
	{
		public string key;
		public string ChineseSimplified;
		public string ChineseTraditional;
		public string English;

		public Data_Localization_Struct(string _key, string _ChineseSimplified, string _ChineseTraditional, string _English)
		{
			key = _key;
			ChineseSimplified = _ChineseSimplified;
			ChineseTraditional = _ChineseTraditional;
			English = _English;
		}
	}

	public static class Data_Localization
	{
		public static Dictionary<string, Data_Localization_Struct> Dic = new Dictionary<string, Data_Localization_Struct>()
		{
			{"LoadGame",new Data_Localization_Struct("LoadGame","载入游戏","載入遊戲","Load Game")},
		};
		public static string key_LoadGame = "LoadGame";
	}
}

