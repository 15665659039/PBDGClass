using UnityEngine;
using System;
using System.Collections;

// 遊戲主迴圈
public class GameLoop : MonoBehaviour 
{
	// 场景状态
	SceneStateController m_SceneStateController = new SceneStateController();
	void Awake()
	{
		// 切换场景不被删除
		GameObject.DontDestroyOnLoad( this.gameObject );
		// 乱数种子
		UnityEngine.Random.seed =(int)DateTime.Now.Ticks;
	}
	void Start () 
	{
		// 设定起始的场景
		m_SceneStateController.SetState(new StartState(m_SceneStateController), "");
	}

	// Update is called once per frame
	void Update () 
	{
		m_SceneStateController.StateUpdate();	
	}
}
