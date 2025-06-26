using UnityEngine;

public class CameraMovement : MonoBehaviour, ICamMovement, IPausable
{  
    [SerializeField, Header("Cam Settings")] private Camera _camera;
    [SerializeField] private float _offsetX;
    [SerializeField] private float _offsetY;
    [SerializeField] private float _offsetZ;
    private Vector3 _offsets;

    [SerializeField, Header("Sensitivity Settings")] private float _sensX = 600f;
    [SerializeField] private float _sensY = 600f;

    [SerializeField, Header("Clamping")] private float _minClampY = -90f;
    [SerializeField] private float _maxClampY = 90f;

    private float _rotationX;
    private float _rotationY;

    public float SensitivityX { get => _sensX; set => _sensX = value; }
    public float SensitivityY { get => _sensY; set => _sensY = value; }

    /// <summary>
    /// Stel camera positie in
    /// </summary>
    /// <param name="pCamera"></param>
    public void Init(Camera pCamera)
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        //pCamera.transform.position = new Vector3(transform.position.x + _offsetX, transform.position.y + _offsetY, transform.position.z + _offsetZ);
        _offsets = new Vector3(_offsetX, _offsetY, _offsetZ);
        pCamera.transform.position += _offsets;
    }
    /// <summary>
    /// Beweegt de camera met je muis
    /// </summary>
    /// <param name="pCam"></param>
    public void MoveCam(Camera pCam)
    {
        float mouseX = Input.GetAxis("Mouse X") * _sensX * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * _sensY * Time.deltaTime;

        _rotationY += mouseX;
        _rotationX -= mouseY;
        _rotationX = Mathf.Clamp(_rotationX, _minClampY, _maxClampY);

        pCam.transform.localRotation = Quaternion.Euler(_rotationX, _rotationY, 0);
        transform.rotation = Quaternion.Euler(0, _rotationY, 0);

        pCam.transform.position = transform.position + _offsets;
    }
}
