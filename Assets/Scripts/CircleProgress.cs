using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CircleProgress : MonoBehaviour
{
    private float smoothSpeed = 1f;

    public Image progressCircle;

    private float targetProgress;
    private float currentProgress;

    public RobotCtrl robot;
    public Transform heart;
    // Start is called before the first frame update
    void Start()
    {
        currentProgress = 0.0f;
        targetProgress = 100.0f;       
    }

    // Update is called once per frame
    void Update()
    {
        if(currentProgress < targetProgress)
        {
            currentProgress += smoothSpeed;
            if (currentProgress >= targetProgress)
            {

                heart.GetChild(robot.HeartNow).gameObject.GetComponent<Image>().sprite = Resources.Load<Sprite>("heart");

                robot.HeartNow++;
                
                currentProgress = targetProgress;
                ResetCurrent();
                gameObject.SetActive(false);
            }

            progressCircle.fillAmount = currentProgress / 100;
        }
    }

    public void ResetCurrent()
    {
        currentProgress = 0.0f;
    }
}
