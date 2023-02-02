using System;
using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using DataCs;
using UnityEngine;
using static UnityEngine.ParticleSystem;
using Random = UnityEngine.Random;


public static class TOOLS
{
	private static Dictionary<uint, MonsterData> monsterIdMap;

	private static Data_Empyrean empyreanData;
	private static PlayerData playerData;

	static TOOLS()
	{
		var data = Data_Empyrean.GetDefaultObject();
		monsterIdMap = new Dictionary<uint, MonsterData>()
		{
			{1u, data.MonsterDatas[0]},
			{2u, data.MonsterDatas[1]},
			{3u, data.MonsterDatas[2]},
			{4u, data.MonsterDatas[3]},
		};
		empyreanData = Data_Empyrean.GetDefaultObject();
		playerData = PlayerData.GetDefaultObject();
	}

	/// <summary>
	/// 通过怪物ID获取怪物信息类对象
	/// </summary>
	/// <param name="id">怪物ID</param>
	/// <returns></returns>
	public static MonsterData GetMonsterDataById(uint id)
	{
		return monsterIdMap[id];
	}

	public static float GetPlayerInitialHp() => playerData.InitialHp;
	
    public static float GetPlayerDps(EPlayerHpState stateWhenFire, uint monsterId, float monsterCurrHp, float monsterCurrDefense)//Attack monster damage
    {
	    float originalDamage = playerData.NormalDamage;
	    if (stateWhenFire == EPlayerHpState.Fever)
	    {
		    originalDamage = playerData.FeverDamage;
	    }
	    else if (stateWhenFire == EPlayerHpState.Overheating)
	    {
		    originalDamage = playerData.OverheatingDamage;
	    }
	    
	    return GetMonsterDataById(monsterId)
		    .ApplyDamage(originalDamage * (1.0f + SkillAdditionSystem.Instance.DamageIncrease), monsterCurrHp, monsterCurrDefense);
    }

    public static float GetMonsterToPlayerDps(uint monsterId, float playerCurrHp)
    {
	    MonsterData monsterData = GetMonsterDataById(monsterId);

	    return playerData.ApplyDamage(monsterData.Damage, playerCurrHp,
		    playerData.InitialDefense + SkillAdditionSystem.Instance.DefenseIncrease, monsterData);
    }

    public static float GetMonsterToTurrutDps(uint monsterId, float turrutCurrHp)
    {
	    if (turrutCurrHp <= 0.0f)
	    {
		    return 0.0f;
	    }
	    
	    MonsterData monsterData = GetMonsterDataById(monsterId);
	    float dmg = monsterData.Damage;
	    if (monsterId == 3u)
	    {
		    dmg *= 2.0f;
	    }

	    float actuallyCaused = Mathf.Clamp(dmg, 0.0f, turrutCurrHp);
	    return actuallyCaused;
    }

    public static float GetPlayerMaxHp()//Gain player health
    {
	    return playerData.MaxHp;
    }

    public static EPlayerHpState GetPlayerHpState(float playerCurrHp)
    {
	    return playerData.GetHpState(playerCurrHp);
    }

    public static float GetAttackSpeed(EPlayerHpState playerHpState)
    {
	    if (playerHpState == EPlayerHpState.Dead)
	    {
		    return 0.0f;
	    }
	    if (playerHpState == EPlayerHpState.Freezing)
	    {
		    return playerData.SlowedAttSpeed;
	    }
	    if (playerHpState == EPlayerHpState.Overheating)
	    {
		    return playerData.FastAttSpeed;
	    }

	    return playerData.NormalAttSpeed;
    }

    public static int GetRequiredExp(int playerCurrLevel)
    {
	    return empyreanData.BasicRequiredExp + playerCurrLevel * empyreanData.RequiredExpIncreasePerLevel;
    }

    public static int GetMonsterExp(uint monsterId)//Get Moster Exp
    {
	    return GetMonsterDataById(monsterId).OfferedExp;
    }

    /// <summary>
    /// 获取击杀怪物返还的HP
    /// </summary>
    /// <param name="monsterId"></param>
    /// <returns></returns>
    public static float GetMonsterOfferedHp(uint monsterId)
    {
	    return GetMonsterDataById(monsterId).OfferedHp;
    }

    private static TurrutData GetTurrutData(ETurrutType turrutType, uint level)
    {
	    if (turrutType == ETurrutType.Center)
	    {
		    return empyreanData.CenterTurrutDatas[level];
	    }

	    return empyreanData.NormalTurrutDatas[level];
    }

    public static void GetTurrutHps(ETurrutType turrutType, uint level, out float maxHp, out float initialHp)
    {
	    TurrutData turrutData = GetTurrutData(turrutType, level);
	    maxHp = turrutData.MaxHp;
	    initialHp = turrutData.InitialHp;
    }

    /// <summary>
    /// 获取塔耗血速度
    /// </summary>
    /// <param name="turrutType">塔类型：中心或普通型</param>
    /// <param name="level">关卡序号，从0开始</param>
    /// <returns></returns>
    public static float GetTurrutConsumeSpeed(ETurrutType turrutType, uint level)
    {
	    return GetTurrutData(turrutType, level).ConsumeSpeed;
    }
    
    /// <summary>
    /// 获取塔热传递速度
    /// </summary>
    /// <param name="turrutType">塔类型：中心或普通型</param>
    /// <param name="level">关卡序号，从0开始</param>
    /// <returns></returns>
    public static float GetTurrutConduceSpeed(ETurrutType turrutType, uint level)
    {
	    return GetTurrutData(turrutType, level).ConduceSpeed;
    }

    public static string[] GetDialoguefirstlevel()//Get the dialogue from the first level
    {
        return new string[] 
        { 
            "1",
            "2",
            "3",
            "4",
        };
    }

    public static int GetMonsterWaves(uint level)
    {
	    if (level == 2u)
	    {
		    return int.MaxValue;
	    }
	    return empyreanData.MonstersInLevels[level];
    }

    public static List<uint> GetFirstMonsters(uint level, uint waveIndex)
    {
	    if (level < 2u)
	    {
		    return empyreanData.MonstersInLevels[level][waveIndex];
	    }

	    var waves = empyreanData.MonstersInLevels[2];
	    if (waveIndex < waves.WavesCount)
	    {
		    return waves[waveIndex];
	    }

	    return GenerateRandomMonsters(waveIndex);
    }

    private static uint GenerateMonsterCount(uint waveIndex)
    {
	    System.Random rand = new System.Random();
	    if (waveIndex < 15u)
	    {
		    return (uint)rand.Next(4, 6);
	    }

	    if (waveIndex < 25u)
	    {
		    return (uint)rand.Next(5, 8);
	    }

	    return (uint)rand.Next(7, 10);
    }

    private static List<uint> GenerateRandomMonsters(uint waveIndex)
    {
	    uint total = GenerateMonsterCount(waveIndex);
	    uint m1Count = 0u, m2Count = 0u, m3Count = 0u;
	    m3Count = (uint)Random.Range(0.0f, 0.3f * total);
	    m2Count = (uint)Random.Range(0.1f * total, 2.5f);
	    m1Count = total - m2Count - m3Count;
	    MonsterWave wave = new MonsterWave(new MonsterConfig(1u, m1Count), new MonsterConfig(2u, m2Count),
		    new MonsterConfig(3u, m3Count));
	    return wave.AllMonsters;
    }
}
