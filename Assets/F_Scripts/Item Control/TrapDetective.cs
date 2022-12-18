using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDetective : MonoBehaviour
{
    public GameObject Parent;
    int Item_Num = 0;

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Obstacles")
        {
            Parent.GetComponent<CharacterControl>().Set_IsTrapped(true);
            Item_Num++;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Obstacles")
        {
            Item_Num--;
            if (Item_Num <= 0) Parent.GetComponent<CharacterControl>().Set_IsTrapped(false);
        }
    }



}
