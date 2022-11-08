using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{






    // Start is called before the first frame update
    void Start()
    {
        //Application.targetFrameRate = 60;
        

    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.RightArrow))
        {
            Vector3 force = new Vector3(0.0f, 10.0f, 0.0f);
            GetComponent<Rigidbody>().AddForce(force * Time.deltaTime * 60.0f,ForceMode.Impulse);


        }




    }
}
