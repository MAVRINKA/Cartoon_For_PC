using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using TMPro;

public class PhotoControl : MonoBehaviour
{
    public GameObject btnComplete;
    public GameObject photoControlParent;
    public GameObject infoPanel;
    public TextMeshProUGUI txtIndexPhoto;
    public int indexPhoto;
    public int MaxPhoto;

    private void Start()
    {
        indexPhoto = MaxPhoto;
    }

    private void Update()
    {
        txtIndexPhoto.text = indexPhoto.ToString();
        
        if(indexPhoto <= 0)
        {
            btnComplete.SetActive(true);
            photoControlParent.SetActive(false);
        } else
        {
            btnComplete.SetActive(false);
            photoControlParent.SetActive(true);
        }
    }

    public void IndexPlus()
    {
        indexPhoto++;
    }

    public void IndexMinus()
    {
        indexPhoto--;
    }

    public void IndexClear()
    {
        indexPhoto = MaxPhoto;
    }

    public void CompleteScene()
    {
        StartCoroutine(Complete());
    }

    public IEnumerator Complete()
    {
        infoPanel.SetActive(true);
        yield return new WaitForSeconds(3);
        FindObjectOfType<SceneManagerScript>().NextSceneIndex(2);
    }

}
