using System;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;


public class Difficulty : MonoBehaviour {
    Slider mySlider;
    // Use this for initialization
	void Start () {

        mySlider = this.gameObject.GetComponent<Slider>();
    }
	
	// Update is called once per frame
    void Update () {
        DifficultySlider(mySlider.value);
    }
    public void DifficultySlider(float value)
    {
        Debug.Log("Difficulty: " + value);
    }
}
