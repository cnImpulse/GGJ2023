using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace MyGameFrameWork
{
    public class ISceneState
    {
        private string m_StateName = "";

        public string StateName
        {
            get { return m_StateName; }
            set { m_StateName = value; }
        }
        protected SceneStateC m_Contorller = null;//×´Ì¬¿ØÖÆÆ÷

        public ISceneState() { }

        public ISceneState(SceneStateC ssc)
        {
            m_Contorller = ssc;
        }

        public virtual void StateBegin(System.Object obj) { }

        public virtual void StateUpdate() { }

        public virtual void StateEnd() { }

        public override string ToString()
        {
            return m_StateName;
        }
    }
}

