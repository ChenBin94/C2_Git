using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    // CamreaPos
    [SerializeField] Vector3 CameraPos = new Vector3(5.0f, 11.0f, 0.0f);

    // LookAt
    [SerializeField] float Smooth = 0.05f;
    [SerializeField] Vector3 CharacterPos = new Vector3(-5.0f, 11.0f, 0.0f);
    [SerializeField] Vector3 LookAtPos = new Vector3(1.0f, 0.0f, 0.0f);
    public GameObject O_LookAtPos;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // CameraPos
        transform.position = transform.position + (CameraPos - transform.position) * Smooth;

        // LookAt
        LookAtPos = transform.position * 2.0f - CharacterPos;
        O_LookAtPos.transform.position = LookAtPos;

    }

    public void SetCameraBodyPos(Vector3 _Pos)
    {
        CameraPos = _Pos;
    }


}
