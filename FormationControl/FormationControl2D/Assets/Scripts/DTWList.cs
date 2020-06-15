using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DTWList 
{
    public GameObject Drone;
    public List<GameObject> TargetList;
    public List<float> WeightList;


    public DTWList(GameObject _Drone, List<GameObject> _TargetList, List<float> _WeightList)
    {
        Drone = _Drone;
        TargetList = _TargetList;
        WeightList = _WeightList;
    }
    public DTWList()
    { }
    
}

public class DTW
{
    public GameObject Drone;
    public GameObject Target;
    public float Weight;

    public DTW(GameObject _Drone, GameObject _Target, float _Weight)
    {
        Drone = _Drone;
        Target = _Target;
        Weight = _Weight;
    }
    public DTW() { }
}

public class DTList
{
    public GameObject Drone;
    public GameObject Target;
    public DTList(GameObject _Drone, GameObject _Target)
    {
        Drone = _Drone;
        Target = _Target;
    }
    public DTList() { }
}
