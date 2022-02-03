using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
public class GetRandom : MonoBehaviour
{
    public int[] ex;
    HashSet<int> zz = new HashSet<int>();
    // Start is called before the first frame update
    void Start()
    {
        GetRandomEx(ex, 0, 10);
        zz.Add(0);
        zz.Add(5);
        zz.Add(3);
        Debug.Log(zz.ElementAt(0));
    }

    public int GetRandomEx(int[] _contain, int _min, int _max)
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
}
