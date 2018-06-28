﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TechTweaking.Bluetooth;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	void Start(){
	
		DontDestroyOnLoad (gameObject);
	}

	public void LoadScene(string name){
	
		SceneManager.LoadScene (name);
	}
}
