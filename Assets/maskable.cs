using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class maskable : MonoBehaviour
{
    Image a;
    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<Image>();
        a.maskable = false;
        Transform g;
        Color c;
       ColorUtility.TryParseHtmlString("#881888", out c);
        a.color = c;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
