using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plataform : MonoBehaviour
{
    // Start is called before the first frame update
    public int state;// 0 idel 1 openning 2 closing
    Vector3 startDirection;
    void Start()
    {
        // Store starting direction of the player with respect to the axis of the level
        startDirection = transform.position - transform.parent.position;
        startDirection.y = 0.0f;
        startDirection.Normalize();
        state = 0;

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Moving();
        /*if(Input.GetKey(KeyCode.O)){
            open();
        }
        else if(Input.GetKey(KeyCode.P)){
            close();
        }*/
        if(state == 1){
            openning();
        }else if(state == 2){
            closing();
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
        float angle = Mathf.Atan2(transform.position.x + transform.parent.position.x, transform.position.z + transform.parent.position.z);
        Vector3 pos = transform.position + transform.parent.position;
        pos.x = (float)4*Mathf.Sin(angle);
        pos.z = (float)4*Mathf.Cos(angle);
        transform.position = pos - transform.parent.position;
    }

    void closing()
    {
        float angle = Mathf.Atan2(transform.position.x + transform.parent.position.x, transform.position.z + transform.parent.position.z);
        Vector3 pos = transform.position + transform.parent.position;
        pos.x = (float)2.91*Mathf.Sin(angle);
        pos.z = (float)2.91*Mathf.Cos(angle);
        transform.position = pos - transform.parent.position;
    }

    void Moving(){
        Vector3 position;
        float angle;
        Vector3 direction, target;
        float rotationSpeed = 100;
        position = transform.position;
        angle = rotationSpeed * Time.deltaTime;
        direction = position - transform.parent.position;
        if (Input.GetKey(KeyCode.O))
        {
            target = transform.parent.position + Quaternion.AngleAxis(angle, Vector3.up) * direction;
        }
        if (Input.GetKey(KeyCode.P))
        {
            target = transform.parent.position + Quaternion.AngleAxis(-angle, Vector3.up) * direction;
        }
        // Correct orientation of player
        // Compute current direction
        Vector3 currentDirection = transform.position - transform.parent.position;
        currentDirection.y = 0.0f;
        currentDirection.Normalize();
        // Change orientation of player accordingly
        Quaternion orientation;
        if ((startDirection - currentDirection).magnitude < 1e-3)
            orientation = Quaternion.AngleAxis(0.0f, Vector3.up);
        else if ((startDirection + currentDirection).magnitude < 1e-3)
            orientation = Quaternion.AngleAxis(180.0f, Vector3.up);
        else
            orientation = Quaternion.FromToRotation(startDirection, currentDirection);
        transform.rotation = orientation;
    }
}
