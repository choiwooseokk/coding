using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.Windows;
public class ImageCreate : MonoBehaviour
{
    public GameObject im;
    public Transform pos;
    public Transform[] t;
    List<Image> z = new List<Image>();
    // Start is called before the first frame update
    void Start()
    {
        for (int i=0;i<10;i++)
        {
            GameObject g = Instantiate(im);
            g.transform.SetParent(t[i % 2]);
            g.AddComponent<ImageMove>();
            g.GetComponent<RectTransform>().localScale = Vector3.zero;
            g.GetComponent<RectTransform>().anchoredPosition3D = Vector3.zero;
            g.AddComponent<CanvasGroup>().alpha = 1;
            z.Add(g.GetComponent<Image>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(mm());
        }
    }
    IEnumerator mm()
    {
        for (int i = 0; i < z.Count; i++)
        {
            StartCoroutine(MoveToVector(z[i].transform, pos, 2));
            StartCoroutine(TimeScale(z[i].transform, 1, 1, 2));
            StartCoroutine(SetAlphaCanvasGroup_numTime(z[i].GetComponent<CanvasGroup>(), 0, 2));
            yield return new WaitForSeconds(0.1f);
        }
    }
    

    public IEnumerator MoveToVector(Transform transform, Transform p, float timeToMove = 1)
    {
        var currentPos = transform.position;
        float t = 0;
        while (t < 1)
        {
            transform.position = Vector3.Lerp(currentPos, p.position, t);
            yield return null;
            t += Time.deltaTime / timeToMove;
        }
        transform.position = p.position;
    }
    public IEnumerator TimeScale(Transform transform, float X, float Y, float timeToMove = 1)
    {
        Vector3 p = new Vector3(X, Y, 1);
        var currentPos = transform.GetComponent<RectTransform>().localScale;
        var t = 0f;
        while (t < 1)
        {
            transform.GetComponent<RectTransform>().localScale = Vector3.Lerp(currentPos, p, t);
            yield return null;
            t += Time.deltaTime / timeToMove;
        }
        transform.GetComponent<RectTransform>().localScale = new Vector3(X, Y, 1);
    }
    public IEnumerator SetAlphaCanvasGroup_numTime(CanvasGroup cg, float _num = 1, float speed = 1f)
    {

        float alpha = cg.alpha;
        float time = 0;
        float disfloat = Mathf.Abs(alpha - _num);
        if (alpha <= _num)
        {
            while (time <= 1f)
            {
                cg.alpha = alpha + (disfloat * time);
                yield return null;
                time += Time.deltaTime / speed;
            }
        }
        else
        {
            while (time <= 1f)
            {
                cg.alpha = alpha - (disfloat * time);
                yield return null;
                time += Time.deltaTime / speed;
            }
        }




        cg.alpha = _num;
    }
    public class ImageMove : MonoBehaviour
    {

    }
}
