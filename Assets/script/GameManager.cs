using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager m_instance;
    public static GameManager Instance => m_instance;

    PlayerLogic m_playerLogic;
    void Awake()
    {
        CreateSingleton();    
    }

    // This code ensures there is only ONE
    void CreateSingleton()
    {
        if(m_instance == null)
        {
            m_instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        m_playerLogic = FindObjectOfType<PlayerLogic>();
    }


    public void Save()
    {
        m_playerLogic.Save();


        PlayerPrefs.Save();

    }

    public void Load()
    {
        m_playerLogic.Load();


    }
}
