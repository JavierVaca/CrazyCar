using UnityEngine;

public class PlayerInput : IPlayerInput 
{
    public float Horizontal => Input.GetAxis("Horizontal");
    public bool JumpVertical => Input.GetKey(KeyCode.O);
}