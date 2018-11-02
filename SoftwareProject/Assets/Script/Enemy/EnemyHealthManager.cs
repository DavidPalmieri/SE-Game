using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyHealthManager : MonoBehaviour
{
    public int MaxHealth = 20;
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
        if (fcount > 5) {
            fcount = 0;
            CurrentHealth -= d; }
        Debug.Log(CurrentHealth);
    }
    //dammage with the hit boxes

}
