using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightLineControl : MonoBehaviour
{
    //------------------test
    public GameObject PS;
    public GameObject PE;

    //------------------

    [SerializeField] float aa = 2.0f;
    [SerializeField] float bb = 1.0f;




    // public
    public GameObject trail;

    // private
    private float Timer = 0.0f;

    Vector3 StartPos;
    Vector3 EndPos;

    // Start is called before the first frame update
    void Start()
    {
        StartPos = Vector3.zero;
        EndPos = Vector3.zero;

        trail.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime * 2.0f;

        if(Timer>=0.1f)
        {
            trail.SetActive(true);
            float deltaY = StartPos.y + (EndPos.y - StartPos.y) * Timer + Mathf.Sin(Timer * Mathf.PI * aa) * bb;
            Vector3 _pos = StartPos + (EndPos - StartPos) * Timer;
            _pos.y = deltaY;
            trail.transform.position = _pos;

        }
        if(Timer >= 1.0f)
        {
            trail.transform.position = EndPos;
        }
        if (Timer >= 2.5f)
        {
            trail.SetActive(false);
            trail.transform.position = StartPos;
        }
        if(Timer>3.2f)
        {
            
            trail.SetActive(true);

            Timer = 0.0f;
        }
        





        //------------------test
        SetStartPos(PS.transform.position);
        SetEndPos(PE.transform.position);
        //------------------
    }


    public void SetStartPos(Vector3 _pos) { StartPos = _pos; }
    public void SetEndPos(Vector3 _pos) {EndPos = _pos; }




}
