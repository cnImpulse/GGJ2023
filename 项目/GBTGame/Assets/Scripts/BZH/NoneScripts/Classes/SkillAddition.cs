
struct AdditionData
{
	public float DamageIncreasePerLevel;
	public float DefenseIncreasePerLevel;
	public float AttackSpeedIncreasePerLevel;

	public AdditionData(float increaseDamage, float increaseDefense, float increaseAttSpeed)
	{
		DamageIncreasePerLevel = increaseDamage;
		DefenseIncreasePerLevel = increaseDefense;
		AttackSpeedIncreasePerLevel = increaseAttSpeed;
	}

	public static AdditionData GetDefaultObject()
	{
		return new AdditionData
		(
			0.05f,
			0.04f,
			0.07f
		);
	}
}

/// <summary>
/// 这个类在游戏运行时即创建并读取存档初始化，且加载时不销毁。
/// </summary>
public class SkillAdditionSystem
{
	public static SkillAdditionSystem Instance { get; private set; }

	struct SkillAddition
	{
		public uint Level;
		public float IncreasePerLevel;

		public SkillAddition(uint level)
		{
			Level = level;
			IncreasePerLevel = 0.0f;
		}

		public float TotalIncrease
		{
			get => Level * IncreasePerLevel;
		}
	}

	private SkillAddition damageAddition;
	private SkillAddition defenseAddition;
	private SkillAddition attSpeedAddition;

	private SkillAdditionSystem(uint lDamage, uint lDefense, uint lAttSpeed)
	{
		damageAddition = new SkillAddition(lDamage);
		defenseAddition = new SkillAddition(lDefense);
		attSpeedAddition = new SkillAddition(lAttSpeed);
		
		var data = AdditionData.GetDefaultObject();
		damageAddition.IncreasePerLevel = data.DamageIncreasePerLevel;
		defenseAddition.IncreasePerLevel = data.DefenseIncreasePerLevel;
		attSpeedAddition.IncreasePerLevel = data.AttackSpeedIncreasePerLevel;
	}

	public static SkillAdditionSystem CreateInstance(uint lDamage, uint lDefense, uint lAttSpeed)
	{
		Instance = new SkillAdditionSystem(lDamage, lDefense, lAttSpeed);
		return Instance;
	}

	public void AddDamageLevel()
	{
		damageAddition.Level++;
	}

	public void ReduceDamageLevel()
	{
		damageAddition.Level--;
	}
	
	public void AddDefenseLevel()
	{
		defenseAddition.Level++;
	}

	public void ReduceDefenseLevel()
	{
		defenseAddition.Level--;
	}
	
	public void AddAttSpeedLevel()
	{
		attSpeedAddition.Level++;
	}

	public void ReduceAttSpeedLevel()
	{
		attSpeedAddition.Level--;
	}
	
	public uint DamageLevel
	{
		get => damageAddition.Level;
		set => damageAddition.Level = value;
	}
	
	public uint DefenseLevel
	{
		get => defenseAddition.Level;
		set => defenseAddition.Level = value;
	}

	public uint AttackSpeedLevel
	{
		get => attSpeedAddition.Level;
		set => attSpeedAddition.Level = value;
	}

	public float DamageIncrease
	{
		get => damageAddition.TotalIncrease;
	}
	
	public float DefenseIncrease
	{
		get => defenseAddition.TotalIncrease;
	}

	public float AttackSpeedIncrease
	{
		get => attSpeedAddition.TotalIncrease;
	}
}