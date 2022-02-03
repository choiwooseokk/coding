using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class math : MonoBehaviour
{
    RectTransform tran;
    Vector3 retVector;

    public int speed = 1;
    private int degree = 0;

    void Start()
    {
        tran = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            degree += speed;
            float radian = degree * Mathf.PI / 180; //라디안값
            Debug.Log(radian);
            retVector.x += 3.5f * Mathf.Cos(radian);
            retVector.y += 3.5f * Mathf.Sin(radian);

            tran.anchoredPosition3D = retVector;
        }
    }
}
