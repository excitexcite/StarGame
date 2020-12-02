using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    // скорость скрола фона
    [SerializeField] float backgroundScrollSpeed = 0.2f;
    // переменная для того, что бы связать модельку (метариал), который мы указали в инспекторе юнити с кодом
    Material myMaterial;
    // вектор для задания движения
    Vector2 offSet;
    // Start is called before the first frame update
    void Start()
    {
        // получили материал фона
        myMaterial = GetComponent<Renderer>().material;
        // задали вектор
        offSet = new Vector2(0f, backgroundScrollSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        // по смене кадров двигаем фон на offSet 
        myMaterial.mainTextureOffset += offSet * Time.deltaTime;
    }
}
