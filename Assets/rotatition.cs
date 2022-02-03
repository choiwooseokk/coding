using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotatition : MonoBehaviour
{
    public Transform _T;
    RectTransform rect;
    public void Start()
    {
        rect = GetComponent<RectTransform>();
        //StartCoroutine(RotationX(_T,-30));
        StartCoroutine(Ratation());
    }
    IEnumerator Ratation()
    {
        float time = 0;
        while(true)
        {
            time -= Time.deltaTime*30;
            //float time += Time.deltaTime * 2;
            rect.eulerAngles = new Vector3(0, 0, time);
            yield return null;

        }
    }
    private void Update()
    {
        //Debug.Log(360- rect.eulerAngles.z);
        //Debug.Log(rect.rotation.z);
    }
    public IEnumerator RotationX(Transform _T,float _F,float f = 10)
    {
        float p = _T.GetComponent<RectTransform>().eulerAngles.x + _F;
        float x = _T.GetComponent<RectTransform>().eulerAngles.x;
        float y = _T.GetComponent<RectTransform>().eulerAngles.y;
        float z = _T.GetComponent<RectTransform>().eulerAngles.z;
        if (x < _F)
        {
            while (x < p)
            {
                x += f * Time.deltaTime;
                _T.GetComponent<RectTransform>().rotation = Quaternion.Euler(x, y, z);
                yield return null;
            }
            _T.GetComponent<RectTransform>().eulerAngles = new Vector3(p, y, z);
        }
        else
        {
            while (x > p)
            {
                x -= f * Time.deltaTime;
                _T.GetComponent<RectTransform>().eulerAngles = new Vector3(x, y, z);
                yield return null;
            }
            _T.GetComponent<RectTransform>().eulerAngles = new Vector3(p, y, z);
        }
    }
}
