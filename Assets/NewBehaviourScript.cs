using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text.RegularExpressions;
using System.Data;
using System.IO;
using UnityEditor;
public enum soundstate
{
    c,
    b,
    a
}
[SerializeField]
public class NewBehaviourScript : MonoBehaviour
{
    public soundstate s;
    public static soundstate state;
    int answernum = 0;
    int i = 0;
    public int[] num;
    public Canvas c;
    public Transform g1, g2;
    private Vector2 newPos = new Vector2();
    public float speed;
    public string a = "*";
    private string path;
    public List<AudioClip> clip = new List<AudioClip>();
    public Object[] fObj;
    private AudioSource Stem1;
    // Start is called before the first frame update
    IEnumerator Start()
    {
        Stem1 = GetComponent<AudioSource>();
        state = s;
        path = "/a/" + state;
        
        //Debug.Log(Application.dataPath +path);
        if (Directory.Exists(Application.dataPath + path))
        {
            
            DirectoryInfo di = new DirectoryInfo(Application.dataPath + path);
            string a = Application.dataPath + path;
            string[] fName;
            
            foreach (FileInfo Dir in di.GetFiles("*.wav"))
            {
                string fileDierctory = Dir.Name;
                WWW www = new WWW(Dir.ToString());
                yield return www;
                //Debug.Log(www);
                www.GetAudioClip().name = fileDierctory;
                //AudioClip c = www.GetAudioClip();
                //Debug.Log(c);
                Stem1.clip = www.GetAudioClip(false);
                clip.Add(www.GetAudioClip(false));
                //fName = Directory.GetFiles(a, "*.wav");
                //Debug.Log(fName[1]);
                //Debug.Log(Dir);
                //for (int i = 0; i < fName.Length; i++)
                //{
                //    fObj[i] = AssetDatabase.LoadAssetAtPath(fName[i], typeof(Object));
                //    Debug.Log(fObj[i]);
                //}
                //AudioClip c = AssetDatabase.LoadAssetAtPath(fileDierctory, typeof(AudioClip)) as AudioClip;
                //Debug.Log(c);
                //clip.Add(c);
                //clip.Add(Dir, typeof(AudioClip));
            }
        }

        //byte[] byteSound = System.IO.File.ReadAllBytes(Application.dataPath + path);
        //for (int i = 0; i < byteSound.Length; i++)
        //    Debug.Log(byteSound[i]);
        //bool a = false;
        //for(int i=0;i<5;i++)
        //{
        //    if (!a)
        //    {
        //        i = 2;
        //        a = true;
        //    }
        //}
        //string TestExpression = "0.1+0.2+(5*2)=";

        //string St = TestExpression;
        //char[] phraseAsChars = TestExpression.ToCharArray();
        //for (int i = 0; i < St.Length; i++)
        //{
        //    if (St.Substring(i, 1) == "×")
        //    {
        //        phraseAsChars[i] = '*';
        //    }
        //}
        //for (int i = 0; i < St.Length; i++)
        //{
        //    if (St.Substring(i, 1) == "÷")
        //    {
        //        phraseAsChars[i] = '/';
        //    }
        //}
        //for (int i = 0; i < St.Length; i++)
        //{
        //    if (St.Substring(i, 1) == "=")
        //    {
        //        phraseAsChars[i] = ' ';
        //    }
        //}
        //St = new string(phraseAsChars);
        //Debug.Log(St);
        ////Table 생성
        //DataTable table = new DataTable();

        //table.Columns.Add("Result", typeof(float));

        //table.Columns["Result"].Expression = St;

        //DataRow row = table.Rows.Add();

        //float a = (float)row["Result"];
        //Debug.Log(a);
    }

    // Update is called once per frame
    void Update()
    {
        if (!Stem1.isPlaying)
        {
            Stem1.clip = clip[Random.Range(0, clip.Count)];
            Stem1.Play();
        }
        //runnintTime += Time.deltaTime * speed;
        //float x = transform.localPosition.x+100 * Mathf.Cos(runnintTime);
        //float y = transform.localPosition.y+100 * Mathf.Sin(runnintTime);
        //newPos = new Vector2(x, y);
        //transform.position = newPos;
        //transform.RotateAround(circle.transform.position, Vector3.up, speed * Time.deltaTime);

        //Vector2 screenpos = RectTransformUtility.WorldToScreenPoint(c.worldCamera)
    }
    /// <summary>
    /// 계산식의 값을 구하기
    /// </summary>
    /// <param name="_s">string으로된식</param>
    /// <param name="_N">int형 배열을 넣지만 숫자만 집어넣기</param>
    void Sign(string _s,int[] _N)
    {
        List<int> q = new List<int>();
        q.Clear();
        int answer = 0;
        int answer1 = 0;
        int answer2 = 0;
        int answer3 = 0;
        int n = 0;
        for(int z=0;z<_s.Length;z++)
        {
            if(_s.Substring(z,1)=="(")
            {
                for(int y=z;y<_s.Length;y++)
                {
                    if(_s.Substring(y,1)==")")
                    {
                        for (int a = z; a < y; a++)
                        {
                            if (_s.Substring(a, 1) == "×")
                            {
                                answer3 = _N[int.Parse(_s.Substring(i - 1, 1))] * _N[int.Parse(_s.Substring(i + 1, 1))];
                                q.Add(i);
                                break;
                            }
                        }
                    }
                }
            }
        }
        for (i = 0; i < _s.Length; i++)
        {
            if (_s.Substring(i, 1) == "×")
            {
                answer1 = _N[int.Parse(_s.Substring(i - 1, 1))] * _N[int.Parse(_s.Substring(i + 1, 1))];
                q.Add(i);
                break;
            }
        }
        for (i = 0; i < _s.Length; i++)
        {
            if (_s.Substring(i, 1) == "+")
            {

                if (q[0] - 1 == i + 1)
                {
                    answer1 += _N[int.Parse(_s.Substring(i - 1, 1))];
                    q.Add(i);
                    answer = answer1;
                    break;
                }
                if (q[0] + 1 == i - 1)
                {
                    answer1 += _N[int.Parse(_s.Substring(i + 1, 1))];
                    q.Add(i);
                    answer = answer1;
                    break;
                }
                else
                {
                    answer2 = _N[int.Parse(_s.Substring(i - 1, 1))] + _N[int.Parse(_s.Substring(i + 1, 1))];
                    q.Add(i);
                    answer = answer1 + answer2;
                    break;
                }
            }
            if (_s.Substring(i, 1) == "-")
            {
                if (q[0] - 1 == i + 1)
                {
                    answer1 = _N[int.Parse(_s.Substring(i - 1, 1))] - answer1;
                    q.Add(i);
                    answer = answer1;
                    break;
                }
                if (q[0] + 1 == i - 1)
                {
                    answer1 -= _N[int.Parse(_s.Substring(i + 1, 1))];
                    q.Add(i);
                    answer = answer1;
                    break;
                }
                else
                {
                    answer2 = _N[int.Parse(_s.Substring(i - 1, 1))] - _N[int.Parse(_s.Substring(i + 1, 1))];
                    q.Add(i);
                    answer = answer1 - answer2;
                    break;
                }
            }
        }
        //if (answer <= 0)
        //{
        //    MakeQuestion();
        //    return;
        //}
        for (i = 0; i < _s.Length; i++)
        {
            if (_s.Substring(i, 1) == "+")
            {
                if (q[1] != i)
                {
                    if ((q[0] + 1 == i - 1 && q[1] - 1 == i + 1) || (q[0] - 1 == i + 1 && q[1] + 1 == i - 1))
                    {
                        answer = answer1 + answer2;
                        break;
                    }
                    if (q[0] + 1 == i - 1 || q[1] + 1 == i - 1)
                    {
                        answer = answer1 + _N[int.Parse(_s.Substring(i + 1, 1))];
                        break;
                    }
                }
            }
            if (_s.Substring(i, 1) == "-")
            {
                if (q[1] != i)
                {
                    if ((q[0] + 1 == i - 1 && q[1] - 1 == i + 1) || (q[0] - 1 == i + 1 && q[1] + 1 == i - 1))
                    {
                        answer = answer2 - answer1;
                        break;
                    }
                    if (q[0] + 1 == i - 1 || q[1] + 1 == i - 1)
                    {
                        answer = answer1 - _N[int.Parse(_s.Substring(i + 1, 1))];
                        break;
                    }
                }
            }
        }
        answernum = answer;
        //_s = Regex.Replace(_s,@"[^0-9]", "");
        //_s = Regex.Replace(_s, @"\d", "");
        //_s.Substring(0, 1);
    }
    
}
