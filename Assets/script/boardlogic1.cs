using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boardlogic1 : MonoBehaviour
{
    public float x_speed;
    float init_x;
    public float target;
    
    // Start is called before the first frame update
    void Start()
    {
        init_x=this.transform.position.x;
        
    }

    // Update is called once per frame
    void Update()
    {
        float dx=x_speed*Time.deltaTime;
        this.transform.Translate(dx,0,0,Space.Self);
        if((this.transform.position.x+target)<init_x){
            if(x_speed<0){
                x_speed=-x_speed;

            }
        }if(this.transform.position.x>init_x){
            if(x_speed>0){
                x_speed=-x_speed;
            }
        }
        
    }
}
