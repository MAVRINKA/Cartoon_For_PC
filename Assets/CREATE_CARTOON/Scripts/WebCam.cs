using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WebCam : MonoBehaviour
{

    public string _nameDevice; //переменная с названием камеры
    WebCamTexture webcamTexture;

    public GameObject infoPanel;

    private void Awake()
    {
        InitCam();
    }

    void Start()

    {
        webcamTexture = new WebCamTexture();
        //WebCamDevice[] devices = WebCamTexture.devices; 
        webcamTexture.deviceName = _nameDevice;
        GetComponent<MeshRenderer>().material.mainTexture = webcamTexture; 
        webcamTexture.Play();
    }

    public void StopCam()
    {
        StartCoroutine(StopWebCam());
    }

    public IEnumerator StopWebCam()
    {
        webcamTexture.Stop();
        GetComponent<MeshRenderer>().material.mainTexture = null;
        yield return new WaitForEndOfFrame();
    }

    void InitCam()
    {
        _nameDevice = PlayerPrefs.GetString("saveCam");
    }

}
