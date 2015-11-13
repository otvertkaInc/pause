using System;
using UnityEngine;
using System.Collections.Generic;

public class ShapeBehaviour : MonoBehaviour
{

    /// <summary>
    ///время начала
    /// </summary>
    public DateTime StarTime;

    /// <summary>
    ///время конца
    /// </summary>
    public DateTime StopTime;

    /// <summary>
    /// Название фигуры (с мальенькой буквы)
    /// </summary>
    public string shape_name = "shape";

    /// <summary>
    /// Создает начальные условия
    /// </summary>
    void Start()
    {
      //  Start = DateTime.Now;
    }

    /// <summary>
    /// Срабатывает, когда на объект кликают мышкой
    /// </summary>
    void OnMouseDown()
    {
        GUI_level_manager ts = FindObjectOfType<GUI_level_manager>();

        ShapeRotation rot = GetComponent<ShapeRotation>();
        ShapeMovement sh = GetComponent<ShapeMovement>();

        if (ts.need_mov)
        {
            if (ts.moveMode && (sh != null))
                sh.isMoving = !sh.isMoving;
            if (ts.rotateMode && (rot != null))
                rot.isRotate = !rot.isRotate;
        }
    }
}