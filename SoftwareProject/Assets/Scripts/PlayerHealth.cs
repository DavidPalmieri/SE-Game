using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth: MonoBehaviour{

    public static int MaxHealth = 100;
    public int CurrentHealth;
    private int fcount = 0;
    public static PlayerHealth Instance;
    static int val;

    // initiation of health
    private void Start()
    {
        Instance = this;
        CurrentHealth = MaxHealth;
    }

    //update called once per frame
    private void Update()
    {
        if(MaxHealth == 100 || MaxHealth == 75 || MaxHealth == 30){
            MaxHealth = GetHealth((float)val);
            CurrentHealth = MaxHealth;
        }
        Debug.Log("health:" + MaxHealth);
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }
            fcount++;
    }

    //Gives health based on difficulty selected
    public static int GetHealth(float value)
    {
        Debug.Log("In and value is: " + value);
        val =(int) value;
        if(value == 2){
            Debug.Log("value == 2");
            return 75;
        }
        else if (value == 3)
        {
            Debug.Log("Value == 3");
            return 30; 
        }

        Debug.Log("Returning int val of: " + val);
        return 100;
    } 
    //Pulls maxHealth from a static instance
    public static int getHealth()
    {
        return MaxHealth;
    }
}
