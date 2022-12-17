using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    enum ActionStates
    {
        Stay,
        Move,
        Handup,


        ActionEnd
    }

    //ActionStates m_Action = ActionStates.Stay;



    public GameObject m_Character;
    


    Animator animator;
    Rigidbody rb;



    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb = m_Character.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float speed = rb.velocity.magnitude;
        if (speed > 0.001f) animator.SetBool("IsWalking", true);
        else animator.SetBool("IsWalking", false);
        //Debug.Log(speed);























    }


    public void SetAction_Handup()
    {
        animator.SetBool("IsWalking", false);
        animator.SetBool("IsHandUp", true);
    }


}
