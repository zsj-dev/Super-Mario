using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deathlogic : MonoBehaviour
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
        StartCoroutine(RespawnCharacter());
    }

    IEnumerator RespawnCharacter()
    {
        yield return new WaitForSeconds(0.5f);

        GameManager.Instance.Load();
    }
}
