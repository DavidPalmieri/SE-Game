﻿using UnityEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ApplicationManager : MonoBehaviour {
	

	public void Quit () 
	{
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#else
		Application.Quit();
		#endif
	}
    public void newgame(int x) {
        SceneManager.LoadScene(x);
    }
}
