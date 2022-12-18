using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class CharacterControl : MonoBehaviour
{
    // public
    [SerializeField] List<Waypoint> path = new List<Waypoint>();
    [SerializeField][Range(0.0f, 300.0f)] float Speed = 50.0f;

    public GameObject animObj;

    // コミュニケーションアイテム
    public GameObject Item_Pointer;
    public GameObject Item_Switch;
    


    // private
    float m_Timer = 0.0f;
    Rigidbody rb;

    // enum
    enum state
    {
        Outside,
        EnterTheDoor,
        BeforeNextStageDoor,



        end
    }

    state PresentState = state.Outside;

    // bool
    bool isMoving = false;

    bool isTrapped = false;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();

        StartCoroutine(FollowPath());
    }

    IEnumerator FollowPath()
    {
        
        {
            foreach (Waypoint waypoint in path)
            {
                Vector3 StartLocation = transform.position;
                Vector3 EndLocation = waypoint.transform.position;


                while ((EndLocation - transform.position).magnitude >= 0.2f)
                {
                    // set move
                    Vector3 CharacterToEndLocation = EndLocation - transform.position;
                    Vector3 Front = CharacterToEndLocation.normalized;

                    Vector3 NowVel = Time.deltaTime * Front * Speed;
                    if (isMoving) 
                    {
                        if (NowVel.magnitude < 3.0f) rb.velocity = Time.deltaTime * Front * Speed;
                    }
                    else
                    {
                        rb.velocity = Vector3.zero;
                    }

                    // set lookat
                    Vector3 ForWardLocation = transform.forward + transform.position;
                    Vector3 LookAtLocation = ForWardLocation + (EndLocation - ForWardLocation) * 0.01f;
                    LookAtLocation.y = transform.position.y;
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
        m_Timer += Time.deltaTime;

        switch (PresentState)
        {
            case state.Outside:
                if (Item_Switch.GetComponent<SwitchControl>().isOpened())
                { 
                    Invoke("Moving", 2.0f);
                    Invoke("InvokeUse_EnterTheDoor", 2.0f);
                }
                break;
            case state.EnterTheDoor:
                if (isTrapped) { StopMoving(); SetMovement_HandUp(); }
                if (!isTrapped) { Invoke("Moving", 0.3f); SetMovement_Walk(); }

                break;
            case state.BeforeNextStageDoor:
                StopMoving();
                break;




            default: break;
        }

        //Debug.Log(PresentState);


    }

    void Moving() { isMoving = true; }
    void StopMoving() { isMoving = false; }
    void InvokeUse_EnterTheDoor() { PresentState = state.EnterTheDoor; }
    void SetMovement_HandUp()
    {
        animObj.GetComponent<CharacterMovement>().SetAction_Handup();
    }
    void SetMovement_Walk()
    {
        animObj.GetComponent<CharacterMovement>().SetAction_Walk();
    }
    public void Set_IsTrapped(bool _isTrapped)
    {
        isTrapped = _isTrapped;
    }
    public void Set_State_BeforeNextStage() { PresentState = state.BeforeNextStageDoor; }



}
