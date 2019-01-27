using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UiTimer : MonoBehaviour
{
    public static float timer;
    public bool timeStarted = true;
    private GUIStyle guiStyle = new GUIStyle();

    void Update()
    {
        if (timeStarted == true)
        {
            timer += Time.deltaTime;
        }
    }

    void OnGUI()
    {
        int minutes = Mathf.FloorToInt(timer / 60F);
        int seconds = Mathf.FloorToInt(timer - minutes * 60);
        string niceTime = string.Format("{0:0}:{1:00}", minutes, seconds);
        guiStyle.fontSize = 40; //change the font size
        guiStyle.normal.textColor = Color.red;
        GUI.Label(new Rect(10, 10, 500, 500), niceTime, guiStyle);
    }

    public void StopTimer()
    {
        timeStarted = false;
    }
}
