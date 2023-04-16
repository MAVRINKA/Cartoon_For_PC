using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraList : MonoBehaviour
{

    void Start()
    {
        WebCamDevice[] devices = WebCamTexture.devices;
        for (int i = 0; i < devices.Length; i++)
            Debug.Log(devices[i].name);

        //MicrophonesName
        //foreach (var device in Microphone.devices)
        //{
        //    Debug.Log("Name: " + device);
        //}
    }

}
