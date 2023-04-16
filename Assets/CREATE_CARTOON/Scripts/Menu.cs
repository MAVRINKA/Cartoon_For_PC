using System.Collections.Generic;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public TMP_Dropdown dropdown;
    public Button btn_Start;
    //public TextMeshProUGUI debug;
    void Start()
    {

        WebCamDevice[] devices = WebCamTexture.devices;
        dropdown.options.Clear();
        var dr = new List<TMP_Dropdown.OptionData>();
        dr.Add(new TMP_Dropdown.OptionData() { text = "Выберите камеру" });
        for (int i = 0; i < devices.Length; i++)
        {
            dr.Add(new TMP_Dropdown.OptionData() { text = WebCamTexture.devices[i].name.ToString()});
        }

        dropdown.AddOptions(dr);

        //debug.text = Application.persistentDataPath;
    }

    private void Update()
    {
        if (dropdown.value != 0)
        {
            btn_Start.interactable = true;
        } else
        {
            btn_Start.interactable = false;
        }
    }

    public void Play()
    {
        if (dropdown.value != 0)
        {
            PlayerPrefs.SetString("saveCam", dropdown.options[dropdown.value].text);
            SceneManager.LoadScene(1);
        }
    }
    public void Exit()
    {
        Application.Quit();
    }
}
