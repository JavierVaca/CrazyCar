using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StreetMover : MonoBehaviour
{
    public GameObject road1;
    public GameObject road2;
    private Vector3 backPosition;
    private Vector3 startPostion;
    private Vector3 moveDirection;
    public float speed = 1;
    private float startSpeed;
    private bool moveFirst;

    // Start is called before the first frame update
    void Start()
    {
        backPosition = road2.transform.position;
        startPostion = road1.transform.position;
        moveDirection = new Vector3(0,0,-0.1f);
        moveFirst = true;
        startSpeed = speed;
        //backPosition.z += 5.0f;
    }

    // Update is called once per frame
    void Update()
    {
        road1.transform.position = road1.transform.position + moveDirection * speed;
        road2.transform.position = road2.transform.position + moveDirection * speed;
    }

    void OnTriggerEnter(Collider collider)
    {
        if(collider.tag == "Player")
        {
            if(moveFirst)
            {
                road1.transform.position = backPosition;
                moveFirst = false;
            }
            else
            {
                road2.transform.position = backPosition;
                moveFirst = true;
            }
        }
    }

    internal void Reset()
    {
        road1.transform.position = startPostion;
        road2.transform.position = backPosition;
        speed = startSpeed;
        moveFirst = true;
    }
}
