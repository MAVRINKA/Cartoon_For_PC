using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ToTextFile : MonoBehaviour
{
    public TMP_InputField nameCartoonlSend;
    public TMP_InputField namePlayer;
    public TMP_InputField emailSend;

    public void CreateTxtFile()
    {
        if (emailSend.text == "" || nameCartoonlSend.text == "" || namePlayer.text == "")
        {
            return;
        }

        string txtDocumentName = Application.dataPath + "/Logs/" + "Email" + ".txt";

        if (!File.Exists(txtDocumentName))
        {
            File.WriteAllText(txtDocumentName, "КУДА ОТПРАВИТЬ МУЛЬТИКИ");
        }

        File.AppendAllText(txtDocumentName, 
            "\n \n" + "1. " + System.DateTime.Now.ToString("dd'.'MM'.'yy'   'HH':'mm") + 
            "\n" + "2. " + nameCartoonlSend.text + "\n" +
            "3. " + namePlayer.text + "\n" +
            "4. " + emailSend.text);
    }
}
