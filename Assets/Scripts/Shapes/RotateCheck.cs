using UnityEngine;
using System.Collections;

public class RotateCheck : MonoBehaviour
{
    public bool RotateFinalPosition = false;

    /// <summary>
    /// Срабатывает при входе объекта в триггер
    /// </summary>
    void OnTriggerEnter2D(Collider2D col)
    {
        ShapeBehaviour shape = GetComponentInParent<ShapeBehaviour>();
        if (col.name.StartsWith(shape.shape_name + "RightRotation"))
        {
            RotateFinalPosition = true;
        }
    }

    /// <summary>
    /// Срабатывает при выходе объекта из триггера
    /// </summary>
    void OnTriggerExit2D(Collider2D col)
    {
        ShapeBehaviour shape = GetComponentInParent<ShapeBehaviour>();

        if (col.name.StartsWith(shape.shape_name + "RightRotation"))
            RotateFinalPosition = false;
    }
}
