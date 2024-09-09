using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingZone : MonoBehaviour
{
    [SerializeField]
    private Slider _slider;
    [SerializeField]
    private GameObject _loadingCanvas;

    [HideInInspector]
    public float loadingSpeed = 4f;

    private IEnumerator coroutine;


    protected virtual void OnTriggerEnter(Collider other)
    {

        StartLoading(other);
    }

    protected void StartLoading(Collider other)
    {
        _loadingCanvas.SetActive(true);
        _slider.value = 0;
        coroutine = LoadingCoroutine(other);
        StartCoroutine(coroutine);
    }


    protected virtual void OnTriggerExit(Collider other)
    {
        if (coroutine != null)
        {
            StopCoroutine(coroutine);
        }
        _loadingCanvas.SetActive(false);
    }

    private IEnumerator LoadingCoroutine(Collider collider)
    {
        float progress = 0;
        while (progress < 1f)
        {
            yield return new WaitForEndOfFrame();
            progress += Time.deltaTime * loadingSpeed;
            _slider.value = progress;
        }
        // loading complited
        LoadingCompleted(collider);
    }

    protected virtual void LoadingCompleted(Collider player)
    {
        _loadingCanvas.SetActive(false);
    }
}
