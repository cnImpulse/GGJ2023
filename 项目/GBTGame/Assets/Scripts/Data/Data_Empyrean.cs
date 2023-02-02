namespace DataCs
{
	public class Data_Empyrean
	{
		public float[] PlayerStateChangedKvps;

		public float MinDamageIncreaseWhenOverheating;

		public float MaxDamageIncreaseWhenOverheating;

		public MonsterData[] MonsterDatas;

		public LevelMonsterWaves[] MonstersInLevels;

		public TurrutData[] CenterTurrutDatas;

		public TurrutData[] NormalTurrutDatas;

		public int BasicRequiredExp;

		public int RequiredExpIncreasePerLevel;

		public static Data_Empyrean GetDefaultObject()
		{
			var result = new Data_Empyrean();
			result.PlayerStateChangedKvps = new[] { 0.2f, 0.6f, 0.9f, };
			result.MinDamageIncreaseWhenOverheating = 3.0f;
			result.MaxDamageIncreaseWhenOverheating = 8.0f;
			result.MonsterDatas = new[]
			{
				new MonsterData("近战法师", 210.0f, 5, 23.0f, 0.0f, 30.0f),
				new MonsterData("自爆冰怪", 100.0f, 8, 18.0f, 0.0f, 69.0f),
				new MonsterData("冰石巨兽", 400.0f, 12, 30.0f, 0.1f, 18.0f),
				new MonsterData("寒冰射手", 100.0f, 5, 1, 0.0f, 55.0f),
			};

			result.MonstersInLevels = new LevelMonsterWaves[3];

			result.MonstersInLevels[0] = new LevelMonsterWaves
			(
				new MonsterWave(new MonsterConfig(1u, 1u)),
				new MonsterWave(new MonsterConfig(1u, 2u)),
				new MonsterWave(new MonsterConfig(1u, 1u), new MonsterConfig(2u, 1u)),
				new MonsterWave(new MonsterConfig(2u, 1u)),
				new MonsterWave(new MonsterConfig(2u, 2u)),
				new MonsterWave(new MonsterConfig(1u, 3u)),
				new MonsterWave(new MonsterConfig(1u, 3u), new MonsterConfig(2u, 2u))
			);
			
			result.MonstersInLevels[1] = new LevelMonsterWaves
			(
				new MonsterWave(new MonsterConfig(2u, 1u)),
				new MonsterWave(new MonsterConfig(1u, 3u), new MonsterConfig(2u, 1u)),
				new MonsterWave(new MonsterConfig(1u, 3u), new MonsterConfig(2u, 2u)),
				new MonsterWave(new MonsterConfig(3u, 1u)),
				new MonsterWave(new MonsterConfig(1u, 2u), new MonsterConfig(3u, 1u)),
				new MonsterWave(new MonsterConfig(1u, 2u), new MonsterConfig(2u, 2u), new MonsterConfig(3u, 2u)),
				new MonsterWave(new MonsterConfig(1u, 3u), new MonsterConfig(2u, 1u)),
				new MonsterWave(new MonsterConfig(1u, 1u), new MonsterConfig(2u, 2u), new MonsterConfig(3u, 1u)),
				new MonsterWave(new MonsterConfig(3u, 2u)),
				new MonsterWave(new MonsterConfig(2u, 2u), new MonsterConfig(3u, 2u)),
				new MonsterWave(new MonsterConfig(1u, 3u), new MonsterConfig(2u, 1u), new MonsterConfig(3u, 1u))
			);
			
			result.MonstersInLevels[2] = new LevelMonsterWaves
			(
				new MonsterWave(new MonsterConfig(1u, 1u), new MonsterConfig(2u, 2u)),
				new MonsterWave(new MonsterConfig(1u, 4u)),
				new MonsterWave(new MonsterConfig(1u, 2u), new MonsterConfig(2u, 2u)),
				new MonsterWave(new MonsterConfig(1u, 2u), new MonsterConfig(2u, 3u)),
				new MonsterWave(new MonsterConfig(1u, 3u), new MonsterConfig(2u, 2u)),
				new MonsterWave(new MonsterConfig(1u, 2u), new MonsterConfig(2u, 1u), new MonsterConfig(3u, 2u)),
				new MonsterWave(new MonsterConfig(1u, 1u), new MonsterConfig(2u, 2u), new MonsterConfig(3u, 1u)),
				new MonsterWave(new MonsterConfig(1u, 2u), new MonsterConfig(2u, 1u), new MonsterConfig(3u, 2u)),
				new MonsterWave(new MonsterConfig(1u, 3u), new MonsterConfig(3u, 2u)),
				new MonsterWave(new MonsterConfig(1u, 3u), new MonsterConfig(2u, 1u), new MonsterConfig(3u, 1u))
			);

			result.CenterTurrutDatas = new TurrutData[3]
			{
				new TurrutData
				(
					2200.0f,
					12.0f,
					40.0f
				),
				new TurrutData
				(
					1400.0f,
					12.0f,
					35.0f
				),
				new TurrutData
				(
					1600.0f,
					9.0f,
					30.0f
				),
			};
			
			result.NormalTurrutDatas = new TurrutData[3]
			{
				new TurrutData
				(
					750.0f,
					5.0f,
					40.0f
				),
				new TurrutData
				(
					600.0f,
					2.5f,
					35.0f
				),
				new TurrutData
				(
					870.0f,
					2.5f,
					30.0f
				),
			};

			result.BasicRequiredExp = 30;
			result.RequiredExpIncreasePerLevel = 8;

			return result;
		}
	}
}