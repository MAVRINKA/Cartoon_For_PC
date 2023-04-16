using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class KeyboardLetter : MonoBehaviour
{
    private string word = null;
    private int wordIndex = 0;
    public TMP_InputField letterName;

    private void Update()
    {
        letterName.text = word;
    }

    public void Alphavite(string alphavite)
    {
        wordIndex++;
        word = word + alphavite;
    }

    public void RemoveLetter()
    {
        if(word.Length > 0)
        word = word.Remove(word.Length - 1, 1);
    }

}
