using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawGizmos : MonoBehaviour
{
    [ExecuteInEditMode]

    public List<GameObject> TargetObjects = new List<GameObject>();
    public List<GameObject> DroneObjects = new List<GameObject>();

    public FormationControl Fcontrol = new FormationControl();
    
    private void Start()
    {
        DroneObjects.AddRange(GameObject.FindGameObjectsWithTag("Drone"));
        TargetObjects.AddRange(GameObject.FindGameObjectsWithTag("Target"));
        Fcontrol.TargetObjects = TargetObjects;
        Fcontrol.DroneObjects = DroneObjects;

        var watch = new System.Diagnostics.Stopwatch();
        watch.Start();

        Fcontrol.FillDTWList();
        Fcontrol.SortNStack();
        
        watch.Stop();
        Debug.Log("Execution Time: " + watch.ElapsedMilliseconds + " ms");
        Debug.Log("Execution Time: " + watch.ElapsedTicks + " System Ticks");
        Debug.Log("Execution Time: " + watch.Elapsed + " ms");
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;

        for (int i = 0; i < DroneObjects.Count; i++)
        {
            Gizmos.DrawLine(Fcontrol.MinTargets[i].Drone.transform.position, Fcontrol.MinTargets[i].Target.transform.position);
        }

    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Resetpositions();
            // UnityEditor.SceneView.RepaintAll();
        }
    }
    private void Resetpositions()
    {
       //Fill This!!!
    }
}