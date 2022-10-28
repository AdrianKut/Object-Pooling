using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SliderManager : MonoBehaviour
{
    [Header("Spawn Radius")]
    [SerializeField] private Slider _sliderRadius;
    [SerializeField] private TextMeshProUGUI _textRadius;

    [Header("Spawn Delay")]
    [SerializeField] private Slider _sliderDelay;
    [SerializeField] private TextMeshProUGUI _textDelay;

    private SpawnManager _playerManager;

    private void Awake()
    {
        _playerManager = GetComponent<SpawnManager>();
    }

    private void Start()
    {
        SetStartingValues();
    }

    private void SetStartingValues()
    {
        _sliderRadius.value = _playerManager.GetRadius();
        _sliderDelay.value = _playerManager.GetSpawnDelay();

        _textRadius.text = _playerManager.GetRadius().ToString();
        _textDelay.text = _playerManager.GetSpawnDelay().ToString();
    }

    public void OnValueRadiusChanged()
    {
        _playerManager.SetSpawnSphereSize(_sliderRadius.value);
        _textRadius.text = _sliderRadius.value.ToString();
    }

    public void OnValueDelayChanged()
    {
        string text = string.Format($"{_sliderDelay.value:F2}");
        _playerManager.SetSpawnDelay(float.Parse(text));
        _textDelay.text = text;
    }
}
