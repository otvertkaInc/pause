using UnityEngine;
using System.Collections.Generic;
using UnityEditor;

public class ShapeRotation : MonoBehaviour
{

    /// <summary>
    /// Проверяет, вращается ли объект
    /// </summary>
    public bool isRotate = true;

    /// <summary>
    /// Скорость вращения
    /// </summary>
    public float SpeedRotation = 0.7f;

    /// <summary>
    /// Проверяет на правильном ли положении фигура
    /// </summary>
    public bool isFinalRotation;

    /// <summary>
    /// Звук вызывается при нажатии на объект
    /// </summary>
    public AudioClip click;

    /// <summary>
    /// Создает начальные условия
    /// </summary>
    void Start()
    {
        isFinalRotation = false;
    }

    void FixedUpdate()
    {
        if (isRotate)
        {
            
            transform.RotateAround(GetComponent<ShapeBehaviour>().Center(), Vector3.forward, SpeedRotation);
        }
            

        List<RotateCheck> rc = new List<RotateCheck>(GetComponentsInChildren<RotateCheck>());
        isFinalRotation = true;
        for (int i = 0; (i < rc.Count) && isFinalRotation; ++i)
            isFinalRotation &= rc[i].RotateFinalPosition;
    }

    /// <summary>
    /// Меняет поворот на остановку и наоборот
    /// </summary>
    public void ChangeRotate()
    {
        isRotate = !isRotate;
        GetComponent<AudioSource>().PlayOneShot(click);
    }
}
