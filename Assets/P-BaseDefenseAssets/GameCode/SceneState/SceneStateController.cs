﻿using UnityEngine;
using System.Collections;

// 場景狀態控制者
public class SceneStateController
{
    /// <summary>
    /// CurrState当前State
    /// </summary>
	private ISceneState m_State;	
	private bool 	m_bRunBegin = false;

    public ISceneState targetState;
    public string targetName;
    public float targetProcess;

	public SceneStateController()
	{}

    //TODO 
    //先进Loading  然后切换到对应场景及阶段
    public void LoadingState(ISceneState State, string LoadSceneName)
    {
        SetState(new LoadingState(this),"LoadingState");
        targetState = State;
        targetName = LoadSceneName;
    }

    // 設定狀態
    public void SetState(ISceneState State, string LoadSceneName)
	{
        
        //Debug.Log ("SetState:"+State.ToString());
        m_bRunBegin = false;

		// 載入場景
		LoadScene( LoadSceneName );

		// 通知前一個State結束
		if( m_State != null )
			m_State.StateEnd();

		// 設定
		m_State=State;	
	}

	// 載入場景
	private void LoadScene(string LoadSceneName)
	{
		if( LoadSceneName==null || LoadSceneName.Length == 0 )
			return ;
		Application.LoadLevel( LoadSceneName );
	}

	// 更新
	public void StateUpdate()
	{

        // 是否還在載入
        if (Application.isLoadingLevel)
        {
            //targetProcess = Application.
            return;
        }

		// 通知新的State開始
		if( m_State != null && m_bRunBegin==false)
		{
			m_State.StateBegin();
			m_bRunBegin = true;
		}


		if( m_State != null)
			m_State.StateUpdate();
	}
}
