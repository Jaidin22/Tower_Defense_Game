using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] waypoints;

    //find all the differet objects that are a child to the waypoints object, add them to waypoints array
    private void Awake ()
    {
        waypoints = new Transform[transform.childCount];
        for (int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = transform.GetChild(i);
        }
    }
}
