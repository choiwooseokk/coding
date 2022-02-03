using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BunsuMaker : MonoBehaviour
{
    /// <summary>
    /// 소수곱셈결과저장
    /// </summary>
    public struct Question
    {
        public Problem q0, q1;
        int pointnum
        {
            get
            {
                return q0.pointPosition + q1.pointPosition;
            }
        }
        /// <summary>
        /// 소수곱셈결과 자연수부분
        /// </summary>
        public int front
        {
            get
            {
                int pow = 1;
                for (int i = 0; i < pointnum; i++)
                {
                    pow *= 10;
                }
                return (q0.noPointNum * q1.noPointNum) / pow;
            }
            //example : noPointNum이 1234고, pointPosition이 1이면 -> front의 값은 123이 된다. (소수 첫째자리에서의 정수값)
        }
        /// <summary>
        /// 소수곱셈결과 소수부분
        /// </summary>
        public int back
        {
            get
            {
                int pow = 1;
                for (int i = 0; i < pointnum; i++)
                {
                    pow *= 10;
                }
                return (q0.noPointNum * q1.noPointNum) % pow;
            }
            //example : noPointNum이 1234고, pointPosition이 1이면 -> back의 값은 4이 된다. (소수 첫째자리에서의 소수값)
        }
        /// <summary>
        /// 소수곱셈결과 몇글자인지
        /// </summary>
        public int count
        {
            get
            {
                return q0.count * q1.count;
            }
        }
        /// <summary>
        /// 소수곱셈결과 50.530일경우 50.53 50.00일경우 50으로나옴
        /// </summary>
        public string answer
        {
            get
            {
                string s = front.ToString() + "." + back.ToString("D" + pointnum.ToString());
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
                return s;
                //return front.ToString() + "." + back.ToString("D" + pointnum.ToString());
            }
        }
        /// <summary>
        /// 배열에 0으로끝나는경우를 다 포함시킴
        /// </summary>
        public List<string> ZeroCount
        {
            get
            {
                Problem a = q0.pointpos > q1.pointpos ? q0 : q1;
                int num = Mathf.Abs(pointpos - a.pointpos);
                List<string> s = new List<string>();
                s.Add(answer);
                string zero = "";
                if (!answer.Contains("."))
                {
                    for (int i = 0; i < num - 1; i++)
                    {
                        zero += "0";
                        s.Add(answer + "." + zero);
                    }
                }
                else
                {
                    for (int i = 0; i < num; i++)
                    {
                        zero += "0";
                        s.Add(answer + zero);
                    }
                }
                return s;
            }
        }

        //자연수에서 소수가되기까지 몇번째 옮겨졋는지,소수몇쨰자리인지
        public int pointpos
        {
            get
            {
                if (answer.Contains("."))
                {
                    int a =answer.Length-answer.IndexOf(".")-1;
                    return a;
                }
                return 0;
            }
        }
    }
    /// <summary>
    /// 각 소수부분저장
    /// </summary>
    public struct Problem
    {
        public int noPointNum;
        public int pointPosition;
        /// <summary>
        /// 소수부분자연수
        /// </summary>
        public int front
        {
            get
            {
                int pow = 1;
                for (int i = 0; i < pointPosition; i++)
                {
                    pow *= 10;
                }
                return noPointNum / pow;
            }
            //example : noPointNum이 1234고, pointPosition이 1이면 -> front의 값은 123이 된다. (소수 첫째자리에서의 정수값)
        }
        /// <summary>
        /// 소수부분
        /// </summary>
        public int back
        {
            get
            {
                int pow = 1;
                for (int i = 0; i < pointPosition; i++)
                {
                    pow *= 10;
                }
                return noPointNum % pow;
            }
            //example : noPointNum이 1234고, pointPosition이 1이면 -> back의 값은 4이 된다. (소수 첫째자리에서의 소수값)
        }
        //front와 back은 12.001과 12.1이같으니 보조용으로만 쓸것!
        /// <summary>
        /// 소수결과 50.530일경우 50.53 50.00일경우 50으로나옴
        /// </summary>
        public string answer
        {
            get
            {
                //questions[curQno].q2.front.ToString() + "." + questions[curQno].q2.back.ToString("D" + questions[curQno].q2.pointPosition.ToString());
                string s = front.ToString() + "." + back.ToString("D" + pointPosition.ToString());
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
                return s;
            }
        }
        /// <summary>
        /// 몇자리인지 체크
        /// </summary>

        public int count
        {
            get
            {
                string s = answer;
                if (s.Contains("."))
                  s = s.Replace(".", "");
                char[] phrase = s.ToCharArray();

                for (int i = 0; i < s.Length; i++)
                {
                    if (s.Substring(i, 1) == "0")
                    {
                        phrase[i] = ' ';

                    }
                    else
                        break;
                }
                s = new string(phrase).Trim();
                return s.Length;
            }
        }
        //0과.을제외한숫자
        public string number
        {
            get
            {
                if (answer.Contains("."))
                {

                    return int.Parse(answer.Replace(".", "")).ToString();
                }
                return answer;
            }
        }
        //자연수에서 소수가되기까지 몇번째 옮겨졋는지
        public int pointpos
        {
            get
            {
                if(answer.Contains("."))
                {
                    int a = answer.Length - answer.IndexOf(".")-1;
                    return a;
                }
                return 0;
            }
        }
    }

    public Problem sosu;
    public Problem integer;
    public Question result;
    public enum Level
    {
        easy1,easy2,easy3,easy4,
        normal1,normal2,normal3,normal4,
        hard
    }
    public Question Result()
    {
        Question q = result;
        q.q0 = sosu;
        q.q1 = integer;
        return q;
    }

    /// <summary>
    /// 숫자만들기 소수X소수
    /// </summary>
    /// <param name="_level">난이도</param>
    /// <param name="_N">소수부분자연수</param>
    /// <param name="Count">Count갯수</param>
    public void MakeNum(Level _level, bool answerType = false, int Count = -1)
    {
        bool returnbool = false;
        do
        {
            List<int> maxcount = new List<int>();
            returnbool = false;
            int sosu_integer = 0, num = 0, sosu_one = 0, sosu_two = 0, sosu_three = 0;
            sosu_one = Random.Range(0, 10);
            sosu_two = Random.Range(0, 10);
            sosu_three = Random.Range(0, 10);
            num = Random.Range(2, 31);

            switch (_level)
            {
                case Level.easy1:
                    {
                        num = Random.Range(2, 10);
                        sosu_integer = 0;
                        maxcount.Add(1);
                        break;
                    }
                case Level.easy2:
                    {
                        num = Random.Range(2, 10);
                        sosu_integer = Random.Range(1, 10);
                        maxcount.Add(2);
                        maxcount.Add(3);
                        break;
                    }
                case Level.easy3:
                    {
                        sosu_integer = 0;
                        num = Random.Range(11, 31);
                        maxcount.Add(2);
                        maxcount.Add(3);
                        maxcount.Add(4);
                        break;
                    }
                case Level.easy4:
                    {
                        sosu_integer = Random.Range(1, 10);
                        num = Random.Range(11, 31);
                        maxcount.Add(2);
                        maxcount.Add(3);
                        maxcount.Add(4);
                        break;
                    }
                case Level.normal1:
                    {
                        num = Random.Range(2, 10);
                        sosu_integer = 0;
                        maxcount.Add(2);
                        maxcount.Add(1);
                        break;
                    }
                case Level.normal2:
                    {
                        num = Random.Range(2, 10);
                        sosu_integer = Random.Range(1, 40);
                        maxcount.Add(4);
                        break;
                    }
                case Level.normal3:
                    {
                        num = Random.Range(11, 31);
                        sosu_integer = 0;
                        maxcount.Add(6);
                        break;
                    }
                case Level.normal4:
                    {
                        num = Random.Range(11, 31);
                        sosu_integer = Random.Range(1, 10);
                        maxcount.Add(6);
                        break;
                    }
                case Level.hard:
                    {
                        num = Random.Range(11, 31);
                        sosu_integer = Random.Range(0, 10);
                        maxcount.Add(8);
                        break;
                    }
            }


            //switch (_level)
            //{
            //    case Level.easy:
            //        {
            //            maxcount.Add(1);
            //            break;
            //        }
            //    case Level.normal:
            //        {
            //            maxcount.Add(2);
            //            break;
            //        }
            //    case Level.hard:
            //        {
            //            maxcount.Add(8);
            //            break;
            //        }
            //}


            sosu_integer *= 1000;
            num *= 1000;
            sosu_one *= 100;
            sosu_two *= 10;


            sosu.noPointNum = sosu_integer + sosu_one + sosu_two + sosu_three;
            sosu.pointPosition = 3;
            integer.noPointNum = num;
            integer.pointPosition = 3;
            result.q0 = sosu;
            result.q1 = integer;
            if (result.front > 999)
                returnbool = true;
            if (Count != -1)
            {
                if (Count != result.count)
                    returnbool = true;
            }
            else
            {
                if (!maxcount.Contains(result.count))
                    returnbool = true;
            }

            if (result.answer.Length > 6)
                returnbool = true;

            if (answerType)
            {
                if (result.answer.Contains("."))
                    returnbool = true;
            }
            else
            {
                if (!result.answer.Contains("."))
                    returnbool = true;
            }

        } while (returnbool);
    }

    public bool CheckAnswer(string s)
    {
        if(result.ZeroCount.Contains(s))
        {
            return true;
        }
        return false;
    }

}