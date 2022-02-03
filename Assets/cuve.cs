using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cuve : MonoBehaviour
{
    public AnimationCurve c;
    public Transform a;
    [Range(0.0f,30.0f)]
    public float x;
    [Range(0.0f, 6.0f)]
    public float y;
    public float b;
    // Start is called before the first frame update
    void Start()
    {
        float a = 1;
        float b = 8;
        Debug.Log((float)1/8);
    }

    // Update is called once per frame
    void Update()
    {
        //x += 1f * Time.deltaTime;
        y += 50f * Time.deltaTime;
        float xx = c.Evaluate(x);
        float yy= c.Evaluate(y);
        a.GetComponent<RectTransform>().anchoredPosition = new Vector2(xx,0);
    }
}
