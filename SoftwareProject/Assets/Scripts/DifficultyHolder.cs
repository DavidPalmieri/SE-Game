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
    float health;
    void Update()
    {
        PlayerHealth.GetHealth(val);
        adjustValue(val);
    }
    public void adjustValue(float value)
    {
        val = value;
        Debug.Log("value:" + value);
        //return value;
    }
}
