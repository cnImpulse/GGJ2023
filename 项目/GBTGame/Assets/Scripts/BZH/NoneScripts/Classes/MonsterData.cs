using UnityEngine;

public class MonsterData
{
	public string MonsterName { get; private set; }
	public float MaxHp { get; private set; }
	public int OfferedExp { get; private set; }
	public float OfferedHp { get; private set; }
	public float InitialDefense { get; private set; }
	public float Damage { get; private set; }

	public MonsterData(string mName, float mHp, int oExp, float oHp, float iDefense, float dmg)
	{
		MonsterName = mName;
		MaxHp = mHp;
		OfferedExp = oExp;
		OfferedHp = oHp;
		InitialDefense = iDefense;
		Damage = dmg;
	}
	
	/// <summary>
	/// 应用伤害。此函数仅具备计算性，不更改实际数值。
	/// </summary>
	/// <param name="dmg">原始伤害值</param>
	/// <param name="currHp">当前HP</param>
	/// <param name="currDefense">当前防御力</param>
	/// <returns>实际应造成的伤害</returns>
	public virtual float ApplyDamage(float dmg, float currHp, float currDefense)
	{
		if (currHp <= 0.0f)
		{
			return 0.0f;
		}
		float actuallyCaused = dmg * (1.0f - currDefense);
		actuallyCaused = Mathf.Clamp(actuallyCaused, 0.0f, currHp);
		//Debug.LogWarning(actuallyCaused);
		return actuallyCaused;
	}
}