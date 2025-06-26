using UnityEngine;
/// <summary>
/// component die ervoor zorgt dat de speler kan springen
/// </summary>
public class Jumper : MonoBehaviour, IUpForce, IPausable
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _groundDistance;
   
    public float JumpForce { get => _jumpForce; set => _jumpForce = value; }
    public float GroundDistance { get => _groundDistance; set => _groundDistance = value; }
  
    /// <summary>
    /// functie die checkt of de speler gaat springen
    /// </summary>
    /// <param name="pRigid"></param>
    public void Jump(Rigidbody pRigid)
    {
        print(Physics.Raycast(transform.position, Vector3.down, _groundDistance));

        if (Input.GetButtonDown("Jump") && IsGrounded()) 
        {
            pRigid.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
        }
    }
    /// <summary>
    /// Checkt of de speler op de grond staat
    /// </summary>
    /// <returns></returns>
    public bool IsGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, _groundDistance);
    }
}
