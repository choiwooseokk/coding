using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class cal_hj : MonoBehaviour
{
    public bool easymode;
    public string[] three;
    [Header("기호위치가변하는식")]
    public bool GihoRand;
    [Header("몇번 변할지")]
    public int gihorandnum;
    [Header("괄호위치가변하는식")]
    public bool gwahoRand;
    List<string> question = new List<string>();
    public List<string> questioninfo = new List<string>();
    public int answer;
    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Z))
            MakeQuestion(2, false);
    }
    public void GihoRandmaker()
    {





        //List<int> rand = new List<int>();




        //int randing;
        //for (int i = 0; i < 3; i++)
        //{

        //    //do
        //    //{
        //    //    randing = Random.Range(0, 24);
        //    //} while (rand.Contains(randing));
        //    //rand.Add(randing);

        //}

        bool fail = false;
        string[] three;
        string[] gihocount = new string[4];
        //string[] giho = new string[mustHavegiho.Length];

        for (int i = 0; i < 4; i++)
        {
            gihocount[i] = mustHavegiho[i];
        }

        for (int z = 0; z < 1; z++)
        {
            int gihonum = 0;
            int num = 0;

            do
            {
                for (int q = 0; q < 4; q++)
                {
                    mustHavegiho[q] = gihocount[q];
                }
                gihonum = 0;
                num = 0;
                question_real = new int[5];
                MakeNumber();

                three = new string[gihorandnum];
                fail = false;



                for (int i = 0; i < gihorandnum; i++)
                {
                    InfixMaker();

                    ReplaceRealnum();

                    if (Calculation().fail == true)
                        fail = true;

                    else
                    {
                        num--;
                        three[i] = Getstring();
                        for (int y = 0; y < mustHavegiho.Length; y++)
                        {
                            if (i != mustHavegiho.Length - 1)
                            {
                                if (y + num < 0)
                                    gihonum = (y + num) + mustHavegiho.Length;
                                else
                                    gihonum = y + num;
                                mustHavegiho[y] = gihocount[gihonum];
                            }
                            else
                            {
                                mustHavegiho[y] = gihocount[(y + 1) % mustHavegiho.Length];
                            }
                        }

                    }

                }

            } while (fail);

            int a = 0;
            int b = 0;
            for (int i = 0; i < 9; i++)
            {
                if (i % 2 == 0)
                {
                    question.Add(question_real[a].ToString());
                    a++;
                }
                else
                {
                    question.Add(gihocount[b]);
                    b++;
                }
            }

            for (int i = 0; i < gihorandnum; i++)
                Debug.Log(three[i]);
        }




    }

    void GwahoRandomaker()
    {


        question_real = new int[5];






        bool fail;
        string[] three = new string[3];
        List<string> three2 = new List<string>();


        do
        {

            three2.Clear();
            int j = Random.Range(0, 24);

            MakeNumber();
            fail = false;
            for (int i = 0; i < 3; i++)
            {
                int gwalholenght = Random.Range(0, 2);
                gwalhoStart = new int[gwalholenght];
                gwalhoEnd = new int[gwalholenght];

                if (gwalholenght == 1)
                {
                    gwalhoStart[0] = Random.Range(0, 4);
                    gwalhoEnd[0] = gwalhoStart[0] + 1;

                }
                if (gwalholenght == 2)
                {
                    gwalhoStart[0] = Random.Range(0, 2);
                    gwalhoEnd[0] = Random.Range(gwalhoStart[0] + 1, 3);

                    gwalhoStart[1] = Random.Range(gwalhoEnd[0] + 1, 4);
                    gwalhoEnd[1] = Random.Range(gwalhoStart[1] + 1, 5);


                }
                InfixMaker(j);

                Getindex();

                ReplaceRealnum();

                if (Calculation().fail == true)
                    fail = true;
                else
                {

                    if (three2.Contains(Getstring()))
                        fail = true;
                    else
                    {
                        three2.Add(Getstring());

                    }



                }

            }

        }
        while (fail);




        for (int i = 0; i < 3; i++)
            Debug.Log(three2[i]);

    }



    public void QuestionString()
    {
        questioninfo.Clear();
        string St = three[0];
        char[] phraseAsChars = St.ToCharArray();
        int a = 0;
        string s = "";
        for (int i = 0; i < phraseAsChars.Length; i++)
        {
            if (i != 0)
            {
                if (int.TryParse(phraseAsChars[i].ToString(), out a))
                {
                    s += phraseAsChars[i].ToString();
                }
                else
                {
                    if (s != "")
                    {
                        questioninfo.Add(s);
                        s = "";
                    }
                    questioninfo.Add(phraseAsChars[i].ToString());
                }
            }
            else if(i==0)
            {
                if (!int.TryParse(phraseAsChars[i].ToString(), out a))
                {
                    questioninfo.Add(phraseAsChars[i].ToString());
                }
                else
                {
                    s += phraseAsChars[i].ToString();
                }
            }
        }
        if (s != "")
        questioninfo.Add(s);
        s = "";
        for (int i = 0; i < questioninfo.Count; i++)
            s += questioninfo[i];
        Debug.Log(s);
    }
    public void MakeQuestion(int gwalho, bool b)
    {
        three = new string[1];
        easymode = b;
        List<int> rand = new List<int>();
        int[] arr = new int[24];
        for (int i = 0; i < 24; i++)
        {
            arr[i] = i;
        }

        bool fail = false;
        int county = 0;
        int j = random.Next(0, 24);
        question_real = new int[4];
        

        int gwalholenght = gwalho;
        gwalhoStart = new int[1];
        gwalhoEnd = new int[1];

        if (gwalholenght == 1)
        {
            gwalhoStart[0] = random.Next(0, 3);
            gwalhoEnd[0] = gwalhoStart[0] + 1;

        }
        if (gwalholenght == 2)
        {
            gwalhoStart[0] = random.Next(0, 2);
            gwalhoEnd[0] = gwalhoStart[0] + 2;


        }
        InfixMaker(j);
        Getindex();
        do
        {
            MakeNumber(InfixToPostfix());
            ReplaceRealnum();


        }
        while (Calculation().fail);
        three[0] = Getstring();
        QuestionString();
        answer = answers[answers.Count - 1];
    }
    public void MakeQuestionnum(bool B = true)
    {
        int returnnum = 0;
        three = new string[1];
        List<int> rand = new List<int>();
        int[] arr = new int[24];
        for (int i = 0; i < 24; i++)
        {
            arr[i] = i;
        }

        bool fail = false;
        int county = 0;
        int j = random.Next(0, 24);
        question_real = new int[4];

        InfixMaker(j);
        Getindex();
        do
        {
            returnnum++;
            if (returnnum > 100)
            {
                MakeQuestionnum(B);
                return;
            }
            SameMakeNumber(B);
            ReplaceRealnum();


        }
        while (Calculation().fail);
        three[0] = Getstring();
        QuestionString();
        answer = answers[answers.Count - 1];
    }
    List<int>[] ListofOrderList = new List<int>[3];


    System.Random random = new System.Random();




    public void SameMakeNumber(bool b)
    {
        if(b)
        {
            int rand = Random.Range(2, 10);
            for (int i = 0; i < question_real.Length; i++)
                question_real[i] = rand;
        }
        else
        {
            //List<int> a = new List<int>();
            //int ran = Random.Range(0, 4);
            //for(int i=0;i<4;)
            //{
            //    if(a.Contains(ran))
            //    {
            //        ran = Random.Range(0, 4);
            //    }
            //    else
            //    {
            //        a.Add(ran);
            //        i++;
            //    }
            //}
            int rand = Random.Range(2, 10);
            int rand1 = Random.Range(2, 10);
            while(rand==rand1)
                rand1 = Random.Range(2, 10);
            for(int i=0;i<4;i++)
            {
                if(i<2)
                question_real[i] = rand;
                else
                    question_real[i] = rand1;
            }
        }
    }


    public void Start()
    {
        for (int i = 0; i < 100; i++)
            MakeQuestion(1,true);
        //for(int i=0;i<1;i++)
        //MakeQuestion(2,false);
        //System.DateTime prev = System.DateTime.Now;
        //if (gwahoRand)
        //    GwahoRandomaker();
        //if (GihoRand)
        //    GihoRandmaker();
        //else
        //{
        //    for (int i = 0; i < 30; i++)
        //    {

        //        int j = Random.Range(0, 24);
        //        question_real = new int[5];


        //        //int gwalholenght = Random.Range(0, 3);
        //        //gwalhoStart = new int[gwalholenght];
        //        //gwalhoEnd = new int[gwalholenght];

        //        //if (gwalholenght == 1)
        //        //{
        //        //    gwalhoStart[0] = Random.Range(0, 4);
        //        //    gwalhoEnd[0] = Random.Range(gwalhoStart[0] + 1, 5);

        //        //}
        //        //if (gwalholenght == 2)
        //        //{
        //        //    gwalhoStart[0] = Random.Range(0, 2);
        //        //    gwalhoEnd[0] = Random.Range(gwalhoStart[0] + 1, 3);

        //        //    gwalhoStart[1] = Random.Range(gwalhoEnd[0] + 1, 4);
        //        //    gwalhoEnd[1] = Random.Range(gwalhoStart[1] + 1, 5);


        //        //}



        //        InfixMaker();
        //        Getindex();
        //        do
        //        {
        //            MakeNumber(InfixToPostfix());
        //            ReplaceRealnum();


        //        }
        //        while (Calculation().fail);
        //    }


        //}
        //System.TimeSpan t = System.DateTime.Now - prev;
        //Debug.Log("Time: " + t.ToString());
    }

    List<string> calculationer_origin = new List<string>();
    List<string> calculationer = new List<string>();
    List<int> orderList = new List<int>();
    List<int> answers = new List<int>();


    //건드리지말것!
    string[] giho = { "÷", "+", "-", "×" };


    //실제 수
    [Header("실제수들")]
    public int[] question_real;

    //괄호 시작점과 끝점//자동생성시에만 생성
    [Header("어떤 숫자 앞에서 괄호가 시작하는지")]
    public int[] gwalhoStart;

    [Header("어떤 숫자 앞에서 괄호가 끝나는지")]
    public int[] gwalhoEnd;

    [Header("꼭 들어가야할 기호")]
    public string[] mustHavegiho = { "÷", "×", "+", "-" };

    public void MakeNumber()
    {

        for (int i = 0; i < question_real.Length; i++)
            question_real[i] = Random.Range(2, 100);

    }


    public void MakeNumber(string _str)
    {
        for (int i = 0; i < question_real.Length; i++)
            question_real[i] = -1;

        if (_str.Contains("-"))
        {
            int i = _str.IndexOf('-');

            if (_str[i - 1] <= 'z' && _str[i - 1] >= 'a' && _str[i - 2] >= 'a' && _str[i - 2] <= 'z')
            {
                question_real[_str[i - 2] - 'a'] = Random.Range(4, 100);
                question_real[_str[i - 1] - 'a'] = Random.Range(2, question_real[_str[i - 2] - 'a']);
            }

        }

        if (_str.Contains("÷"))
        {
            int i = _str.IndexOf('÷');

            if (_str[i - 1] <= 'z' && _str[i - 1] >= 'a' && _str[i - 2] >= 'a' && _str[i - 2] <= 'z')
            {
                question_real[_str[i - 1] - 'a'] = Random.Range(2, 10);
                question_real[_str[i - 2] - 'a'] = Random.Range(2, 10) * question_real[_str[i - 1] - 'a'];

            }

        }

        if (_str.Contains("×"))
        {
            int i = _str.IndexOf('×');



            if (_str[i - 1] <= 'z' && _str[i - 1] >= 'a' && _str[i - 2] >= 'a' && _str[i - 2] <= 'z')
            {
                question_real[_str[i - 1] - 'a'] = Random.Range(2, 12);
                question_real[_str[i - 2] - 'a'] = Random.Range(2, 12);

            }
        }

        if (_str.Contains("+"))
        {
            int i = _str.IndexOf('+');

            if (_str[i - 1] <= 'z' && _str[i - 1] >= 'a' && _str[i - 2] >= 'a' && _str[i - 2] <= 'z')
            {
                question_real[_str[i - 1] - 'a'] = Random.Range(2, 100);
                question_real[_str[i - 2] - 'a'] = Random.Range(2, 100);

            }

        }



        for (int i = 0; i < question_real.Length; i++)
        {
            if (question_real[i] == -1)
                question_real[i] = Random.Range(2, 100);
        }
    }



    public int cal_ex(string _str)
    {
        int a = question_real[_str[0] - 'a'];
        int b = 0;
        if (_str.Length > 2)
            b = question_real[_str[2] - 'a'];
        for (int i = 1; i < _str.Length;)
        {
            if (i == 1)
            {

                switch (_str[i])
                {
                    case '+':
                        question_real[_str[i - 1] - 'a'] = Random.Range(2, 100);
                        question_real[_str[i + 1] - 'a'] = Random.Range(2, 100);
                        break;
                    case '×':
                        question_real[_str[i - 1] - 'a'] = Random.Range(3, 10);
                        question_real[_str[i + 1] - 'a'] = Random.Range(3, 15);
                        break;
                    case '÷':
                        question_real[_str[i + 1] - 'a'] = Random.Range(3, 10);
                        question_real[_str[i - 1] - 'a'] = Random.Range(3, 15) * question_real[_str[i + 1] - 'a'];
                        break;
                }

            }

            if (i == 3)
            {
                switch (_str[i])
                {
                    case '+':
                        switch (_str[i - 2])
                        {
                            case '÷':

                                question_real[_str[i - 1] - 'a'] = Random.Range(3, 10);
                                question_real[_str[i - 3] - 'a'] = Random.Range(3, 15) * question_real[_str[i - 1] - 'a'];
                                question_real[_str[i + 1] - 'a'] = Random.Range(3, 100);
                                break;
                            case '×':
                                question_real[_str[i - 1] - 'a'] = Random.Range(3, 15);
                                question_real[_str[i - 3] - 'a'] = Random.Range(3, 10);
                                question_real[_str[i + 1] - 'a'] = Random.Range(3, 100);
                                break;
                        }
                        break;
                    case '×':
                        switch (_str[i])
                        {
                            case '÷':
                                question_real[_str[i - 1] - 'a'] = Random.Range(3, 10);
                                question_real[_str[i - 3] - 'a'] = Random.Range(3, 15) * question_real[_str[i - 1] - 'a'];
                                question_real[_str[i + 1] - 'a'] = Random.Range(3, 10);
                                break;
                            case '+':
                                question_real[_str[i - 1] - 'a'] = Random.Range(3, 100);
                                question_real[_str[i - 3] - 'a'] = Random.Range(3, 100);
                                question_real[_str[i + 1] - 'a'] = Random.Range(3, 10);
                                break;

                        }
                        break;
                    case '÷':
                        switch (_str[i])
                        {
                            case '+':
                                question_real[_str[i + 1] - 'a'] = Random.Range(2, 10);
                                int temp = Random.Range(2, 15);
                                int temp2 = Random.Range(1, temp);
                                question_real[_str[i - 3] - 'a'] = (temp - temp2) * question_real[_str[i + 1] - 'a'];
                                question_real[_str[i - 1] - 'a'] = (temp2) * question_real[_str[i + 1] - 'a'];



                                break;
                            case '×':
                                question_real[_str[i + 1] - 'a'] = Random.Range(2, 10);

                                break;

                        }
                        break;
                }


            }





            if (_str[i] == '+')
            {

                a = a + b;
                i++; i++;
                if (_str.Length > i)
                {
                    b = question_real[_str[i - 1] - 'a'];
                }
            }

            else if (_str[i] == '-')
            {

                a = a - b;
                i++; i++;
                if (_str.Length > i)
                {
                    b = question_real[_str[i - 1] - 'a'];
                }
            }
            else if (_str[i] == '×')
            {

                a = a * b;
                i++; i++;
                if (_str.Length > i)
                {
                    b = question_real[_str[i - 1] - 'a'];
                }
            }

            else if (_str[i] == '÷')
            {

                a = a / b;
                i++; i++;
                if (_str.Length > i)
                {
                    b = question_real[_str[i - 1] - 'a'];
                }
            }
            else
                i++;

        }


        return a;





    }
















    public void Put_Int(int[] _question_real)
    {
        question_real = _question_real;
    }

    public void InfixMaker(int _count = -1)
    {




        calculationer.Clear();
        int gwalhocount = 0;
        int gihocount = 0;


        int[] randoming = { 0, 1, 2, 3 };
        for (int j = 0; j < 10; j++)
        {
            int rand = Random.Range(0, 4);
            int temp = randoming[0];
            randoming[0] = randoming[rand];
            randoming[rand] = temp;
        }


        int[,] randbeam = new int[24, 4];

        int count0 = 0;
        for (int i = 0; i < 4; i++)
        {

            for (int j = 0; j < 3; j++)
            {
                for (int k = 0; k < 2; k++)
                {
                    List<int> randy = new List<int>();
                    randy.Add(0);
                    randy.Add(1);
                    randy.Add(2);
                    randy.Add(3);

                    randbeam[count0, 0] = randy[i];
                    randy.RemoveAt(i);
                    randbeam[count0, 1] = randy[j];
                    randy.RemoveAt(j);
                    randbeam[count0, 2] = randy[k];
                    randy.RemoveAt(k);
                    randbeam[count0, 3] = randy[0];
                    randy.RemoveAt(0);

                    count0++;

                }
            }

        }









        for (int i = 0; i < question_real.Length; i++)
        {

            if (gwalhocount < gwalhoStart.Length && i == gwalhoStart[gwalhocount])
            {

                calculationer.Add("(");
            }


            calculationer.Add(((char)('a' + i)).ToString());

            if (gwalhocount < gwalhoStart.Length && i == gwalhoEnd[gwalhocount])
            {
                calculationer.Add(")");
                gwalhocount++;
            }

            if (i != question_real.Length - 1)
            {


                if (_count != -1)
                {


                    calculationer.Add(giho[randbeam[_count, gihocount]]);
                    gihocount++;
                }


                else if (mustHavegiho.Length > gihocount)
                {
                    calculationer.Add(mustHavegiho[gihocount]);
                    gihocount++;
                }
                else
                {

                    calculationer.Add(giho[randoming[gihocount]]);

                    gihocount++;

                }

                //todo: 기호 랜덤 한번씩 생성토록할것.
            }
        }


        calculationer_origin = calculationer.ToList();




    }

    public void ReplaceRealnum()
    {
        for (int i = 0; i < question_real.Length; i++)
        {


            calculationer[calculationer_origin.IndexOf(((char)('a' + i)).ToString())] = question_real[i].ToString();


        }


    }



    public (bool fail, List<int> answer) Calculation()
    {
        answers.Clear();

        List<List<string>> calc = new List<List<string>>();
        List<string> calculator = calculationer.ToList();

        int count = 0;
        for (int i = 0; i < calculator.Count;)
        {
            if (calculator[i] == "(")
            {
                calculator.RemoveAt(i);
                List<string> fix = new List<string>();



                while (calculator[i] != ")")
                {

                    fix.Add(calculator[i]);
                    calculator.RemoveAt(i);
                }
                calculator.RemoveAt(i);
                calculator.Insert(i, "On" + count.ToString());
                count++;
                calc.Add(fix);
            }
            else
                i++;
        }






        List<List<int>> order = new List<List<int>>();
        for (int i = 0; i < calc.Count; i++)
        {

            order.Add(new List<int>());
            int count2 = 0;

            for (int j = 0; j < calc[i].Count;)
            {
                if (calc[i][j] == "×")
                {
                    int a = int.Parse(calc[i][j - 1]);
                    int b = int.Parse(calc[i][j + 1]);

                    calc[i].RemoveAt(j - 1);
                    calc[i].RemoveAt(j - 1);
                    calc[i].RemoveAt(j - 1);

                    calc[i].Insert(j - 1, (a * b).ToString());

                    answers.Add((a * b));

                    if (a * b > 150)
                        return (true, null);
                }
                else if (calc[i][j] == "÷")
                {
                    int a = int.Parse(calc[i][j - 1]);
                    int b = int.Parse(calc[i][j + 1]);

                    calc[i].RemoveAt(j - 1);
                    calc[i].RemoveAt(j - 1);
                    calc[i].RemoveAt(j - 1);

                    calc[i].Insert(j - 1, (a / b).ToString());

                    if (a % b != 0 || a / b < 3)
                        return (true, null);
                    answers.Add((a / b));

                }
                else
                    j++;
            }



            for (int j = 0; j < calc[i].Count;)
            {
                if (calc[i][j] == "+")
                {
                    int a = int.Parse(calc[i][j - 1]);
                    int b = int.Parse(calc[i][j + 1]);

                    calc[i].RemoveAt(j - 1);
                    calc[i].RemoveAt(j - 1);
                    calc[i].RemoveAt(j - 1);

                    calc[i].Insert(j - 1, (a + b).ToString());



                    answers.Add((a + b));

                    if (a + b > 300)
                        return (true, null);



                }
                else if (calc[i][j] == "-")
                {
                    int a = int.Parse(calc[i][j - 1]);
                    int b = int.Parse(calc[i][j + 1]);

                    calc[i].RemoveAt(j - 1);
                    calc[i].RemoveAt(j - 1);
                    calc[i].RemoveAt(j - 1);

                    calc[i].Insert(j - 1, (a - b).ToString());

                    answers.Add((a - b));

                    if (a - b < 2)
                        return (true, null);

                }
                else
                    j++;
            }



            int temp = calculator.IndexOf("On" + i.ToString());






            calculator.RemoveAt(temp);
            calculator.Insert(temp, answers[answers.Count - 1].ToString());


        }





        List<int> tempList = new List<int>();
        //여기서부터 다시 인덱싱 필요
        for (int i = 0; i < calculator.Count;)
        {

            if (calculator[i] == "×")
            {





                int a = int.Parse(calculator[i - 1]);
                int b = int.Parse(calculator[i + 1]);

                calculator.RemoveAt(i - 1);
                calculator.RemoveAt(i - 1);
                calculator.RemoveAt(i - 1);
                calculator.Insert(i - 1, (a * b).ToString());
                answers.Add((a * b));

                if (a * b > 150)
                    return (true, null);




            }

            else if (calculator[i] == "÷")
            {

                int a = int.Parse(calculator[i - 1]);
                int b = int.Parse(calculator[i + 1]);

                calculator.RemoveAt(i - 1);
                calculator.RemoveAt(i - 1);
                calculator.RemoveAt(i - 1);
                calculator.Insert(i - 1, (a / b).ToString());
                answers.Add((a / b));
                if (a % b != 0 || a / b < 3)
                    return (true, null);

            }
            else
                i++;


        }




        for (int i = 0; i < calculator.Count;)
        {
            if (calculator[i] == "+")
            {

                int a = int.Parse(calculator[i - 1]);
                int b = int.Parse(calculator[i + 1]);

                calculator.RemoveAt(i - 1);
                calculator.RemoveAt(i - 1);
                calculator.RemoveAt(i - 1);
                calculator.Insert(i - 1, (a + b).ToString());
                answers.Add((a + b));

                if (a + b > 300)
                    return (true, null);

            }

            else if (calculator[i] == "-")
            {

                int a = int.Parse(calculator[i - 1]);
                int b = int.Parse(calculator[i + 1]);

                calculator.RemoveAt(i - 1);
                calculator.RemoveAt(i - 1);
                calculator.RemoveAt(i - 1);
                calculator.Insert(i - 1, (a - b).ToString());
                answers.Add((a - b));
                if (a - b < 0)
                    return (true, null);
            }

            else
                i++;


        }





















        return (false, answers.ToList());


    }



    public List<int> Getindex()
    {
        orderList.Clear();

        int i = 0;
        for (int j = 0; j < gwalhoStart.Length; j++)
        {
            while (i < calculationer_origin.Count && calculationer_origin[i] != "(")
            {
                i++;
            }

            int starter = i;
            while (i < calculationer_origin.Count && calculationer_origin[i] != ")")
            {

                if (calculationer_origin[i] == "×")
                {

                    orderList.Add(i);

                }
                else if (calculationer_origin[i] == "÷")
                {
                    orderList.Add(i);

                }
                i++;
            }

            i = starter;
            while (i < calculationer_origin.Count && calculationer_origin[i] != ")")
            {

                if (calculationer_origin[i] == "+")
                {

                    orderList.Add(i);

                }
                else if (calculationer_origin[i] == "-")
                {
                    orderList.Add(i);

                }
                i++;
            }

            i++;


        }


        for (i = 0; i < calculationer_origin.Count; i++)
        {

            if (calculationer_origin[i] == "(")
            {
                while (i < calculationer_origin.Count && calculationer_origin[i] != ")")
                    i++;
                i++;
            }

            if (i < calculationer_origin.Count)
            {
                if (calculationer_origin[i] == "×")
                {

                    orderList.Add(i);

                }
                else if (calculationer_origin[i] == "÷")
                {
                    orderList.Add(i);

                }

            }



        }



        for (i = 0; i < calculationer_origin.Count; i++)
        {

            if (calculationer_origin[i] == "(")
            {
                while (i < calculationer_origin.Count && calculationer_origin[i] != ")")
                    i++;
                i++;
            }

            if (i < calculationer_origin.Count)
            {
                if (calculationer_origin[i] == "+")
                {

                    orderList.Add(i);

                }
                else if (calculationer_origin[i] == "-")
                {
                    orderList.Add(i);

                }

            }



        }


        return orderList;


    }



    public string Getstring()
    {
        string infix_str = "";
        for (int i = 0; i < calculationer.Count; i++)
        {
            infix_str += calculationer[i];
        }
        return infix_str;

    }







    private string InfixToPostfix()
    {
        Stack<string> postfix_stack = new Stack<string>();
        string postfix_str = "";
        for (int i = 0; i < calculationer_origin.Count; i++)
        {

            if (calculationer_origin[i] == "(")
            {
                postfix_stack.Push(calculationer_origin[i]);
            }
            else if (calculationer_origin[i] == "+" || calculationer_origin[i] == "-")
            {
                string temp;
                while (postfix_stack.Count > 0)
                {
                    temp = postfix_stack.Pop();
                    if (temp == "(")
                    {
                        postfix_stack.Push(temp);
                        break;
                    }
                    else
                    {
                        postfix_str += temp;
                    }
                }
                postfix_stack.Push(calculationer_origin[i]);
            }
            else if (calculationer_origin[i] == ")")
            {
                string temp;
                while (true)
                {
                    temp = postfix_stack.Pop();
                    if (temp != "(")
                    {
                        postfix_str += temp;
                    }
                    else
                        break;
                }
            }
            else if (calculationer_origin[i] == "÷" || calculationer_origin[i] == "×")
            {
                postfix_stack.Push(calculationer_origin[i]);
            }
            else
            {
                postfix_str += calculationer_origin[i];
            }
        }
        while (postfix_stack.Count > 0)
        {
            postfix_str += postfix_stack.Pop();
        }
        return postfix_str;
    }








}




















//public void MakingwithString(string gihos, int start, int end)
//{

//    giho_count = gihos.Length;
//    gwalhoStart = start;
//    gwalhoEnd = end;
//    innercount = end - start + 1;
//    question_count = gihos.Length + 1;

//    bool check = false;

//    for (int i = 0; i < gihos.Length; i++)
//    {
//        giho[i] = gihos[i].ToString();
//    }
//    do
//    {
//        infix_str = "";
//        int whereisgwalho = start;




//        for (int i = 0; i < whereisgwalho; i++)
//        {
//            infix_str += question_order[i].ToString() + giho[i];
//        }
//        if (innercount == 3)
//        {
//            infix_str += "(" + question_order[whereisgwalho] + giho[whereisgwalho] + question_order[whereisgwalho + 1] + giho[whereisgwalho + 1] + question_order[whereisgwalho + 2] + ")";
//            for (int i = whereisgwalho + 2; i < question_count - 1; i++)
//            {
//                infix_str += giho[i] + question_order[i + 1];
//            }
//        }
//        else
//        {
//            infix_str += "(" + question_order[whereisgwalho] + giho[whereisgwalho] + question_order[whereisgwalho + 1] + ")";
//            for (int i = whereisgwalho + 1; i < question_count - 1; i++)
//            {
//                infix_str += giho[i] + question_order[i + 1];
//            }
//        }

//        MakeRandomNum();
//        InfixToPostfix(infix_str);

//        CalculateOrderer();
//        check = Calculation();
//    } while (check == false);
//}











//// 식 자동생성기
//public void MakeQuestion()
//{






//    do
//    {
//        //식 자동생성기
//        Making_expression(change);
//        //식 자동생성기
//        MakeRandomNum();
//        ////식 수동생성기
//        //for (int i = 0; i < 4; i++)
//        //question_real[i] = Random.Range(1, 100);
//        //innercount = 2;
//        //question_count = 4;
//        //infix_str = "(a+b)×c-d";
//        ////식 수동생성기



//        CalculateOrderer();
//        check = Calculation();
//    } while (check == false);
//}







////answer을 구하는 함수
//public bool Calculation()
//{

//    List<string> forcalculationNode = new List<string>();
//    string[] forcalculation = new string[question_count * 2 - 1];
//    Stack<int> calculation_stack = new Stack<int>();
//    answer_array = new int[question_count - 1];
//    int[] temporderer = new int[orderer.Length];
//    orderer.CopyTo(temporderer, 0);
//    int count = 0;
//    int length = 0;

//    for (int i = 0; i < question_count; i++)
//    {
//        length += question_real[i].ToString().Length;
//    }




//    for (int i = 0; i < infix_str.Length; i++)
//    {
//        if (infix_str[i] == 'a' || infix_str[i] == 'b' || infix_str[i] == 'c' || infix_str[i] == 'd')
//        {
//            switch (infix_str[i])
//            {
//                case 'a':
//                    forcalculationNode.Add(question_real[0].ToString());

//                    break;
//                case 'b':
//                    forcalculationNode.Add(question_real[1].ToString());

//                    break;
//                case 'c':
//                    forcalculationNode.Add(question_real[2].ToString());

//                    break;
//                case 'd':
//                    forcalculationNode.Add(question_real[3].ToString());

//                    break;


//            }




//        }


//        else if (infix_str[i] != '(' && infix_str[i] != ')')
//        {
//            forcalculationNode.Add(infix_str[i].ToString());
//            count++;
//        }
//    }





//    for (int i = 0; i < orderer.Length; i++)
//    {
//        int temp = 0;
//        switch (forcalculationNode[1 + 2 * temporderer[0]])
//        {
//            case "÷":
//                if (int.Parse(forcalculationNode[2 * temporderer[0]]) % int.Parse(forcalculationNode[2 * temporderer[0] + 2]) != 0)
//                    return false;
//                temp = int.Parse(forcalculationNode[2 * temporderer[0]]) / int.Parse(forcalculationNode[2 * temporderer[0] + 2]);
//                if (forcalculationNode[2 * temporderer[0]].Length > 1 && forcalculationNode[2 * temporderer[0] + 2].Length > 1 || temp > 100 && int.Parse(forcalculationNode[2 * temporderer[0] + 2]) > 60)
//                    return false;
//                break;
//            case "+":
//                temp = int.Parse(forcalculationNode[2 * temporderer[0]]) + int.Parse(forcalculationNode[2 * temporderer[0] + 2]);
//                break;
//            case "-":
//                temp = int.Parse(forcalculationNode[2 * temporderer[0]]) - int.Parse(forcalculationNode[2 * temporderer[0] + 2]);
//                break;
//            case "#":
//                temp = int.Parse(forcalculationNode[2 * temporderer[0]]) - int.Parse(forcalculationNode[2 * temporderer[0] + 2]);
//                break;
//            case "@":
//                temp = int.Parse(forcalculationNode[2 * temporderer[0]]) + int.Parse(forcalculationNode[2 * temporderer[0] + 2]);
//                break;
//        }


//        forcalculationNode.RemoveAt(2 * temporderer[0]);
//        forcalculationNode.RemoveAt(2 * temporderer[0]);
//        forcalculationNode.RemoveAt(2 * temporderer[0]);
//        forcalculationNode.Insert(2 * temporderer[0], temp.ToString());
//        if (temp < 2 || temp > 99)
//            return false;
//        answer_array[i] = temp;
//        int isbig = temporderer[0];
//        for (int j = 0; j < temporderer.Length - 1; j++)
//        {

//            temporderer[j] = temporderer[j + 1];
//            if (temporderer[j] > isbig)
//            {
//                temporderer[j]--;

//            }
//        }


//    }

//    length += answer_array[question_count - 2].ToString().Length;
//    if (length > 9)
//        return false;


//    return true;
//}
////계산 순서상 기호가 몇번째로 오는지 확인하는 함수
//public void CalculateOrderer()
//{
//    orderer = new int[question_count - 1];
//    int count = 0;


//    for (int i = gwalhoStart; i < gwalhoEnd; i++)
//    {
//        if (giho[i] == "÷")
//        {
//            orderer[count] = i;
//            count++;
//        }
//    }

//    for (int i = gwalhoStart; i < gwalhoEnd; i++)
//    {
//        if (giho[i] != "÷")
//        {
//            orderer[count] = i;
//            count++;
//        }
//    }


//    for (int i = 0; i < gwalhoStart; i++)
//    {
//        if (giho[i] == "÷")
//        {
//            orderer[count] = i;
//            count++;
//        }
//    }

//    for (int i = gwalhoEnd; i < orderer.Length; i++)
//    {
//        if (giho[i] == "÷")
//        {
//            orderer[count] = i;
//            count++;
//        }
//    }



//    for (int i = 0; i < gwalhoStart; i++)
//    {
//        if (giho[i] != "÷")
//        {
//            orderer[count] = i;
//            count++;
//        }
//    }

//    for (int i = gwalhoEnd; i < orderer.Length; i++)
//    {
//        if (giho[i] != "÷")
//        {
//            orderer[count] = i;
//            count++;
//        }
//    }





//    //for (int i = 0; i < postfix_str.Length; i++)
//    //{ 
//    //    if (postfix_str[i] == '×' || postfix_str[i] == '+' || postfix_str[i] == '-' || postfix_str[i] == '@' || postfix_str[i] == '#')
//    //    {
//    //        for (int j = 0; j < giho_count; j++)
//    //        {
//    //            if (giho[j] == postfix_str[i].ToString())
//    //            {
//    //                orderer[count] = j;
//    //                count++;
//    //            }
//    //        }
//    //    }
//    //}
//}

//void MakeRandomNum()
//{
//    bool success = true;
//    do
//    {
//        success = true;
//        int length = 0;

//        for (int i = 0; i < 4; i++)
//        {
//            int casing = Random.Range(0, 3);
//            switch (casing)
//            {
//                case 0:
//                    question_real[i] = Random.Range(2, 10);
//                    break;
//                case 1:
//                    question_real[i] = Random.Range(10, 100);
//                    break;
//                case 2:
//                    question_real[i] = Random.Range(10, 171);
//                    break;

//            }



//            length += question_real[i].ToString().Length;
//        }
//        if (hardmode && question_count * 2 - 1 > length)
//            success = false;
//        if ((!hardmode) && question_count + 1 < length)
//            success = false;
//    } while (!success);

//}



////식 자동생성기
//void Making_expression(bool change = false)
//{

//    infix_str = "";
//    int whereisgwalho = 0;

//    //기호 섞어주기
//    for (int i = 0; i < 20; i++)
//    {
//        int rand = Random.Range(0, giho_count);
//        string temp = giho[0];
//        giho[0] = giho[rand];
//        giho[rand] = temp;
//    }
//    for (int i = 0; i < giho_count; i++)
//    {
//        if (giho[i] == "÷")
//        {
//            int rand = Random.Range(0, question_count - 1);
//            string temp = giho[rand];
//            giho[rand] = giho[i];
//            giho[i] = temp;
//        }
//    }
//    //X인데는 괄호넣지않기
//    do
//    {
//        whereisgwalho = 0;
//        if (innercount == 3)
//        {
//            whereisgwalho = Random.Range(0, question_count - 2);
//            gwalhoStart = whereisgwalho;
//            gwalhoEnd = whereisgwalho + 2;
//        }

//        else
//        {
//            whereisgwalho = Random.Range(0, question_count - 1);
//            gwalhoStart = whereisgwalho;
//            gwalhoEnd = whereisgwalho + 1;
//        }

//    } while (giho[whereisgwalho] == "÷" && (!change));
//    for (int i = 0; i < whereisgwalho; i++)
//    {
//        infix_str += question_order[i].ToString() + giho[i];
//    }
//    if (innercount == 3)
//    {
//        infix_str += "(" + question_order[whereisgwalho] + giho[whereisgwalho] + question_order[whereisgwalho + 1] + giho[whereisgwalho + 1] + question_order[whereisgwalho + 2] + ")";
//        for (int i = whereisgwalho + 2; i < question_count - 1; i++)
//        {
//            infix_str += giho[i] + question_order[i + 1];
//        }
//    }
//    else
//    {
//        infix_str += "(" + question_order[whereisgwalho] + giho[whereisgwalho] + question_order[whereisgwalho + 1] + ")";
//        for (int i = whereisgwalho + 1; i < question_count - 1; i++)
//        {
//            infix_str += giho[i] + question_order[i + 1];
//        }
//    }

//}

////실제 표현식(infix)
//public string RealExpression()
//{
//    string expression = "";

//    for (int i = 0; i < infix_str.Length; i++)
//    {
//        switch (infix_str[i])
//        {
//            case 'a':
//                expression += question_real[0];
//                break;
//            case 'b':
//                expression += question_real[1];
//                break;
//            case 'c':
//                expression += question_real[2];
//                break;
//            case 'd':
//                expression += question_real[3];
//                break;
//            default:
//                expression += infix_str[i];
//                break;
//        }
//    }
//    return expression;
//}



