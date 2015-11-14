using UnityEngine;
using System.Collections;

public class ShapeMovement : MonoBehaviour
{
    // Костыль!!! Исправить позже
    public string shape_name;

    /// <summary>
    /// Скорость движения
    /// </summary>
    public float Speed = 0.5f;

    /// <summary>
    /// Направление движения
    /// </summary>
    public Vector3 direction;

    /// <summary>
    /// Проверяет, находится ли объект в движении
    /// </summary>
    public bool isMoving = true;

    /// <summary>
    /// Проверяет на финальной ли позиции фигура
    /// </summary>
    public bool isFinalPosition;

    /// <summary>
    /// Звук вызывается при нажатии на объект
    /// </summary>
    public AudioClip click;

    /// <summary>
    /// Создает начальные условия
    /// </summary>
    void Start ()
    {
        ShapeBehaviour sh = GetComponent<ShapeBehaviour>();
        direction = GameObject.Find(sh.shape_name + "ChangeDirection1").GetComponent<DirChanger>().transform.position - transform.position;
        direction = direction.normalized;
        isFinalPosition = false;
        shape_name = sh.shape_name;
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
    /// Меняет движение на остановку и наоборот
    /// </summary>
    public void ChangeMove()
    {
        isMoving = !isMoving;
        GetComponent<AudioSource>().PlayOneShot(click);
    }
}
