using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    [SerializeField] private Camera mainCam;
    public Transform initialTransform;

    [SerializeField] public GameObject remains;
    [SerializeField] public GameObject explosion;

    public GameObject originalObject;

    public bool isHit;
    public bool isShake;
    bool iszoom;

    private void Start()
    {
        initialTransform.rotation = mainCam.transform.rotation;
    }

    private void Update()
    {
        if (isHit)
        {
            StartCoroutine(DestroyEffect());
            isHit = false;
        }

        if (iszoom)
        {
            mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, 30, .05f);
        }
        else if (!iszoom)
        {
            mainCam.fieldOfView = Mathf.Lerp(mainCam.fieldOfView, 60, .05f);
        }

        //if (isShake)
        //{
        //    StartCoroutine(CameraShake(0.3f, 2f));
        //}
        //else if (!isShake)
        //{
        //    // nothing happens
        //}
    }

    void CameraEffect()
    {
        mainCam.transform.LookAt(remains.transform.position);

        Time.timeScale = 0.5f;
    }

    void Revert()
    {
        Time.timeScale = 1f;

        mainCam.transform.rotation = initialTransform.rotation;
    }

    public IEnumerator DestroyEffect()
    {
        if (isHit)
        {
            CameraEffect();

            iszoom = true;

            yield return new WaitForSeconds(0.8f);

            Revert();

            iszoom = false;
        }
    }

    //public IEnumerator CameraShake(float duration, float magnitude)
    //{
    //    isShake = false;

    //    Vector3 originalPos = mainCam.transform.localPosition;

    //    float elapsed = 0.0f;

    //    while (elapsed < duration)
    //    {
    //        float x = Random.Range(-1f, 1f) * magnitude;
    //        float y = Random.Range(-1f, 1f) * magnitude;

    //        mainCam.transform.localPosition = new Vector3(x, y, originalPos.z);

    //        elapsed += Time.deltaTime;

    //        yield return null;
    //    }

    //    mainCam.transform.localPosition = originalPos;
    //}

}
