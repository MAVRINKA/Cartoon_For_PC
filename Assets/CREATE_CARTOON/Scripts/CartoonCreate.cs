using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UI;
using AlmostEngine.Screenshot;

public class CartoonCreate : MonoBehaviour
{
    public Image image1;
    public Sprite[] SpriteArray;
    
    public RawImage Photos;
    public List<Texture> texturePhotos = new List<Texture>();
    private int currentImage = 0;
    public float fadeTime = 2f;
    public bool fadefinished = false;


    private float deltaTime = 0.0f;

    public float timer1 = 5.0f;
    public float timer1Remaining = 5.0f;
    public bool timer1IsRunning = true;

    private string folder = "C:/Screenshots";

    // Start is called before the first frame update
    void Start()
    {
        if (System.IO.Directory.Exists(folder))
        {
            foreach (string file in System.IO.Directory.GetFiles(folder))
            {
                System.IO.Directory.Delete(file, true);
            }
        }

        image1.sprite = SpriteArray[currentImage];
        //Photos.texture = texturePhotos[currentImage];

        bool timer1IsRunning = false;
        // timer1 should be bigger than fade time 
        timer1Remaining = timer1;

        InvokeRepeating("ChangeImage", timer1, timer1Remaining);
    }

    // Update is called once per frame
    void Update()
    {

        if (timer1IsRunning)
        {
            if (timer1Remaining > 0)
            {
                timer1Remaining -= Time.deltaTime;

                image1.CrossFadeAlpha(1, fadeTime, false);
            }

            else
            {
                Debug.Log("Timer1 has finished!");
                timer1Remaining = timer1;
                fadefinished = true;
                //image1.sprite = SpriteArray[currentImage];
                timer1IsRunning = !timer1IsRunning;

                image1.CrossFadeAlpha(0, fadeTime, false);
            }

        }

        if (Input.GetKey(KeyCode.P))
        {
            //ispaused = !ispaused;
            timer1IsRunning = !timer1IsRunning;
        }
    }

    void fade()
    {
        image1.canvasRenderer.SetAlpha(0.0f);
        image1.sprite = SpriteArray[currentImage];
        timer1Remaining = timer1;
        timer1IsRunning = true;
    }

    public void ChangeImage()
    {
        {
            currentImage++;

            if (currentImage >= SpriteArray.Length)
                currentImage = 0;

            fade();
        }
    }

}