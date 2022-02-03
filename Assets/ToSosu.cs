using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToSosu : MonoBehaviour
{
    public int q;
    public int w;
    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log(5.ToString("D" + 3));
        Debug.Log(Sosu(q, w));
    }
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
            Debug.Log(Sosu(q, w));
    }
    string Sosu(int a, int b)
    {
        string s = "";
        int r = 0;
        int length = 0;
        if (a == 0 || b == 0)
        {
            return "0이 있습니다.";
        }
        if (a % b == 0)
        {
            s = (a / b).ToString();
        }
        else
        {
            r = (a * (1000000)) / b;

            length = Mathf.Abs(b.ToString().Length - a.ToString().Length);

            string temp = (r%1000000).ToString();
            char[] p = temp.ToCharArray();
            for (int i = temp.Length - 1; i > 0; i--)
            {

                if (temp.Substring(i, 1) != "0")
                {
                    break;
                }
                else
                    p[i] = ' ';
            }
            temp = new string(p).Trim();
            s = $"{r/1000000}.{int.Parse(temp).ToString("D" + length)}";
        }


        char[] phrase = s.ToCharArray();
        if (s.Contains("."))
        {
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
        }
        s = new string(phrase).Trim();
        int num = 0;
        if (s.Contains("."))
        {
            num = s.Length - s.IndexOf(".") - 1;
        }
        if (num > 3)
        {
            return null;
        }
        return s;
    }
}