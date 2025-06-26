using TMPro;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// houd de timer bij hoelang de speler in een bepaald scene is
/// </summary>
public class Timer : MonoBehaviour, IPausable
{
    private TextMeshProUGUI _text;

    [SerializeField] private float _totalTime;
    private float _currentTime;

    [SerializeField] private UnityEvent _onTimesUp;

    public UnityEvent OnTimesUp => _onTimesUp;
    public float TotalTime { get => _totalTime; set => _totalTime = value; }
    public float CurrentTime
    {
        get => _currentTime;
        set
        {
            _currentTime = Mathf.Clamp(value, 0, _totalTime);
        }
    }

    private void Start()
    {
        _text = GetComponent<TextMeshProUGUI>();
        _currentTime = TotalTime;
    }
    private void Update()
    {
        _currentTime -= Time.deltaTime;
        _text.text = $"Time: {Mathf.RoundToInt(_currentTime)}";

        if (_currentTime <= 0)
            _onTimesUp?.Invoke();
    }
    /// <summary>
    /// reset de timer
    /// </summary>
    public void ResetTimer()
    {
        _currentTime = _totalTime;
    }
}
