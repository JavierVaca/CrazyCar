using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour, IPlayer
{
    private Player player;
    public Player Player { get {return player;} }
    private Rigidbody rbd;
     public Rigidbody Rbd { get {return rbd;} }
    private Vector3 force;
    public Vector3 Force { get {return force;} }
    private bool grounded;
    public bool Grounded { get {return grounded;} set{ this.grounded = value; }}
    private Vector3 startPosition;
    public Vector3 StartPosition { get {return startPosition;} }
    [SerializeField]
    public UnityEvent OnDieEvent;
    public float jumpSpeed = 50f;
    public float JumpSpeed { get {return jumpSpeed;} }
    public float speed = 200f;
    public float Speed { get {return speed;} }

    // Start is called before the first frame update
    void Start()
    {
        player= new Player(this);  
        rbd = GetComponent<Rigidbody>(); 
        Grounded = true;
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        force = player.GetMoveDirection(Grounded);      
    }

    void FixedUpdate() {
        player.Move(force, transform.position);
    }

    void OnCollisionEnter(Collision other) {
        if(other.gameObject.tag == "Floor")
        {
            Grounded = true;
        }
        else if(other.gameObject.tag == "Car")
        {
            Die();
        }
    }

    internal void ResetPosition()
    {
        transform.position = startPosition;
    }

    void Die()
    {
        Debug.Log("Death");
        OnDieEvent.Invoke();
    }
}
      