using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LoadingbarControl : MonoBehaviour
{
    public Image circleFillImage;
    public TextMeshProUGUI txtLoadingBar;
    public GameObject previewCartoon;
    public GameObject mainLoadingBar;
    public GameObject txtUI;

    void Update()
    {
        FillCircleValue();
        if(circleFillImage.fillAmount >= 1f)
        {
            mainLoadingBar.SetActive(false);
            previewCartoon.SetActive(true);
            txtUI.SetActive(true);
        }
    }

    void FillCircleValue()
    {
        circleFillImage.fillAmount += Time.deltaTime * 0.2f;
        txtLoadingBar.text =  (circleFillImage.fillAmount * 100).ToString("f0") + "%";
    }
}