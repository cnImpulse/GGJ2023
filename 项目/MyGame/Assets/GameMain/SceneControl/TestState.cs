using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DataCs;

namespace MyGameFrameWork
{
    public class TestState : ISceneState
    {
        public TestState(SceneStateC c) : base(c)
        {
            this.StateName = "TestState";
        }

        public override void StateBegin(System.Object obj)
        {
            UISystem.Instance.OpenUIForm(Data_UIFormID.key_TestForm);

        }

        public override void StateUpdate()
        {

        }

        public override void StateEnd()
        {

        }

        
    }
}
