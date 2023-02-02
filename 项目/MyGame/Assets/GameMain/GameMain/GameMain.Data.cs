using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameFrameWork
{
    public partial class GameMain
    {
        public SceneStateC sceneStateC;

        //public StartState StartState;
        //public MainState MainState;
        //public TestState TestState;

        public void StateInit()
        {
            sceneStateC = new SceneStateC();

            //StartState = new StartState(sceneStateC);
            //MainState = new MainState(sceneStateC);
            //TestState = new TestState(sceneStateC);

            //sceneStateC.AddState(Data_StateName.StartState_name, StartState);
            //sceneStateC.AddState(Data_StateName.MainState_name, MainState);
            //sceneStateC.AddState(Data_StateName.TestState_name, TestState);
        }
    }
}


