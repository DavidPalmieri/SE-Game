using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof (Rigidbody2D))]
//[RequireComponent (typeof Seeker))]

public class Basic_AI : MonoBehaviour {
    public Transform target;

    public float updateRate = 2f;

    //private Seeker seeker;

    private Rigidbody2D rb;

    //The clculated path
    public RenderingPath path;

    // AI speed
    public float speed = 300f;
    //way to change between force and inpluse, way for enemy to behave
    public ForceMode2D fmode;

    public bool pathIsEnded = false;



}
