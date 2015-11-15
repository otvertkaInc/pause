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
            List<Transform> center = new List<Transform>(GetComponentsInChildren<Transform>());
            int ind = 0;

            // Предполагается, что RotateCenter у объекта всего один
            for (int i = 1; i < center.Count; ++i)
            {
                if (center[i].name == "RotateCenter")
                {
                    ind = i;
                    break;
                }
            }

            // Все будет работать! Если у объекта нет RotateCenter, то объект будет вращаться вокруг своего собственного центра
            transform.RotateAround(center[ind].position, Vector3.forward, SpeedRotation);
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
