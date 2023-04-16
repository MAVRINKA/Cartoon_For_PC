using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class ScreenshotPreview : MonoBehaviour
{
    public GameObject canvas;
    string[] files = null;
    int whichScreenshotIsShown = 0;
    void Start()
    {
        files = Directory.GetFiles(Application.dataPath + "/Cartoon" + "/", "*.png");
        if(files.Length > 0)
        {
            GetPictureAndShowIt();
        }

        for (int i = 0; i < files.Length - 1; i++)
        {
            Debug.Log(i);
        }
        
    }

    void GetPictureAndShowIt()
    {
        string pathToFile = files[whichScreenshotIsShown];
        Texture2D texture = GetScreenshoImage(pathToFile);
        Sprite sp = Sprite.Create(texture, new Rect(0, 0, texture.width, texture.height), new Vector2(0.5f, 0.5f));
        canvas.GetComponent<Image>().sprite = sp;
    }

    Texture2D GetScreenshoImage(string filePath)
    {
        Texture2D texture = null;
        byte[] fileBytes;

        if (File.Exists(filePath)) 
        {
            fileBytes = File.ReadAllBytes(filePath);
            texture = new Texture2D(2, 2, TextureFormat.RGB24, false);
            texture.LoadImage(fileBytes);
        }

        return texture;
    }

    public void NextPicture()
    {
        if(files.Length > 0)
        {
            whichScreenshotIsShown += 1;
            if(whichScreenshotIsShown > files.Length - 1)
            {
                whichScreenshotIsShown = 0;
                GetPictureAndShowIt();
            }
        }
    }


    public void PreviewsPicture()
    {
        if (files.Length > 0)
        {
            whichScreenshotIsShown -= 1;
            if (whichScreenshotIsShown < 0)
            {
                whichScreenshotIsShown = files.Length - 1;
                GetPictureAndShowIt();
            }
        }
    }
}
