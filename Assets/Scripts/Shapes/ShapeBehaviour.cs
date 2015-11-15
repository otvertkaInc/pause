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

    public Vector3 Center()
    {
        List<Transform> center = new List<Transform>(GetComponentsInChildren<Transform>());
        int ind = 0;

        // Предполагается, что RotateCenter у объекта всего один
        for (int i = 1; i < center.Count; ++i)
        {
            if (center[i].name == "Center")
            {
                ind = i;
                break;
            }
        }

        // Все будет работать! Если у объекта нет RotateCenter, то вернется своей собственный центр
        return center[ind].position;
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
                sh.ChangeMove(); // Заменил на ф-цию, для более легкого доступа к звукам
            if (ts.rotateMode && (rot != null))
                rot.ChangeRotate(); // Аналогично
        }
    }
}