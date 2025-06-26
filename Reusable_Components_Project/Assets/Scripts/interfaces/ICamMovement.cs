using UnityEngine;

/// <summary>
/// Interface met gegevens van cameramovement
/// </summary>
public interface ICamMovement
{
    public float SensitivityX { get; set; }
    public float SensitivityY { get; set; }

    public void Init(Camera pCam);
    public void MoveCam(Camera pCam); 
}
