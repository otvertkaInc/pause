using UnityEngine;
using System.Collections.Generic;

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
    /// Создает начальные условия
    /// </summary>
    void Start()
    {
        isFinalRotation = false;
    }

    void FixedUpdate()
    {
        if (isRotate)
            transform.Rotate(new Vector3(0f, 0f, SpeedRotation));

        List<RotateCheck> rc = new List<RotateCheck>(GetComponentsInChildren<RotateCheck>());
        isFinalRotation = true;
        for (int i = 0; (i < rc.Count) && isFinalRotation; ++i)
            isFinalRotation &= rc[i].RotateFinalPosition;
    }
}
