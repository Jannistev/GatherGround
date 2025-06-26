using UnityEngine;

public class Walking : MonoBehaviour, IMovement, IPausable
{
    //deze component word niet gebruikt in het project

    [SerializeField] private float _movementSpeed;
    
    public float MovementSpeed { get => _movementSpeed; set => _movementSpeed = value; }
  
    /// <summary>
    /// zorgt ervoor dat de speler kan lopen
    /// </summary>
    /// <param name="pRigid"></param>
    public void Move(Rigidbody pRigid)
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * verticalInput + transform.right * horizontalInput;
        movement.Normalize();

        pRigid.velocity = new Vector3(0, pRigid.velocity.y, 0) + movement * _movementSpeed;        
    }
}
