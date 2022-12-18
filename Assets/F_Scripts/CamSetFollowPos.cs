using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class CamSetFollowPos : MonoBehaviour
{
    public Vector3 _Pos;

    public Vector3 ReturnFollowPos()
    {
        return _Pos;
    }


}
