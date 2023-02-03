using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DataCs;
using MyGameFrameWork;


namespace GGJ2023
{
    public class MainState : ISceneState
    {

        GameObject Enity1;
        GameObject Spawn1;
        GameObject Spawn2;
        GameObject Spawn3;
        GameObject Spawn4;
        GameObject Spawn5;
        GameObject Spawn6;
        GameObject Player;

        GameObject Tower1;
        GameObject Tower2;
        GameObject Tower3;
        GameObject Tower4;
        GameObject Tower5;

        List<EnemySpawn> Spawns;

        GameObject HPBarCanvas;

        int curr_wave;
        int last_enemy;

        int cuur_level;
        int all_wave;

        int player_level = 0;
        int player_exp = 0;

        int lastSkill;

        PlayerMove pm;

        bool isFirst;
        public MainState(SceneStateC c) : base(c)
        {
            this.StateName = "MainState";
            isFirst = true;
        }

        public override void StateBegin(System.Object obj)
        {
            if (isFirst)
            {
                isFirst = false;
                EventManagerSystem.Instance.Add2(DataCs.Data_EventName.GameOver_str, GameOver);
                EventManagerSystem.Instance.Add2(DataCs.Data_EventName.KillMonster_str, KillMonster);
                EventManagerSystem.Instance.Add2(Data_EventName.BackMenu_str, OnBackMenu);
                EventManagerSystem.Instance.Add2(Data_EventName.NextLevel_str, OnNextLevel);
            }

            SoundSystem.Instance.StopMusic(Data_AudioID.key_GameBgm);
            SkillAdditionSystem.CreateInstance(0, 0, 0);

            Enity1 = m_Contorller.GetData("Enity1") as GameObject;

            Spawn1 = m_Contorller.GetData("Spawn1") as GameObject;
            Spawn2 = m_Contorller.GetData("Spawn2") as GameObject;
            Spawn3 = m_Contorller.GetData("Spawn3") as GameObject;
            Spawn4 = m_Contorller.GetData("Spawn4") as GameObject;
            Spawn5 = m_Contorller.GetData("Spawn5") as GameObject;
            Spawn6 = m_Contorller.GetData("Spawn6") as GameObject;
            Spawns = new List<EnemySpawn>();

            Spawns.Add(Spawn1.GetComponent<EnemySpawn>());
            Spawns.Add(Spawn2.GetComponent<EnemySpawn>());
            Spawns.Add(Spawn3.GetComponent<EnemySpawn>());
            Spawns.Add(Spawn4.GetComponent<EnemySpawn>());
            Spawns.Add(Spawn5.GetComponent<EnemySpawn>());
            Spawns.Add(Spawn6.GetComponent<EnemySpawn>());
            Player = m_Contorller.GetData("Player") as GameObject;
            pm = Player.GetComponent<PlayerMove>();
            HPBarCanvas = m_Contorller.GetData("HPBarCanvas") as GameObject;

            Tower1 = m_Contorller.GetData("Tower1") as GameObject;
            Tower2 = m_Contorller.GetData("Tower2") as GameObject;
            Tower3 = m_Contorller.GetData("Tower3") as GameObject;
            Tower4 = m_Contorller.GetData("Tower4") as GameObject;
            Tower5 = m_Contorller.GetData("Tower5") as GameObject;



            /*EventManagerSystem.Instance.Add2(DataCs.Data_EventName.GameOver_str, GameOver);
            EventManagerSystem.Instance.Add2(DataCs.Data_EventName.KillMonster_str, KillMonster);
            EventManagerSystem.Instance.Add2(Data_EventName.BackMenu_str, OnBackMenu);
            EventManagerSystem.Instance.Add2(Data_EventName.NextLevel_str, OnNextLevel);*/
            curr_wave = 0;
            lastSkill = (int)m_Contorller.GetData("lastKill");
            cuur_level = (int)obj;
            all_wave = TOOLS.GetMonsterWaves((uint)cuur_level);
            Enity1?.SetActive(true);
            CreateTower();
            CreateEnemy();
            Player.GetComponent<PlayerMove>().PlayerInit();
            CreateMainUI();
        }

        public override void StateUpdate()
        {
            //Debug.Log("MainState Update");
        }

        public override void StateEnd()
        {
            SoundSystem.Instance.PlayMusic(Data_AudioID.key_GameBgm);
            //EventManagerSystem.Instance.Delete2(DataCs.Data_EventName.GameOver_str, GameOver);
            ////EventManagerSystem.Instance.Delete2(DataCs.Data_EventName.KillMonster_str, KillMonster);
            //EventManagerSystem.Instance.Delete2(Data_EventName.BackMenu_str, OnBackMenu);
            //EventManagerSystem.Instance.Delete2(Data_EventName.NextLevel_str, OnNextLevel);
            Spawns.Clear();
        }

        void CreateMainUI()
        {
            float MainTowerHp;
            float MainTowerHp2;
            TOOLS.GetTurrutHps(ETurrutType.Center, (uint)cuur_level, out MainTowerHp, out MainTowerHp2);
            UISystem.Instance.OpenUIForm(Data_UIFormID.key_MainForm, new MainFormStruct(MainTowerHp, player_level, player_exp));
        }

        void CreatePlayer()
        {

        }

        void CreateTower()
        {
            Tower1.GetComponent<Tower>().init(ETurrutType.Normal, cuur_level);
            Tower2.GetComponent<Tower>().init(ETurrutType.Normal, cuur_level);
            Tower3.GetComponent<Tower>().init(ETurrutType.Normal, cuur_level);
            Tower4.GetComponent<Tower>().init(ETurrutType.Normal, cuur_level);
            Tower5.GetComponent<Tower>().init(ETurrutType.Center, cuur_level);
        }

        void CreateEnemySpawn()
        {

        }

        void CreateEnemy()
        {
            List<uint> Monsters = TOOLS.GetFirstMonsters((uint)cuur_level, (uint)curr_wave);
            last_enemy = Monsters.Count;
            for (int i = 0; i < Monsters.Count; i++)
            {
                Spawns[i % Spawns.Count].SpawnPlan((int)Monsters[i]);
            }
        }

        void GameOver(IEventArgs eventArgs)
        {
            GameOverEventArgs gameOverEventArgs = (GameOverEventArgs)eventArgs;
            Debug.Log("GameOver");
            //UISystem.Instance.OpenUIForm(Data_UIFormID.key_GameOverForm,new GameOverStruct("您失败了",true,cuur_level));
            Enity1.SetActive(false);
            if (cuur_level == 2)
            {
                m_Contorller.SetState("AllGameOverState", null);
            }
            /*Sequence seq = DOTween.Sequence();
            seq.AppendInterval(0.1f);
            seq.AppendCallback(() => {
                Enity1.SetActive(false);
            });*/
        }

        void GameOverOK()
        {
            //Debug.Log("GameOK");
            /*Sequence seq = DOTween.Sequence();
            seq.AppendInterval(0.1f);
            seq.AppendCallback(() => {
                Enity1.SetActive(false);
            });*/
            Enity1.SetActive(false);
            UISystem.Instance.OpenUIForm(Data_UIFormID.key_GameOverForm, new GameOverStruct("恭喜通过第" + (cuur_level + 1).ToString() + "关", false, cuur_level));
        }

        void OnNextLevel(IEventArgs eventArgs)
        {
            NextLevelEventArgs nextLevelEventArgs = (NextLevelEventArgs)eventArgs;
            int level = nextLevelEventArgs.Level;

            curr_wave = 0;
            cuur_level = level;
            all_wave = TOOLS.GetMonsterWaves((uint)cuur_level);
            Enity1?.SetActive(true);
            CreateTower();
            CreateEnemy();
            pm.PlayerInit();
            CreateMainUI();
        }

        void KillMonster(IEventArgs eventArgs)
        {

            KillMonsterEventArgs killMonsterEventArgs = (KillMonsterEventArgs)eventArgs;
            int killWave = killMonsterEventArgs.Wave;
            last_enemy--;
            PlayerAddHp((uint)killWave);
            PlayerAddExp((uint)killWave);
            if (last_enemy == 0)
            {
                curr_wave++;


                if (curr_wave < all_wave)
                {
                    CreateEnemy();
                }
                else
                {
                    GameOverOK();
                    EventManagerSystem.Instance.Invoke2(DataCs.Data_EventName.GameOK_str, GameOKEventArgs.Create(cuur_level));
                }
            }
        }

        void PlayerAddHp(uint id)
        {
            float DPS = TOOLS.GetMonsterOfferedHp(id);
            pm.Injure(-DPS);
            EventManagerSystem.Instance.Invoke2(Data_EventName.PlayerInjure_str, PlayerInjureEventArgs.Create(-DPS));

        }

        void PlayerAddExp(uint id)
        {
            int exp = TOOLS.GetMonsterExp(id);
            EventManagerSystem.Instance.Invoke2(Data_EventName.AddExp_str, AddExpEventArgs.Create(exp));

            int max_exp = TOOLS.GetRequiredExp(player_level);

            int addSkill = 0;

            if (exp + player_exp >= max_exp)
            {
                player_level++;
                addSkill++;
                player_exp = exp + player_exp - max_exp;

            }
            else
            {
                player_exp += exp;

            }

            max_exp = TOOLS.GetRequiredExp(player_level);

            while (player_exp >= max_exp)
            {
                player_level++;
                addSkill++;
                player_exp -= max_exp;
                max_exp = TOOLS.GetRequiredExp(player_level);
            }
            m_Contorller.SetData("lastSkill", lastSkill + addSkill);
            //Debug.Log(lastSkill + addSkill);
            lastSkill += addSkill;
        }

        private void OnBackMenu(IEventArgs eventArgs)
        {
            m_Contorller.SetState("MenuState", null);
        }


    }
}

