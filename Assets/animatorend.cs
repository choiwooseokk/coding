using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class animatorend : MonoBehaviour
{
    Animator a;
    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<Animator>();
        //a.SetTrigger("zz");
        //StartCoroutine(A(a,"dd"));
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            
            StartCoroutine(A(a,"ee"));
        }
    }
    public IEnumerator A(Animator _A,string s)
    {
        float time = 0;
        AnimatorStateInfo info = _A.GetCurrentAnimatorStateInfo(0);
        while(!_A.GetCurrentAnimatorStateInfo(0).IsName(s))
        {
            time += Time.deltaTime;
            yield return null;
        }
        Debug.Log(time);
        float f = info.length;
        Debug.Log(f);
        yield return new WaitForSeconds(f-time);
        Debug.Log("a");
        _A.SetTrigger("zzz");
    }
}
