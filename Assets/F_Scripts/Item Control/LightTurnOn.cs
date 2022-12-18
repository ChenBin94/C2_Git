using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightTurnOn : MonoBehaviour
{
    Color m_color = Color.black;

    float Timmer = 0.0f;
    bool isTurnedOn = false;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Light>().color = m_color;
    }

    // Update is called once per frame
    void Update()
    {
        if(isTurnedOn)
        {
            Timmer += Time.deltaTime*0.5f;
            if(Timmer <=1.0f)
            {
                m_color.r = Timmer * 220.0f / 255.0f;
                m_color.g = Timmer * 220.0f / 255.0f;
                m_color.b = Timmer * 220.0f / 255.0f;
            }
        }

        GetComponent<Light>().color = m_color;



    }

    public void TurnOnTheLight()
    {
        isTurnedOn = true;
    }
}
