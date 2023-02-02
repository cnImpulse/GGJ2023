using DataCs;
using UnityEngine;

public enum EPlayerHpState : uint
{
	Dead = 0u,					//死亡
	Freezing = 1u,				//热量不足(1状态)
	Normal = 1u << 1,			//正常(2状态)
	Fever = 1u << 2,			//发热(3状态)
	Overheating = 1u << 3,		//过热(4状态)
}
    
public class PlayerData
{
	public float MaxHp { get; private set; }
	public float InitialHp { get; private set; }
	public float InitialDefense { get; private set; }
	public float NormalDamage { get; private set; }
	public float FeverDamage { get; private set; }
	public float OverheatingDamage { get; private set; }
	public float InitialMoveSpeed { get; private set; }
	public float NormalAttSpeed { get; private set; }
	public float SlowedAttSpeed { get; private set; }
	public float FastAttSpeed { get; private set; }
    
	public PlayerData(float mHp, float iDefense, float nDmg, float fDmg, float oDmg, float iSpeed, float nAttSpeed, float sAttSpeed, float fAttSpeed)
	{
		MaxHp = mHp;
		InitialHp = 0.5f * MaxHp;
		InitialDefense = iDefense;
		NormalDamage = nDmg;
		FeverDamage = fDmg;
		OverheatingDamage = oDmg;
		InitialMoveSpeed = iSpeed;
		NormalAttSpeed = nAttSpeed;
		SlowedAttSpeed = sAttSpeed;
		FastAttSpeed = fAttSpeed;
	}

	public static PlayerData GetDefaultObject()
	{
		return new PlayerData
		(
			620.0f,
			0.0f,
			78.0f,
			34.0f,
			66.0f,
			3.0f,
			4.0f,
			2.0f,
			6.0f
		);
	}
    
	/// <summary>
	/// 获取当前玩家状态。
	/// </summary>
	/// <param name="currHp">当前HP</param>
	/// <returns>HP对应的状态枚举值</returns>
	public EPlayerHpState GetHpState(float currHp)
	{
		float hpPercentage = currHp / MaxHp;
		//Debug.Log(hpPercentage);
		uint result = 0u;
		float[] kvps = Data_Empyrean.GetDefaultObject().PlayerStateChangedKvps;
		do
		{
			if (hpPercentage == 0.0f) break;
			result = 1u;
			if (hpPercentage < kvps[0]) break;
			result <<= 1;
			if (hpPercentage < kvps[1]) break;
			result <<= 1;
			if (hpPercentage < kvps[2]) break;
			result <<= 1;
    
		} while (false);
		return (EPlayerHpState)result;
	}
    
	/// <summary>
	/// 应用伤害。此函数仅具备计算性，不更改实际数值。
	/// </summary>
	/// <param name="dmg">原始伤害值</param>
	/// <param name="currHp">当前HP</param>
	/// <param name="currDefense">当前防御力</param>
	/// <param name="damageTaker">伤害施加者，为怪物属性对象</param>
	/// <returns>实际应造成的伤害</returns>
	public float ApplyDamage(float dmg, float currHp, float currDefense, MonsterData damageTaker)
	{
		if (currHp <= 0.0f) return 0.0f;
		
		float actuallyCaused = dmg * (1.0f - currDefense);
		//Debug.Log(actuallyCaused);
		if (GetHpState(currHp) == EPlayerHpState.Overheating)
		{
			var data = Data_Empyrean.GetDefaultObject();
			actuallyCaused *=
				Random.Range(data.MinDamageIncreaseWhenOverheating, data.MaxDamageIncreaseWhenOverheating);
		}
		//Debug.LogWarning(actuallyCaused);
		actuallyCaused = Mathf.Clamp(actuallyCaused, 0.0f, currHp);
		Debug.LogError(actuallyCaused);
		return actuallyCaused;
		
	}
}