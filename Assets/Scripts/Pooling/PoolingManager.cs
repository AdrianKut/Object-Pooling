using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

public class PoolingManager : MonoBehaviour
{
    public static PoolingManager Instance;
    private PoolingManager() { }

    [SerializeField] private GameObject _prefab;
    [SerializeField] private int _amount;
    [SerializeField] private List<GameObject> _listPool;

    private void Awake()
    {
        if (Instance == null)
        {
            DOTween.SetTweensCapacity(5000, 500);
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        InitialPool();
    }

    private void InitialPool()
    {
        _listPool = new List<GameObject>();

        for (int i = 0; i < _amount; i++)
        {
            var newPoolingObject = Instantiate(_prefab, transform.position, Quaternion.identity);
            newPoolingObject.SetActive(false);
            newPoolingObject.transform.SetParent(transform);
            _listPool.Add(newPoolingObject);
        }
    }

    public GameObject GetObject()
    {
        foreach (var item in _listPool)
        {
            if (item.activeInHierarchy == false)
            {
                return item;
            }
        }
        return null;
    }
}
