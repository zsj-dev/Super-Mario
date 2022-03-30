using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckLoadLogic : MonoBehaviour
{
    AudioSource m_audioSource;

    [SerializeField]
    AudioClip m_Sound;


    // Start is called before the first frame update
    void Start()
    {

        m_audioSource=GetComponent<AudioSource>();
        

    }
    void OnTriggerEnter(Collider other)
    {   
        m_audioSource.PlayOneShot(m_Sound);
        GameManager.Instance.Save();
    }
}
