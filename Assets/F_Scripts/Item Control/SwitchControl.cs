using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchControl : MonoBehaviour
{
    // public
    public Material OutlineObj;
    public float Outline_Max = 0.1f;
    public float Outline_Speef = 3.0f;

    public GameObject Light_Out;
    public GameObject Light_InSide;
    public GameObject Light_InSide_Sport;

    // private
    int m_state = 0;


    float Timmer = 0.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        if(m_state==0)
        {
            Timmer += Time.deltaTime;
            float value = (Mathf.Sin(Timmer * Outline_Speef) + 1.0f) * Outline_Max;
            OutlineObj.SetFloat("_OutValue", value);
        }

        if (m_state == 1)
        {
            OutlineObj.SetFloat("_OutValue", Outline_Max);
        }

        if (m_state == 2)
        {
            OutlineObj.SetFloat("_OutValue", 0.0f);
            Light_Out.SetActive(false);

            Light_InSide.GetComponent<LightTurnOn>().TurnOnTheLight();
            Light_InSide_Sport.GetComponent<LightTurnOn>().TurnOnTheLight();
        }

    }

    public void ChangeState()
    {
        m_state++;
    }

    public bool isOpened()
    {
        if (m_state >= 2) return true;
        else return false;
    }


}
