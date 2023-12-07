using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform : MonoBehaviour
{
    // Start is called before the first frame update
    public int state;// 0 idel 1 openning 2 closing
    Vector3 startDirection;
    bool opencheck;
    bool closecheck;

    float radi;
    void Start()
    {   
        radi = Mathf.Sqrt(transform.position.x*transform.position.x + transform.position.z*transform.position.z);
        // Store starting direction of the player with respect to the axis of the level
        startDirection = transform.position - transform.parent.position;
        startDirection.y = 0.0f;
        startDirection.Normalize();
        state = 0;
        opencheck = false;
        closecheck = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.O) && !opencheck){
            open();
            opencheck = true;
            /*Moving();
            Vector3 t = Vector3.zero;
            t.y = transform.position.y;
            transform.position = t;*/
        }
        else if(Input.GetKeyUp(KeyCode.O) && opencheck){
            opencheck = false;
        }
        if(Input.GetKey(KeyCode.P) && !closecheck){
            close();
            closecheck = true;
        }else if(Input.GetKeyUp(KeyCode.O) && closecheck){
            closecheck = false;
        }

        

        if(state == 1){
            openning();
            state = 0;
        }else if(state == 2){
            closing();
            state = 0;
        }
    }

    public void open()
    {
        state = 1;
    }

    public void close()
    {
        state = 2;
    }

    void openning()
    {
        
        float angle = Mathf.Atan2(transform.position.x, transform.position.z);
        Vector3 pos = transform.position;
        pos.x = (float)radi*Mathf.Sin(angle)*-15.0f;
        pos.z = (float)radi*Mathf.Cos(angle)*-15.0f;
        transform.position = pos;
    }

    void closing()
    {
        float angle = Mathf.Atan2(transform.position.x, transform.position.z);
        Vector3 pos = transform.position;
        pos.x = (float)radi*Mathf.Sin(angle);
        pos.z = (float)radi*Mathf.Cos(angle);
        transform.position = pos;
    }

    void Moving(){
        Vector2 xz;
        xz.x = transform.position.x;
        xz.y = transform.position.z;
        Debug.Log(transform.position);
        Debug.Log(transform.parent.position);

        /*xz = xz * 2;
        Vector3 final = transform.position;
        final.x += xz.x;
        final.z += xz.y;
        transform.position = final;
        */
    }
}
