using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SpawnPionts {
    private int Trigger;
    private int Spawns;

    public SpawnPionts(int trigger, int spawns)
    {
        Trigger = trigger;
        Spawns = spawns;
    }

    public void SpawnEnemy(GameObject toSpawn)
    {
        Vector3 SP;
        float x, y=0, z;

        for (int i = 0; i < Spawns; i++)
        {
            z = (float)10.0 / (Spawns + 1) - 5;
            if (i%2==0)
            {
                x = Trigger + 5;
            }
            else
            {
                x = Trigger + 7;
            }

            SP = new Vector3(x, y, z);
            GameObject newGO = GameObject.Instantiate(toSpawn, SP, toSpawn.transform.rotation) as GameObject;
        }

    }
}
