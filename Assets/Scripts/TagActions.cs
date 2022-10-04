using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagActions : MonoBehaviour
{
    Vector3 Start_Position = new Vector3(0.0f, 0.0f, 0.0f);
    Vector3 Temp_GoUp = new Vector3(0.0f, 0.0f, 0.0f);

    [SerializeField] float Time_GoUp=1.0f;
    [SerializeField] float Speed_GoUp = 100.0f;
    [SerializeField] float Distance_GoUp = 4.0f;

    [SerializeField] float ShowTime = 5.0f;

    float temp = 0.0f;
    float temp2 = 0.0f;

    bool CloseTab = false;

    // Start is called before the first frame update
    void Start()
    {
        Start_Position = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!CloseTab)
        {
            temp += Time.deltaTime;

            if (temp <= Time_GoUp)
            {
                temp2 = Mathf.Pow(1.0f / Speed_GoUp, temp) * Distance_GoUp * 0.01f;
            }
            else temp2 = 0.0f;

            Temp_GoUp.y += temp2;

            if (temp >= ShowTime)
            {
                temp = Time_GoUp;
                CloseTab = true;
            }
        }



        if(CloseTab)
        {
            temp -= Time.deltaTime;
            temp2 = Mathf.Pow(1.0f / Speed_GoUp, temp) * Distance_GoUp * 0.01f;

            Temp_GoUp.y -= temp2;

            if (temp <= 0.0f) Destroy(this.gameObject);
        }

        transform.position = Start_Position + Temp_GoUp;
    }










}
