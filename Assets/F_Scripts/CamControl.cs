using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamControl : MonoBehaviour
{
    // public
    public GameObject CamFollow;
    public GameObject CamLookAt;

    public float CamSpeed_Follow = 10.0f;
    public float CamSpeed_LookAt = 10.0f;

    // Click Item
    public List<GameObject> ClickItems = new List<GameObject>();

    // Special Click Item
    public GameObject ClickItem_Switch;
    public GameObject ClickItem_Cleanner;


    // Pointer
    public GameObject Pointer_Obj;
    Vector3 Pointer_TargetPos;





    // private
    private Vector3 m_OriginalTransform_Follow;
    private Vector3 m_OriginalTransform_LookAt;

    private Vector3 m_LerpFollow_Pos;
    private Vector3 m_LerpLookAt_Pos;

    private GameObject Previous_Obj;
    private GameObject Present_Obj;


    // Start is called before the first frame update
    void Start()
    {
        m_OriginalTransform_Follow = CamFollow.GetComponent<Transform>().position;
        m_OriginalTransform_LookAt = CamLookAt.GetComponent<Transform>().position;

        m_LerpFollow_Pos = m_OriginalTransform_Follow;
        m_LerpLookAt_Pos = m_OriginalTransform_LookAt;

        Pointer_TargetPos = Pointer_Obj.transform.position;
        Previous_Obj = Pointer_Obj;
        Present_Obj = Pointer_Obj;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray,out hit))
            {
                foreach(GameObject obj in ClickItems)
                {
                    if (obj == hit.collider.gameObject)
                    {
                        //if(Present_Obj!= obj)
                        {
                            Previous_Obj = Present_Obj;
                            Present_Obj = obj;
                        }
                        LerpPointerPos(Present_Obj);
                        ClickItem_Special(Present_Obj);



                        Debug.Log(Present_Obj);
                        Debug.Log(Previous_Obj);


                        break;
                    }
                    
                }
            }
        }

        if (Input.GetKeyDown(KeyCode.Tab) || Input.GetMouseButtonDown(1))
        {
            ResetCamera();
        }

        LerpFollow();
        LerpLookAt();

        MovePointer();


    }


    void SwitchLookAtToTargetObject(GameObject _obj)
    {
        m_LerpLookAt_Pos = _obj.transform.position;

        m_LerpFollow_Pos = _obj.GetComponent<CamSetFollowPos>().ReturnFollowPos();


        //Debug.Log(_obj);
    }

    void LerpFollow()
    {
        CamFollow.transform.position = CamFollow.transform.position + (m_LerpFollow_Pos - CamFollow.transform.position) * 0.01f * CamSpeed_Follow;
    }

    void LerpLookAt()
    {
        CamLookAt.transform.position = CamLookAt.transform.position + (m_LerpLookAt_Pos - CamLookAt.transform.position) * 0.01f * CamSpeed_LookAt;
    }

    void LerpPointerPos(GameObject _obj)
    {
        if(_obj!=Previous_Obj)
        {
            Pointer_Obj.transform.position = Previous_Obj.transform.position;

            Pointer_Obj.SetActive(true);
            Pointer_TargetPos = _obj.transform.position;
            Invoke("SetPointerFalse", 0.5f);
        }
    }
    void MovePointer()
    {
        if(Pointer_Obj.activeSelf)
        {
            Pointer_Obj.transform.position = Pointer_Obj.transform.position + (Pointer_TargetPos - Pointer_Obj.transform.position) * 0.3f;
        }

    }
    void SetPointerFalse() 
    { 
        Pointer_Obj.SetActive(false); 
    }

    void ResetCamera()
    {
        m_LerpLookAt_Pos = m_OriginalTransform_LookAt;
        m_LerpFollow_Pos = m_OriginalTransform_Follow;
    }

    void ClickItem_Special(GameObject _obj)
    {
        if (_obj == ClickItem_Switch)
        {
            SwitchLookAtToTargetObject(_obj);
            _obj.GetComponent<SwitchControl>().ChangeState();

            if (_obj.GetComponent<SwitchControl>().isOpened() == true)
            {
                ResetCamera();
            }
        }

        
        if (_obj == ClickItem_Cleanner)
        {
            _obj.GetComponent<CleanerControl>().SetIsInuse(true);
        }
        if(_obj!= ClickItem_Cleanner && Previous_Obj== ClickItem_Cleanner)
        {
            Previous_Obj.GetComponent<CleanerControl>().SetIsInuse(false);
        }




    }


}
