using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mouse : MonoBehaviour
{
    GameObject T_CameraControlPoint;

    private void OnMouseDown()
    {
        Debug.Log(this.transform.position);

        T_CameraControlPoint = GameObject.FindGameObjectWithTag("CameraControlPoint");
        T_CameraControlPoint.GetComponent<CameraMove>().SetCameraBodyPos(transform.position);
    }


    void Update()
    {



    }





}
