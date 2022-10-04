using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowTag : MonoBehaviour
{
    public GameObject Tag;

    bool Is_ShowTag = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(Is_ShowTag)
        {
            Instantiate(Tag, this.transform.position, Quaternion.identity);
            Is_ShowTag = false;
        }






    }


    private void OnMouseDown()
    {
        Is_ShowTag = true;
    }








}
