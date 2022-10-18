using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMover : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField][Range(0.0f, 5.0f)] float Speed = 1.0f;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FollowPath());



    }


    IEnumerator FollowPath()
    {
        foreach(Waypoint waypoint in path)
        {
            Vector3 StartLocation = transform.position;
            Vector3 EndLocation = waypoint.transform.position;
            float travelPercencent = 0.0f;

            transform.LookAt(EndLocation);

            while(travelPercencent < 1.0f)
            {
                travelPercencent += Time.deltaTime * Speed;
                transform.position = Vector3.Lerp(StartLocation, EndLocation, travelPercencent);
                yield return new WaitForEndOfFrame();
            }
        }
    }
}
