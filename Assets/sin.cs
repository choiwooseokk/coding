using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class sin : MonoBehaviour
{
    [SerializeField] [Range(0f, 30)] private float speed = 1f;
    [SerializeField] [Range(0f, 30)] private float length = 1f;
    private float runningTime = 0f;
    private float zRot = 0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (length >0)
        {
            length -= Time.deltaTime*speed;
            runningTime += Time.deltaTime * speed;
            zRot = Mathf.Sin(runningTime) * length;
            transform.GetComponent<RectTransform>().localEulerAngles = new Vector3(0, 0, zRot);
        }
    }
}
