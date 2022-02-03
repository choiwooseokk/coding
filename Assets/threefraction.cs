using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class threefraction : MonoBehaviour
{
    public List<string> fraction = new List<string>();
    public List<string> answer_fraction = new List<string>();
    public int one, two, three;
    // Start is called before the first frame update
    void Start()
    {


        System.Diagnostics.Stopwatch stop = new System.Diagnostics.Stopwatch();
        stop.Start();
        for (int i = 0; i < 1; i++)
        {
            //MakeQ(1, 4);
            MakeQ2(0,4,2);
        }
        stop.Stop();
        Debug.Log((float)(stop.ElapsedMilliseconds) * 0.001f + "초");
    }
    /// <summary>
    /// 기약분수로 뽑기 true면 기약분수 false면 약분가능
    /// </summary>
    /// <param name="bunmo"></param>
    /// <param name="bunja"></param>
    /// <returns></returns>
    public static System.Tuple<int, int> Reduced_Num(int bunmo, int bunja)
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
    /// 세분수 숫자
    /// </summary>
    /// <param name="stage">난이도</param>
    public void MakeNum(int stage = 0)
    {
        switch (stage)
        {
            case 0:
                {
                    do
                    {
                        one = Random.Range(2, 10);
                        two = Random.Range(2, 10);
                        three = Random.Range(2, 10);
                    }
                    while (one == two || one == three || two == three);
                    break;
                }
            case 1:
                {
                    int count = 0;
                    do
                    {
                        count = 0;
                        one = Random.Range(2, 21);
                        two = Random.Range(2, 21);
                        three = Random.Range(2, 21);
                        if (one > 9)
                            count++;
                        if (two > 9)
                            count++;
                        if (three > 9)
                            count++;
                    }
                    while (one == two || one == three || two == three || count != 2);
                    break;
                }
        }

    }
    ///// <summary>
    ///// 세분수로직
    ///// </summary>
    ///// <param name="stage">난이도호출 0은easy 1은 normal</param>
    ///// <param name="N">약분횟수 4는 이중약분</param>
    ///// <param name="rand">어디가 이중약분될지 0은 맨왼쪽부터 1은중간 2는오른쪽</param>
    ///// <param name="up">이중약분이 분모랑될지 분자랑될지 up은 분자</param>
    //public void MakeQ(int stage = 0, int N = 0, int rand = 4, bool up = true)
    //{
    //    fraction.Clear();
    //    answer_fraction.Clear();
    //    int count = 0;
    //    int count2 = 0;
    //    int N2 = 0;
    //    int a = 0;
    //    int b = 0;
    //    int c = 0;
    //    N2 = N - 3;
    //    if (N2 < 0)
    //        N2 = 0;


    //    bool returnbool = false;
    //    do
    //    {
    //        returnbool = false;
    //        count = 0;
    //        count2 = 0;
    //        a = 0;
    //        b = 0;
    //        c = 0;
    //        do
    //        {
    //            MakeNum(stage);

    //            a = Random.Range(1, one);
    //            b = Random.Range(1, two);
    //            c = Random.Range(1, three);



    //        } while (!Reduced_Check(one, a) || !Reduced_Check(two, b) || !Reduced_Check(three, c));


    //        int temp_one = one;
    //        int temp_two = two;
    //        int temp_three = three;
    //        int temp_a = a;
    //        int temp_b = b;
    //        int temp_c = c;




    //        if (N2 < 1)
    //        {
    //            if (!Reduced_Check(two, a) && !Reduced_Check(three, a))
    //                returnbool = true;
    //            if (!Reduced_Check(one, b) && !Reduced_Check(three, b))
    //                returnbool = true;
    //            if (!Reduced_Check(two, c) && !Reduced_Check(one, c))
    //                returnbool = true;

    //        }
    //        else
    //        {
    //            if (rand == 0)
    //            {
    //                if (up)
    //                {
    //                    if (!Reduced_Check(two, a))
    //                    {
    //                        var check = Reduced_Num(two, a);
    //                        if (!Reduced_Check(three, check.Item2))
    //                        {
    //                            check = Reduced_Num(three, a);
    //                            if (check.Item2 == 1 || check.Item1 == 1)
    //                                returnbool = true;
    //                        }
    //                        else
    //                            returnbool = true;
    //                    }
    //                    else
    //                        returnbool = true;
    //                }
    //                else
    //                {
    //                    if (!Reduced_Check(one, b))
    //                    {
    //                        var check = Reduced_Num(one, b);
    //                        if (!Reduced_Check(check.Item1, c))
    //                        {
    //                            check = Reduced_Num(one, c);
    //                            if (check.Item2 == 1 || check.Item1 == 1)
    //                                returnbool = true;
    //                        }
    //                        else
    //                            returnbool = true;
    //                    }
    //                    else
    //                        returnbool = true;
    //                }
    //            }
    //            else if (rand == 1)
    //            {
    //                if (up)
    //                {
    //                    if (!Reduced_Check(one, b))
    //                    {
    //                        var check = Reduced_Num(one, b);
    //                        if (!Reduced_Check(three, check.Item2))
    //                        {
    //                            check = Reduced_Num(three, b);
    //                            if (check.Item2 == 1 || check.Item1 == 1)
    //                                returnbool = true;
    //                        }
    //                        else
    //                            returnbool = true;
    //                    }
    //                    else
    //                        returnbool = true;
    //                }
    //                else
    //                {
    //                    if (!Reduced_Check(two, a))
    //                    {
    //                        var check = Reduced_Num(two, a);
    //                        if (!Reduced_Check(check.Item1, c))
    //                        {
    //                            check = Reduced_Num(two, c);
    //                            if (check.Item2 == 1 || check.Item1 == 1)
    //                                returnbool = true;
    //                        }
    //                        else
    //                            returnbool = true;
    //                    }
    //                    else
    //                        returnbool = true;
    //                }
    //            }
    //            else
    //            {
    //                if (up)
    //                {
    //                    if (!Reduced_Check(one, c))
    //                    {
    //                        var check = Reduced_Num(one, c);
    //                        if (!Reduced_Check(two, check.Item2))
    //                        {
    //                            check = Reduced_Num(two, c);
    //                            if (check.Item2 == 1 || check.Item1 == 1)
    //                                returnbool = true;
    //                        }
    //                        else
    //                            returnbool = true;
    //                    }
    //                    else
    //                        returnbool = true;
    //                }
    //                else
    //                {
    //                    if (!Reduced_Check(three, a))
    //                    {
    //                        var check = Reduced_Num(three, a);
    //                        if (!Reduced_Check(check.Item1, b))
    //                        {
    //                            check = Reduced_Num(two, b);
    //                            if (check.Item2 == 1 || check.Item1 == 1)
    //                                returnbool = true;
    //                        }
    //                        else
    //                            returnbool = true;
    //                    }
    //                    else
    //                        returnbool = true;
    //                }
    //            }
    //        }







    //        if (!Reduced_Check(one, b))
    //        {
    //            count++;
    //            if (N2 < 1)
    //                if (!Reduced_Check(one, c))
    //                    returnbool = true;
    //            var check = Reduced_Num(one, b);
    //            one = check.Item1;
    //            b = check.Item2;


    //        }
    //        if (!Reduced_Check(one, c))
    //        {
    //            count++;
    //            var check = Reduced_Num(one, c);
    //            one = check.Item1;
    //            c = check.Item2;

    //        }
    //        if (!Reduced_Check(two, a))
    //        {
    //            count++;
    //            if (N2 < 1)
    //                if (!Reduced_Check(two, c))
    //                    returnbool = true;
    //            var check = Reduced_Num(two, a);
    //            two = check.Item1;
    //            a = check.Item2;


    //        }
    //        if (!Reduced_Check(two, c))
    //        {
    //            count++;
    //            var check = Reduced_Num(two, c);
    //            two = check.Item1;
    //            c = check.Item2;

    //        }
    //        if (!Reduced_Check(three, a))
    //        {
    //            count++;
    //            if (N2 < 1)
    //                if (!Reduced_Check(three, b))
    //                    returnbool = true;
    //            var check = Reduced_Num(three, a);
    //            three = check.Item1;
    //            a = check.Item2;


    //        }
    //        if (!Reduced_Check(three, b))
    //        {
    //            count++;
    //            var check = Reduced_Num(three, b);
    //            three = check.Item1;
    //            b = check.Item2;

    //        }
    //        one = temp_one;
    //        two = temp_two;
    //        three = temp_three;
    //        a = temp_a;
    //        b = temp_b;
    //        c = temp_c;

    //        if (N2 == 0)
    //        {
    //            if (count != N)
    //                returnbool = true;
    //        }
    //        if (N == 0)
    //        {
    //            if (one * two * three >= 100)
    //                returnbool = true;
    //        }
    //        else
    //        {
    //            var answer_check = Reduced_Num(one * two * three, a * b * c);
    //            if (answer_check.Item1 >= 100)
    //                returnbool = true;
    //        }
    //    }
    //    while (returnbool);



    //    fraction.Add(one);
    //    fraction.Add(a);
    //    fraction.Add(two);
    //    fraction.Add(b);
    //    fraction.Add(three);
    //    fraction.Add(c);



    //    var answer = Reduced_Num(one * two * three, a * b * c);

    //    answer_fraction.Add(answer.Item1);
    //    answer_fraction.Add(answer.Item2);
    //}




    /// <summary>
    /// 세분수로직
    /// </summary>
    /// <param name="stage">난이도호출 0은easy 1은 normal</param>
    /// <param name="N">약분횟수 4는 이중약분</param>
    /// <param name="daecount">대분수 횟수</param>
    /// <param name="rand">어디가 이중약분될지 0은 맨왼쪽부터 1은중간 2는오른쪽</param>
    /// <param name="up">이중약분이 분모랑될지 분자랑될지 up은 분자</param>


    public void MakeQ2(int stage = 0, int N = 0, int daecount = 0, int rand = 4, bool up = true)
    {
        fraction.Clear();
        answer_fraction.Clear();
        int count = 0;
        int count2 = 0;
        int N2 = 0;
        int a = 0;
        int b = 0;
        int c = 0;
        N2 = N - 3;
        if (N2 < 0)
            N2 = 0;


        bool returnbool = false;
        do
        {
            returnbool = false;
            count = 0;
            count2 = 0;
            a = 0;
            b = 0;
            c = 0;
            do
            {
                count = 0;
                MakeNum(stage);

                a = Random.Range(1, one * 5);
                b = Random.Range(1, two * 5);
                c = Random.Range(1, three * 5);

                if (a > one)
                    count++;
                if (b > two)
                    count++;
                if (c > three)
                    count++;



            } while (!Reduced_Check(one, a) || !Reduced_Check(two, b) || !Reduced_Check(three, c)||daecount!=count);
            count = 0;

            int temp_one = one;
            int temp_two = two;
            int temp_three = three;
            int temp_a = a;
            int temp_b = b;
            int temp_c = c;




            if (N2 < 1)
            {
                if (!Reduced_Check(two, a) && !Reduced_Check(three, a))
                    returnbool = true;
                if (!Reduced_Check(one, b) && !Reduced_Check(three, b))
                    returnbool = true;
                if (!Reduced_Check(two, c) && !Reduced_Check(one, c))
                    returnbool = true;

            }
            else
            {
                if (rand == 0)
                {
                    if (up)
                    {
                        if (!Reduced_Check(two, a))
                        {
                            var check = Reduced_Num(two, a);
                            if (!Reduced_Check(three, check.Item2))
                            {
                                check = Reduced_Num(three, a);
                                if (check.Item2 == 1 || check.Item1 == 1)
                                    returnbool = true;
                            }
                            else
                                returnbool = true;
                        }
                        else
                            returnbool = true;
                    }
                    else
                    {
                        if (!Reduced_Check(one, b))
                        {
                            var check = Reduced_Num(one, b);
                            if (!Reduced_Check(check.Item1, c))
                            {
                                check = Reduced_Num(one, c);
                                if (check.Item2 == 1 || check.Item1 == 1)
                                    returnbool = true;
                            }
                            else
                                returnbool = true;
                        }
                        else
                            returnbool = true;
                    }
                }
                else if (rand == 1)
                {
                    if (up)
                    {
                        if (!Reduced_Check(one, b))
                        {
                            var check = Reduced_Num(one, b);
                            if (!Reduced_Check(three, check.Item2))
                            {
                                check = Reduced_Num(three, b);
                                if (check.Item2 == 1 || check.Item1 == 1)
                                    returnbool = true;
                            }
                            else
                                returnbool = true;
                        }
                        else
                            returnbool = true;
                    }
                    else
                    {
                        if (!Reduced_Check(two, a))
                        {
                            var check = Reduced_Num(two, a);
                            if (!Reduced_Check(check.Item1, c))
                            {
                                check = Reduced_Num(two, c);
                                if (check.Item2 == 1 || check.Item1 == 1)
                                    returnbool = true;
                            }
                            else
                                returnbool = true;
                        }
                        else
                            returnbool = true;
                    }
                }
                else
                {
                    if (up)
                    {
                        if (!Reduced_Check(one, c))
                        {
                            var check = Reduced_Num(one, c);
                            if (!Reduced_Check(two, check.Item2))
                            {
                                check = Reduced_Num(two, c);
                                if (check.Item2 == 1 || check.Item1 == 1)
                                    returnbool = true;
                            }
                            else
                                returnbool = true;
                        }
                        else
                            returnbool = true;
                    }
                    else
                    {
                        if (!Reduced_Check(three, a))
                        {
                            var check = Reduced_Num(three, a);
                            if (!Reduced_Check(check.Item1, b))
                            {
                                check = Reduced_Num(two, b);
                                if (check.Item2 == 1 || check.Item1 == 1)
                                    returnbool = true;
                            }
                            else
                                returnbool = true;
                        }
                        else
                            returnbool = true;
                    }
                }
            }







            if (!Reduced_Check(one, b))
            {
                count++;
                if (N2 < 1)
                    if (!Reduced_Check(one, c))
                        returnbool = true;
                var check = Reduced_Num(one, b);
                one = check.Item1;
                b = check.Item2;


            }
            if (!Reduced_Check(one, c))
            {
                count++;
                var check = Reduced_Num(one, c);
                one = check.Item1;
                c = check.Item2;

            }
            if (!Reduced_Check(two, a))
            {
                count++;
                if (N2 < 1)
                    if (!Reduced_Check(two, c))
                        returnbool = true;
                var check = Reduced_Num(two, a);
                two = check.Item1;
                a = check.Item2;


            }
            if (!Reduced_Check(two, c))
            {
                count++;
                var check = Reduced_Num(two, c);
                two = check.Item1;
                c = check.Item2;

            }
            if (!Reduced_Check(three, a))
            {
                count++;
                if (N2 < 1)
                    if (!Reduced_Check(three, b))
                        returnbool = true;
                var check = Reduced_Num(three, a);
                three = check.Item1;
                a = check.Item2;


            }
            if (!Reduced_Check(three, b))
            {
                count++;
                var check = Reduced_Num(three, b);
                three = check.Item1;
                b = check.Item2;

            }
            one = temp_one;
            two = temp_two;
            three = temp_three;
            a = temp_a;
            b = temp_b;
            c = temp_c;

            if (N2 == 0)
            {
                if (count != N)
                    returnbool = true;
            }
            if (N == 0)
            {
                if (one * two * three >= 100)
                    returnbool = true;
            }
            else
            {
                var answer_check = Reduced_Num(one * two * three, a * b * c);
                if (answer_check.Item1 >= 100)
                    returnbool = true;
            }
        }
        while (returnbool);

        if(a/one==0)
        {
            fraction.Add("");
        }
        else
        fraction.Add((a / one).ToString());
        fraction.Add(one.ToString());
        fraction.Add((a%one).ToString());
        if (b / two == 0)
        {
            fraction.Add("");
        }
        else
            fraction.Add((b / two).ToString());
        fraction.Add(two.ToString());
        fraction.Add((b % two).ToString());
        if (c / three == 0)
        {
            fraction.Add("");
        }
        else
            fraction.Add((c / three).ToString());
        fraction.Add(three.ToString());
        fraction.Add((c % three).ToString());



        var answer = Reduced_Num(one * two * three, a * b * c);

        if (answer.Item2 / answer.Item1 == 0)
            answer_fraction.Add("");
        else
            answer_fraction.Add((answer.Item2/answer.Item1).ToString());
        answer_fraction.Add(answer.Item1.ToString());
        answer_fraction.Add((answer.Item2%answer.Item1).ToString());
    }

}