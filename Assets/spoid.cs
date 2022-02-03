using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class spoid : MonoBehaviour
{
    struct QuestionInfo
    {
        public List<string> q;
        public string integer;
        public List<string> answer;
        public List<int> count;
        public List<Zero> zero;
    }
    public struct Zero
    {
        public List<string> zero;
    }
    QuestionInfo q;
    Zero z;
    public Image i;
    public Color c;
    Vector3 mpos;
    public Sprite s;
    public Transform _T;
    public string[] zz;
    // Start is called before the first frame update
    void Start()
    {

    }
    public int GetRandom(int[] _contain, int _min, int _max)
    {
        HashSet<int> exclude = new HashSet<int>();
        for (int i = 0; i < _contain.Length; i++)
        {
            exclude.Add(_contain[i]);
        }
        var range = Enumerable.Range(_min, _max).Where(i => !exclude.Contains(i));
        int index = Random.Range(_min, _max - exclude.Count);
        return range.ElementAt(index);
    }
    // Update is called once per frame
    void Update()
    {
        mpos = Input.mousePosition;
        if (Input.GetMouseButtonDown(0))
            StartCoroutine(a());
    }
    IEnumerator a()
    {
        //이부분이 그그그그 스크린샷해서 텍스쳐로반환하는부분임
        Texture2D t = new Texture2D(Screen.width, Screen.height, TextureFormat.RGB24, false);
        //텍스쳐완료될때까지 기다려줌
        yield return new WaitForEndOfFrame();
        t.ReadPixels(new Rect(0, 0, Screen.width, Screen.height), 0, 0);
        t.Apply();

        //추출된 색
        c = t.GetPixel((int)mpos.x, (int)mpos.y);

        i.color = c;
    }
}
