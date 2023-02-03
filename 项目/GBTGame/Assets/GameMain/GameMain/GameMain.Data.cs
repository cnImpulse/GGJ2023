using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameFrameWork
{
    public partial class GameMain
    {
        public SceneStateC sceneStateC;

        public StartState StartState;
        public EndGameState EndGameState;
        public MainState MainState;
        public MenuState MenuState;
        public SkillState SkillState;
        public AllGameOverState AllGameOverState;
        public AllGameStartState AllGameStartState;
        //public TestState TestState;

        public void StateInit()
        {
            sceneStateC = new SceneStateC();
            StartState = new StartState(sceneStateC);
            EndGameState = new EndGameState(sceneStateC);
            MainState = new MainState(sceneStateC);
            MenuState = new MenuState(sceneStateC);
            SkillState = new SkillState(sceneStateC);
            AllGameOverState = new AllGameOverState(sceneStateC);
            AllGameStartState = new AllGameStartState(sceneStateC);
            //MainState = new MainState(sceneStateC);
            //TestState = new TestState(sceneStateC);

            sceneStateC.AddState(StartState.StateName, StartState);
            sceneStateC.AddState(EndGameState.StateName, EndGameState);
            sceneStateC.AddState(MainState.StateName, MainState);
            sceneStateC.AddState(MenuState.StateName, MenuState);
            sceneStateC.AddState(SkillState.StateName, SkillState);
            sceneStateC.AddState(AllGameOverState.StateName, AllGameOverState);
            sceneStateC.AddState(AllGameStartState.StateName, AllGameStartState);
            sceneStateC.SetState(StartState.StateName);
            //sceneStateC.AddState(Data_StateName.MainState_name, MainState);
            //sceneStateC.AddState(Data_StateName.TestState_name, TestState);
        }
    }
}


