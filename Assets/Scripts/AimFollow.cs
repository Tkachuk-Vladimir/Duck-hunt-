using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimFollow : MonoBehaviour
{

    private Vector3 mousePos;  //координаты указателя мыши

    AudioSource ShootAudio;   // добавляем поле ShootAudio

    float timer;

    void Start()
    {
        // выключаем видимость курсора
        Cursor.visible = false;

        // доспук к звукам
        ShootAudio = GetComponent<AudioSource>();
    }

    void Update()
    {
        // находим координату указателя мышки внутри mainCamera
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // переместить прицел в координату указателя мыши
        transform.position = new Vector3(mousePos.x, mousePos.y, 0);

       // timer += Time.deltaTime;

      //  if (timer >= 0.5f)
       // {
            // если нажать на левую клавишу мыши 
            if (Input.GetButton("Fire1"))
            {
                ShootAudio.Play(); // on Sound shoot, включить звук выстрела
                timer = 0;
            }
        //}
    }
}
