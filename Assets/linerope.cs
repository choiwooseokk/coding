using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class linerope : MonoBehaviour
{
    Vector3 origin;
    public Transform T;
    public float f;
    public Transform t;
    public List<Transform> moveobejct = new List<Transform>();
    // Update is called once per frame
    void Start()
    {
        if (t != null)
        {
            Transform[] g = t.GetComponentsInChildren<Transform>();
            foreach (Transform ga in g)
            {
                if (ga != t)
                    moveobejct.Add(ga);
            }
        }
        for(int i=0;i<moveobejct.Count;i++)
        {
            //moveobejct[i].
        }
        //this.GetComponent<>
    }
    void Update()
    {
    }
}
