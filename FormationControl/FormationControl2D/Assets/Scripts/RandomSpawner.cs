using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomSpawner : MonoBehaviour
{
    public GameObject Target;
    public GameObject Drone;
    GameObject tempT, tempD;
    public int DroneNTargetCount = 3;
    private void Awake()
    {
        List<Vector3> SpawnPointList=new List<Vector3>();

        while (SpawnPointList.Count != DroneNTargetCount * 2)
        {
            Vector3 temp = new Vector3(Random.Range(-17, 17), Random.Range(-9, 9), 0);

            if (!SpawnPointList.Contains(temp))
            {
                SpawnPointList.Add(temp);
            }
        }
        int namecount = 1;
        for (int i = 1; i <= DroneNTargetCount*2; i+=2)
        {
            tempD= (GameObject)Instantiate(Drone, SpawnPointList[i], Drone.transform.rotation);
            tempD.name = "Drone " + namecount;
            namecount++;
        }
        namecount = 1;
        for (int i = 0; i < DroneNTargetCount * 2; i+=2)
        {
            tempT = (GameObject)Instantiate(Target, SpawnPointList[i], Target.transform.rotation);
            tempT.name = "Target " + namecount;
            namecount++;
        }
    }
}