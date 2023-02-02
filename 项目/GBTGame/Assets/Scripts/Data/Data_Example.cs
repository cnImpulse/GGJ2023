using System.Collections;
using System.Collections.Generic;

//CreateTime：2022/7/25 10:32:03
namespace DataCs
{
	public struct Data_Example_Struct
	{
		public string key;
		public int ID;
		public string path;

		public Data_Example_Struct(string _key, int _ID, string _path)
		{
			key = _key;
			ID = _ID;
			path = _path;
		}
	}

	public static class Data_Example
	{
		public static Dictionary<string, Data_Example_Struct> Dic = new Dictionary<string, Data_Example_Struct>()
		{
			{"Bright_Beginning",new Data_Example_Struct("Bright_Beginning",1000,"Audio/Music/Bright_Beginning")},
			{"Dark_Journey",new Data_Example_Struct("Dark_Journey",1001,"Audio/Music/Dark_Journey")},
			{"March_of_the_Brave",new Data_Example_Struct("March_of_the_Brave",1002,"Audio/Music/March_of_the_Brave")},
			{"Solemn_Place",new Data_Example_Struct("Solemn_Place",1003,"Audio/Music/Solemn_Place")},
			{"Coins",new Data_Example_Struct("Coins",1004,"Audio/Effect/Coins")},
			{"Electricity",new Data_Example_Struct("Electricity",1005,"Audio/Effect/Electricity")},
			{"Sleeping",new Data_Example_Struct("Sleeping",1006,"Audio/Effect/Sleeping")},
			{"Turn_to_stone",new Data_Example_Struct("Turn_to_stone",1007,"Audio/Effect/Turn_to_stone")},
			{"Swoosh",new Data_Example_Struct("Swoosh",1008,"Audio/Effect/Swoosh")},
		};
		public static string key_Bright_Beginning = "Bright_Beginning";
		public static string key_Dark_Journey = "Dark_Journey";
		public static string key_March_of_the_Brave = "March_of_the_Brave";
		public static string key_Solemn_Place = "Solemn_Place";
		public static string key_Coins = "Coins";
		public static string key_Electricity = "Electricity";
		public static string key_Sleeping = "Sleeping";
		public static string key_Turn_to_stone = "Turn_to_stone";
		public static string key_Swoosh = "Swoosh";
	}
}

