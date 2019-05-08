using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using System.Text;


public class Background : MonoBehaviour
{
    public bool gamestart = false;
    public float cursorx; 
    public float cursory; 
    public static int ParticipantID = 2;
    public BlueCircle bluecircle;
    string path = @"C:\Users\IMLAB\Desktop\data_2dtask\" + ParticipantID + "_"+"data.txt";



    void OnGUI()
    {
       Event m_Event = Event.current;
        if (m_Event.type == EventType.MouseDown)
            {
                bluecircle.NextTargetSet();
                ScreenText.InternalBlock += 1;
            }
    }


    // Start is called before the first frame update
    //void start()
    //{
     

    //}

    //// Update is called once per frame
    void Update()
    {
        //Debug.Log(gamestart);

        //Debug.Log(gamestart);
        cursorx = Input.mousePosition.x;
        cursory = Input.mousePosition.y;

        if (!BlueCircle.ClickSuccess)
        {
            if (!File.Exists(path))
            {
                // Create a file to write to.
                string createText = cursorx + "_" +
                    cursory + "_" +
                    BlueCircle.ballx + "," +
                    BlueCircle.bally + "_" +
                    Time.fixedTime + "_" +
                    Time.deltaTime + "_" +
                    BlueCircle.BlockCount + "_" +
                    Environment.NewLine;
                File.WriteAllText(path, createText);
            }

            string appendText = cursorx + "_" +
                    cursory + "_" +
                    BlueCircle.ballx + "," +
                    BlueCircle.bally + "_" +
                    Time.fixedTime + "_" +
                    Time.deltaTime + "_" +
                    BlueCircle.BlockCount + "_" +
                    Environment.NewLine;
            File.AppendAllText(path, appendText);

        }

    }
}
