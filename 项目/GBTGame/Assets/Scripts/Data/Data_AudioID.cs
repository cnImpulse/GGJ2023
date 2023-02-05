using System.Collections;
using System.Collections.Generic;

//CreateTime：2023/2/5 11:00:54
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
			{"Level1",new Data_AudioID_Struct("Level1",1017,"Audio/BGM/Level1")},
			{"Level2",new Data_AudioID_Struct("Level2",1018,"Audio/BGM/Level2")},
			{"Level3",new Data_AudioID_Struct("Level3",1019,"Audio/BGM/Level3")},
			{"Main",new Data_AudioID_Struct("Main",1020,"Audio/BGM/Main")},
			{"Fail",new Data_AudioID_Struct("Fail",1021,"Audio/Effect/Fail")},
			{"Success",new Data_AudioID_Struct("Success",1022,"Audio/Effect/Success")},
			{"Warning",new Data_AudioID_Struct("Warning",1023,"Audio/Effect/Warning")},
			{"Oxygen",new Data_AudioID_Struct("Oxygen",1024,"Audio/Effect/Oxygen")},
			{"Water",new Data_AudioID_Struct("Water",1025,"Audio/Effect/Water")},
			{"Fertilizer",new Data_AudioID_Struct("Fertilizer",1026,"Audio/Effect/Fertilizer")},
			{"ReleaseSkill",new Data_AudioID_Struct("ReleaseSkill",1027,"Audio/Effect/ReleaseSkill")},
			{"CatchBad",new Data_AudioID_Struct("CatchBad",1028,"Audio/Effect/CatchBad")},
			{"CatchGood",new Data_AudioID_Struct("CatchGood",1029,"Audio/Effect/CatchGood")},
			{"Boom",new Data_AudioID_Struct("Boom",1030,"Audio/Effect/Boom")},
			{"LevelFail",new Data_AudioID_Struct("LevelFail",1031,"Audio/Effect/LevelFail")},
			{"LevelSuccess",new Data_AudioID_Struct("LevelSuccess",1032,"Audio/Effect/LevelSuccess")},
			{"CutDown",new Data_AudioID_Struct("CutDown",1033,"Audio/Effect/CutDown")},
			{"Hit",new Data_AudioID_Struct("Hit",1034,"Audio/Effect/Hit")},
			{"Click",new Data_AudioID_Struct("Click",1035,"Audio/Effect/Click")},
			{"Switch",new Data_AudioID_Struct("Switch",1036,"Audio/Effect/Switch")},
			{"Clear",new Data_AudioID_Struct("Clear",1037,"Audio/Effect/Clear")},
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
		public static string key_Level1 = "Level1";
		public static string key_Level2 = "Level2";
		public static string key_Level3 = "Level3";
		public static string key_Main = "Main";
		public static string key_Fail = "Fail";
		public static string key_Success = "Success";
		public static string key_Warning = "Warning";
		public static string key_Oxygen = "Oxygen";
		public static string key_Water = "Water";
		public static string key_Fertilizer = "Fertilizer";
		public static string key_ReleaseSkill = "ReleaseSkill";
		public static string key_CatchBad = "CatchBad";
		public static string key_CatchGood = "CatchGood";
		public static string key_Boom = "Boom";
		public static string key_LevelFail = "LevelFail";
		public static string key_LevelSuccess = "LevelSuccess";
		public static string key_CutDown = "CutDown";
		public static string key_Hit = "Hit";
		public static string key_Click = "Click";
		public static string key_Switch = "Switch";
		public static string key_Clear = "Clear";
	}
}

