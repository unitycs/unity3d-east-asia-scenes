using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DayTimer : MonoBehaviour
{
    public MenuCtrl menu;

    private Text timetext;
    private float lastTime;
    private float curTime;

    private int minute;
    private int hour;
    // Start is called before the first frame update
    void Start()
    {
        timetext = GetComponent<Text>();
        lastTime = Time.time;
        hour = 12;
        minute = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (menu.isMenu) return;
        curTime = Time.time;
        if(curTime - lastTime >= Time.deltaTime*150)
        {
            Debug.Log("work");
            lastTime = curTime;
            minute += 10;
            if(minute>=60)
            {
                minute = 0;
                hour++;
                if (hour >= 24) hour = 0;
            }

            timetext.text = string.Format("{0:00}:{1:00}", hour, minute);
        }
    }
}
