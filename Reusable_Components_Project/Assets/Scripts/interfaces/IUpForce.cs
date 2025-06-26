using UnityEngine;

/// <summary>
/// Interface voor verschillende upforces zoals jump
/// </summary>
public interface IUpForce
{
    public float JumpForce { get; set; }
    public void Jump(Rigidbody _rigid);
}