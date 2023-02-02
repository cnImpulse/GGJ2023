public enum ETurrutType
{
	Center,				//中心
	Normal,				//普通型
}

public class TurrutData
{
	public float MaxHp { get; private set; }
	public float InitialHp { get; private set; }
	
	/// <summary>
	/// 消耗热力值速度
	/// </summary>
	public float ConsumeSpeed { get; private set; }
	
	/// <summary>
	/// 热传导速度
	/// </summary>
	public float ConduceSpeed { get; private set; }

	public TurrutData(float maxHp, float consumeSpeed, float conductionSpeed)
	{
		MaxHp = maxHp;
		InitialHp = 0.9f * maxHp;
		ConsumeSpeed = consumeSpeed;
		ConduceSpeed = conductionSpeed;
	}
}