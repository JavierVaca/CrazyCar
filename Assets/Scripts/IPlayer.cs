using UnityEngine;
public interface IPlayer
{
    Player Player{ get; }
    Rigidbody Rbd { get; }
    Vector3 Force{ get; }
    bool Grounded{ get; set; }
    Vector3 StartPosition{ get; }
    float JumpSpeed{ get; }
    float Speed{ get; }
}