using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject enemy;                // The enemy prefab to be spawned.
    public GameObject player;
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    private Vector3 SP;

    void Start()
    {
        
    }
    void Update()
    {
        SP = new Vector3(player.transform.position.x + 7, player.transform.position.y, player.transform.position.z);

        if (Input.GetKeyDown(KeyCode.P))
            Instantiate(enemy, SP, enemy.transform.rotation);
    }
}