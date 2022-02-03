using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dictinary : MonoBehaviour
{
    Dictionary<string, int> d = new Dictionary<string, int>();
    // Start is called before the first frame update
    void Start()
    {
        d.Add("a", 1);
        d.Add("aa", 2);
        d.Add("aaa", 3);
        var b = new List<string>(d.Keys);
        var c = new List<int>(d.Values);
        //Debug.Log(b[0]);
        //Debug.Log(c);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
