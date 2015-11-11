using UnityEngine;
using System.Collections;

public class RotateCheck : MonoBehaviour
{
    /// <summary>
    /// Срабатывает при входе объекта в триггер
    /// </summary>
    void OnTriggerEnter2D(Collider2D col)
    {
        Debug.Log("OnTriggerEnter2D RotateCheck"); // Он почему-то сюда не заходит :(
        ShapeBehaviour shape = GetComponentInParent<ShapeBehaviour>();
        if (col.name.StartsWith(shape.shape_name + "RightRotation"))
        {
            Debug.Log("On if RotateCheck");
            GetComponentInParent<ShapeRotation>().isFinalRotation = true;
        }
    }

    /// <summary>
    /// Срабатывает при выходе объекта из триггера
    /// </summary>
    void OnTriggerExit2D(Collider2D col)
    {
        Debug.Log("OnTriggerExit2D RotateCheck");
        ShapeBehaviour shape = GetComponentInParent<ShapeBehaviour>();

        if (col.name.StartsWith(shape.shape_name + "RightRotation"))
            GetComponentInParent<ShapeRotation>().isFinalRotation = false;
    }
}
