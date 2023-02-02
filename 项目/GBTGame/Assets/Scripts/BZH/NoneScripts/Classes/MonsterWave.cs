using System.Collections.Generic;

public class MonsterConfig
{
	public uint MonsterId;
	public uint MonsterCount;

	public MonsterConfig(uint id, uint count)
	{
		MonsterId = id;
		MonsterCount = count;
	}
}

public class MonsterWave
{
	private MonsterConfig[] monsterConfigs;

	public MonsterWave(params MonsterConfig[] configs)
	{
		monsterConfigs = new MonsterConfig[configs.Length];
		configs.CopyTo(monsterConfigs, 0);
	}

	public List<uint> AllMonsters
	{
		get
		{
			var result = new List<uint>(10);
			foreach (var monsterConfig in monsterConfigs)
			{
				for (uint i = 0u; i < monsterConfig.MonsterCount; i++)
				{
					result.Add(monsterConfig.MonsterId);
				}
			}

			return result;
		}
	}
}

public class LevelMonsterWaves
{
	private MonsterWave[] monsterWaves;

	public LevelMonsterWaves(params MonsterWave[] waves)
	{
		monsterWaves = new MonsterWave[waves.Length];
		waves.CopyTo(monsterWaves, 0);
	}

	public int WavesCount
	{
		get => monsterWaves.Length;
	}

	public List<uint> this[int waveIndex]
	{
		get => monsterWaves[waveIndex].AllMonsters;
	}
	
	public List<uint> this[uint waveIndex]
	{
		get => monsterWaves[waveIndex].AllMonsters;
	}

	public static implicit operator int(LevelMonsterWaves waves)
	{
		return waves.WavesCount;
	}
}