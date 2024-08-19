using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class LoadingState : ISceneState
{
    public LoadingState(SceneStateController Controller) : base(Controller)
    {
        this.StateName = "LoadingState";
    }

    public override void StateBegin()
    {
        m_Controller.SetState(m_Controller.targetState, m_Controller.targetName);
    }
    public override void StateUpdate()
    {
        //TODO  进度条设计
        //m_Controller.targetProcess
    }
    public override void StateEnd()
    {
        
    }

}

