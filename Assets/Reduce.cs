using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reduce : MonoBehaviour
{
    public static List<int> GetAliquots(int _target)
    {
        List<int> list = new List<int>();

        for (int i = 2; i <= _target; i++)
        {
            if (_target % i == 0)
                list.Add(i);
        }

        return list;

    }

    public static bool CheckReducible(List<int> _aliquots, int _target)
    {
        foreach (var ali in _aliquots)
        {
            if (_target % ali == 0)
                return true;
        }

        return false;
    }
    public static bool CheckReducible(List<int> _aliquots, int _target, out int s)
    {
        s = 0;
        foreach (var ali in _aliquots)
        {
            if (_target % ali == 0)
            {
                s = ali;
                return true;
            }
        }

        return false;
    }

    public static System.Tuple<int, int> GetLastNums(int bottom, int top)
    {

        var list = GetAliquots(bottom);
        while (CheckReducible(list, top, out int num))
        {
            top /= num;
            bottom /= num;

            list = GetAliquots(bottom);
        }


        return new System.Tuple<int, int>(bottom, top);
    }
    //public static System.Tuple<bool, bool> GetReduce(int bottom, int top)
    //{

    //    var list = GetAliquots(bottom);
    //    while (CheckReducible(list, top, out int num))
    //    {
    //        top /= num;
    //        bottom /= num;

    //        list = GetAliquots(bottom);
    //    }


    //    return new System.Tuple<bool, bool>(bottom, top);
    //}

}
