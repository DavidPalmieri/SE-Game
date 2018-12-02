using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemy1;                // The enemy prefab to be spawned.
    public GameObject enemy2;
    public GameObject player;
    private List<SpawnPionts> SPs = new List<SpawnPionts>();
    private int fcount;
    private float playerPos;
    private float trigger;

    void Start()
    {
        // add Spawn Points
        SPs.Add(new SpawnPionts(-90, 1, enemy1));
        SPs.Add(new SpawnPionts(-60, 2, enemy1));
        SPs.Add(new SpawnPionts(-30, 2, enemy1));
        SPs.Add(new SpawnPionts(0, 3, enemy1));
        SPs.Add(new SpawnPionts(30, 4, enemy1));
        SPs.Add(new SpawnPionts(60, 4, enemy1));
        SPs.Add(new SpawnPionts(90, 5, enemy1));

        fcount = 0;
    }
    void Update()
    {
        if (++fcount > 6)
        {
            playerPos = player.GetComponent<Rigidbody>().transform.position.x;

            foreach (SpawnPionts SP in SPs)
            {
                trigger = SP.getTrigger();

                if (!SP.getTriggered() && playerPos > trigger && playerPos < trigger + 2)
                {
                    SP.setTriggered(true);
                    SP.SpawnEnemy();
                }
            }
        }
        else if (fcount > 12)
        {
            fcount = 0;
        }

    }
}