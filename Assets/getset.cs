using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Expantion_Fraction;
public class getset : MonoBehaviour
{
    class MyClass
    {
        //public int num { set; get; }
        //public int num;
        //public int num2;
        //public int sum { get { return num + num2; } }
        //public override string ToString()
        //{
        //    return "num = " + num + ", num2 = " + num2;
        //}
    }
    // Start is called before the first frame update


    struct QuestionInfo
    {
        int maxQno;

        List<Problem> p { get; }

        public QuestionInfo(List<Problem> _p, int _maxQno)
        {
            this.maxQno = _maxQno;
            this.p = _p;
        }

        public int LeftTop(int curQno)
        {
            if(curQno < 0 || curQno >= maxQno)
            {
                Debug.LogError("");
                return -1;
            }
            return p[curQno].L_bunja;
        }

        public int LeftBottom(int curQno)
        {
            if (curQno < 0 || curQno >= maxQno)
            {
                Debug.LogError("");
                return -1;
            }
            return p[curQno].L_bunmo;
        }

        public int RightTop(int curQno)
        {
            if (curQno < 0 || curQno >= maxQno)
            {
                Debug.LogError("");
                return -1;
            }
            return p[curQno].R_bunja;
        }

        public int RightBottom(int curQno)
        {
            if (curQno < 0 || curQno >= maxQno)
            {
                Debug.LogError("");
                return -1;
            }
            return p[curQno].R_bunmo;
        }


        public int AnswerTop(int curQno)
        {
            if (curQno < 0 || curQno >= maxQno)
            {
                Debug.LogError("");
                return -1;
            }
            return p[curQno].answer_bunja;
        }

        public int AnswerBottom(int curQno)
        {
            if (curQno < 0 || curQno >= maxQno)
            {
                Debug.LogError("");
                return -1;
            }
            return p[curQno].answer_bunmo;
        }

        public int LeftBottomReduce(int curQno)
        {
            return p[curQno].reduceNums[0];
        }

        public int LeftTopReduce(int curQno)
        {
            return p[curQno].reduceNums[3];
        }

        public int RightBottomReduce(int curQno)
        {
            return p[curQno].reduceNums[2];
        }

        public int RightTopReduce(int curQno)
        {
            return p[curQno].reduceNums[1];
        }


        public void DebugLog()
        {
#if UNITY_EDITOR
            for(int i = 0; i<maxQno; i++)
            {
                Debug.Log($"<size=20>{i + 1}번:  {LeftTop(i)}/{LeftBottom(i)} x {RightTop(i)}/{RightBottom(i)} = {AnswerTop(i)}/{AnswerBottom(i)}</size>");
            }
#endif
        }

    }
    QuestionInfo info;


    fraction2_ws maker = new fraction2_ws();
    void Start()
    {
        //MyClass s = new MyClass();
        //s.num = 10;
        //s.num2 = 150;
        //Debug.Log(s.sum);
        //Debug.Log(s.sum);
        //Debug.Log(s);
        //System.Diagnostics.Stopwatch stopwatch = new System.Diagnostics.Stopwatch();
        //stopwatch.Start();
        //for (int i = 0; i < 100; i++)
        //{
        //    Problem p = new Problem();
        //    p = maker.MakeBunsu((Level)2, abbreviationNum.two);
        //    //Debug.Log($"{p.L_bunja}/{p.L_bunmo} ");
        //    //Debug.Log($"{p.R_bunja}/{p.R_bunmo} ");
        //    //Debug.Log("                               ");
        //    //Debug.Log($"a: {p.answer_bunja}/{p.answer_bunmo} ");
        //    //Debug.Log("                               ");
        //}
        //stopwatch.Stop();

        //Debug.Log(stopwatch.ElapsedMilliseconds + "ms");


        MakeQuestion();


    }
    void MakeQuestion()
    {
        List<F_Level> level = new List<F_Level>();
        List<F_Count> count = new List<F_Count>();
        for (int i=0;i<20;i++)
        {
            if (i < 5)
            {
                level.Add(F_Level.normal);
            }
            else if (i < 10)
            {
                level.Add(F_Level.normal);
            }
            else
            {
                level.Add(F_Level.normal);
            }

            if (i < 5)
            {
                count.Add(F_Count.leftone);
            }
            else if (i < 10)
            {
                count.Add(F_Count.leftone);
            }
            else
            {
                count.Add(F_Count.leftone);
            }
        }

        info = new QuestionInfo(maker.MakeFractions(level, count, 20), 20);
        info.DebugLog();

    }



    // Update is called once per frame
    void Update()
    {
        
    }
}
