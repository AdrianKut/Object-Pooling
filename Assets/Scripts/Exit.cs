using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    private Button _button;

    private void OnEnable()
    {
        _button = GetComponent<Button>();
        _button.onClick.AddListener(ExitOnClick);
    }

    private void OnDisable()
    {
        _button.onClick.RemoveListener(ExitOnClick);
    }

    public void ExitOnClick()
    {
#if UNITY_EDITOR
        if (EditorApplication.isPlaying)
        {
            EditorApplication.isPlaying = false;
        }
#endif
        Application.Quit();
    }
}
