using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class timer : MonoBehaviour
{
    public Text t;
    public Transform T;
    public GameObject a;
    float screen = 0;
    public List<int> z = new List<int>();
    // Start is called before the first frame update
    void Start()
    {
        //Vector3 Temp = Camera.main.ViewportToWorldPoint(Vector3.one) - Camera.main.ViewportToWorldPoint(Vector3.zero);
        //if (Temp.x > Temp.y / 9 * 16)
        //    Temp.x = Temp.y / 9 * 16;
        //else
        //    Temp.y = Temp.x * 9 / 16;

        //screen = Temp.y;
        //Debug.Log(Temp.y);
        //for (int i = 0; i < 6; i++)
        //{
        //    z.Add(Random.Range(0, 6));
        //    while (z.Contains(z[z.Count - 1]))
        //        z[z.Count - 1] = (Random.Range(0, 6));
        //}
        string b = "d" + " "+"d"+" "+"  "+"b";
        Debug.Log(b);
        b = b.Replace(" ", "");
        Debug.Log(b);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log("a");
            int r = Random.Range(0, 6);
            for(int i=0;i<z.Count;)
            {
                Debug.Log("c");
                if (z.Contains(r))
                {
                    Debug.Log("b");
                    r = Random.Range(0, 6);
                }
                else
                {
                    Debug.Log("d");
                    z.Add(r);
                    i++;
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            int r = Random.Range(0, 4);
            //List<int> list = new List<int>();
            for (int i = 0; i < 4;)
            {
                if (z.Contains(r))
                {
                    r = Random.Range(0, 4);
                }
                else
                {
                    z.Add(r);
                    ++i;
                }
            }
        }
        //Vector3 mousepos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        //mousepos.z = 0;
        //a.transform.GetComponent<RectTransform>().position = mousepos;
        //float f = Vector2.Distance(T.position, a.transform.GetComponent<RectTransform>().anchoredPosition);
        //Vector2 size = T.GetComponent<RectTransform>().sizeDelta;
        //size.x = f;
        //T.GetComponent<RectTransform>().sizeDelta = size;

        //float angle = Mathf.Atan2(a.transform.GetComponent<RectTransform>().anchoredPosition3D.y, a.transform.GetComponent<RectTransform>().anchoredPosition3D.x) * Mathf.Rad2Deg;
        //T.GetComponent<RectTransform>().rotation = Quaternion.Euler(new Vector3(0, 0, angle));
    }
}
