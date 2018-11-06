using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour {
    public GameObject enemy;                // The enemy prefab to be spawned.
    public GameObject player;            
    public Transform[] spawnPoints;         // An array of the spawn points this enemy can spawn from.
    private Vector3 SP;

    void Start()
    { SP = enemy.transform.position; }
    void Update()
    {
        if(Input.GetKeyDown ("/"))
            Instantiate(enemy, enemy.transform.position , enemy.transform.rotation);
    }
}