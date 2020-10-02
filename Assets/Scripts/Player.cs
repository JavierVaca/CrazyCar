using System;
using UnityEngine;

public class Player {
    public IPlayerInput playerInput;
    private IPlayer player;

    public Player(IPlayer player)
    {
        playerInput = new PlayerInput();
        this.player = player;
    }

     public Vector3 GetMoveDirection(bool grounded)
    {
        Vector3 direction = new Vector3();
        if(playerInput.Horizontal > 0)
        {
            direction.x = 1;
        }
        else if(playerInput.Horizontal < 0)
        {
            direction.x = -1;
        }
        if(playerInput.JumpVertical && grounded)
        {
            direction.y = 1;
        }
        return direction;
    }

    internal void Move(Vector3 force, Vector3 position)
    {
        if(player.Grounded)
        {
            if(force.y > 0)
            {
                player.Rbd.AddForce(new Vector3(0, force.y, 0) * player.JumpSpeed);
                player.Grounded = false;
                force.y = 0;
            }
            player.Rbd.MovePosition(position + force * player.Speed * Time.deltaTime);
        }
    }
}