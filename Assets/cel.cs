using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class cel : MonoBehaviour
{
    private void Awake()
    {
            string s = "72÷27-45";
            //Debug.Log(Notation.Equation(s));
        char c = 'A';
        //Debug.Log(&c);
        for (int i = 0; i < 1000; i++)
        {
            
            //string ss = "135÷5 + 40";
            //Debug.Log(Notation.Equation(ss));
            //string sss = "(5+40)";
            //Debug.Log(Notation.Equation(sss));
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
public static class Notation
{
    static int Precede(char c)
    {
        switch (c)
        {
            case '(':
            case ')':
                return 0;
            case '+':
            case '-':
                return 1;
            case '*':
            case '/':
                return 2;
        }
        return -1;
    }
    public static string InfixTopostfix(string s)
    {
        Stack<char> infixToPostfixstack = new Stack<char>();

        char[] ca = s.ToCharArray();
        char popChar;
        string t = "";
        for (int i = 0, count = ca.Length; i < count; i++)
        {
            switch (ca[i])
            {
                case '+':
                case '-':
                case '*':
                case '/':
                    do
                    {
                        if (infixToPostfixstack.Count == 0)
                        {
                            break;
                        }
                        popChar = infixToPostfixstack.Pop();
                        if (Precede(popChar) >= Precede(ca[i]))
                        {
                            t += " " + popChar;
                        }
                        else
                        {
                            infixToPostfixstack.Push(popChar);
                            break;
                        }
                    } while (true);

                    t += " ";
                    infixToPostfixstack.Push(ca[i]);
                    break;

                case '(':
                    infixToPostfixstack.Push(ca[i]);
                    break;
                case ')':
                    do
                    {
                        popChar = infixToPostfixstack.Pop();
                        if (popChar == '(')
                        {
                            break;
                        }
                        t += " " + popChar;
                    } while (true);
                    break;

                default:
                    t += ca[i];
                    break;

            }
        }
        for (int i = 0, count = infixToPostfixstack.Count; i < count; i++)
        {
            t += " " + infixToPostfixstack.Pop();
        }
        return t;
    }
    public static double PostfixProcess(string s, int skillLevel, int tileLevel)
    {
        Stack<double> stack = new Stack<double>();

        double value = 0;
        double op1, op2;

        string[] sa = s.Split(' ');

        if (s.Length == 0)
        {
            throw new System.ArgumentException("Parameter cannot be null", "string");
        }
        else if (s.Length == 1)
        {
            value = Convert.ToDouble(sa[0]);
            return value;
        }
        for (int i = 0, count = sa.Length; i < count; i++)
        {
            if (sa[i] != "+" && sa[i] != "-" && sa[i] != "*" && sa[i] != "/")
            {
                if (sa[i] == "sLv")
                {
                    stack.Push(skillLevel);
                }
                else if (sa[i] == "atk")
                {
                    stack.Push(0);
                }
                else if (sa[i] == "tLv")
                {
                    stack.Push(tileLevel);
                }
                else
                {
                    stack.Push((Convert.ToDouble(sa[i])));
                }
                continue;
            }
            op2 = stack.Pop();
            op1 = stack.Pop();

            switch (sa[i])
            {
                case "+": value = op1 + op2; break;
                case "-": value = op1 - op2; break;
                case "*": value = op1 * op2; break;
                case "/": value = op1 / op2; break;
            }
            stack.Push(value);
        }
        value = stack.Pop();
        return value;
    }
    public static int Equation(string _S)
    {
        string St = _S;
        char[] phraseAsChars = St.ToCharArray();
        for (int i = 0; i < St.Length; i++)
        {
            if (St.Substring(i, 1) == "×")
            {
                //int b = St.IndexOf("×");
                phraseAsChars[i] = '*';
            }
        }
        for (int i = 0; i < St.Length; i++)
        {
            if (St.Substring(i, 1) == "÷")
            {
                //int c = St.IndexOf("÷");
                phraseAsChars[i] = '/';
            }
        }
        for (int i = 0; i < St.Length; i++)
        {
            if (St.Substring(i, 1) == "=")
            {
                //int d = St.IndexOf("=");
                phraseAsChars[i] = ' ';
            }
        }
        int a = 0;
        for (int i = 0; i < St.Length; i++)
        {
            if (St.Substring(i, 1) == "-")
            {
                if (i == 0)
                    return -9999;
                else
                {
                    bool b = int.TryParse(St.Substring(i - 1, 1), out a);
                    if (!b)
                    {
                        if(St.Substring(i - 1, 1)!=")")
                        return -9999;
                    }
                }
            }
        }
            St = new string(phraseAsChars).Replace(" ", ""); ;
            string sTemp = St;

            string sTemp2 = string.Empty;
            double dTemp;

            sTemp2 = InfixTopostfix(sTemp);
            dTemp = PostfixProcess(sTemp2, 0, 0);

            return (int)dTemp;

    }
}