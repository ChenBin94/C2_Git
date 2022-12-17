using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlash : MonoBehaviour
{
    public Material m_material;
    public Color m_color;

    [SerializeField] float FlashStrength = 5.0f;
    [SerializeField] float FlashSpeed = 5.0f;


    float Timer = 0.0f;


    // Start is called before the first frame update
    void Start()
    {
        //m_material = GetComponent<Material>();
        //m_material.EnableKeyword("_EMISSION");
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime * FlashSpeed;


        m_material.SetColor("_EmissionColor", m_color * FlashStrength * (Mathf.Sin(Timer) + 1.0f));


        //Debug.Log(Mathf.Sin(Timer)+1.0f);
    }
}
