using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FolderCreate : MonoBehaviour
{
    void Start()
    {
        Directory.CreateDirectory(Application.dataPath + "/Logs");
        Directory.CreateDirectory(Application.dataPath + "/Cartoon");
    }
}
