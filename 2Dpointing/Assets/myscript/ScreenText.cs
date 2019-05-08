using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScreenText : MonoBehaviour
{
    //public int BlockCount;
    public GameObject BlockDisplay;
    public static int InternalBlock;
    public int SuccessBlock;
    public int FailBlock;

    public Button mybutton;
    //private bool isBtnDown = false;
    
    
    private void Start()
    {
        
    }
   
    private void Update()
    {
        InternalBlock = BlueCircle.BlockCount;
        SuccessBlock = BlueCircle.success;
        BlockDisplay.GetComponent<Text>().text = "Trials : " + InternalBlock + "\n" + "Success : " + SuccessBlock;
        

        //BlockDisplay.GetComponent<Text>().text = "Success : " + SuccessBlock;
        //FailBlock = BlueCircle.BlockCount - BlueCircle.success;
        //BlockDisplay.GetComponent<Text>().text = "Fail : " + FailBlock;

        //Debug.Log(isBtnDown);
    }
}
