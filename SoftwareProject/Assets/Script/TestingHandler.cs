//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using CodeMonkey.Utils;

//public class TestingHandler : MonoBehaviour
//{

//    [SerializeField] private HealthBar healthBar;
//    //this testing script will ensure the health bar can reduce if damage is taken
//    private void Start()
//    {
//        float health = 1f;
//        FunctionPeriodic.Create(() =>
//        {
//            if (health > 0)
//            {
//                health -= .01f;
//                healthBar.SetSize(health);
//            }
//            if (health < -.3f)
//            {
//                // flashing if under 30% health
//                if ((health * 100f) % 3 == 0)
//                {
//                    healthBar.SetColor(Color.white);
//                }
//                else
//                {
//                    healthBar.SetColor(Color.red);
//                }

//            }
//        }, 0.03f);
//    }
//}
