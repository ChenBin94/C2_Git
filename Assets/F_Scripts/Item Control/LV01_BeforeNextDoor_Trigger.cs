using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LV01_BeforeNextDoor_Trigger : MonoBehaviour
{
    public GameObject obj;

    void Update()
    {
        float _dis = Vector3.Distance(obj.GetComponent<Transform>().position, transform.position);
        if (_dis<=1.5f)
        {
            obj.GetComponent<CharacterControl>().Set_State_BeforeNextStage();
            Destroy(gameObject);
        }
    }
}
