using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    Animator _animator;

    float duration = 6f;
    private float t = 0;
    bool isReset = false;
    public Material bodyMaterial;
    public Material mouthMaterial;
    Color final;


    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
        final = new Vector4(0.4056604f, 0f, 0f);
        StartCoroutine(MoveOverSeconds(new Vector3 (0.0f, 1.43f, -6.25f), 1f));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        StartCoroutine(SpeedControl());
        ColorChanger();

    }

    IEnumerator SpeedControl()
    {
        yield return new WaitForSeconds(0.5f);
        if (_animator.speed < 5f){
            _animator.speed += 0.02f;
        }
    }


    public IEnumerator MoveOverSeconds (Vector3 end, float seconds)
    {
        float elapsedTime = 0;
        Vector3 startingPos = transform.position;
        while (elapsedTime < seconds)
        {
            transform.position = Vector3.Lerp(startingPos, end, (elapsedTime / seconds));
            elapsedTime += Time.deltaTime;
            yield return new WaitForEndOfFrame();
        }
        transform.position = end;
    }

    void ColorChanger()
    {
        mouthMaterial.color = Color.Lerp(Color.black, Color.red, t);
        bodyMaterial.color = Color.Lerp(Color.yellow, Color.red, t*6f);
        if (t < 1f) {t += Time.deltaTime/duration;}   
    }

}
