using UnityEngine;
using System.Collections.Generic;

public class ShapeBehaviour : MonoBehaviour
{
    /// <summary>
    /// Скорость движения
    /// </summary>
    public float Speed = 0.5f;

    //время начала
    //public DateTime Start;
    //время конца
    //public DateTime Stop;

    /// <summary>
    /// Направление движения
    /// </summary>
    public Vector3 direction;

    /// <summary>
    /// Название фигуры (с мальенькой буквы)
    /// </summary>
    public string shape_name = "Shape";

    /// <summary>
    /// Проверяет, находится ли объект в движении
    /// </summary>
    public bool isMoving = true;

    /// <summary>
    /// Проверяет на финальной ли позиции фигура
    /// </summary>
    public bool isFinalPosition;

    /// <summary>
    /// Создает начальные условия
    /// </summary>
    void Start()
    {
      //  Start = DateTime.Now;
        direction = GameObject.Find(shape_name + "ChangeDirection1").GetComponent<DirChanger>().transform.position - transform.position;
        direction = direction.normalized;
        isFinalPosition = false;
    }

    /// <summary>
    /// Обновляется несколько раз за кадр
    /// </summary>
    void FixedUpdate()
    {
        if (isMoving)
            GetComponent<Rigidbody2D>().velocity = direction * Speed;
        else
            GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }

    /// <summary>
    /// Срабатывает, когда на объект кликают мышкой
    /// </summary>
    void OnMouseDown()
    {
        GUI_level_manager ts = FindObjectOfType<GUI_level_manager>();
        ShapeRotation rot = GetComponent<ShapeRotation>();
        
        if (ts.need_mov)
        {
            if (ts.moveMode)
                isMoving = !isMoving;
            if (ts.rotateMode && (rot != null))
                rot.isRotate = !rot.isRotate;
        }
    }
}