//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Pointer : MonoBehaviour
//{
//    public float m_Distance = 10.0f;
//    public LineRenderer m_LineRenderer = null;
//    public LayerMask m_EverythingMask = 0;
//    public LayerMask m_InteractableMask = 0;

//    private Transform m_CurrentOrigin = null;
    
//    private RaycastHit CreateRaycast(int layer)
//    {
//        RaycastHit hit;
//        return hit;
//    }

//    private void Update()
//    {
//        Vector3 hitPoint = UpdateLine();
//    }

//    private Vector3 UpdateLine()
//    {
//        //Create ray
//        RaycastHit hit = CreateRaycast(m_EverythingMask);

//        // default end
//        Vector3 endPosition = m_CurrentOrigin.position + (m_CurrentOrigin.forward * m_Distance);

//        //check hit
//        if(hit.collider != null)
//        {
//            endPosition = hit.point;
//        }

//        //set poisition
//        m_LineRenderer.SetPosition(0, m_CurrentOrigin.position);
//        m_LineRenderer.SetPosition(1, endPosition);

//        return endPosition;
//    }

//}
