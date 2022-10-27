using UnityEngine;

public class Information : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0f;
    }

    private void OnDestroy()
    {
        Time.timeScale = 1f;
    }

    public void DestroyOnClick()
    {
        Destroy(gameObject);
    }
}
