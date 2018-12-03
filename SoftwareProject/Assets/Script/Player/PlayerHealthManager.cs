using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

// - Health methods ---------------------------------------------
public class PlayerHealthManager : MonoBehaviour
{
    public int MaxHealth = 100;
    public int CurrentHealth;
    private int fcount = 0;
    PlayerHealth phealth;


    // initiation of health
    private void Start()
    {
        GameObject PlayerHealth = GameObject.Find("Player Health");
        //PlayerHealth phealth;
        //phealth = PlayerHealth.GetComponent<PlayerHealth>();

        //CurrentHealth = phealth.getHealth();
        applyDiff();
        CurrentHealth = MaxHealth;
    }

    //update called once per frame
    private void Update()
    {
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
            SceneManager.LoadScene(0);
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

        gameObject.GetComponentInChildren<HealthBarController>().SetSize((float)CurrentHealth / (float)MaxHealth);
    }
    private void applyDiff()
    {
        MaxHealth = PlayerHealth.getHealth();
    }
}