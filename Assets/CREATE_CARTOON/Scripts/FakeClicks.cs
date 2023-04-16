using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FakeClicks : MonoBehaviour
{
    [SerializeField] GameObject[] buttons;
    public int buttonIndex; 

    void Update()
    {
         if(Input.inputString == "1")
        {
            buttonIndex -= 1;
            if(buttonIndex >= 0 && buttonIndex < buttons.Length)
            {
                ExecuteEvents.Execute(buttons[buttonIndex], new PointerEventData(EventSystem.current), ExecuteEvents.pointerEnterHandler);
            }
        }
    }
}
