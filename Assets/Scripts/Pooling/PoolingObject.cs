using DG.Tweening;
using System.Collections;
using UnityEngine;

public class PoolingObject : MonoBehaviour
{
    [SerializeField] private float _fadeTime = 1f;
    [SerializeField] private float _joinForce;
    private Material _material;
    private Rigidbody _rigidbody;
    private ColorsCounter _colorsCounter;
    private ResourcesManager _resourcesManager;

    private void OnEnable()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _colorsCounter = ColorsCounter.Instance;
        _resourcesManager = ResourcesManager.Instance;
        StartCoroutine(FadingMaterial());
    }

    private void OnDisable()
    {
        _colorsCounter.DecreaseSelectedColorAmount(_material.name);
    }

    private void FixedUpdate()
    {
        _rigidbody.AddForce(transform.localPosition * -_joinForce);
    }

    private IEnumerator FadingMaterial()
    {
        Renderer renderer = GetComponent<Renderer>();
        _material = _resourcesManager.GetRandomMaterial();

        _colorsCounter.IncreaseSelectedColorAmount(_material.name);
        
        renderer.material = _material;

        renderer.material.DOFade(1f, _fadeTime);
        yield return new WaitForSeconds(_fadeTime);
        renderer.material.DOFade(0f, _fadeTime);
        yield return new WaitForSeconds(_fadeTime);

        gameObject.SetActive(false);
    }
}
