using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] private float _radius;
    [SerializeField] private float _spawnDelay;

    private void Awake()
    {
        SetSpawnSphereSize(_radius);
    }

    private void Start()
    {
        StartCoroutine(InstantiateNewObject());
    }

    public float GetRadius()
    {
        return _radius;
    }

    public float GetSpawnDelay()
    {
        return _spawnDelay;
    }

    public void SetSpawnDelay(float delay)
    {
        _spawnDelay = delay;
    }

    public void SetSpawnSphereSize(float size)
    {
        _radius = size;
        gameObject.transform.localScale = new Vector3(_radius * 2, _radius * 2, _radius * 2);
    }

    private IEnumerator InstantiateNewObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(_spawnDelay);

            var newObject = PoolingManager.Instance.GetObject();
            if (newObject != null)
            {
                newObject.SetActive(true);
                Vector3 randomPosition = (Random.insideUnitSphere * _radius) + transform.position;
                newObject.transform.position = randomPosition;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, _radius);
    }
}
