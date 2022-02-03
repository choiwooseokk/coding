using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayTime : MonoBehaviour
{
    enum Check
    {
        zero,
        pass,
        no
    }
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(R("5.2", "5.2"));
        Debug.Log(R("5", "5.2"));
        Debug.Log(R("5", "5.0"));
        Debug.Log(R("5.2", "5.25"));
        Debug.Log(R("5.2", "5.205"));
    }
    Check R(string answer, string _input)
    {
        string s = _input;
        char[] phrase = s.ToCharArray();
        for (int i = s.Length - 1; i > 0; i--)
        {
            if (s.Substring(i, 1) != "0")
            {
                if (s.Substring(i, 1) == ".")
                {
                    phrase[i] = ' ';
                    break;
                }
                break;
            }
            else
                phrase[i] = ' ';
        }
        s = new string(phrase).Trim();


        if (_input.Contains("."))
        {
            if (_input.Substring(_input.Length - 1, 1) == "0")
            {
                if (answer == s)
                {
                    return Check.zero;
                }
                else
                {
                    return Check.no;
                }
            }
            else
            {
                if (answer == _input)
                    return Check.pass;
            }
            return Check.no;
        }
        else
        {
            if (answer == _input)
            {
                return Check.pass;
            }
            return Check.no;
        }
    }

}