using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour {

    public int MaxHealth;
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
    public void HurtEnemy (int damageDelt){
        CurrentHealth -= damageDelt;
    }
    public void SetMaxHealth()
    {
        CurrentHealth = MaxHealth;
    }
}
