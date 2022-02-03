using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Expantion_Fraction
{
    
    [System.Serializable]
    public struct Problem
    {
        public F_Level F_level;
        public F_Count count;
        public int L_bunmo { get; }
        public int R_bunmo { get; }
        public int L_bunja { get; }
        public int R_bunja { get; }
        //int L_integer { get; }
        //int R_integer { get; }

        public int answer_bunmo { get; }
        public int answer_bunja { get; }

        /// 왼쪽 분모, 오른쪽 분자, 오른쪽 분모, 왼쪽 분자
        public List<int> reduceNums { get; }
        
        public Problem(F_Level F_level, F_Count count, int lBunmo, int lBunja, int rBunmo, int rBunja)
        {
            L_bunmo = lBunmo;
            R_bunmo = rBunmo;
            L_bunja = lBunja;
            R_bunja = rBunja;
            this.F_level = F_level;
            this.count = count;

            var check = fraction2_ws.multbunsu(L_bunmo, L_bunja, R_bunmo, R_bunja);
            var Reduce = fraction2_ws.Reduced_Num(L_bunmo, R_bunja);
            var Reduce1 = fraction2_ws.Reduced_Num(R_bunmo, L_bunja);
            reduceNums = new List<int>()
            {
                Reduce.Item1, Reduce.Item2,
                Reduce1.Item1, Reduce1.Item2
            };
            answer_bunmo = check.Item2;
            answer_bunja = check.Item3;
        }
    }
    
    
    public enum F_Level { easy, normal, hard };
    public enum F_Count { zero, leftone,rightone, two };
    public enum kiyacType { wrong, nokiyac, kiyac };


    public class fraction2_ws : MonoBehaviour
    {
        public static List<int> reducenum = new List<int>();
       

        // Start is called before the first frame update
        void Start()
        {
            //System.Diagnostics.Stopwatch stop = new System.Diagnostics.Stopwatch();
            //stop.Start();
            ////Make(F_level.easy);
            ////Make(F_level.normal);
            ////Make(F_level.hard);
            //MakeQuestion();
            //stop.Stop();
            //Debug.Log(stop.ElapsedMilliseconds + "ms");

        }

        public List<Problem> p = new List<Problem>();
        public int maxqnum=0;
        void MakeQuestion()
        {
            List<F_Level> level = new List<F_Level>();
            List<F_Count> count = new List<F_Count>();


            for (int i=0; i< maxqnum; i++)
            {
                if(i<5)
                {
                    level.Add(F_Level.normal);
                }
                else if(i<10)
                {
                    level.Add(F_Level.normal);
                }
                else
                {
                    level.Add(F_Level.normal);
                }

                if(i<5)
                {
                    count.Add(F_Count.leftone);
                }
                else if(i<10)
                {
                    count.Add(F_Count.leftone);
                }
                else
                {
                    count.Add(F_Count.leftone);
                }
            }

            p = MakeFractions(level, count, maxqnum);

        }

        public List<Problem> MakeFractions(List<F_Level> level, List<F_Count> a, int maxQno)
        {
            List<Problem> qList = new List<Problem>();

            for (int i = 0; i < maxQno;)
            {
                Problem p = MakeBunsu(level[i], a[i]);

                if(qList.Contains(p))
                {
                    continue;
                }

                qList.Add(MakeBunsu(level[i], a[i]));

                
                i++;
            }

            

            return qList;





            //List<Problem> eList = new List<Problem>();
            //List<Problem> nList = new List<Problem>();
            //List<Problem> hList = new List<Problem>();

            //bool is_has_easy = level.Contains(F_level.easy);
            //bool is_has_normal = level.Contains(F_level.normal);
            //bool is_has_hard = level.Contains(F_level.hard);

            //if(is_has_easy)
            //{
            //    eList = Make(F_level.easy);
            //}
            //if(is_has_normal)
            //{
            //    nList = Make(F_level.normal);
            //}
            //if(is_has_hard)
            //{
            //    hList = Make(F_level.hard);
            //}

            //List<int> used_easy = new List<int>();
            //List<int> used_normal = new List<int>();
            //List<int> used_hard = new List<int>();

            //for (int i=0; i<maxQno;i++)
            //{
            //    int index;
            //    switch(level[i])
            //    {
            //        case F_level.easy:
            //            do
            //            {
            //                index = Random.Range(0, eList.Count);
            //            } while (used_easy.Contains(index) || eList[index].count != a[i]);
            //            used_easy.Add(index);
            //            qList.Add(eList[index]);

            //            break;
            //        case F_level.normal:
            //            do
            //            {
            //                index = Random.Range(0, nList.Count);
            //            } while (used_normal.Contains(index) || nList[index].count != a[i]);
            //            used_normal.Add(index);
            //            qList.Add(nList[index]);
            //            break;
            //        case F_level.hard:
            //            do
            //            {
            //                index = Random.Range(0, hList.Count);
            //            } while (used_hard.Contains(index) || hList[index].count != a[i]);
            //            used_hard.Add(index);
            //            qList.Add(hList[index]);
            //            break;
            //    }
            //}


            //return qList;
        }

        #region 분수만드는 기능들
        /// <summary>
        /// 최대공약수
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        public static int GetGCD(int a, int b)
        {
            if (a == 0 || b == 0)
                return 0;

            if (b > a)
            {
                int tmp = a;
                a = b;
                b = tmp;
            }

            return (a % b == 0 ? b : GetGCD(b, a % b));
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
        /// 기약분수인지 체크
        /// </summary>
        /// <param name="bunmo"></param>
        /// <param name="bunja"></param>
        /// <param name="_NatureContain"></param>
        /// <returns></returns>
        public static bool Reduced_Check(int bunmo, int bunja, bool _NatureContain = false)
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
        /// 가분수를 대분수로만들기
        /// </summary>
        /// <param name="num"></param>
        /// <param name="num1"></param>
        /// <returns></returns>
        public static System.Tuple<int, int, int> ToDaebunsu(int num, int num1)
        {
            int a = num1 / num;
            int b = num1 % num;
            return new System.Tuple<int, int, int>(a, num, b);
        }
        /// <summary>
        /// 대분수를 가분수로만들기
        /// </summary>
        /// <param name="num"></param>
        /// <param name="num1"></param>
        /// <returns></returns>
        public static System.Tuple<int, int> ToGabunsu(int num, int num1, int num2)
        {
            int a;
            if (num != 0)
                a = (num * num1) + num2;
            else
                a = num2;
            return new System.Tuple<int, int>(num1, a);
        }
        /// <summary>
        /// 약수
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public static List<int> abbreviation(List<int> a, int num)
        {
            for (int i = 2; i <= num; i++)
            {
                if (num % i == 0)
                    a.Add(i);
            }
            return a;
        }
        #endregion


        #region 분수결과를뽑는기능들

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

        /// <summary>
        /// 분수X분수 item1이 0이나오면 진분수 item2가1이나오며item3이0이 나오면 자연수
        /// </summary>
        /// <param name="bottom">분모</param>
        /// <param name="top">분자</param>
        /// <param name="num">분수에들어갈자연수</param>
        /// <param name="num1">곱할 자연수</param>
        /// <returns></returns>
        public static System.Tuple<int, int, int> multbunsu(int bottom, int top, int bottom1, int top1, int num = 0, int num1 = 0)
        {
            var g = ToGabunsu(num, bottom, top);
            var g1 = ToGabunsu(num1, bottom1, top1);

            var gg = Reduced_Num(g.Item1, g.Item2);
            var gg1 = Reduced_Num(g1.Item1, g1.Item2);


            var check = Reduced_Num(gg.Item1, gg1.Item2);
            var check1 = Reduced_Num(gg1.Item1, gg.Item2);

            //var gg = 

            reducenum.Clear();
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


            return new System.Tuple<int, int, int>(resultint, resultmo, resulitja);

        }

        #endregion
        

        #region 분수만드는로직

        public void MakeNum(F_Level _level, out int L_bunmo, out int L_bunja, out int R_bunmo, out int R_bunja)
        {
            switch (_level)
            {
                case F_Level.easy:
                    L_bunmo = Random.Range(2, 10);
                    R_bunmo = Random.Range(2, 10);
                    L_bunja = Random.Range(1, L_bunmo);
                    R_bunja = Random.Range(1, R_bunmo);
                    break;
                case F_Level.normal:
                    if(Random.Range(0,2)==0)
                    {
                        L_bunmo = Random.Range(10, 31);
                        R_bunmo = Random.Range(2, 10);
                    }
                    else
                    {
                        L_bunmo = Random.Range(2, 10);
                        R_bunmo = Random.Range(10, 31);
                    }
                    L_bunja = Random.Range(1, L_bunmo);
                    R_bunja = Random.Range(1, R_bunmo);
                    break;
                case F_Level.hard:
                    L_bunmo = Random.Range(20, 51);
                    R_bunmo = Random.Range(20, 51);
                    L_bunja = Random.Range(1, L_bunmo);
                    R_bunja = Random.Range(1, R_bunmo);
                    break;
                default:
                    L_bunmo = 0;
                    L_bunja = 0;
                    R_bunmo = 0;
                    R_bunja = 0;
                    return;
            }
        }
        public Problem MakeBunsu(F_Level _level, F_Count _Num)
        {
            Problem p = new Problem();
            int looptime = 0;
            while (true)
            {
                if (++looptime > 10000)
                {
                    Debug.LogError("Loop Error");
                    return p;
                }

                MakeNum(_level, out int L_bunmo, out int L_bunja, out int R_bunmo, out int R_bunja);
                List<int> a = new List<int>();
                abbreviation(a, L_bunmo);
                List<int> b = new List<int>();
                abbreviation(b, R_bunmo);

                if (!Reduced_Check(L_bunmo, L_bunja) || !Reduced_Check(R_bunmo, R_bunja))
                    continue;



                switch (_Num)
                {
                    case F_Count.zero:
                        {

                            if ((GetGCD(R_bunja, L_bunmo) != 1) || (GetGCD(L_bunja, R_bunmo) != 1))
                                continue;
                            break;
                        }
                    case F_Count.leftone:
                        {
                            if ((GetGCD(R_bunja, L_bunmo) == 1) || (GetGCD(L_bunja, R_bunmo) != 1))
                                continue;
                            break;
                        }
                    case F_Count.rightone:
                        {
                            if ((GetGCD(R_bunja, L_bunmo) != 1) || (GetGCD(L_bunja, R_bunmo) == 1))
                                continue;
                            //if (!a.Contains(R_bunja) || b.Contains(L_bunja))
                            //    continue;
                            break;
                        }
                    case F_Count.two:
                        {
                            if ((GetGCD(R_bunja, L_bunmo) == 1) || (GetGCD(L_bunja, R_bunmo) == 1))
                                continue;
                            //if (!a.Contains(R_bunja) || !b.Contains(L_bunja))
                            //    continue;
                            break;
                        }
                }
                var check = multbunsu(L_bunmo, L_bunja, R_bunmo, R_bunja);
                if (check.Item2 > 99)
                    continue;
                p = new Problem(_level, _Num, L_bunmo, L_bunja, R_bunmo, R_bunja);
                return p;
            }
        }

        List<Problem> Make(F_Level level)
        {
            List<Problem> problem = new List<Problem>();
            bool easyCheck = true;
            bool normalCheck = true;
            bool hardCheck = true ;
            int lownum=0;
            int highnum=0;
            if(level == F_Level.easy)
            {
                lownum = 2;
                highnum = 11;
            }
            else if (level== F_Level.normal)
            {
                lownum = 2;
                highnum = 31;
            }
            else
            {
                lownum = 20;
                highnum = 41;
            }

            // 2~30
            int lBottom, rBottom, lTop, rTop;
            //System.Diagnostics.Stopwatch stop = new System.Diagnostics.Stopwatch();
            //stop.Start();
            for (lBottom = lownum; lBottom < highnum; lBottom++)
            {
                for (lTop = 1; lTop < lBottom; lTop++)
                {
                    if (GetGCD(lBottom, lTop) != 1)
                    {
                        continue;
                    }

                    for (rBottom = lownum; rBottom < highnum; rBottom++)
                    {
                       
                        for (rTop = 1; rTop < rBottom; rTop++)
                        {
                            if (GetGCD(rBottom, rTop) != 1)
                            {
                                continue;
                            }

                            var c = Reduced_Num(lBottom, rTop);
                            var c1 = Reduced_Num(rBottom, lTop);
                            if (c.Item1 * c1.Item1 > 99)
                                continue;

                            bool check1 = !Reduced_Check(lBottom, rTop);
                            bool check2 = !Reduced_Check(rBottom, lTop);

                            if (check1 && check2)
                            {
                                // 2번
                                problem.Add(new Problem(level, F_Count.two, lBottom, lTop, rBottom, rTop));
                            }
                            else if (check1 && !check2)
                            {
                                // 1번
                                problem.Add(new Problem(level, F_Count.leftone, lBottom, lTop, rBottom, rTop));
                            }
                            else if (!check1 && check2)
                            {
                                // 1번
                                problem.Add(new Problem(level, F_Count.rightone, lBottom, lTop, rBottom, rTop));
                            }
                            else
                            {
                                // 0번
                                problem.Add(new Problem(level, F_Count.zero, lBottom, lTop, rBottom, rTop));
                            }
                        }
                    }
                }
            }
            //stop.Stop();
            //Debug.Log(stop.ElapsedMilliseconds + "ms");
            //fract.Add(level, problem);
            //foreach(var pro in problem)
            //{
            //    Debug.Log($"{pro.L_bunja}/{pro.L_bunmo} × {pro.R_bunja}/{pro.R_bunmo}");
            //    Debug.Log(pro.count);
            //    Debug.Log("                       ");
            //}
            return problem;
        }

        #endregion

    }
}