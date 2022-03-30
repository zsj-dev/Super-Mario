using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerLogic : MonoBehaviour
{
    AudioSource m_audioSource;

    [SerializeField]
    AudioClip m_stepSound;

    [SerializeField]
    AudioClip m_coinSound;
    [SerializeField]
    AudioClip m_victory;

    [SerializeField]
    Text m_ammoText;
    const float MOVEMENT_SPEED = 5.0f;
    const float JUMP_HEIGHT = 0.25f;
    float GRAVITY = 0.9f;

    float m_horizontalInput;

    CharacterController m_characterController;

    Vector3 m_movement;

    bool m_isJumping = false;
    bool m_changeDirection=false;

    Animator m_animator;
    int direction;
    int rotateValue;
    int jumplevel;

    int jumpstatement;

    int victory=0;


    int score;
    // Start is called before the first frame update
    void Start()
    {
        m_characterController = GetComponent<CharacterController>();
        m_animator = GetComponent<Animator>();
        m_audioSource=GetComponent<AudioSource>();
        jumplevel=0;
        rotateValue=180;
        direction=1;
        score=0;
        jumpstatement=0;
    }

    // Update is called once per frame
    void Update()
    {
        m_horizontalInput = Input.GetAxis("Horizontal");
        if(m_horizontalInput>0){
            if(direction==0){
                m_changeDirection=true;
                direction=1;
            }
            
        }
        if(m_horizontalInput<0){
            if(direction==1){
                m_changeDirection=true;
                direction=0;
            }
            
        }

        m_animator.SetFloat("HorizontalInput", Mathf.Abs(m_horizontalInput));
        if(jumplevel>1){
            jumplevel=0;
        }

        if(Input.GetButtonDown("Jump") && (m_characterController.isGrounded||jumplevel==1))
        {
            if(jumplevel==0){
                m_audioSource.PlayOneShot(m_stepSound);
            }
            m_isJumping = true;
            jumpstatement=1;
            jumplevel++;
        }
    }

    void FixedUpdate()
    {
        if(m_changeDirection){
            m_changeDirection=false;
            transform.Rotate(Vector3.up, rotateValue);

        }
        if(m_isJumping)
        {
            m_movement.y = JUMP_HEIGHT;
            m_isJumping = false;
        }

        m_movement.y -= GRAVITY * Time.deltaTime;

        m_movement.x = m_horizontalInput * MOVEMENT_SPEED * Time.deltaTime;

        m_characterController.Move(m_movement);
        if(jumpstatement==1){
            if(m_characterController.isGrounded){
                jumpstatement=0;
                m_audioSource.PlayOneShot(m_stepSound);
            }
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Coin")
        {
            m_audioSource.PlayOneShot(m_coinSound);
            Destroy(other.gameObject);
            score++;
            UpdateAmmoText();
        }
        if(other.tag == "Gravitation1")
        {
            GRAVITY=0.2f;

        }
        if(other.tag == "Gravitation2")
        {
            GRAVITY=0.9f;

        }
        if(other.tag == "Finish")
        {
            if(victory==0){
                victory=1;
                m_audioSource.PlayOneShot(m_victory);
                Invoke("QuitGame",6f);
            }

        }
    }


    public void Save()
    {
        PlayerPrefs.SetFloat("PlayerPosX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerPosY", transform.position.y);
        PlayerPrefs.SetFloat("PlayerPosZ", transform.position.z);

    }

    public void Load()
    {
        float playerPosX = PlayerPrefs.GetFloat("PlayerPosX");
        float playerPosY = PlayerPrefs.GetFloat("PlayerPosY");
        float playerPosZ = PlayerPrefs.GetFloat("PlayerPosZ");

        m_characterController.enabled = false;
        transform.position = new Vector3(playerPosX, playerPosY, playerPosZ);
        m_characterController.enabled = true;
        GRAVITY = 0.9f;
    }
    void Footstep(int i){
        if(m_characterController.isGrounded){
            m_audioSource.PlayOneShot(m_stepSound);
        }
    }

    void UpdateAmmoText()
    {
        m_ammoText.text = "Score: " + score;
    }
    void QuitGame(){
        UnityEditor.EditorApplication.isPlaying=false;
        Application.Quit();
    }
}
