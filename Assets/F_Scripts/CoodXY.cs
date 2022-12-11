using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

[ExecuteAlways]
public class CoodXY : MonoBehaviour
{
    TextMeshPro lable;
    Vector2Int coordinates = new Vector2Int();

    private void Awake()
    {
        lable = GetComponent<TextMeshPro>();
        DisplayCoordinates();
    }

    // Update is called once per frame
    void Update()
    {
        
        if(!Application.isPlaying)
        {
            DisplayCoordinates();
            UpdateObjectName();
        }

    }

    void DisplayCoordinates()
    {
        coordinates.x = Mathf.RoundToInt(transform.parent.position.x / 2);
        coordinates.y = Mathf.RoundToInt(transform.parent.position.z / 2);

        //lable.text = coordinates.x + "," + coordinates.y;
        lable.text = " ";
    }

    void UpdateObjectName()
    {
        transform.parent.name = coordinates.ToString();
    }



}
