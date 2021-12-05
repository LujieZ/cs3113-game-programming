using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 using UnityEngine.UI;
public class Blackout : MonoBehaviour
{
    public Image image;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        var tempColor = image.color;
        tempColor.a = 1f;
        image.color = tempColor;
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalVar.Blackout || (!GlobalVar.Blackout && image.color.a > 0.1f)){
            image.color = Color.Lerp(Color.clear, Color.black, Mathf.PingPong(Time.time, 1));
        }

        GlobalVar.Dark = image.color.a>0.85f;
        
    }

}
