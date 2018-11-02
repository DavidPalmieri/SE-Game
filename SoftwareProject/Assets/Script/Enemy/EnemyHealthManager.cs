using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    public int MaxHealth = 20;
    public int CurrentHealth;

    // initiation of health
    private void Start(){
        CurrentHealth = MaxHealth;
    }
    //update called once per frame
    private void Update(){
        if(CurrentHealth <= 0) {
            Destroy(gameObject);
        }
    }
    public void SetMaxHealth()
    {
        CurrentHealth = MaxHealth;
    }
    //dammage with the hit boxes
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Attack 1 Box")
        {
            CurrentHealth -= 5;
        }
        else if (other.gameObject.name == "Attack 2 Box")
        {
            CurrentHealth -= 10;
        }
    }
}
