using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class TestingHandler : MonoBehaviour {

    [SerializeField] private HealthBar healthbar;
    //this testing script will ensure the health bar can reduce if damage is taken
    private void Start()
    {
        float health = 1f;
        FunctionPeriodic.Create(() =>
        {
            if (health > 0)
            {
                health -= .01f;
                healthbar.SetSize(health);
            }
        }, 0.03f);
    }
}
