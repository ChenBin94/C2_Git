using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField][Range(0.0f, 300.0f)] float Speed = 50.0f;

    Rigidbody rb;

    // 
    public GameObject animObj;
    Animator animator;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(FollowPath());

        animator = animObj.GetComponent<Animator>();
    }

    IEnumerator FollowPath()
    {
        {
            foreach (Waypoint waypoint in path)
            {
                Vector3 StartLocation = transform.position;
                Vector3 EndLocation = waypoint.transform.position;


                while ((EndLocation - transform.position).magnitude >= 0.1f)
                {
                    // set move
                    Vector3 CharacterToEndLocation = EndLocation - transform.position;
                    Vector3 Front = CharacterToEndLocation.normalized;

                    Vector3 NowVel = Time.deltaTime * Front * Speed;
                    if (NowVel.magnitude < 3.0f) rb.velocity = Time.deltaTime * Front * Speed;

                    // set lookat
                    Vector3 ForWardLocation = transform.forward + transform.position;
                    Vector3 LookAtLocation = ForWardLocation + (EndLocation - ForWardLocation) * 0.01f;
                    transform.LookAt(LookAtLocation);

                    // wait
                    yield return new WaitForEndOfFrame();
                }


            }
            rb.velocity = Vector3.zero;
        }
    }

    // Update is called once per frame
    void Update()
    {


    }
}