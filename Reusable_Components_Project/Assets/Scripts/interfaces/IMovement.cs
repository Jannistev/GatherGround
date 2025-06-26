using UnityEngine;
/// <summary>
/// Interface voor scripts met movement
/// </summary>
public interface IMovement
{
    public float MovementSpeed { get; set; }

    public void Move(Rigidbody pRigid);
}
/// <summary>
/// Interface voor scripts met movement met stamina
/// </summary>
public interface IStaminaMovement : IMovement
{
    public float Stamina { get; set; }
}

