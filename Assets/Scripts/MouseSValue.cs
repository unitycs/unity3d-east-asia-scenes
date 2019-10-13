using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseSValue : MonoBehaviour
{
    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    public void SliderFunc_MouseSensitivity(Slider slider)
    {
        int a = (int)(slider.value * 300f);
        text.text = a.ToString();
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
