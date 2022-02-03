using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SortList : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
        SortedList<string,int> sorted = new SortedList<string, int>();
        //sorted.Add(5, "aa");
        //sorted.Add(3, "aaa");
        //sorted.Add(4, "aaaa");
        //sorted.Add(1, "a");
        //sorted.Add(2, "aaaaa");
        sorted.Add("5", 5);
        sorted.Add("2", 2);
        sorted.Add("4", 4);
        sorted.Add("1", 1);

        Debug.Log(sorted.Values);
        
        foreach (KeyValuePair<string, int> k in sorted) 
        {
            Debug.Log(k.Value);
            Debug.Log(k);
        }
    }
}