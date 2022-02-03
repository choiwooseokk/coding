using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[ExecuteInEditMode]
public class line : MonoBehaviour
{
    LineRenderer lr;
    public Transform g;
    public List<Text> t = new List<Text>(); 
    // Start is called before the first frame update
    void Start()
    {
        lr = GetComponent<LineRenderer>();
        lr.SetColors(Color.white, Color.white);
        lr.SetWidth(0.1f, 0.1f);
        //Text[] ta = g.GetComponentsInChildren<Text>();
        //foreach(Text a in ta)
        //{
        //    t.Add(a);
        //}
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < t.Count; i++)
        {
            if (t[i].text == "Χ")
            {
                lr.SetPosition(0, new Vector3(t[i - 1].transform.position.x, t[i - 1].transform.position.y, 0));
                lr.SetPosition(1, new Vector3(t[i - 1].transform.position.x, t[i - 1].transform.position.y-1, 0));
                lr.SetPosition(1, new Vector3(t[i + 1].transform.position.x, t[i + 1].transform.position.y - 1, 0));
                //lr.SetPosition(0, new Vector3(t[i-1].transform.GetComponent<RectTransform>().localPosition.x, t[i - 1].transform.GetComponent<RectTransform>().localPosition.y, 0));
                //lr.SetPosition(1, new Vector3(1, 1, 1));
            }
        }
    }
}
