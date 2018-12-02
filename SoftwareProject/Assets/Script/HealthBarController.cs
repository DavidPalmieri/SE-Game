using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBarController : MonoBehaviour
{
    public GameObject bar;

    private PlayerHealthManager playerHealth;
    private int mHealth, cHealth;


    // Use this for initialization
    void Start()
    {
        playerHealth = gameObject.GetComponent<PlayerHealthManager>();
    }

    public void Update()
    {

    }

    //controls the health size
    public void SetSize(float healthPercent)
    {
        bar.transform.localScale = new Vector3(healthPercent, 0.77f, 1f);
    }
}