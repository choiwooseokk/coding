using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;
using System.Text;

public class dirqns : MonoBehaviour
{
    public int ans = 0;
    public int ans1 = 0;
    public List<int> mixfraction = new List<int>();
    public List<int> properfraction = new List<int>();
    public List<int> answermixfraction = new List<int>();
    public List<int> answerproperfraction = new List<int>();
    public List<int> reducenum = new List<int>();
    public int AnswerMo;
    public int AnswerJa;
    int AnswerNum;
    int maxbunmo;
    int maxnumber;
    public bool Nature;
    public enum stage { easy, normal, hard };
    public enum fractionType { proper, mix, natural, random };
    public enum kiyacType { wrong, nokiyac, kiyac };
    private void Start()
    {


        for (int i = 0; i < 100000; i++)
        {
            mixedAbbreviation(stage.normal, fractionType.mix, true);
            if (Reduced_Check(mixfraction[1], mixfraction[3]))
            {
                Debug.Log(properfraction[0]);
                Debug.Log(properfraction[2]);
                Debug.Log(i+" :   실패");
                return;
            }
            
        }
        //for(int i=0;i<10000;i++)
        //{
        //    do
        //        properAbbreviation(stage.normal, fractionType.mix, false);
        //    while (properfraction[1] != 1);
        //    if(answerproperfraction[2]==0)
        //    {
        //        Debug.Log("a");
        //        Debug.Break();
        //    }
        //}


        //var c = multbunsu(25, 8, 18, 15,1,1);
        //Debug.Log(c.Item1);
        //Debug.Log(c.Item2);
        //Debug.Log(c.Item3);
        //var q = multAnswernum(0, 0, 0, 6);
        //Debug.Log(q.Item1);
        //Debug.Log(q.Item2);
        //Debug.Log(q.Item3);
        //for (int i = 0; i < 100; i++)
        //{
        //    //    int rand = 2;
        //    //    bool returnbool;
        //    //    //대분수를 가분수로 고치기 전에 약분
        //    //    if (rand == 0)
        //    //    {
        //    //        do
        //    //        {
        //    //mixedAbbreviation(stage.hard, fractionType.mix, true);
        //    //Debug.Log(mixfraction[1]);
        //    //mixedAbbreviation(stage.hard, fractionType.mix, false);
        //    //Debug.Log(mixfraction[1]);
        //    do
        //    {
        //        freeMixAbbreviation(5, 30, 35, fractionType.natural);
        //    } while (mixfraction[3] < 30);
        //    Debug.Log(mixfraction[0]);
        //    Debug.Log(mixfraction[1]);
        //    Debug.Log(mixfraction[2]);
        //    Debug.Log(mixfraction[3]);
        //}
        //mixedAbbreviation(stage.normal, fractionType.natural, true);
        //            returnbool = false;
        //            var check = ToGabunsu(answermixfraction[0], answermixfraction[1], answermixfraction[2]);
        //            Debug.Log(mixfraction[0]);
        //            Debug.Log(mixfraction[1]);
        //            Debug.Log(mixfraction[2]);
        //            Debug.Log(mixfraction[3]);

        //            var c = Reduced_Num(mixfraction[1], mixfraction[3]);
        //            Debug.Log(mixfraction[0]);
        //            Debug.Log(c.Item1);
        //            Debug.Log(mixfraction[2]);
        //            Debug.Log(c.Item2);

        //            Debug.Log(c.Item1);
        //            Debug.Log(mixfraction[0] * c.Item1 + mixfraction[2]);
        //            Debug.Log(c.Item2);

        //            Debug.Log(c.Item1);
        //            Debug.Log(c.Item2 * (mixfraction[0] * c.Item1 + mixfraction[2]));
        //            if (c.Item1 < c.Item2 * (mixfraction[0] * c.Item1 + mixfraction[2]))
        //            {
        //                var c1 = ToDaebunsu(c.Item1, c.Item2 * (mixfraction[0] * c.Item1 + mixfraction[2]));
        //                Debug.Log(c1.Item1);
        //                Debug.Log(c1.Item2);
        //                Debug.Log(c1.Item3);
        //                var check1 = ToGabunsu(c1.Item1, c1.Item2, c1.Item3);
        //                if (check.Item1 == check1.Item1 && check.Item2 == check1.Item2)
        //                    returnbool = true;
        //            }
        //            else
        //            {
        //                Debug.Log(c.Item1);
        //                Debug.Log(c.Item2 * (mixfraction[0] * c.Item1 + mixfraction[2]));
        //                if (check.Item1 == c.Item1 && check.Item2 == c.Item2 * (mixfraction[0] * c.Item1 + mixfraction[2]))
        //                    returnbool = true;
        //            }

        //        } while (returnbool);
        //    }
        //    //분자랑 자연수를 약분 분자가0일때자연수 분모붙자같은경우 없애기
        //    else if (rand == 1)
        //    {
        //        do
        //        {
        //            do
        //            {
        //                returnbool = true;
        //                List<int> bunjalist = new List<int>();
        //                List<int> integer = new List<int>();
        //                mixedAbbreviation(stage.easy, fractionType.natural, true);
        //                var ch = ToGabunsu(mixfraction[0], mixfraction[1], mixfraction[2]);
        //                abbreviation(bunjalist, ch.Item2);
        //                abbreviation(integer, mixfraction[3]);
        //                for (int y = 0; y < bunjalist.Count; y++)
        //                {
        //                    for (int z = 0; z < integer.Count; z++)
        //                    {
        //                        if (bunjalist[y] == integer[z])
        //                            returnbool = false;
        //                    }
        //                }
        //            } while (returnbool);
        //            returnbool = false;
        //            var check = ToGabunsu(answermixfraction[0], answermixfraction[1], answermixfraction[2]);
        //            Debug.Log(mixfraction[0]);
        //            Debug.Log(mixfraction[1]);
        //            Debug.Log(mixfraction[2]);
        //            Debug.Log(mixfraction[3]);

        //            var d = ToGabunsu(mixfraction[0], mixfraction[1], mixfraction[2]);

        //            Debug.Log(d.Item1);
        //            Debug.Log(d.Item2);
        //            Debug.Log(mixfraction[3]);

        //            var c = Reduced_Num(d.Item2, mixfraction[3]);

        //            Debug.Log(mixfraction[1]);
        //            Debug.Log(c.Item1);
        //            Debug.Log(c.Item2);

        //            Debug.Log(mixfraction[1]);
        //            Debug.Log(c.Item1*c.Item2);
        //            if (mixfraction[1] < c.Item1 * c.Item2)
        //            {
        //                var c1 = ToDaebunsu(mixfraction[1], c.Item1 * c.Item2);
        //                Debug.Log(c1.Item1);
        //                Debug.Log(c1.Item2);
        //                Debug.Log(c1.Item3);
        //                var check1 = ToGabunsu(c1.Item1, c1.Item2, c1.Item3);
        //                if (check.Item1 == check1.Item1 && check.Item2 == check1.Item2)
        //                    returnbool = true;
        //                if (c.Item1 == c.Item2)
        //                    returnbool = true;
        //            }
        //            else
        //            {
        //                Debug.Log(mixfraction[1]);
        //                Debug.Log(c.Item1 * c.Item2);
        //                if (check.Item1 == mixfraction[1] && check.Item2 == c.Item2 * (mixfraction[1] * mixfraction[0] + c.Item1) * c.Item2)
        //                    returnbool = true;
        //            }

        //        } while (returnbool);
        //    }
        //    //분모에 자연수를 곱합
        //    else
        //    {
        //        do
        //        {
        //            do
        //            {
        //                returnbool = true;
        //                List<int> bunjalist = new List<int>();
        //                List<int> bunmo = new List<int>();
        //                mixedAbbreviation(stage.easy, fractionType.natural, true);
        //                abbreviation(bunjalist, mixfraction[2]);
        //                abbreviation(bunmo, mixfraction[1] * mixfraction[3]);
        //                for (int y = 0; y < bunjalist.Count; y++)
        //                {
        //                    for (int z = 0; z < bunmo.Count; z++)
        //                    {
        //                        if (bunjalist[y] == bunmo[z])
        //                            returnbool = false;
        //                    }
        //                }
        //            } while (returnbool);
        //            var check = ToGabunsu(answermixfraction[0], answermixfraction[1], answermixfraction[2]);
        //            returnbool = false;


        //            var d = ToGabunsu(mixfraction[0], mixfraction[1], mixfraction[2]);
        //            Debug.Log(mixfraction[0]);
        //            Debug.Log(mixfraction[1]);
        //            Debug.Log(mixfraction[2]);
        //            Debug.Log(mixfraction[3]);

        //            Debug.Log(mixfraction[1]);
        //            Debug.Log(d.Item2);
        //            Debug.Log(mixfraction[3]);


        //            Debug.Log(mixfraction[1]*mixfraction[3]);
        //            Debug.Log(d.Item2*mixfraction[3]);

        //            var r = Reduced_Num(mixfraction[1] * mixfraction[3], d.Item2 * mixfraction[3]);

        //            Debug.Log(r.Item1);
        //            Debug.Log(r.Item2);

        //             var c1 = ToDaebunsu(r.Item1,r.Item2);
        //             Debug.Log(c1.Item1);
        //             Debug.Log(c1.Item2);
        //             Debug.Log(c1.Item3);
        //             var check1 = ToGabunsu(c1.Item1, c1.Item2, c1.Item3);
        //             if (check.Item1 == check1.Item1 && check.Item2 == check1.Item2)
        //                    returnbool = true;

        //        } while (returnbool);
        //    }
        //}


        //for (int i = 0; i < 100; i++)
        //{


        //mixedAbbreviation(stage.normal, fractionType.random, false);
        //Debug.Log("자연수 : " + mixfraction[0] + " 분모 : " + mixfraction[1] + " 분자 : " + mixfraction[2] + " 곱하는 숫자 : " + mixfraction[3] + " = 자연수 : " + answermixfraction[0] + " 분모 : " + answermixfraction[1] + " 분자 : " + answermixfraction[2]);
        //mixedAbbreviation(stage.normal, fractionType.mix, false);
        //Debug.Log("자연수 : " + mixfraction[0] + " 분모 : " + mixfraction[1] + " 분자 : " + mixfraction[2] + " 곱하는 숫자 : " + mixfraction[3] + " = 자연수 : " + answermixfraction[0] + " 분모 : " + answermixfraction[1] + " 분자 : " + answermixfraction[2]);
        //mixedAbbreviation(stage.easy, true);
        //mixedAbbreviation(stage.normal, true);
        //mixedAbbreviation(stage.hard, true);
        //freeAbbreviation(6, 1, 7, false);
        //properAbbreviation(stage.easy, fractionType.num);
        //properAbbreviation(stage.normal, fractionType.num);
        //properAbbreviation(stage.hard, fractionType.num);
        //properAbbreviation(stage.easy, fractionType.mix, false);
        //Debug.Log(" 분모 : " + properfraction[0] + " 분자 : " + properfraction[1] + " 곱하는 숫자 : " + properfraction[2] + " = 자연수 : " + answerproperfraction[0] + " 분모 : " + answerproperfraction[1] + " 분자 : " + answerproperfraction[2]);
        //properAbbreviation(stage.easy, fractionType.proper, true);
        //Debug.Log(" 분모 : " + properfraction[0] + " 분자 : " + properfraction[1] + " 곱하는 숫자 : " + properfraction[2] + " = 자연수 : " + answerproperfraction[0] + " 분모 : " + answerproperfraction[1] + " 분자 : " + answerproperfraction[2]);
        //properAbbreviation(stage.easy, fractionType.proper, false);
        //Debug.Log(" 분모 : " + properfraction[0] + " 분자 : " + properfraction[1] + " 곱하는 숫자 : " + properfraction[2] + " = 자연수 : " + answerproperfraction[0] + " 분모 : " + answerproperfraction[1] + " 분자 : " + answerproperfraction[2]);

        //properAbbreviation(stage.normal, fractionType.random, true);
        //Debug.Log(" 분모 : " + properfraction[0] + " 분자 : " + properfraction[1] + " 곱하는 숫자 : " + properfraction[2] + " = 자연수 : " + answerproperfraction[0] + " 분모 : " + answerproperfraction[1] + " 분자 : " + answerproperfraction[2]);
        //properAbbreviation(stage.normal, fractionType.random, false);
        //Debug.Log(" 분모 : " + properfraction[0] + " 분자 : " + properfraction[1] + " 곱하는 숫자 : " + properfraction[2] + " = 자연수 : " + answerproperfraction[0] + " 분모 : " + answerproperfraction[1] + " 분자 : " + answerproperfraction[2]);

        //properAbbreviation(stage.easy, fractionType.natural, true);
        //Debug.Log(" 분모 : " + properfraction[0] + " 분자 : " + properfraction[1] + " 곱하는 숫자 : " + properfraction[2] + " = 자연수 : " + answerproperfraction[0] + " 분모 : " + answerproperfraction[1] + " 분자 : " + answerproperfraction[2]);
        //properAbbreviation(stage.easy, fractionType.proper);
        //properAbbreviation(stage.normal, fractionType.proper);
        //properAbbreviation(stage.hard, fractionType.proper);
        //properAbbreviation(stage.easy, fractionType.mix);
        //properAbbreviation(stage.normal, fractionType.mix);
        //properAbbreviation(stage.hard, fractionType.mix);
        //mixedAbbreviation(stage.easy, fractionType.mix,false);
        //freeMixAbbreviation(5, 15, 7);
        //Debug.Log("자연수 : " + mixfraction[0] + " 분모 : " + mixfraction[1] + " 분자 : " + mixfraction[2] + " 곱하는 숫자 : " + mixfraction[3] + " = 자연수 : " + answermixfraction[0] + " 분모 : " + answermixfraction[1] + " 분자 : " + answermixfraction[2]);
        //freeMixAbbreviation(5, 15, 7, fractionType.natural);
        //Debug.Log("자연수 : " + mixfraction[0] + " 분모 : " + mixfraction[1] + " 분자 : " + mixfraction[2] + " 곱하는 숫자 : " + mixfraction[3] + " = 자연수 : " + answermixfraction[0] + " 분모 : " + answermixfraction[1] + " 분자 : " + answermixfraction[2]);
        //freeMixAbbreviation(5, 7, 7, fractionType.mix);
        //Debug.Log("자연수 : " + mixfraction[0] + " 분모 : " + mixfraction[1] + " 분자 : " + mixfraction[2] + " 곱하는 숫자 : " + mixfraction[3] + " = 자연수 : " + answermixfraction[0] + " 분모 : " + answermixfraction[1] + " 분자 : " + answermixfraction[2]);
        //freeAbbreviation(10, 1, 3,false);
        //Debug.Log(" 분모 : " + properfraction[0] + " 분자 : " + properfraction[1] + " 곱하는 숫자 : " + properfraction[2] + " = 자연수 : " + answerproperfraction[0] + " 분모 : " + answerproperfraction[1] + " 분자 : " + answerproperfraction[2]);
        //Debug.Log("자연수 : " + mixfraction[0] + " 분모 : " + mixfraction[1] + " 분자 : " + mixfraction[2] + " 곱하는 숫자 : " + mixfraction[3] + " = 자연수 : " + answermixfraction[0] + " 분모 : " + answermixfraction[1] + " 분자 : " + answermixfraction[2]);
        //}
        //properAbbreviation(stage.easy,false);
        //for (int i = 0; i < 100; i++)
        //freeAbbreviation(5, 1, 7, false);
        //var check = multAnswernum(4, 2, 0, 8);
        //Debug.Log(check.Item1);
        //Debug.Log(check.Item2);
        //Debug.Log(check.Item3);

    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            Debug.Log(Reduced_Num(ans, ans1).Item1);
            Debug.Log(Reduced_Num(ans, ans1).Item2);
            //Debug.Log(Reduced_Check(ans, ans1, Nature));
            //Debug.Log(Abbreviation(ans, ans1, AnswerMo, AnswerJa));
            //var Check = Abbreviation(ans, ans1, AnswerMo, AnswerJa);
        }
    }
    /// <summary>
    /// 기약분수로 뽑기
    /// </summary>
    /// <param name="bunmo"></param>
    /// <param name="bunja"></param>
    /// <returns></returns>
    public System.Tuple<int, int> Reduced_Num(int bunmo, int bunja)
    {
        int a = 0, b = 0;
        List<int> bunmolist = new List<int>();
        List<int> bunjalist = new List<int>();
        int samelist = 0;
        bool end = false;
        for (int i = 2; i <= bunmo; i++)
        {
            if (bunmo % i == 0)
                bunmolist.Add(i);
        }
        for (int i = 2; i <= bunja; i++)
        {
            if (bunja % i == 0)
                bunjalist.Add(i);
        }
        for (int i = bunmolist.Count - 1; i >= 0; i--)
        {
            for (int y = bunjalist.Count - 1; y >= 0; y--)
            {
                if (bunmolist[i] == bunjalist[y])
                {

                    samelist = bunjalist[y];
                    end = true;
                    break;
                }
            }
            if (end)
                break;
        }
        if (samelist != 0)
        {
            bunmo /= samelist;
            bunja /= samelist;
        }
        return new System.Tuple<int, int>(bunmo, bunja);
    }
    /// <summary>
    /// 기약분수인지 체크 true면 기약분수 false면 기약분수X
    /// </summary>
    /// <param name="bunmo"></param>
    /// <param name="bunja"></param>
    /// <param name="_NatureContain"></param>
    /// <returns></returns>
    public bool Reduced_Check(int bunmo, int bunja, bool _NatureContain = false)
    {
        if (!_NatureContain)
        {
            var Check = Reduced_Num(bunmo, bunja);
            int a = Check.Item1;
            int b = Check.Item2;

            if (bunmo == a && bunja == b)
                return true;
            else
                return false;
        }
        else
        {
            var Check = Reduced_Num(bunmo, bunja);
            int a = Check.Item1;
            int b = Check.Item2;

            if (a == 1)
                return true;
            if (bunmo == a && bunja == b)
                return true;
            else
                return false;
        }
        return false;
    }
    /// <summary>
    /// 공약수갯수
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public int SameNum(int a,int b)
    {
        int same = 0;

        List<int> o = new List<int>();
        List<int> o1 = new List<int>();

        abbreviation(o, a);
        abbreviation(o1, b);


        for (int i = 0; i < o1.Count; i++)
        {
            if (o.Contains(o1[i]))
            {
                same++;
            }
        }


        return same;
    }
    /// <summary>
    /// 가분수를 대분수로만들기
    /// </summary>
    /// <param name="num"></param>
    /// <param name="num1"></param>
    /// <returns></returns>
    public System.Tuple<int,int,int> ToDaebunsu(int num,int num1)
    {
        int a = num1 / num;
        int b = num1 % num;
        return new System.Tuple<int, int,int>(a,num,b);
    }
    /// <summary>
    /// 대분수를 가분수로만들기
    /// </summary>
    /// <param name="num"></param>
    /// <param name="num1"></param>
    /// <returns></returns>
    public System.Tuple<int, int> ToGabunsu(int num, int num1,int num2)
    {
        int a;
        if (num != 0)
            a = (num * num1) + num2;
        else
            a = num2;
        return new System.Tuple<int, int>(num1,a);
    }
    /// <summary>
    /// 약수
    /// </summary>
    /// <param name="num"></param>
    /// <returns></returns>
    public List<int> abbreviation(List<int> a, int num)
    {
        for (int i = 2; i <= num; i++)
        {
            if (num % i == 0)
                a.Add(i);
        }
        return a;
    }
    /// <summary>
    /// 분수X분수 item1이 0이나오면 진분수 item2가1이나오며item3이0이 나오면 자연수
    /// </summary>
    /// <param name="bottom">분모</param>
    /// <param name="top">분자</param>
    /// <param name="num">분수에들어갈자연수</param>
    /// <param name="num1">곱할 자연수</param>
    /// <returns></returns>
    public System.Tuple<int, int, int> multbunsu(int bottom, int top, int bottom1, int top1, int num = 0,int num1=0)
    {
        var g = ToGabunsu(num, bottom, top);
        var g1 = ToGabunsu(num1, bottom1, top1);

        var gg = Reduced_Num(g.Item1,g.Item2);
        var gg1 = Reduced_Num(g1.Item1,g1.Item2);


        var check = Reduced_Num(gg.Item1, gg1.Item2);
        var check1 = Reduced_Num(gg1.Item1, gg.Item2);

        //var gg = 


        reducenum.Add(check.Item1);
        reducenum.Add(check.Item2);
        reducenum.Add(check1.Item1);
        reducenum.Add(check1.Item2);

        int bunmo = check.Item1;
        int bunja = check1.Item2;
        int bunmo1 = check1.Item1;
        int bunja1 = check.Item2;

        int a = bunmo * bunmo1;
        int b = bunja * bunja1;

        int resultint = b / a;
        int resultmo = a;
        int resulitja = b % a;

        //check

        //top += bottom * num;
        //top *= num1;
        //int a = bottom;
        //int b = top;
        //int c;
        //List<int> list = new List<int>();
        //List<int> list1 = new List<int>();
        //List<int> answerList = new List<int>();
        //for (int i = 2; i <= a; i++)
        //{
        //    if (a % i == 0)
        //        list.Add(i);

        //}
        //for (int i = 2; i <= b; i++)
        //{
        //    if (b % i == 0)
        //        list1.Add(i);

        //}
        //for (int i = 0; i < list.Count; i++)
        //{
        //    for (int y = 0; y < list1.Count; y++)
        //    {
        //        if (list[i] == list1[y])
        //            answerList.Add(list1[y]);
        //    }
        //}

        //int temp = 1;
        //int temp1 = 1;
        //for (int i = 0; i < answerList.Count; i++)
        //{
        //    if (answerList[i] > temp)
        //        temp = answerList[i];
        //}

        //a /= temp;
        //b /= temp;
        //c = b / a;
        //b %= a;

        return new System.Tuple<int, int, int>(resultint, resultmo, resulitja);

    }
    /// <summary>
    /// 분수X자연수 item1이 0이나오면 진분수 item2가1이나오며item3이0이 나오면 자연수
    /// </summary>
    /// <param name="bottom">분모</param>
    /// <param name="top">분자</param>
    /// <param name="num">분수에들어갈자연수</param>
    /// <param name="num1">곱할 자연수</param>
    /// <returns></returns>
    public System.Tuple<int,int,int> multAnswernum(int bottom, int top, int num = 0, int num1 = 1)
    {
        var check = Reduced_Num(bottom, num1);
        reducenum.Add(check.Item1);
        reducenum.Add(check.Item2);
        top += bottom * num;
        top *= num1;
        int a = bottom;
        int b = top;
        int c;
        List<int> list = new List<int>();
        List<int> list1 = new List<int>();
        List<int> answerList = new List<int>();
        for (int i = 2; i <= a; i++)
        {
            if (a % i == 0)
                list.Add(i);

        }
        for (int i = 2; i <= b; i++)
        {
            if (b % i == 0)
                list1.Add(i);

        }
        for (int i = 0; i < list.Count; i++)
        {
            for (int y = 0; y < list1.Count; y++)
            {
                if (list[i] == list1[y])
                    answerList.Add(list1[y]);
            }
        }

        int temp = 1;
        int temp1 = 1;
        for (int i = 0; i < answerList.Count; i++)
        {
            if (answerList[i] > temp)
                temp = answerList[i];
        }

        a /= temp;
        b /= temp;
        c = b / a;
        b %= a;
        return new System.Tuple<int, int,int>(c,a, b);

    }
    public System.Tuple<int, int> multAnswer(int bottom, int top, int bottom1, int top1, int num = 0, int num1 = 0)
    {
        top += bottom * num;
        top1 += bottom1 * num1;
        int a = bottom * bottom1;
        int b = top * top1;
        List<int> list = new List<int>();
        List<int> list1 = new List<int>();
        List<int> answerList = new List<int>();
        for (int i = 2; i <= a; i++)
        {
            if (a % i == 0)
                list.Add(i);

        }
        for (int i = 2; i <= b; i++)
        {
            if (b % i == 0)
                list1.Add(i);

        }
        for (int i = 0; i < list.Count; i++)
        {
            for (int y = 0; y < list1.Count; y++)
            {
                if (list[i] == list1[y])
                    answerList.Add(list1[y]);
            }
        }

        int temp = 1;
        int temp1 = 1;
        for (int i = 0; i < answerList.Count; i++)
        {
            if (answerList[i] > temp)
                temp = answerList[i];
        }

        a /= temp;
        b /= temp;

        return new System.Tuple<int, int>(a, b);
    }
    public System.Tuple<int, int> diviAnswer(int bottom, int top, int bottom1, int top1, int num = 0, int num1 = 0)
    {
        top += bottom * num;
        top1 += bottom1 * num1;
        int a = bottom * top1;
        int b = bottom1 * top;

        List<int> list = new List<int>();
        List<int> list1 = new List<int>();
        List<int> answerList = new List<int>();

        for (int i = 2; i <= a; i++)
        {
            if (a % i == 0)
                list.Add(i);

        }
        for (int i = 2; i <= b; i++)
        {
            if (b % i == 0)
                list1.Add(i);

        }
        for (int i = 0; i < list.Count; i++)
        {
            for (int y = 0; y < list1.Count; y++)
            {
                if (list[i] == list1[y])
                    answerList.Add(list1[y]);
            }
        }

        int temp = 1;
        int temp1 = 1;
        for (int i = 0; i < answerList.Count; i++)
        {
            if (answerList[i] > temp)
                temp = answerList[i];
        }
        a /= temp;
        b /= temp;

        return new System.Tuple<int, int>(a, b);
    }
    /// <summary>
    /// 기약분수인지아닌지 체크 0이면 오답 1이면 기약분수아님 2면 기약분수
    /// </summary>
    /// <param name="resultbottom">입력받을 분모</param>
    /// <param name="resulttop">입력받을 분자</param>
    /// <param name="answerbottom">정답 분모</param>
    /// <param name="answertop">정답 분자</param>
    /// <returns></returns>
    public kiyacType Abbreviation(int Inputbunmo, int Inputbunja, int answerbunmo, int answerbunja)
    {
        //var Check_Input = Reduced_Num(Inputbunmo, Inputbunja);
        var Check_answer = Reduced_Num(answerbunmo, answerbunja);
        if (Inputbunmo == Check_answer.Item1 && Inputbunja == Check_answer.Item2)
            return kiyacType.kiyac;
        else
        {

            if (Inputbunmo % Check_answer.Item1 == 0)
            {
                int a = Inputbunmo / Check_answer.Item1;
                if ((Check_answer.Item2 * a == Inputbunja))
                    return kiyacType.nokiyac;
            }
            return kiyacType.wrong;
        }

    }

    public bool CheckAbbreviation;
    public bool Checkreduced;
    System.Random random = new System.Random();
    /// <summary>
    /// 대분수만들기 true면 약분가능 false 약분불가능
    /// </summary>
    /// <param name="s">스테이지</param>
    /// <param name="f">정답형태</param>
    /// <param name="B">약분되는지안되는지</param>
    /// <param name="two">공약수가 두개일지아닐지</param>
    public void mixedAbbreviation(stage s, fractionType f = fractionType.random, bool B = true, bool two = false)
    {
        int a = 0;

        List<int> sosu = new List<int>();
        bool flag = true;
        List<int> bunmolist = new List<int>();
        for (int i = 2; i < 51; i++)
        {
            for (int y = 2; y < i; y++)
            {
                if (i % y == 0)
                    flag = false;
            }
            if (flag)
                sosu.Add(i);
            flag = true;
        }
        switch (f)
        {
            case fractionType.random:
                {
                    if (B)
                    {
                        do
                        {
                            mixfraction.Clear();
                            answermixfraction.Clear();
                            switch (s)
                            {
                                case stage.easy:
                                    {
                                        do
                                        {
                                            maxbunmo = random.Next(2, 10);
                                        } while (sosu.Contains(maxbunmo));
                                        for (int i = 2; i < maxbunmo; i++)
                                        {
                                            if (maxbunmo % i == 0)
                                            {
                                                bunmolist.Add(i);
                                            }
                                        }
                                        maxnumber = random.Next(1, 4);
                                        mixfraction.Add(maxnumber);
                                        mixfraction.Add(maxbunmo);
                                        break;
                                    }
                                case stage.normal:
                                    {
                                        do
                                        {
                                            maxbunmo = random.Next(5, 21);
                                        } while (sosu.Contains(maxbunmo));
                                        for (int i = 2; i < maxbunmo; i++)
                                        {
                                            if (maxbunmo % i == 0)
                                            {
                                                bunmolist.Add(i);
                                            }
                                        }
                                        maxnumber = random.Next(1, 4);
                                        mixfraction.Add(maxnumber);
                                        mixfraction.Add(maxbunmo);
                                        break;
                                    }
                                case stage.hard:
                                    {
                                        do
                                        {
                                            maxbunmo = random.Next(11, 31);
                                        } while (sosu.Contains(maxbunmo));
                                        for (int i = 2; i < maxbunmo; i++)
                                        {
                                            if (maxbunmo % i == 0)
                                            {
                                                bunmolist.Add(i);
                                            }
                                        }
                                        maxnumber = random.Next(1, 2);
                                        mixfraction.Add(maxnumber);
                                        mixfraction.Add(maxbunmo);
                                        break;
                                    }
                            }
                            int returnnum = 0;
                            bool b = false;
                            bool b1 = false;
                            int bunjanum;
                            bool returnbool = false;
                            List<int> bunjalist = new List<int>();
                            do
                            {
                                bunjalist.Clear();
                                returnbool = false;
                                bunjanum = random.Next(1, maxbunmo);
                                for (int i = 2; i < bunjanum; i++)
                                {
                                    if (bunjanum % i == 0)
                                    {
                                        bunjalist.Add(i);
                                    }
                                }
                                for (int i = 0; i < bunjalist.Count; i++)
                                    if (bunmolist.Contains(bunjalist[i]))
                                        returnbool = true;
                                if (bunmolist.Contains(bunjanum))
                                    returnbool = true;
                            } while (returnbool);
                            int num;
                            do
                            {
                                returnbool = false;
                                if (sosu.Contains(maxbunmo))
                                    num = maxbunmo * random.Next(2, 9);
                                else
                                    num = (bunmolist[random.Next(0, bunmolist.Count)]) * random.Next(2, 9);
                                //if (num > maxbunmo)
                                //{
                                //    if (num % maxbunmo == 0)
                                //        returnbool = true;
                                //}
                                if (s == stage.easy)
                                {
                                    if (num == maxbunmo || num > 9)
                                    {
                                        returnbool = true;
                                    }
                                }
                                else
                                {
                                    if (num == maxbunmo || num > 15)
                                    {
                                        returnbool = true;
                                    }
                                }
                            } while (returnbool);
                            mixfraction.Add(bunjanum);
                            mixfraction.Add(num);
                            var check = multAnswernum(mixfraction[1], mixfraction[2], mixfraction[0], mixfraction[3]);
                            answermixfraction.Add(check.Item1);
                            answermixfraction.Add(check.Item2);
                            answermixfraction.Add(check.Item3);
                            a = check.Item1;
                            if (two)
                            {
                                if (SameNum(maxbunmo, num) > 1)
                                    a = 101;

                            }
                            if (Reduced_Check(maxbunmo, num))
                                a = 101;
                        } while (a > 100);
                    }
                    else
                    {
                        do
                        {
                            mixfraction.Clear();
                            answermixfraction.Clear();
                            switch (s)
                            {
                                case stage.easy:
                                    {
                                        maxbunmo = random.Next(2, 10);
                                        for (int i = 2; i < maxbunmo; i++)
                                        {
                                            if (maxbunmo % i == 0)
                                            {
                                                bunmolist.Add(i);
                                            }
                                        }
                                        maxnumber = random.Next(1, 4);
                                        mixfraction.Add(maxnumber);
                                        mixfraction.Add(maxbunmo);
                                        break;
                                    }
                                case stage.normal:
                                    {
                                        maxbunmo = random.Next(5, 21);
                                        for (int i = 2; i < maxbunmo; i++)
                                        {
                                            if (maxbunmo % i == 0)
                                            {
                                                bunmolist.Add(i);
                                            }
                                        }
                                        maxnumber = random.Next(1, 4);
                                        mixfraction.Add(maxnumber);
                                        mixfraction.Add(maxbunmo);
                                        break;
                                    }
                                case stage.hard:
                                    {
                                        maxbunmo = random.Next(11, 31);
                                        for (int i = 2; i < maxbunmo; i++)
                                        {
                                            if (maxbunmo % i == 0)
                                            {
                                                bunmolist.Add(i);
                                            }
                                        }
                                        maxnumber = random.Next(1, 3);
                                        mixfraction.Add(maxnumber);
                                        mixfraction.Add(maxbunmo);
                                        break;
                                    }
                            }
                            int returnnum = 0;
                            bool b = false;
                            bool b1 = false;
                            int bunjanum;
                            bool returnbool = false;
                            List<int> bunjalist = new List<int>();
                            do
                            {
                                bunjalist.Clear();
                                returnbool = false;
                                bunjanum = random.Next(1, maxbunmo);
                                for (int i = 2; i < bunjanum; i++)
                                {
                                    if (bunjanum % i == 0)
                                    {
                                        bunjalist.Add(i);
                                    }
                                }
                                for (int i = 0; i < bunjalist.Count; i++)
                                    if (bunmolist.Contains(bunjalist[i]))
                                        returnbool = true;
                                if (bunmolist.Contains(bunjanum))
                                    returnbool = true;
                            } while (returnbool);
                            int num;
                            do
                            {
                                returnbool = false;
                                if (s == stage.easy)
                                    num = random.Next(2, 10);
                                else
                                    num = random.Next(2, 16);
                                for (int i = 0; i < bunmolist.Count; i++)
                                {
                                    if (num % bunmolist[i] == 0)
                                        returnbool = true;
                                }
                            } while (returnbool);
                            mixfraction.Add(bunjanum);
                            mixfraction.Add(num);
                            var check = multAnswernum(mixfraction[1], mixfraction[2], mixfraction[0], mixfraction[3]);
                            answermixfraction.Add(check.Item1);
                            answermixfraction.Add(check.Item2);
                            answermixfraction.Add(check.Item3);
                            a = check.Item1;
                        } while (a > 100);
                    }
                    break;
                }
            case fractionType.proper:
                {
                    Debug.LogError("만들수 없는 분수입니다.");
                    Debug.Break();
                    break;
                }
            case fractionType.mix:
                {
                    if (B)
                    {
                        do
                        {
                            mixfraction.Clear();
                            answermixfraction.Clear();
                            switch (s)
                            {
                                case stage.easy:
                                    {
                                        do
                                        {
                                            maxbunmo = random.Next(4, 10);
                                        } while (sosu.Contains(maxbunmo));
                                        for (int i = 2; i < maxbunmo; i++)
                                        {
                                            if (maxbunmo % i == 0)
                                            {
                                                bunmolist.Add(i);
                                            }
                                        }
                                        maxnumber = random.Next(1, 4);
                                        mixfraction.Add(maxnumber);
                                        mixfraction.Add(maxbunmo);
                                        break;
                                    }
                                case stage.normal:
                                    {
                                        do
                                        {
                                            maxbunmo = random.Next(5, 21);
                                        } while (sosu.Contains(maxbunmo));
                                        for (int i = 2; i < maxbunmo; i++)
                                        {
                                            if (maxbunmo % i == 0)
                                            {
                                                bunmolist.Add(i);
                                            }
                                        }
                                        maxnumber = random.Next(1, 4);
                                        mixfraction.Add(maxnumber);
                                        mixfraction.Add(maxbunmo);
                                        break;
                                    }
                                case stage.hard:
                                    {
                                        do
                                        {
                                            maxbunmo = random.Next(11, 31);
                                        } while (sosu.Contains(maxbunmo));
                                        for (int i = 2; i < maxbunmo; i++)
                                        {
                                            if (maxbunmo % i == 0)
                                            {
                                                bunmolist.Add(i);
                                            }
                                        }
                                        maxnumber = random.Next(1, 3);
                                        mixfraction.Add(maxnumber);
                                        mixfraction.Add(maxbunmo);
                                        break;
                                    }
                            }
                            int returnnum = 0;
                            bool b = false;
                            bool b1 = false;
                            int bunjanum;
                            bool returnbool = false;
                            List<int> bunjalist = new List<int>();
                            do
                            {
                                bunjalist.Clear();
                                returnbool = false;
                                bunjanum = random.Next(1, maxbunmo);
                                for (int i = 2; i < bunjanum; i++)
                                {
                                    if (bunjanum % i == 0)
                                    {
                                        bunjalist.Add(i);
                                    }
                                }
                                for (int i = 0; i < bunjalist.Count; i++)
                                    if (bunmolist.Contains(bunjalist[i]))
                                        returnbool = true;
                                if (bunmolist.Contains(bunjanum))
                                    returnbool = true;
                            } while (returnbool);
                            int num;
                            do
                            {
                                returnbool = false;
                                num = (bunmolist[random.Next(0, bunmolist.Count)]) * random.Next(2, 9);
                                if (num > maxbunmo)
                                {
                                    if (num % maxbunmo == 0)
                                        returnbool = true;
                                }
                                if (s == stage.easy)
                                {
                                    if (num == maxbunmo || num > 9)
                                    {
                                        returnbool = true;
                                    }
                                }
                                else
                                {
                                    if (num == maxbunmo || num > 15)
                                    {
                                        returnbool = true;
                                    }
                                }
                            } while (returnbool);
                            mixfraction.Add(bunjanum);
                            mixfraction.Add(num);
                            var check = multAnswernum(mixfraction[1], mixfraction[2], mixfraction[0], mixfraction[3]);
                            answermixfraction.Add(check.Item1);
                            answermixfraction.Add(check.Item2);
                            answermixfraction.Add(check.Item3);
                            a = check.Item1;
                            if (two)
                            {
                                if (SameNum(maxbunmo, num) > 1)
                                    a = 101;

                            }
                            if (Reduced_Check(maxbunmo, num))
                                a = 101;
                        } while (a > 100 || a <= 0);
                    }
                    else
                    {
                        do
                        {
                            mixfraction.Clear();
                            answermixfraction.Clear();
                            switch (s)
                            {
                                case stage.easy:
                                    {
                                        do
                                        {
                                            maxbunmo = random.Next(2, 10);
                                        } while (sosu.Contains(maxbunmo));
                                        for (int i = 2; i < maxbunmo; i++)
                                        {
                                            if (maxbunmo % i == 0)
                                            {
                                                bunmolist.Add(i);
                                            }
                                        }
                                        maxnumber = random.Next(1, 4);
                                        mixfraction.Add(maxnumber);
                                        mixfraction.Add(maxbunmo);
                                        break;
                                    }
                                case stage.normal:
                                    {
                                        do
                                        {
                                            maxbunmo = random.Next(5, 21);
                                        } while (sosu.Contains(maxbunmo));
                                        for (int i = 2; i < maxbunmo; i++)
                                        {
                                            if (maxbunmo % i == 0)
                                            {
                                                bunmolist.Add(i);
                                            }
                                        }
                                        maxnumber = random.Next(1, 4);
                                        mixfraction.Add(maxnumber);
                                        mixfraction.Add(maxbunmo);
                                        break;
                                    }
                                case stage.hard:
                                    {
                                        do
                                        {
                                            maxbunmo = random.Next(11, 31);
                                        } while (sosu.Contains(maxbunmo));
                                        for (int i = 2; i < maxbunmo; i++)
                                        {
                                            if (maxbunmo % i == 0)
                                            {
                                                bunmolist.Add(i);
                                            }
                                        }
                                        maxnumber = random.Next(1, 2);
                                        mixfraction.Add(maxnumber);
                                        mixfraction.Add(maxbunmo);
                                        break;
                                    }
                            }
                            int returnnum = 0;
                            bool b = false;
                            bool b1 = false;
                            int bunjanum;
                            bool returnbool = false;
                            List<int> bunjalist = new List<int>();
                            int num;
                            do
                            {
                                bunjalist.Clear();
                                returnbool = false;
                                bunjanum = random.Next(1, maxbunmo);
                                for (int i = 2; i < bunjanum; i++)
                                {
                                    if (bunjanum % i == 0)
                                    {
                                        bunjalist.Add(i);
                                    }
                                }
                                for (int i = 0; i < bunjalist.Count; i++)
                                    if (bunmolist.Contains(bunjalist[i]))
                                        returnbool = true;
                                if (bunmolist.Contains(bunjanum))
                                    returnbool = true;

                                if (s == stage.easy)
                                    num = random.Next(2, 10);
                                else
                                    num = random.Next(2, 16);
                                for (int i = 0; i < bunmolist.Count; i++)
                                {
                                    if (num % bunmolist[i] == 0)
                                        returnbool = true;
                                }
                            } while (returnbool);
                            mixfraction.Add(bunjanum);
                            mixfraction.Add(num);
                            var check = multAnswernum(mixfraction[1], mixfraction[2], mixfraction[0], mixfraction[3]);
                            answermixfraction.Add(check.Item1);
                            answermixfraction.Add(check.Item2);
                            answermixfraction.Add(check.Item3);
                            a = check.Item1;
                        } while (a > 100);
                    }
                    break;
                }
            case fractionType.natural:
                {
                    if (s == stage.hard)
                        s = stage.normal;
                    do
                    {
                        mixfraction.Clear();
                        answermixfraction.Clear();
                        switch (s)
                        {
                            case stage.easy:
                                {
                                    maxbunmo = random.Next(2, 10);
                                    for (int i = 2; i < maxbunmo; i++)
                                    {
                                        if (maxbunmo % i == 0)
                                        {
                                            bunmolist.Add(i);
                                        }
                                    }
                                    maxnumber = random.Next(1, 4);
                                    mixfraction.Add(maxnumber);
                                    mixfraction.Add(maxbunmo);
                                    break;
                                }
                            case stage.normal:
                                {
                                    maxbunmo = random.Next(2, 16);
                                    for (int i = 2; i < maxbunmo; i++)
                                    {
                                        if (maxbunmo % i == 0)
                                        {
                                            bunmolist.Add(i);
                                        }
                                    }
                                    maxnumber = random.Next(1, 4);
                                    mixfraction.Add(maxnumber);
                                    mixfraction.Add(maxbunmo);
                                    break;
                                }
                            case stage.hard:
                                {
                                    maxbunmo = random.Next(2, 16);
                                    for (int i = 2; i < maxbunmo; i++)
                                    {
                                        if (maxbunmo % i == 0)
                                        {
                                            bunmolist.Add(i);
                                        }
                                    }
                                    maxnumber = random.Next(1, 6);
                                    mixfraction.Add(maxnumber);
                                    mixfraction.Add(maxbunmo);
                                    break;
                                }
                        }
                        int returnnum = 0;
                        bool b = false;
                        bool b1 = false;
                        int bunjanum;
                        bool returnbool = false;
                        List<int> bunjalist = new List<int>();
                        do
                        {
                            bunjalist.Clear();
                            returnbool = false;
                            bunjanum = random.Next(1, maxbunmo);
                            for (int i = 2; i < bunjanum; i++)
                            {
                                if (bunjanum % i == 0)
                                {
                                    bunjalist.Add(i);
                                }
                            }
                            for (int i = 0; i < bunjalist.Count; i++)
                                if (bunmolist.Contains(bunjalist[i]))
                                    returnbool = true;
                            if (bunmolist.Contains(bunjanum))
                                returnbool = true;
                        } while (returnbool);
                        int num;
                        do
                        {
                            returnbool = false;

                            int z = 15 / maxbunmo;
                            if (sosu.Contains(maxbunmo))
                                num = maxbunmo * random.Next(1, 15);
                            else if (maxbunmo >= 15)
                                num = maxbunmo;
                            else
                                num = maxbunmo * (random.Next(1, z + 1));

                            //if(z<=1)
                            //num = maxbunmo;
                            //else
                            //num = maxbunmo * (random.Next(1, z + 1));
                            if (num > 15)
                            {
                                returnbool = true;
                            }
                        } while (returnbool);
                        mixfraction.Add(bunjanum);
                        mixfraction.Add(num);
                        var check = multAnswernum(mixfraction[1], mixfraction[2], mixfraction[0], mixfraction[3]);
                        answermixfraction.Add(check.Item1);
                        answermixfraction.Add(check.Item2);
                        answermixfraction.Add(check.Item3);
                        a = check.Item1;
                        if (two)
                        {
                            if (SameNum(maxbunmo, num) > 1)
                                a = 101;

                        }
                        if (Reduced_Check(maxbunmo, num))
                            a = 101;
                    } while (a > 100);
                    break;
                }
        }
    }
    /// <summary>
    /// 진분수만들기 true면약분가능 false 약분불가능
    /// </summary>
    /// <param name="s">스테이지</param>
    /// <param name="f">정답형태</param>
    /// <param name="B">약분되는지안되는지</param>
    /// <param name="two">공약수가 두개일지아닐지</param>
    public void properAbbreviation(stage s, fractionType f = fractionType.random, bool B = true, bool two = false)
    {
        int a = 0;

        List<int> sosu = new List<int>();
        bool flag = true;
        List<int> bunmolist = new List<int>();
        for (int i = 2; i < 51; i++)
        {
            for (int y = 2; y < i; y++)
            {
                if (i % y == 0)
                    flag = false;
            }
            if (flag)
                sosu.Add(i);
            flag = true;
        }
        switch (f)
        {
            case fractionType.random:
                {
                    if (B)
                    {
                        do
                        {
                            properfraction.Clear();
                            answerproperfraction.Clear();
                            switch (s)
                            {
                                case stage.easy:
                                    {
                                        maxbunmo = random.Next(2, 10);
                                        for (int i = 2; i < maxbunmo; i++)
                                        {
                                            if (maxbunmo % i == 0)
                                            {
                                                bunmolist.Add(i);
                                            }
                                        }
                                        properfraction.Add(maxbunmo);
                                        break;
                                    }
                                case stage.normal:
                                    {
                                        do
                                            maxbunmo = random.Next(5, 21);
                                        while (sosu.Contains(maxbunmo));
                                        for (int i = 2; i < maxbunmo; i++)
                                        {
                                            if (maxbunmo % i == 0)
                                            {
                                                bunmolist.Add(i);
                                            }
                                        }
                                        properfraction.Add(maxbunmo);
                                        break;
                                    }
                                case stage.hard:
                                    {
                                        do
                                            maxbunmo = random.Next(11, 31);
                                        while (sosu.Contains(maxbunmo));
                                        for (int i = 2; i < maxbunmo; i++)
                                        {
                                            if (maxbunmo % i == 0)
                                            {
                                                bunmolist.Add(i);
                                            }
                                        }
                                        properfraction.Add(maxbunmo);
                                        break;
                                    }
                            }
                            int returnnum = 0;
                            bool b = false;
                            bool b1 = false;
                            int bunjanum;
                            bool returnbool = false;
                            List<int> bunjalist = new List<int>();
                            do
                            {
                                bunjalist.Clear();
                                returnbool = false;
                                bunjanum = random.Next(1, maxbunmo);
                                for (int i = 2; i < bunjanum; i++)
                                {
                                    if (bunjanum % i == 0)
                                    {
                                        bunjalist.Add(i);
                                    }
                                }
                                for (int i = 0; i < bunjalist.Count; i++)
                                    if (bunmolist.Contains(bunjalist[i]))
                                        returnbool = true;
                                if (bunmolist.Contains(bunjanum))
                                    returnbool = true;
                            } while (returnbool);
                            int num;
                            do
                            {
                                returnbool = false;
                                if (sosu.Contains(maxbunmo))
                                    num = maxbunmo * random.Next(1, 15);
                                else
                                    num = (bunmolist[random.Next(0, bunmolist.Count)]) * random.Next(2, 15);
                                //if (num > maxbunmo)
                                //{
                                //    if (num % maxbunmo == 0)
                                //        returnbool = true;
                                //}
                                if (s == stage.easy)
                                {
                                    if (num > 9)
                                    {
                                        returnbool = true;
                                    }
                                }
                                else
                                {
                                    if (num > 30)
                                    {
                                        returnbool = true;
                                    }
                                }
                            } while (returnbool);
                            properfraction.Add(bunjanum);
                            properfraction.Add(num);
                            var check = multAnswernum(properfraction[0], properfraction[1], 0, properfraction[2]);
                            answerproperfraction.Add(check.Item1);
                            answerproperfraction.Add(check.Item2);
                            answerproperfraction.Add(check.Item3);
                            a = check.Item1;
                            if (two)
                            {
                                if (SameNum(maxbunmo, num) > 1)
                                    a = 101;

                            }
                            if (Reduced_Check(maxbunmo, num))
                                a = 101;
                        } while (a > 100);
                    }
                    else
                    {
                        do
                        {
                            properfraction.Clear();
                            answerproperfraction.Clear();
                            switch (s)
                            {
                                case stage.easy:
                                    {
                                        maxbunmo = random.Next(2, 10);
                                        for (int i = 2; i < maxbunmo; i++)
                                        {
                                            if (maxbunmo % i == 0)
                                            {
                                                bunmolist.Add(i);
                                            }
                                        }
                                        properfraction.Add(maxbunmo);
                                        break;
                                    }
                                case stage.normal:
                                    {
                                        maxbunmo = random.Next(5, 21);
                                        for (int i = 2; i < maxbunmo; i++)
                                        {
                                            if (maxbunmo % i == 0)
                                            {
                                                bunmolist.Add(i);
                                            }
                                        }
                                        properfraction.Add(maxbunmo);
                                        break;
                                    }
                                case stage.hard:
                                    {
                                        maxbunmo = random.Next(11, 31);
                                        for (int i = 2; i < maxbunmo; i++)
                                        {
                                            if (maxbunmo % i == 0)
                                            {
                                                bunmolist.Add(i);
                                            }
                                        }
                                        properfraction.Add(maxbunmo);
                                        break;
                                    }
                            }
                            int returnnum = 0;
                            bool b = false;
                            bool b1 = false;
                            int bunjanum;
                            bool returnbool = false;
                            List<int> bunjalist = new List<int>();
                            do
                            {
                                bunjalist.Clear();
                                returnbool = false;
                                bunjanum = random.Next(1, maxbunmo);
                                for (int i = 2; i < bunjanum; i++)
                                {
                                    if (bunjanum % i == 0)
                                    {
                                        bunjalist.Add(i);
                                    }
                                }
                                for (int i = 0; i < bunjalist.Count; i++)
                                    if (bunmolist.Contains(bunjalist[i]))
                                        returnbool = true;
                                if (bunmolist.Contains(bunjanum))
                                    returnbool = true;
                            } while (returnbool);
                            int num;
                            do
                            {
                                returnbool = false;
                                if (s == stage.easy)
                                    num = random.Next(2, 10);
                                else
                                    num = random.Next(2, 31);
                                for (int i = 0; i < bunmolist.Count; i++)
                                {
                                    if (num % bunmolist[i] == 0)
                                        returnbool = true;
                                }
                            } while (returnbool);
                            properfraction.Add(bunjanum);
                            properfraction.Add(num);
                            var check = multAnswernum(properfraction[0], properfraction[1], 0, properfraction[2]);
                            answerproperfraction.Add(check.Item1);
                            answerproperfraction.Add(check.Item2);
                            answerproperfraction.Add(check.Item3);
                            a = check.Item1;
                        } while (a > 100);
                    }
                    break;
                }
            case fractionType.proper:
                {
                    if (B)
                    {
                        do
                        {
                            properfraction.Clear();
                            answerproperfraction.Clear();
                            switch (s)
                            {
                                case stage.easy:
                                    {
                                        do
                                            maxbunmo = random.Next(4, 10);
                                        while (sosu.Contains(maxbunmo));
                                        for (int i = 2; i < maxbunmo; i++)
                                        {
                                            if (maxbunmo % i == 0)
                                            {
                                                bunmolist.Add(i);
                                            }
                                        }
                                        properfraction.Add(maxbunmo);
                                        break;
                                    }
                                case stage.normal:
                                    {
                                        do
                                            maxbunmo = random.Next(5, 21);
                                        while (sosu.Contains(maxbunmo));
                                        for (int i = 2; i < maxbunmo; i++)
                                        {
                                            if (maxbunmo % i == 0)
                                            {
                                                bunmolist.Add(i);
                                            }
                                        }
                                        properfraction.Add(maxbunmo);
                                        break;
                                    }
                                case stage.hard:
                                    {
                                        do
                                            maxbunmo = random.Next(11, 31);
                                        while (sosu.Contains(maxbunmo));
                                        for (int i = 2; i < maxbunmo; i++)
                                        {
                                            if (maxbunmo % i == 0)
                                            {
                                                bunmolist.Add(i);
                                            }
                                        }
                                        properfraction.Add(maxbunmo);
                                        break;
                                    }
                            }
                            int returnnum = 0;
                            bool b = false;
                            bool b1 = false;
                            int bunjanum;
                            bool returnbool = false;
                            List<int> bunjalist = new List<int>();
                            int num;
                            do
                            {
                                num = (bunmolist[random.Next(0, bunmolist.Count)]);
                                bunjalist.Clear();
                                returnbool = false;
                                bunjanum = random.Next(1, maxbunmo / 2);
                                for (int i = 2; i < bunjanum; i++)
                                {
                                    if (bunjanum % i == 0)
                                    {
                                        bunjalist.Add(i);
                                    }
                                }
                                for (int i = 0; i < bunjalist.Count; i++)
                                    if (bunmolist.Contains(bunjalist[i]))
                                        returnbool = true;
                                if (bunmolist.Contains(bunjanum))
                                    returnbool = true;

                                num = (bunmolist[random.Next(0, bunmolist.Count)]);
                                if (num > maxbunmo)
                                {
                                    if (num % maxbunmo == 0)
                                        returnbool = true;
                                }
                                if (s == stage.easy)
                                {
                                    if (num == maxbunmo || num > 10 || bunjanum * num >= maxbunmo)
                                    {
                                        returnbool = true;
                                    }
                                }
                                else
                                {
                                    if (num == maxbunmo || num > 30 || bunjanum * num >= maxbunmo)
                                    {
                                        returnbool = true;
                                    }
                                }
                            } while (returnbool);
                            properfraction.Add(bunjanum);
                            properfraction.Add(num);
                            var check = multAnswernum(properfraction[0], properfraction[1], 0, properfraction[2]);
                            answerproperfraction.Add(check.Item1);
                            answerproperfraction.Add(check.Item2);
                            answerproperfraction.Add(check.Item3);
                            a = check.Item1;
                            if (two)
                            {
                                if (SameNum(maxbunmo, num) > 1)
                                    a = 101;

                            }
                            if (Reduced_Check(maxbunmo, num))
                                a = 101;
                        } while (a > 100);
                    }
                    else
                    {
                        do
                        {
                            properfraction.Clear();
                            answerproperfraction.Clear();
                            switch (s)
                            {
                                case stage.easy:
                                    {
                                        maxbunmo = random.Next(4, 10);
                                        for (int i = 2; i < maxbunmo; i++)
                                        {
                                            if (maxbunmo % i == 0)
                                            {
                                                bunmolist.Add(i);
                                            }
                                        }
                                        properfraction.Add(maxbunmo);
                                        break;
                                    }
                                case stage.normal:
                                    {
                                        maxbunmo = random.Next(5, 21);
                                        for (int i = 2; i < maxbunmo; i++)
                                        {
                                            if (maxbunmo % i == 0)
                                            {
                                                bunmolist.Add(i);
                                            }
                                        }
                                        properfraction.Add(maxbunmo);
                                        break;
                                    }
                                case stage.hard:
                                    {
                                        maxbunmo = random.Next(11, 31);
                                        for (int i = 2; i < maxbunmo; i++)
                                        {
                                            if (maxbunmo % i == 0)
                                            {
                                                bunmolist.Add(i);
                                            }
                                        }
                                        properfraction.Add(maxbunmo);
                                        break;
                                    }
                            }
                            int returnnum = 0;
                            bool b = false;
                            bool b1 = false;
                            int bunjanum;
                            bool returnbool = false;
                            List<int> bunjalist = new List<int>();
                            int num;
                            do
                            {
                                bunjalist.Clear();
                                returnbool = false;
                                bunjanum = random.Next(1, maxbunmo / 2);
                                for (int i = 2; i < bunjanum; i++)
                                {
                                    if (bunjanum % i == 0)
                                    {
                                        bunjalist.Add(i);
                                    }
                                }
                                for (int i = 0; i < bunjalist.Count; i++)
                                    if (bunmolist.Contains(bunjalist[i]))
                                        returnbool = true;
                                if (bunmolist.Contains(bunjanum))
                                    returnbool = true;
                                if (s == stage.easy)
                                    num = random.Next(2, 10);
                                else
                                    num = random.Next(2, 31);
                                for (int i = 0; i < bunmolist.Count; i++)
                                {
                                    if (num % bunmolist[i] == 0)
                                        returnbool = true;
                                }
                                if (num * bunjanum >= maxbunmo)
                                    returnbool = true;
                            } while (returnbool);
                            properfraction.Add(bunjanum);
                            properfraction.Add(num);
                            var check = multAnswernum(properfraction[0], properfraction[1], 0, properfraction[2]);
                            answerproperfraction.Add(check.Item1);
                            answerproperfraction.Add(check.Item2);
                            answerproperfraction.Add(check.Item3);
                            a = check.Item1;
                        } while (a > 100);
                    }
                    break;
                }
            case fractionType.mix:
                {
                    if (B)
                    {
                        do
                        {
                            properfraction.Clear();
                            answerproperfraction.Clear();
                            switch (s)
                            {
                                case stage.easy:
                                    {
                                        do
                                            maxbunmo = random.Next(4, 10);
                                        while (sosu.Contains(maxbunmo));
                                        for (int i = 2; i < maxbunmo; i++)
                                        {
                                            if (maxbunmo % i == 0)
                                            {
                                                bunmolist.Add(i);
                                            }
                                        }
                                        properfraction.Add(maxbunmo);
                                        break;
                                    }
                                case stage.normal:
                                    {
                                        do
                                            maxbunmo = random.Next(5, 21);
                                        while (sosu.Contains(maxbunmo));
                                        for (int i = 2; i < maxbunmo; i++)
                                        {
                                            if (maxbunmo % i == 0)
                                            {
                                                bunmolist.Add(i);
                                            }
                                        }
                                        properfraction.Add(maxbunmo);
                                        break;
                                    }
                                case stage.hard:
                                    {
                                        do
                                            maxbunmo = random.Next(11, 31);
                                        while (sosu.Contains(maxbunmo));
                                        for (int i = 2; i < maxbunmo; i++)
                                        {
                                            if (maxbunmo % i == 0)
                                            {
                                                bunmolist.Add(i);
                                            }
                                        }
                                        properfraction.Add(maxbunmo);
                                        break;
                                    }
                            }
                            int returnnum = 0;
                            bool b = false;
                            bool b1 = false;
                            int bunjanum;
                            bool returnbool = false;
                            List<int> bunjalist = new List<int>();
                            do
                            {
                                bunjalist.Clear();
                                returnbool = false;
                                bunjanum = random.Next(1, maxbunmo);
                                for (int i = 2; i < bunjanum; i++)
                                {
                                    if (bunjanum % i == 0)
                                    {
                                        bunjalist.Add(i);
                                    }
                                }
                                for (int i = 0; i < bunjalist.Count; i++)
                                    if (bunmolist.Contains(bunjalist[i]))
                                        returnbool = true;
                                if (bunmolist.Contains(bunjanum))
                                    returnbool = true;
                            } while (returnbool);
                            int num;
                            do
                            {
                                returnbool = false;
                                num = (bunmolist[random.Next(0, bunmolist.Count)]) * random.Next(2, 15);
                                if (num > maxbunmo)
                                {
                                    if (num % maxbunmo == 0)
                                        returnbool = true;
                                }
                                if (s == stage.easy)
                                {
                                    if (num == maxbunmo || num > 10)
                                    {
                                        float z = num * bunjanum;
                                        returnbool = true;
                                    }
                                }
                                else
                                {
                                    if (num == maxbunmo || num > 30)
                                    {
                                        float z = num * bunjanum;
                                        returnbool = true;
                                    }
                                }
                            } while (returnbool);
                            properfraction.Add(bunjanum);
                            properfraction.Add(num);
                            var check = multAnswernum(properfraction[0], properfraction[1], 0, properfraction[2]);
                            answerproperfraction.Add(check.Item1);
                            answerproperfraction.Add(check.Item2);
                            answerproperfraction.Add(check.Item3);
                            a = check.Item1;
                            if (two)
                            {
                                if (SameNum(maxbunmo, num) > 1)
                                    a = 101;

                            }
                            if (Reduced_Check(maxbunmo, num))
                                a = 101;
                        } while (a > 100 || a <= 0);
                    }
                    else
                    {
                        do
                        {
                            properfraction.Clear();
                            answerproperfraction.Clear();
                            switch (s)
                            {
                                case stage.easy:
                                    {
                                        do
                                            maxbunmo = random.Next(4, 10);
                                        while (sosu.Contains(maxbunmo));
                                        for (int i = 2; i < maxbunmo; i++)
                                        {
                                            if (maxbunmo % i == 0)
                                            {
                                                bunmolist.Add(i);
                                            }
                                        }
                                        properfraction.Add(maxbunmo);
                                        break;
                                    }
                                case stage.normal:
                                    {
                                        do
                                            maxbunmo = random.Next(5, 21);
                                        while (sosu.Contains(maxbunmo));
                                        for (int i = 2; i < maxbunmo; i++)
                                        {
                                            if (maxbunmo % i == 0)
                                            {
                                                bunmolist.Add(i);
                                            }
                                        }
                                        properfraction.Add(maxbunmo);
                                        break;
                                    }
                                case stage.hard:
                                    {
                                        maxbunmo = random.Next(11, 31);
                                        for (int i = 2; i < maxbunmo; i++)
                                        {
                                            if (maxbunmo % i == 0)
                                            {
                                                bunmolist.Add(i);
                                            }
                                        }
                                        properfraction.Add(maxbunmo);
                                        break;
                                    }
                            }
                            int returnnum = 0;
                            bool b = false;
                            bool b1 = false;
                            int bunjanum;
                            bool returnbool = false;
                            List<int> bunjalist = new List<int>();
                            int num;
                            do
                            {
                                bunjalist.Clear();
                                returnbool = false;
                                bunjanum = random.Next(1, maxbunmo);
                                for (int i = 2; i < bunjanum; i++)
                                {
                                    if (bunjanum % i == 0)
                                    {
                                        bunjalist.Add(i);
                                    }
                                }
                                for (int i = 0; i < bunjalist.Count; i++)
                                    if (bunmolist.Contains(bunjalist[i]))
                                        returnbool = true;
                                if (bunmolist.Contains(bunjanum))
                                    returnbool = true;
                                if (s == stage.easy)
                                    num = random.Next(2, 10);
                                else
                                    num = random.Next(2, 31);
                                for (int i = 0; i < bunmolist.Count; i++)
                                {
                                    if (num % bunmolist[i] == 0)
                                        returnbool = true;
                                }
                                if (num * bunjanum <= maxbunmo)
                                    returnbool = true;
                            } while (returnbool);
                            properfraction.Add(bunjanum);
                            properfraction.Add(num);
                            var check = multAnswernum(properfraction[0], properfraction[1], 0, properfraction[2]);
                            answerproperfraction.Add(check.Item1);
                            answerproperfraction.Add(check.Item2);
                            answerproperfraction.Add(check.Item3);
                            a = check.Item1;
                        } while (a > 100);
                    }
                    break;
                }
            case fractionType.natural:
                {
                    do
                    {
                        properfraction.Clear();
                        answerproperfraction.Clear();
                        if (s == stage.hard)
                            s = stage.normal;
                        switch (s)
                        {
                            case stage.easy:
                                {
                                    maxbunmo = random.Next(2, 10);
                                    for (int i = 2; i < maxbunmo; i++)
                                    {
                                        if (maxbunmo % i == 0)
                                        {
                                            bunmolist.Add(i);
                                        }
                                    }
                                    properfraction.Add(maxbunmo);
                                    break;
                                }
                            case stage.normal:
                                {
                                    maxbunmo = random.Next(2, 16);
                                    for (int i = 2; i < maxbunmo; i++)
                                    {
                                        if (maxbunmo % i == 0)
                                        {
                                            bunmolist.Add(i);
                                        }
                                    }
                                    properfraction.Add(maxbunmo);
                                    break;
                                }
                        }
                        int returnnum = 0;
                        bool b = false;
                        bool b1 = false;
                        int bunjanum;
                        bool returnbool = false;
                        List<int> bunjalist = new List<int>();
                        do
                        {
                            bunjalist.Clear();
                            returnbool = false;
                            bunjanum = random.Next(1, maxbunmo);
                            for (int i = 2; i < bunjanum; i++)
                            {
                                if (bunjanum % i == 0)
                                {
                                    bunjalist.Add(i);
                                }
                            }
                            for (int i = 0; i < bunjalist.Count; i++)
                                if (bunmolist.Contains(bunjalist[i]))
                                    returnbool = true;
                            if (bunmolist.Contains(bunjanum))
                                returnbool = true;
                        } while (returnbool);
                        int num;
                        do
                        {
                            returnbool = false;
                            int z = 30 / maxbunmo;
                            if (sosu.Contains(maxbunmo))
                                num = maxbunmo * random.Next(1, 15);
                            else if (maxbunmo >= 15)
                                num = maxbunmo;
                            else
                                num = maxbunmo * (random.Next(1, z + 1));
                            //if(z<=1)
                            //num = maxbunmo;
                            //else
                            //num = maxbunmo * (random.Next(1, z + 1));
                            if (num > 30)
                            {
                                returnbool = true;
                            }
                        } while (returnbool);
                        properfraction.Add(bunjanum);
                        properfraction.Add(num);
                        var check = multAnswernum(properfraction[0], properfraction[1], 0, properfraction[2]);
                        answerproperfraction.Add(check.Item1);
                        answerproperfraction.Add(check.Item2);
                        answerproperfraction.Add(check.Item3);
                        a = check.Item1;
                        if (two)
                        {
                            if (SameNum(maxbunmo, num) > 1)
                                a = 101;

                        }
                        if (Reduced_Check(maxbunmo, num))
                            a = 101;
                    } while (a > 100);
                }
                break;
        }
    }
    /// <summary>
    /// 숫자제한가능한 분수만들기 분모,분자,곱할숫자 true면 약분가능 false면약분X
    /// </summary>
    /// <param name="bottom"></param>
    /// <param name="top"></param>
    /// <param name="nums"></param>
    /// <param name="B"></param>
    public void freeAbbreviation(int bottom, int top, int nums, bool B = true)
    {
        int a = 0;

        List<int> sosu = new List<int>();
        bool flag = true;
        List<int> bunmolist = new List<int>();
        for (int i = 2; i < 51; i++)
        {
            for (int y = 2; y < i; y++)
            {
                if (i % y == 0)
                    flag = false;
            }
            if (flag)
                sosu.Add(i);
            flag = true;
        }
        
        if (B)
        {
            if (bottom < 4)
                bottom = 4;
            if (nums < 8)
                nums = 8;
            do
            {
                properfraction.Clear();
                answerproperfraction.Clear();
                maxbunmo = random.Next(4, bottom + 1);
                for (int i = 2; i < maxbunmo; i++)
                {
                    if (maxbunmo % i == 0)
                    {
                        bunmolist.Add(i);
                    }
                }
                properfraction.Add(maxbunmo);
                int bunjanum;
                bool returnbool = false;
                List<int> bunjalist = new List<int>();
                List<int> numlist = new List<int>();
                do
                {
                    bunjalist.Clear();
                    returnbool = false;
                    bunjanum = random.Next(1, top + 1);
                    for (int i = 2; i < bunjanum; i++)
                    {
                        if (bunjanum % i == 0)
                        {
                            bunjalist.Add(i);
                        }
                    }
                    for (int i = 0; i < bunjalist.Count; i++)
                        if (bunmolist.Contains(bunjalist[i]))
                            returnbool = true;
                    if (bunmolist.Contains(bunjanum))
                        returnbool = true;
                } while (returnbool);
                int num;
                do
                {
                    numlist.Clear();
                    returnbool = false;
                    num = random.Next(2, nums + 1);
                    for (int i = 2; i <= num; i++)
                        if (num % i == 0)
                            numlist.Add(i);
                    for (int y = 0; y < numlist.Count; y++)
                        if (!bunmolist.Contains(numlist[y]))
                        {
                            returnbool = true;
                        }
                    if (num > maxbunmo)
                    {
                        if (num % maxbunmo == 0)
                            returnbool = true;
                    }
                    if (num == maxbunmo || num > 30)
                    {
                        returnbool = true;
                    }
                } while (returnbool);
                properfraction.Add(bunjanum);
                properfraction.Add(num);
                var check = multAnswernum(properfraction[0], properfraction[1], 0, properfraction[2]);
                answerproperfraction.Add(check.Item1);
                answerproperfraction.Add(check.Item2);
                answerproperfraction.Add(check.Item3);
                a = check.Item1;
            } while (a > 100);
        }
        else
        {
            do
            {
                int returnnum = 0;
                bool b = false;
                bool b1 = false;
                int bunjanum;
                int num;
                bool returnbool = false;
                do
                {
                    properfraction.Clear();
                answerproperfraction.Clear();
                maxbunmo = random.Next(2, bottom + 1);
                bunmolist.Clear();
            for (int i = 2; i < maxbunmo; i++)
            {
                if (maxbunmo % i == 0)
                {
                    bunmolist.Add(i);
                }
            }
            properfraction.Add(maxbunmo);
            
            
                List<int> bunjalist = new List<int>();
            List<int> numlist = new List<int>();
            
                bunjalist.Clear();
                returnbool = false;
                bunjanum = random.Next(1, top + 1);
                for (int i = 2; i < bunjanum; i++)
                {
                    if (bunjanum % i == 0)
                    {
                        bunjalist.Add(i);
                    }
                }
                for (int i = 0; i < bunjalist.Count; i++)
                    if (bunmolist.Contains(bunjalist[i]))
                        returnbool = true;
                if (bunmolist.Contains(bunjanum))
                    returnbool = true;
                num = random.Next(2, nums+1);
                for (int i = 0; i < bunmolist.Count; i++)
                {
                    if (num % bunmolist[i] == 0)
                        returnbool = true;
                }
                    if (num % maxbunmo==0)
                        returnbool = true;
            } while (returnbool);
            properfraction.Add(bunjanum);
            properfraction.Add(num);
            var check = multAnswernum(properfraction[0], properfraction[1], 0, properfraction[2]);
            answerproperfraction.Add(check.Item1);
            answerproperfraction.Add(check.Item2);
            answerproperfraction.Add(check.Item3);
            a = check.Item1;
        } while (a > 100) ;
    }
    }
    /// <summary>
    /// 자연수로 약분되는 분수 true면 대분수 false면 진분수
    /// </summary>
    /// <param name="s"></param>
    /// <param name="B"></param>
    public void NumAbbreviation(stage s, bool B = true)
    {
        int a = 0;

        List<int> sosu = new List<int>();
        bool flag = true;
        List<int> bunmolist = new List<int>();
        if (s == stage.hard)
            s = stage.normal;
        if (B)
        {
            do
            {
                mixfraction.Clear();
                answermixfraction.Clear();
                switch (s)
                {
                    case stage.easy:
                        {
                            maxbunmo = random.Next(4, 10);
                            for (int i = 2; i < maxbunmo; i++)
                            {
                                if (maxbunmo % i == 0)
                                {
                                    bunmolist.Add(i);
                                }
                            }
                            maxnumber = random.Next(1, 4);
                            mixfraction.Add(maxnumber);
                            mixfraction.Add(maxbunmo);
                            break;
                        }
                    case stage.normal:
                        {
                            maxbunmo = random.Next(10, 16);
                            for (int i = 2; i < maxbunmo; i++)
                            {
                                if (maxbunmo % i == 0)
                                {
                                    bunmolist.Add(i);
                                }
                            }
                            maxnumber = random.Next(1, 4);
                            mixfraction.Add(maxnumber);
                            mixfraction.Add(maxbunmo);
                            break;
                        }
                }
                int returnnum = 0;
                bool b = false;
                bool b1 = false;
                int bunjanum;
                bool returnbool = false;
                List<int> bunjalist = new List<int>();
                do
                {
                    bunjalist.Clear();
                    returnbool = false;
                    bunjanum = random.Next(1, maxbunmo);
                    for (int i = 2; i < bunjanum; i++)
                    {
                        if (bunjanum % i == 0)
                        {
                            bunjalist.Add(i);
                        }
                    }
                    for (int i = 0; i < bunjalist.Count; i++)
                        if (bunmolist.Contains(bunjalist[i]))
                            returnbool = true;
                    if (bunmolist.Contains(bunjanum))
                        returnbool = true;
                } while (returnbool);
                int num;
                do
                {
                    returnbool = false;
                    int z = 15 / maxbunmo;
                    //if(z<=1)
                    //num = maxbunmo;
                    //else
                    num = maxbunmo * (random.Next(1, z+1));
                    if (num > 15)
                    {
                        returnbool = true;
                    }
                } while (returnbool);
                mixfraction.Add(bunjanum);
                mixfraction.Add(num);
                var check = multAnswernum(mixfraction[1], mixfraction[2], mixfraction[0], mixfraction[3]);
                answermixfraction.Add(check.Item1);
                answermixfraction.Add(check.Item2);
                answermixfraction.Add(check.Item3);
                a = check.Item1;
            } while (a > 100);
        }
        else
        {
            do
            {
                properfraction.Clear();
                answerproperfraction.Clear();
                switch (s)
                {
                    case stage.easy:
                        {
                            maxbunmo = random.Next(4, 10);
                            for (int i = 2; i < maxbunmo; i++)
                            {
                                if (maxbunmo % i == 0)
                                {
                                    bunmolist.Add(i);
                                }
                            }
                            properfraction.Add(maxbunmo);
                            break;
                        }
                    case stage.normal:
                        {
                            maxbunmo = random.Next(10, 21);
                            for (int i = 2; i < maxbunmo; i++)
                            {
                                if (maxbunmo % i == 0)
                                {
                                    bunmolist.Add(i);
                                }
                            }
                            properfraction.Add(maxbunmo);
                            break;
                        }
                }
                int returnnum = 0;
                bool b = false;
                bool b1 = false;
                int bunjanum;
                bool returnbool = false;
                List<int> bunjalist = new List<int>();
                do
                {
                    bunjalist.Clear();
                    returnbool = false;
                    bunjanum = random.Next(1, maxbunmo);
                    for (int i = 2; i < bunjanum; i++)
                    {
                        if (bunjanum % i == 0)
                        {
                            bunjalist.Add(i);
                        }
                    }
                    for (int i = 0; i < bunjalist.Count; i++)
                        if (bunmolist.Contains(bunjalist[i]))
                            returnbool = true;
                    if (bunmolist.Contains(bunjanum))
                        returnbool = true;
                } while (returnbool);
                int num;
                do
                {
                    returnbool = false;
                    int z = 30 / maxbunmo;
                    //if(z<=1)
                    //num = maxbunmo;
                    //else
                    num = maxbunmo * (random.Next(1, z + 1));
                    if (num > 30)
                    {
                        returnbool = true;
                    }
                } while (returnbool);
                properfraction.Add(bunjanum);
                properfraction.Add(num);
                var check = multAnswernum(properfraction[0], properfraction[1], 0, properfraction[2]);
                answerproperfraction.Add(check.Item1);
                answerproperfraction.Add(check.Item2);
                answerproperfraction.Add(check.Item3);
                a = check.Item1;
            } while (a > 100);
        }

    }
    public void freeAbbreviation1(int bottom, int top, int nums, fractionType f = fractionType.random, bool B = true)
    {
        int a = 0;
        int bunja = 0;
        List<int> sosu = new List<int>();
        bool flag = true;
        List<int> bunmolist = new List<int>();
        for (int i = 2; i < 51; i++)
        {
            for (int y = 2; y < i; y++)
            {
                if (i % y == 0)
                    flag = false;
            }
            if (flag)
                sosu.Add(i);
            flag = true;
        }
        if (B)
        {
            do
            {
                properfraction.Clear();
                answerproperfraction.Clear();
                maxbunmo = random.Next(3, bottom + 1);
                for (int i = 2; i < maxbunmo; i++)
                {
                    if (maxbunmo % i == 0)
                    {
                        bunmolist.Add(i);
                    }
                }
                properfraction.Add(maxbunmo);
                if (top == 1)
                    bunja = 1;
                else
                    bunja = maxbunmo - 1;
                int returnnum = 0;
                bool b = false;
                bool b1 = false;
                int bunjanum;
                bool returnbool = false;
                List<int> bunjalist = new List<int>();
                List<int> numlist = new List<int>();
                do
                {
                    bunjalist.Clear();
                    returnbool = false;
                    bunjanum = random.Next(2, bunja + 1);
                    for (int i = 2; i < bunjanum; i++)
                    {
                        if (bunjanum % i == 0)
                        {
                            bunjalist.Add(i);
                        }
                    }
                    for (int i = 0; i < bunjalist.Count; i++)
                        if (bunmolist.Contains(bunjalist[i]))
                            returnbool = true;
                    if (bunmolist.Contains(bunjanum))
                        returnbool = true;
                    if (bunjanum % maxbunmo == 0)
                        returnbool = true;
                } while (returnbool);
                int num;
                do
                {
                    returnbool = false;
                    num = random.Next(2, nums + 1);
                    for (int i = 0; i < bunmolist.Count; i++)
                    {
                        if (num % bunmolist[i] == 0)
                            returnbool = true;
                    }
                    if (num % maxbunmo == 0)
                        returnbool = true;
                } while (returnbool);
                properfraction.Add(bunjanum);
                properfraction.Add(num);
                var check = multAnswernum(properfraction[0], properfraction[1], 0, properfraction[2]);
                answerproperfraction.Add(check.Item1);
                answerproperfraction.Add(check.Item2);
                answerproperfraction.Add(check.Item3);
                a = check.Item1;
            } while (a > 100);
        }
        else
        {
                switch (f)
                {
                    case fractionType.random:
                        {
                            do
                            {

                                int returnnum = 0;
                                bool b = false;
                                bool b1 = false;
                                int bunjanum;
                                bool returnbool = false;
                                List<int> bunjalist = new List<int>();
                                List<int> numlist = new List<int>();
                                int num;
                                do
                                {
                                bunmolist.Clear();
                                    returnbool = false;
                                    properfraction.Clear();
                                    answerproperfraction.Clear();
                                    maxbunmo = random.Next(3, bottom + 1);
                                    for (int i = 2; i < maxbunmo; i++)
                                    {
                                        if (maxbunmo % i == 0)
                                        {
                                            bunmolist.Add(i);
                                        }
                                    }
                                    properfraction.Add(maxbunmo);
                                    if (top == 1)
                                        bunja = 1;
                                    else
                                        bunja = maxbunmo - 1;
                                    bunjalist.Clear();
                                    returnbool = false;
                                    bunjanum = random.Next(2, bunja + 1);
                                    for (int i = 2; i < bunjanum; i++)
                                    {
                                        if (bunjanum % i == 0)
                                        {
                                            bunjalist.Add(i);
                                        }
                                    }
                                    for (int i = 0; i < bunjalist.Count; i++)
                                        if (bunmolist.Contains(bunjalist[i]))
                                            returnbool = true;
                                    if (bunmolist.Contains(bunjanum))
                                        returnbool = true;
                                    if (bunjanum % maxbunmo == 0)
                                        returnbool = true;

                                    if (sosu.Contains(maxbunmo))
                                        num = maxbunmo * random.Next(2, 15);
                                    else
                                        num = (bunmolist[random.Next(0, bunmolist.Count)]) * random.Next(2, 15);
                                    if (num > nums)
                                    {
                                        returnbool = true;
                                    }
                                } while (returnbool);
                                properfraction.Add(bunjanum);
                                properfraction.Add(num);
                                var check = multAnswernum(properfraction[0], properfraction[1], 0, properfraction[2]);
                                answerproperfraction.Add(check.Item1);
                                answerproperfraction.Add(check.Item2);
                                answerproperfraction.Add(check.Item3);
                                a = check.Item1;
                            } while (a > 100);
                            break;
                        }
                    case fractionType.natural:
                        {
                            do
                            {

                                int returnnum = 0;
                                bool b = false;
                                bool b1 = false;
                                int bunjanum;
                                bool returnbool = false;
                                List<int> bunjalist = new List<int>();
                                List<int> numlist = new List<int>();
                                int num;
                                do
                                {
                                    bunmolist.Clear();
                                    returnbool = false;
                                    properfraction.Clear();
                                    answerproperfraction.Clear();
                                    maxbunmo = random.Next(3, bottom + 1);
                                    for (int i = 2; i < maxbunmo; i++)
                                    {
                                        if (maxbunmo % i == 0)
                                        {
                                            bunmolist.Add(i);
                                        }
                                    }
                                    properfraction.Add(maxbunmo);
                                    if (top == 1)
                                        bunja = 1;
                                    else
                                        bunja = maxbunmo - 1;
                                    bunjalist.Clear();
                                    returnbool = false;
                                    bunjanum = random.Next(2, bunja + 1);
                                    for (int i = 2; i < bunjanum; i++)
                                    {
                                        if (bunjanum % i == 0)
                                        {
                                            bunjalist.Add(i);
                                        }
                                    }
                                    for (int i = 0; i < bunjalist.Count; i++)
                                        if (bunmolist.Contains(bunjalist[i]))
                                            returnbool = true;
                                    if (bunmolist.Contains(bunjanum))
                                        returnbool = true;
                                    if (bunjanum % maxbunmo == 0)
                                        returnbool = true;

                                    num = maxbunmo * random.Next(1, 10);
                                    if (num > nums)
                                    {
                                        returnbool = true;
                                    }
                                } while (returnbool);
                                properfraction.Add(bunjanum);
                                properfraction.Add(num);
                                var check = multAnswernum(properfraction[0], properfraction[1], 0, properfraction[2]);
                                answerproperfraction.Add(check.Item1);
                                answerproperfraction.Add(check.Item2);
                                answerproperfraction.Add(check.Item3);
                                a = check.Item1;
                            } while (a > 100);
                            break;
                        }
                }
        }
    }
    public void freeMixAbbreviation(int interger, int bottom, int natural, fractionType f = fractionType.random, bool B = true)
    {
        int a = 0;

        List<int> sosu = new List<int>();
        bool flag = true;
        List<int> bunmolist = new List<int>();
        for (int i = 2; i < 51; i++)
        {
            for (int y = 2; y < i; y++)
            {
                if (i % y == 0)
                    flag = false;
            }
            if (flag)
                sosu.Add(i);
            flag = true;
        }
        switch (f)
        {
            case fractionType.random:
                {
                    if (B)
                    {
                        do
                        {
                            mixfraction.Clear();
                            answermixfraction.Clear();
                            do
                                maxbunmo = random.Next(2, bottom + 1);
                            while (sosu.Contains(maxbunmo));
                            for (int i = 2; i < maxbunmo; i++)
                            {
                                if (maxbunmo % i == 0)
                                {
                                    bunmolist.Add(i);
                                }
                            }
                            maxnumber = random.Next(1, interger+1);
                            mixfraction.Add(maxnumber);
                            mixfraction.Add(maxbunmo);
                            int returnnum = 0;
                            bool b = false;
                            bool b1 = false;
                            int bunjanum;
                            bool returnbool = false;
                            List<int> bunjalist = new List<int>();
                            do
                            {
                                bunjalist.Clear();
                                returnbool = false;
                                bunjanum = random.Next(1, maxbunmo);
                                for (int i = 2; i < bunjanum; i++)
                                {
                                    if (bunjanum % i == 0)
                                    {
                                        bunjalist.Add(i);
                                    }
                                }
                                for (int i = 0; i < bunjalist.Count; i++)
                                    if (bunmolist.Contains(bunjalist[i]))
                                        returnbool = true;
                                if (bunmolist.Contains(bunjanum))
                                    returnbool = true;
                            } while (returnbool);
                            int num;
                            do
                            {
                                returnbool = false;
                                    num = (bunmolist[random.Next(0, bunmolist.Count)]) * random.Next(2, 9);
                                //if (num > maxbunmo)
                                //{
                                //    if (num % maxbunmo == 0)
                                //        returnbool = true;
                                //}
                                if (num > natural)
                                {
                                    returnbool = true;
                                }
                            } while (returnbool);
                            mixfraction.Add(bunjanum);
                            mixfraction.Add(num);
                            var check = multAnswernum(mixfraction[1], mixfraction[2], mixfraction[0], mixfraction[3]);
                            answermixfraction.Add(check.Item1);
                            answermixfraction.Add(check.Item2);
                            answermixfraction.Add(check.Item3);
                            a = check.Item1;
                        } while (a > 100);
                    }
                    else
                    {
                        do
                        {
                            mixfraction.Clear();
                            answermixfraction.Clear();
                            maxbunmo = random.Next(2, bottom+1);
                            for (int i = 2; i < maxbunmo; i++)
                            {
                                if (maxbunmo % i == 0)
                                {
                                    bunmolist.Add(i);
                                }
                            }
                            maxnumber = random.Next(1, interger+1);
                            mixfraction.Add(maxnumber);
                            mixfraction.Add(maxbunmo);
                            int returnnum = 0;
                            bool b = false;
                            bool b1 = false;
                            int bunjanum;
                            bool returnbool = false;
                            List<int> bunjalist = new List<int>();
                            do
                            {
                                bunjalist.Clear();
                                returnbool = false;
                                bunjanum = random.Next(1, maxbunmo);
                                for (int i = 2; i < bunjanum; i++)
                                {
                                    if (bunjanum % i == 0)
                                    {
                                        bunjalist.Add(i);
                                    }
                                }
                                for (int i = 0; i < bunjalist.Count; i++)
                                    if (bunmolist.Contains(bunjalist[i]))
                                        returnbool = true;
                                if (bunmolist.Contains(bunjanum))
                                    returnbool = true;
                            } while (returnbool);
                            int num;
                            do
                            {
                                returnbool = false;
                                num = random.Next(2, natural+1);
                                for (int i = 0; i < bunmolist.Count; i++)
                                {
                                    if (num % bunmolist[i] == 0)
                                        returnbool = true;
                                }
                            } while (returnbool);
                            mixfraction.Add(bunjanum);
                            mixfraction.Add(num);
                            var check = multAnswernum(mixfraction[1], mixfraction[2], mixfraction[0], mixfraction[3]);
                            answermixfraction.Add(check.Item1);
                            answermixfraction.Add(check.Item2);
                            answermixfraction.Add(check.Item3);
                            a = check.Item1;
                        } while (a > 100);
                    }
                    break;
                }
            case fractionType.proper:
                {
                    Debug.LogError("만들수 없는 분수입니다.");
                    Debug.Break();
                    break;
                }
            case fractionType.mix:
                {
                    if (B)
                    {
                        do
                        {
                            mixfraction.Clear();
                            answermixfraction.Clear();
                            do
                            {
                                maxbunmo = random.Next(4, bottom+1);
                            } while (sosu.Contains(maxbunmo));
                            for (int i = 2; i < maxbunmo; i++)
                            {
                                if (maxbunmo % i == 0)
                                {
                                    bunmolist.Add(i);
                                }
                            }
                            maxnumber = random.Next(1, interger+1);
                            mixfraction.Add(maxnumber);
                            mixfraction.Add(maxbunmo);
                            int returnnum = 0;
                            bool b = false;
                            bool b1 = false;
                            int bunjanum;
                            bool returnbool = false;
                            List<int> bunjalist = new List<int>();
                            do
                            {
                                bunjalist.Clear();
                                returnbool = false;
                                bunjanum = random.Next(1, maxbunmo);
                                for (int i = 2; i < bunjanum; i++)
                                {
                                    if (bunjanum % i == 0)
                                    {
                                        bunjalist.Add(i);
                                    }
                                }
                                for (int i = 0; i < bunjalist.Count; i++)
                                    if (bunmolist.Contains(bunjalist[i]))
                                        returnbool = true;
                                if (bunmolist.Contains(bunjanum))
                                    returnbool = true;
                            } while (returnbool);
                            int num;
                            do
                            {
                                returnbool = false;
                                num = (bunmolist[random.Next(0, bunmolist.Count)]) * random.Next(2, 9);
                                if (num > maxbunmo)
                                {
                                    if (num % maxbunmo == 0)
                                        returnbool = true;
                                }
                                if (num == maxbunmo || num > natural)
                                {
                                    returnbool = true;
                                }
                            } while (returnbool);
                            mixfraction.Add(bunjanum);
                            mixfraction.Add(num);
                            var check = multAnswernum(mixfraction[1], mixfraction[2], mixfraction[0], mixfraction[3]);
                            answermixfraction.Add(check.Item1);
                            answermixfraction.Add(check.Item2);
                            answermixfraction.Add(check.Item3);
                            a = check.Item1;
                        } while (a > 100 || a <= 0);
                    }
                    else
                    {
                        do
                        {
                            mixfraction.Clear();
                            answermixfraction.Clear();
                            do
                            {
                                maxbunmo = random.Next(2, bottom+1);
                            } while (sosu.Contains(maxbunmo));
                            for (int i = 2; i < maxbunmo; i++)
                            {
                                if (maxbunmo % i == 0)
                                {
                                    bunmolist.Add(i);
                                }
                            }
                            maxnumber = random.Next(1, interger+1);
                            mixfraction.Add(maxnumber);
                            mixfraction.Add(maxbunmo);
                            break;
                            int returnnum = 0;
                            bool b = false;
                            bool b1 = false;
                            int bunjanum;
                            bool returnbool = false;
                            List<int> bunjalist = new List<int>();
                            int num;
                            do
                            {
                                bunjalist.Clear();
                                returnbool = false;
                                bunjanum = random.Next(1, maxbunmo);
                                for (int i = 2; i < bunjanum; i++)
                                {
                                    if (bunjanum % i == 0)
                                    {
                                        bunjalist.Add(i);
                                    }
                                }
                                for (int i = 0; i < bunjalist.Count; i++)
                                    if (bunmolist.Contains(bunjalist[i]))
                                        returnbool = true;
                                if (bunmolist.Contains(bunjanum))
                                    returnbool = true;

                                num = random.Next(2, natural+1);
                                for (int i = 0; i < bunmolist.Count; i++)
                                {
                                    if (num % bunmolist[i] == 0)
                                        returnbool = true;
                                }
                            } while (returnbool);
                            mixfraction.Add(bunjanum);
                            mixfraction.Add(num);
                            var check = multAnswernum(mixfraction[1], mixfraction[2], mixfraction[0], mixfraction[3]);
                            answermixfraction.Add(check.Item1);
                            answermixfraction.Add(check.Item2);
                            answermixfraction.Add(check.Item3);
                            a = check.Item1;
                        } while (a > 100);
                    }
                    break;
                }
            case fractionType.natural:
                {
                    do
                    {
                        mixfraction.Clear();
                        answermixfraction.Clear();
                        
                        int returnnum = 0;
                        bool b = false;
                        bool b1 = false;
                        int bunjanum;
                        bool returnbool = false;
                        List<int> bunjalist = new List<int>();
                        int num;
                        do
                        {
                            bunmolist.Clear();
                            mixfraction.Clear();
                            maxbunmo = random.Next(2, bottom + 1);
                            for (int i = 2; i < maxbunmo; i++)
                            {
                                if (maxbunmo % i == 0)
                                {
                                    bunmolist.Add(i);
                                }
                            }
                            maxnumber = random.Next(1, interger + 1);
                            mixfraction.Add(maxnumber);
                            mixfraction.Add(maxbunmo);
                            bunjalist.Clear();
                            returnbool = false;
                            bunjanum = random.Next(1, maxbunmo);
                            for (int i = 2; i < bunjanum; i++)
                            {
                                if (bunjanum % i == 0)
                                {
                                    bunjalist.Add(i);
                                }
                            }
                            for (int i = 0; i < bunjalist.Count; i++)
                                if (bunmolist.Contains(bunjalist[i]))
                                    returnbool = true;
                            if (bunmolist.Contains(bunjanum))
                                returnbool = true;

                            int z = 15 / maxbunmo;
                            if (sosu.Contains(maxbunmo))
                                num = maxbunmo * random.Next(1, 15);
                            else if (maxbunmo >= 15)
                                num = maxbunmo;
                            else
                                num = maxbunmo * (random.Next(1, z + 1));

                            //if(z<=1)
                            //num = maxbunmo;
                            //else
                            //num = maxbunmo * (random.Next(1, z + 1));
                            if (num > natural)
                            {
                                returnbool = true;
                            }
                        } while (returnbool);
                        mixfraction.Add(bunjanum);
                        mixfraction.Add(num);
                        var check = multAnswernum(mixfraction[1], mixfraction[2], mixfraction[0], mixfraction[3]);
                        answermixfraction.Add(check.Item1);
                        answermixfraction.Add(check.Item2);
                        answermixfraction.Add(check.Item3);
                        a = check.Item1;
                    } while (a > 100);
                    break;
                }
        }
    }
}


