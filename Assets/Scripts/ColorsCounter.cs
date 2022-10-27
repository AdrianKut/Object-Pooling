using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;

public class ColorsCounter : MonoBehaviour
{
    public static ColorsCounter Instance;
    private ColorsCounter() { }

    [Header("Texts Counter")]
    [SerializeField] private TextMeshProUGUI _textAllObjects;
    [SerializeField] private TextMeshProUGUI _textCounterBlack;
    [SerializeField] private TextMeshProUGUI _textCounterRed;
    [SerializeField] private TextMeshProUGUI _textCounterPink;
    [SerializeField] private TextMeshProUGUI _textCounterBlue;
    [SerializeField] private TextMeshProUGUI _textCounterGreen;
    [SerializeField] private TextMeshProUGUI _textCounterYellow;

    private Dictionary<string, int> _colorsDictionary = new();
    private Dictionary<string, TextMeshProUGUI> _textsCounterColorDictionary = new();

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            ColorsStartingValues();
            InitialColorsCounterDictionary();
        }
        else
        {
            Destroy(this);
        }
    }

    private void ColorsStartingValues()
    {
        _colorsDictionary.Add("Black", 0);
        _colorsDictionary.Add("Red", 0);
        _colorsDictionary.Add("Pink", 0);
        _colorsDictionary.Add("Blue", 0);
        _colorsDictionary.Add("Green", 0);
        _colorsDictionary.Add("Yellow", 0);
    }

    private void InitialColorsCounterDictionary()
    {
        _textsCounterColorDictionary.Add("Black", _textCounterBlack);
        _textsCounterColorDictionary.Add("Red", _textCounterRed);
        _textsCounterColorDictionary.Add("Pink", _textCounterPink);
        _textsCounterColorDictionary.Add("Blue", _textCounterBlue);
        _textsCounterColorDictionary.Add("Green", _textCounterGreen);
        _textsCounterColorDictionary.Add("Yellow", _textCounterYellow);
    }

    public void IncreaseSelectedColorAmount(string key)
    {
        _colorsDictionary[key] += 1;
        _textsCounterColorDictionary[key].text = key + ": " + _colorsDictionary[key];

        _textAllObjects.text = "" + _colorsDictionary.Values.Sum();
    }

    public void DecreaseSelectedColorAmount(string key)
    {
        _colorsDictionary[key] -= 1;
        _textsCounterColorDictionary[key].text = key + ": " + _colorsDictionary[key];

        _textAllObjects.text = "" + _colorsDictionary.Values.Sum();
    }
}
