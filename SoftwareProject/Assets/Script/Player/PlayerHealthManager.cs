using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// - Health methods ---------------------------------------------
public class PlayerHealthManager : MonoBehaviour
{
    public int MaxHealth = 100;
    public int CurrentHealth;
    private int fcount = 0;

    // initiation of health
    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    //update called once per frame
    private void Update()
    {
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
        }

        fcount++;
    }

    //dammage with the hit boxes
    private void Hit(int d)
    {
        if (fcount > 5)
        {
            fcount = 0;
            CurrentHealth -= d;
        }
        Debug.Log(CurrentHealth);
    }
}