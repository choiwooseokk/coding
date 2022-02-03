using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Offset : MonoBehaviour
{
    public GameObject image;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
            image.GetComponent<Image>().material.SetTextureOffset("_MainTex", new Vector2(0.5f, 0.5f));
    }
}
