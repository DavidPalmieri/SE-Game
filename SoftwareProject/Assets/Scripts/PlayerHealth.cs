using System;
using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth: MonoBehaviour{

    public int MaxHealth = 100;
    public int CurrentHealth;
    private int fcount = 0;
    public static PlayerHealth Instance;
    static int val;
    //GameObject Difficulty= GameObject.Find("Difficulty");
    //float value = Difficulty.GetComponent<DifficultyHolder>().val;



    // initiation of health
    private void Start()
    {
        Instance = this;
        //GameObject Difficulty = GameObject.Find("Difficulty");
        //MaxHealth = GetHealth(Difficulty.GetComponent<DifficultyHolder>().val);
        CurrentHealth = MaxHealth;
    }

    //update called once per frame
    private void Update()
    {
        if(MaxHealth == 100 || MaxHealth == 75 || MaxHealth == 50){
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

    //damage with the hit boxes
    private void Hit(int d)
    {
        if (fcount > 5)
        {
            fcount = 0;
            CurrentHealth -= d;
        }
            Debug.Log(CurrentHealth);
        }
        
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
            return 50; 
        }

        Debug.Log("Returning int val of: " + val);
        return 100;
    } 
}
