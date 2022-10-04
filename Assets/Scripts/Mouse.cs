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
        T_CameraControlPoint.GetComponent<Camera>().SetCameraBodyPos(transform.position);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            T_CameraControlPoint.GetComponent<Camera>().SetCameraBodyPos(new Vector3(35.0f, 11.0f, 0.0f));
        }


    }





}
