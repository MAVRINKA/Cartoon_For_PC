using AlmostEngine.Screenshot.Extra;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenshotAndroidPath : MonoBehaviour
{

    public GameObject UI_First;
    public GameObject UI_Second;
    public Button PhotoBtn;
    public void TakeAShot()
    {
        StartCoroutine(CaptureIt());
    }

    public IEnumerator CaptureIt()
    {
        BtnNotInteractable();
        UI_First.SetActive(false);
        UI_Second.SetActive(false);
        TimeStamp();
        FileName();
        PathToSave();
        ScreenCapture.CaptureScreenshot(PathToSave());
        yield return new WaitForEndOfFrame();
        UI_First.SetActive(true);
        yield return new WaitForSeconds(1f);
        BtnInteractable();
    }

    public void BtnInteractable()
    {
        PhotoBtn.interactable = true;
        PhotoBtn.GetComponent<Outline>().effectColor = Color.black;
    }
    public void BtnNotInteractable()
    {
        PhotoBtn.interactable = false;
        PhotoBtn.GetComponent<Outline>().effectColor = Color.red;
    }
    private string TimeStamp()
    {
        string timeStamp = System.DateTime.Now.ToString("dd-MM-yyyy-HH-mm-ss");
        return timeStamp;
    }
    private string FileName()
    {
        string fileName = "Screenshot" + TimeStamp() + ".png";
        return fileName;
    }
    private string PathToSave()
    {
        string pathToSave = Application.dataPath + "/Cartoon" + "/" + FileName();
        return pathToSave;
    }
}
