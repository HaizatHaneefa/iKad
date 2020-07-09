using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Vuforia;

public class GameManager : MonoBehaviour
{
    bool isOn;

    void Start()
    {
        StartCoroutine(SetFocus());
    }

    void Update()
    {

    }

    public void Reset()
    {
        SceneManager.LoadScene(0);
    }

    public void OpenSite()
    {
        Application.OpenURL("put the link here nanti ye");
    }

    public void Flashlight()
    {
        if (!isOn)
        {
            CameraDevice.Instance.SetFlashTorchMode(true);
            isOn = true;
        }
        else if (isOn)
        {
            CameraDevice.Instance.SetFlashTorchMode(false);
            isOn = false;
        }
    }

    IEnumerator SetFocus()
    {
        yield return new WaitForSeconds(3);

        CameraDevice.Instance.SetFocusMode(CameraDevice.FocusMode.FOCUS_MODE_CONTINUOUSAUTO);
    }
}
