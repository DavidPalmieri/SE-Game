using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DifficultyHolder : MonoBehaviour {
    public float val=1;
    public float MaxHealth;
    // Use this for initialization
    void start()
    {
        GameObject PlayerHealth = GameObject.Find("Player Health");

    }

    //Called once per frame
    void Update()
    {
        PlayerHealth.GetHealth(val);
        adjustValue(val);
    }
    //Changes the value when the slider is moved.
    public void adjustValue(float value)
    {
        val = value;
        Debug.Log("value:" + value);
        //return value;
    }
}
