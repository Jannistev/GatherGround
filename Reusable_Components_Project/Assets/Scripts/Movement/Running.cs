using TMPro;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class Running : MonoBehaviour, IStaminaMovement, IPausable
{
    //snelheid dat de speler loopt
    [SerializeField, Header("Speed Settings")] private float _walkingSpeed;
    //snelheid dat de speler sprint
    [SerializeField] private float _sprintSpeed;
    private float _movementSpeed = 1;
    private float _usedSpeed;

    //maximale aantal energie de de speler heeft
    [SerializeField, Header("Energy Settings")] private float _maxEnergy;
    //geeft aan hoe snel de speler moe word
    [SerializeField] private float _tiringSpeed;
    //geeft aan hoe snel de speler weer stamina krijgt
    [SerializeField] private float _recoverySpeed;
    //hoeveel energie de speler nu heeft
    private float _energy;

    //tekst die aangeeft hoeveel stamina de speler heeft
    [SerializeField] private TMP_Text _text;

    public float MovementSpeed { get => _movementSpeed; set => _movementSpeed = Mathf.Clamp(value, 0, Mathf.Infinity); }
    public float Stamina
    {
        get => _energy;
        set
        {
            _energy = Mathf.Clamp(value, 0, Mathf.Infinity);
            _text.text = $"Stamina: {Mathf.RoundToInt(_energy)}/{_maxEnergy}";
        }
    }
    

    private void Start()
    {
        _energy = _maxEnergy;
    }
    /// <summary>
    /// Zorgt ervoor dat de speler beweegt
    /// </summary>
    /// <param name="pRigid">rigidbody die de speler moet bewegen</param>
    public void Move(Rigidbody pRigid)
    {
        CheckInput();

        MoveObject(pRigid);
    }
    /// <summary>
    /// Checkt of de speler moet sprinten of lopen
    /// </summary>
    private void CheckInput()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            OnRunning();
        }
        else
        {
            OnWalking();
        }
   
    }
    private void MoveObject(Rigidbody pRigid)
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movement = transform.forward * verticalInput + transform.right * horizontalInput;
        movement.Normalize();

        Vector3 currentVelocity = pRigid.velocity;
        Vector3 targetVelocity = movement * (_movementSpeed * _usedSpeed);
        pRigid.velocity = new Vector3(targetVelocity.x, currentVelocity.y, targetVelocity.z);
    }   
    /// <summary>
    /// Berekent de snelheid en stamina van de speler als die sprint
    /// </summary>
    private void OnRunning()
    {
        Stamina -= Time.deltaTime * _tiringSpeed;
        Stamina = Mathf.Clamp(_energy, 0, _maxEnergy);

        if (_energy > 0.5f)
            _usedSpeed = _sprintSpeed;
        else
            _usedSpeed = _walkingSpeed;
    }
    /// <summary>
    /// berekent de snelheid en stamina van de speler als die loopt
    /// </summary>
    private void OnWalking()
    {
        Stamina += Time.deltaTime * _recoverySpeed;
        Stamina = Mathf.Clamp(_energy, 0, _maxEnergy);
        _usedSpeed = _walkingSpeed;
    }
}