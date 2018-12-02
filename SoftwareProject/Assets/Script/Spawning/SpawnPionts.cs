using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnPionts
{
    private float Trigger;
    private int Spawns;
    private GameObject Enemy;
    private bool Triggered;

    public SpawnPionts(float trigger, int spawns, GameObject enemy)
    {
        Trigger = trigger;
        Spawns = spawns;
        Enemy = enemy;
        Triggered = false;
    }

    public float getTrigger()
    {
        return Trigger;
    }

    public bool getTriggered()
    {
        return Triggered;
    }
    public void setTriggered(bool triggered)
    {
        Triggered = triggered;
    }

    public void SpawnEnemy()
    {
        Vector3 SP;
        float x, y = 5, z;

        for (int i = 1; i <= Spawns; i++)
        {
            //generate the Z cordinate for spawning
            z = (float)(10.0 / (Spawns + 1)) * i - 5;

            //generate the X cordinate for spawning, stagger the enemies
            if (i % 2 == 0)
            {
                x = Trigger + 12;
            }
            else
            {
                x = Trigger + 10;
            }

            SP = new Vector3(x, y, z);
            GameObject newGO = GameObject.Instantiate(Enemy, SP, Enemy.transform.rotation) as GameObject;
        }
    }
}
