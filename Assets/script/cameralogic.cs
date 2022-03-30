using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameralogic : MonoBehaviour
{
    [SerializeField]
    GameObject m_player;

    Vector3 m_cameraTarget;


    float m_cameraYOffset = 1f;
    float m_cameraZOffset = -8.0f;



    void Start(){
        m_cameraTarget = m_player.transform.position;
      
    }

    // Update is called once per frame
    void Update()
    {
        m_cameraTarget = m_player.transform.position;
        m_cameraTarget.y+=m_cameraYOffset;
       
    }
    void LateUpdate()
    {

        // Add some distance between camera and player / target
        Vector3 cameraOffset = new Vector3(0, 0, m_cameraZOffset);
        transform.position = m_cameraTarget + cameraOffset;
    }

}
