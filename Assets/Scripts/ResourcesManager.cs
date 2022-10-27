using UnityEngine;

public class ResourcesManager : MonoBehaviour
{
    public static ResourcesManager Instance;
    private ResourcesManager() { }

    [SerializeField] private Material[] _materialsArray;

    private void Awake()
    {
        if (Instance == null)
        {
            InitialMaterials();
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void InitialMaterials()
    {
        _materialsArray = Resources.LoadAll<Material>("Materials/");
    }

    public Material GetRandomMaterial()
    {
        return _materialsArray[Random.Range(0, _materialsArray.Length)];  
    }
}
