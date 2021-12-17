using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Blackout : MonoBehaviour
{
    public Image image;
    float elapsed = 0f;
    string sceneName;

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<Image>();
        var tempColor = image.color;
        tempColor.a = 1f;
        image.color = tempColor;
        sceneName = SceneManager.GetActiveScene().name;
    }

    // Update is called once per frame
    void Update()
    {
        if(GlobalVar.Blackout){
            // while(image.color.a < 0.8f){
            //     image.color = Color.Lerp(Color.clear, Color.black, Mathf.PingPong(Time.time, 1));
            // }
            image.color = Color.black;
        }
        else if(GlobalVar.Blink || (!GlobalVar.Blink && image.color.a > 0.1f)){
            image.color = Color.Lerp(Color.clear, Color.black, Mathf.PingPong(Time.time, 1));
        }

        GlobalVar.Dark = !GlobalVar.Blackout && image.color.a>0.85f;
        GlobalVar.Clear = image.color.a<0.5f;

        if(sceneName=="Level 2"){
            elapsed += Time.deltaTime;
            if (elapsed >= 10f) {
                elapsed = elapsed % 10f;
                StartCoroutine(Blink());
            }
        }

        else if(sceneName=="Level 3"){
            elapsed += Time.deltaTime;
            if (elapsed >= 8f) {
                elapsed = elapsed % 8f;
                StartCoroutine(Blink());
            }
        }
    }

    IEnumerator Blink(){
        GlobalVar.Blink = true;
        yield return new WaitForSeconds(1);
        GlobalVar.Blink = false;
    }

    // void Blink() {
    //     print("Blink");
    // }

}
