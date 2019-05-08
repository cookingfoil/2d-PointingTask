using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainButtonClick : MonoBehaviour
{
    public GameObject textBox;

    // Update is called once per frame
    public void ClickTheButton()
    {
        textBox.SetActive(true);
        
    }
}
