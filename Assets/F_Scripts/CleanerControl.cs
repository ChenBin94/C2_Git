using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CleanerControl : MonoBehaviour
{
    // public
    [SerializeField] float CleanerPower = 1.0f;
    public Material m_material;

    // private
    private Camera mainCamera;
    private Vector3 currentPosition = Vector3.zero;
    private bool isInuse = false;
    private float Timer = 0.0f;



    // Start is called before the first frame update
    void Start()
    {
        mainCamera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;


        if (Input.GetMouseButton(0))
        {
            var ray = mainCamera.ScreenPointToRay(Input.mousePosition);
            var raycastHitList = Physics.RaycastAll(ray,Mathf.Infinity,LayerMask.GetMask(new string[] {"Floor"})).ToList();
            if (raycastHitList.Any())
            {
                var distance = Vector3.Distance(mainCamera.transform.position, raycastHitList.First().point);
                var mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, distance);

                currentPosition = mainCamera.ScreenToWorldPoint(mousePosition);
            }
        }

        if (isInuse)
        {
            CleanerMover();
            CleanerTurnner();

            float value = Mathf.Sin(Timer * 3.0f) + 1.0f;
            m_material.SetFloat("_OutValue", 0.1f * value);
        }
        else
        {
            m_material.SetFloat("_OutValue", 0.0f);
        }

    }

    void CleanerMover()
    {
        if (currentPosition != Vector3.zero && Vector3.Distance(currentPosition, transform.position) >= 1.0f)
        {
            Vector3 m_Velocity = (currentPosition - transform.position).normalized;
            m_Velocity.y = 0.0f;

            GetComponent<Rigidbody>().velocity = m_Velocity * CleanerPower;

            
        }
    }

    void CleanerTurnner()
    {
        Vector3 m_TargetTurn = new Vector3(currentPosition.x, transform.position.y, currentPosition.z);
        Vector3 m_PresentTurn = transform.position + transform.forward;
        transform.LookAt(m_PresentTurn + (m_TargetTurn - m_PresentTurn) * 0.05f);

    }

    public void SetIsInuse(bool _use)
    {
        isInuse = _use;
    }



    //void OnDrawGizmos()
    //{
    //    if (currentPosition != Vector3.zero)
    //    {
    //        Gizmos.color = Color.blue;
    //        Gizmos.DrawSphere(currentPosition, 0.5f);
    //    }
    //}
}
