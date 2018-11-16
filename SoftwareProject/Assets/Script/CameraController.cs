using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject Char;       //Public variable to store a reference to the Char game object

    public int facingRight = 1;

    private Vector3 offset;         //Private variable to store the offset distance between the Char and camera
    private Vector3 nOffset;

    // Use this for initialization
    void Start()
    {
        //Calculate and store the offset value by getting the distance between the Char's position and camera's position.
        offset = transform.position - Char.transform.position;
        nOffset = new Vector3(0, offset.y, offset.z);
    }

    // LateUpdate is called after Update each frame
    void LateUpdate()
    {
        // Set the position of the camera's transform to be the same as the Char's, but offset by the calculated offset distance.
        float move = Input.GetAxis("Horizontal");

        //flip camera
        if (move == 0)
            facingRight = 0;
        else if (move > 0 && facingRight > -1)
            facingRight = -1;
        else if (move < 0 && facingRight < 1)
            facingRight = 1;

        if (facingRight == 0)
            transform.position = Char.transform.position + nOffset;
        else if (facingRight == 1)
            transform.position = new Vector3(Char.transform.position.x - offset.x, Char.transform.position.y + offset.y, Char.transform.position.z + offset.z);
        else if (facingRight == -1)
            transform.position = Char.transform.position + offset;
    }
}
