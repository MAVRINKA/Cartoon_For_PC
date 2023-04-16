// For Directory.GetFiles and Directory.GetDirectories
// For File.Exists, Directory.Exists
using System.IO;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using AlmostEngine.Screenshot;
using UnityEngine.Events;
using System.Collections;

public class FileFolder : MonoBehaviour
{

    public UnityEvent StartRecorder;
    public UnityEvent StopRecorder;

    public int currentImage = 0;
    public float fadeTime = 2f;
    public bool fadefinished = false;

    public float timer1 = 5.0f;
    public float timer1Remaining = 5.0f;
    public bool timer1IsRunning = true;

    private readonly string folder;
    public RawImage photosPrew;

    public List<TextureExporter.ImageFile> m_ImageFiles = new List<TextureExporter.ImageFile>();
    private void Start()
    {

        LoadImageFiles();

        if (Directory.Exists(Application.persistentDataPath))
        {
            Debug.Log("ÅÑÒÜ ÒÀÊÀß ÏÀÏÊÀ");
        }
        //else
        //{
        //    Directory.CreateDirectory(Application.dataPath);
        //}

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
        if (!string.IsNullOrEmpty(Application.persistentDataPath))
        {
            m_ImageFiles = TextureExporter.LoadFromPath(Application.persistentDataPath);
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

        if (currentImage >= m_ImageFiles.Count)
        {
            StartCoroutine(StopRecords());
            currentImage = 0;
        }

        photosPrew.texture = m_ImageFiles[currentImage].m_Texture;
    }

}