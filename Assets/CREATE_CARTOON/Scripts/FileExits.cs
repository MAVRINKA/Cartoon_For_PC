// For Directory.GetFiles and Directory.GetDirectories
// For File.Exists, Directory.Exists
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using AlmostEngine.Screenshot;
using UnityEngine.Events;
using System.Collections;

public class FileExits : MonoBehaviour
{

    public UnityEvent StartRecorder;
    public UnityEvent StopRecorder;

    public int currentImage = 0;
    public float fadeTime = 2f;
    public bool fadefinished = false;

    public float timer1 = 5.0f;
    public float timer1Remaining = 5.0f;
    public bool timer1IsRunning = true;

    private readonly string folder ;
    public RawImage photosPrew;

    public List<TextureExporter.ImageFile> m_ImageFiles = new List<TextureExporter.ImageFile>();
    private void Start()
    {

        if (Directory.Exists(Application.dataPath + "/Cartoon"))
        {
            Debug.Log("ЕСТЬ ТАКАЯ ПАПКА");
        }
        //else
        //{
        //    Directory.CreateDirectory(Application.dataPath);
        //}

        LoadImageFiles();

        for (int i = 0; i < m_ImageFiles.Count - 1; i++)
        {
            Debug.Log(i);
        }

        bool timer1IsRunning = false;
        timer1Remaining = timer1;

        StartRecorder.Invoke();

        InvokeRepeating("ChangeImage", timer1, timer1Remaining);
    }

    private void Update()
    {
        if (timer1IsRunning)
        {
            if (timer1Remaining > 0)
            {
                timer1Remaining -= Time.deltaTime;
            }

            else
            {
                Debug.Log("Timer1 has finished!");
                timer1Remaining = timer1;
                fadefinished = true;
                timer1IsRunning = !timer1IsRunning;
            }
        }

    }

    public virtual void LoadImageFiles()
    {
        m_ImageFiles.Clear();
        if (!string.IsNullOrEmpty(Application.dataPath + "/Cartoon"))
        {
            m_ImageFiles = TextureExporter.LoadFromPath(Application.dataPath + "/Cartoon");
        }
        photosPrew.texture = m_ImageFiles[0].m_Texture;
    }

    public IEnumerator StopRecords()
    {
        yield return new WaitForEndOfFrame();
        StopRecorder?.Invoke();
    }

    public void ChangeImage()
    {
            currentImage++;

        if (currentImage == m_ImageFiles.Count)
        {
            StartCoroutine(StopRecords());
            currentImage = 0;
        }

        photosPrew.texture = m_ImageFiles[currentImage].m_Texture;
    }

}