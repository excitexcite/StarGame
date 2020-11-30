using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class joystick : MonoBehaviour
{
    Vector3 target_vector;
    public GameObject touch_marker;

    public Player player;
    Vector3 ee;
    bool onFire = false;

    // Start is called before the first frame update
    void Start()
    {
        touch_marker.transform.position = transform.position;
        ee = new Vector3(0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //если есть касание
        if (Input.GetMouseButton(0)){
            //player.FireOn();
           Vector3 touch_pos = Input.mousePosition;

            target_vector = touch_pos - transform.position;
            touch_marker.transform.position = touch_pos;

            //Получаем направление движения
            float aa = (float)Math.Sqrt(target_vector.x * target_vector.x + target_vector.y*target_vector.y);
            ee = new Vector3(target_vector.x / aa, target_vector.y/aa, 0); 

            //Если произоло касание за радиусом джойстика
            if(target_vector.magnitude > 100){
               touch_marker.transform.position = transform.position + ee * 100; 
           }
           if (onFire == false){
               Debug.Log(1);
               //player.FireOn();
           }
           onFire = true;
        }
        //если нет касания
        else {
            //player.FireOff();
            touch_marker.transform.position += (touch_marker.transform.position - transform.position) * -1 / 30;
        }
        


        //передать вектор движения игроку
        player.MoveJoys((touch_marker.transform.position - transform.position)/125);
        
    }
}
