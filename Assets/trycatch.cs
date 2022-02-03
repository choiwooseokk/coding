using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class trycatch : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        tryTest();


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void tryTest()
    {
        int arr = 5;
        int z = 0;

        try
        {
            //int[] 배열의 크기를 넘은 인덱스를 사용하여 예외 발생
            int f = arr/z;
            Debug.Log("a");
        }
        catch (Exception e)
        {
            string s = string.Format("예외 발생 : {0}", e.Message);
            Debug.Log(s);
            Debug.Log("b");
        }
        finally
        {
            Debug.Log("c");
        }
    }

}
