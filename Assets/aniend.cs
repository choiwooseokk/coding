using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aniend : MonoBehaviour
{
    public Animation a;
    // Start is called before the first frame update
    void Start()
    {
        //StartCoroutine(end());
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
        {
            StartCoroutine(end());
        }
        if (Input.GetKeyDown(KeyCode.X))
        {
            StartCoroutine(end("bb"));
        }
    }

    // Update is called once per frame
    IEnumerator end(string s = null)
    {

        if (s != null)
        {
            Animation _a = a;
            AnimationClip c = null;
            foreach (AnimationState state in _a)
            {
                if (state.name == s)
                {
                    c = state.clip;
                }
            }
            a.Play(s);
            yield return new WaitForSeconds(c.length);
        }
        else
        {
            a.Play();
            yield return new WaitForSeconds(a.clip.length);
        }
        Debug.Log("a");
        //yield return null;
    }
}
