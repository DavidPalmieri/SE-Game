using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawn : MonoBehaviour
{
    public GameObject enemy1;                // The enemy prefab to be spawned.
    public GameObject enemy2;
    public GameObject player;
    public GameObject VictoryText;
    private List<SpawnPionts> SPs = new List<SpawnPionts>();
    private long fCount;
    private long score;
    private float playerPos;
    private float trigger;
    private bool won;


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

        fCount = 0;
        won = false;
    }
    void Update()
    {
        if ((++fCount) % 4 == 0)
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

            if (playerPos > 110 && !won)
            {
                score = fCount;
                won = true;
                VictoryText.SetActive(true);
            }

            if (won && score + 300 < fCount)
            {
                SceneManager.LoadScene(0);
            }
        }
    }
}