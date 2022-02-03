using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Textsize : MonoBehaviour
{
    // Update is called once per frame
    private void Start()
    {
        BunsuMaker s = new BunsuMaker();
        s.MakeNum(BunsuMaker.Level.hard);
        Debug.Log(s.sosu.answer);
        Debug.Log(s.sosu.pointpos);
        Debug.Log(s.integer.answer);
        Debug.Log(s.integer.pointpos);
        Debug.Log(s.result.answer);
        Debug.Log(s.result.pointpos);
    }
    void Update()
    {
        
    }
}
