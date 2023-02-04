using System.Collections;
using System.Collections.Generic;

//CreateTime：2023/2/4 14:55:09
namespace DataCs
{
	public struct Data_AudioID_Struct
	{
		public string key;
		public int ID;
		public string path;

		public Data_AudioID_Struct(string _key, int _ID, string _path)
		{
			key = _key;
			ID = _ID;
			path = _path;
		}
	}

	public static class Data_AudioID
	{
		public static Dictionary<string, Data_AudioID_Struct> Dic = new Dictionary<string, Data_AudioID_Struct>()
		{
			{"Bright_Beginning",new Data_AudioID_Struct("Bright_Beginning",1000,"Audio/Music/Bright_Beginning")},
			{"Dark_Journey",new Data_AudioID_Struct("Dark_Journey",1001,"Audio/Music/Dark_Journey")},
			{"March_of_the_Brave",new Data_AudioID_Struct("March_of_the_Brave",1002,"Audio/Music/March_of_the_Brave")},
			{"Solemn_Place",new Data_AudioID_Struct("Solemn_Place",1003,"Audio/Music/Solemn_Place")},
			{"Coins",new Data_AudioID_Struct("Coins",1004,"Audio/Effect/Coins")},
			{"Electricity",new Data_AudioID_Struct("Electricity",1005,"Audio/Effect/Electricity")},
			{"Sleeping",new Data_AudioID_Struct("Sleeping",1006,"Audio/Effect/Sleeping")},
			{"Turn_to_stone",new Data_AudioID_Struct("Turn_to_stone",1007,"Audio/Effect/Turn_to_stone")},
			{"Swoosh",new Data_AudioID_Struct("Swoosh",1008,"Audio/Effect/Swoosh")},
			{"FireBurning",new Data_AudioID_Struct("FireBurning",1009,"Audio/Effect/FireBurning")},
			{"FireShining",new Data_AudioID_Struct("FireShining",1010,"Audio/Effect/FireShining")},
			{"GameBgm",new Data_AudioID_Struct("GameBgm",1011,"Audio/Effect/GameBgm")},
			{"FireHit",new Data_AudioID_Struct("FireHit",1012,"Audio/Effect/FireHit")},
			{"TurrDestroyed",new Data_AudioID_Struct("TurrDestroyed",1013,"Audio/Effect/TurrDestroyed")},
			{"PlayerInjured",new Data_AudioID_Struct("PlayerInjured",1014,"Audio/Effect/PlayerInjured")},
			{"PlayerDie",new Data_AudioID_Struct("PlayerDie",1015,"Audio/Effect/PlayerDie")},
			{"Monster2Bomb",new Data_AudioID_Struct("Monster2Bomb",1016,"Audio/Effect/Monster2Bomb")},
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
		public static string key_FireBurning = "FireBurning";
		public static string key_FireShining = "FireShining";
		public static string key_GameBgm = "GameBgm";
		public static string key_FireHit = "FireHit";
		public static string key_TurrDestroyed = "TurrDestroyed";
		public static string key_PlayerInjured = "PlayerInjured";
		public static string key_PlayerDie = "PlayerDie";
		public static string key_Monster2Bomb = "Monster2Bomb";
	}
}

