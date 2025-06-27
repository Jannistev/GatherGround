using UnityEngine;
/// <summary>
/// component die ervoor zorgt dat de speler kan springen
/// </summary>
public class DoubleJumper : MonoBehaviour, IUpForce, IPausable
{
    [SerializeField] private float _jumpForce;
    [SerializeField] private float _groundDistance;

    private bool _canDoubleJump;

    public float JumpForce { get => _jumpForce; set => _jumpForce = value; }
    public float GroundDistance { get => _groundDistance; set => _groundDistance = value; }

    /// <summary>
    /// functie die checkt of de speler gaat springen en kan double jumpen
    /// </summary>
    /// <param name="pRigid"></param>
    public void Jump(Rigidbody pRigid)
    {
        //print(Physics.Raycast(pRigid.transform.position, Vector3.down, _groundDistance));

        if (Input.GetButtonDown("Jump") && IsGrounded(pRigid))
        {
            pRigid.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _canDoubleJump = true;
        }
        else if (Input.GetButtonDown("Jump") && _canDoubleJump)
        {
            pRigid.AddForce(Vector3.up * _jumpForce, ForceMode.Impulse);
            _canDoubleJump = false;
        }
    }
    /// <summary>
    /// Checkt of de speler op de grond staat
    /// </summary>
    /// <returns></returns>
    public bool IsGrounded(Rigidbody pRigid)
    {
        return Physics.Raycast(pRigid.transform.position, Vector3.down, _groundDistance);
    }
}
