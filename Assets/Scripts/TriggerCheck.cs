using UnityEngine;

public class TriggerCheck : MonoBehaviour
{
    /// <summary>
    /// Срабатывает при входе объекта в триггер
    /// </summary>
    void OnTriggerEnter2D(Collider2D col)
    {
        ShapeBehaviour shape = GetComponentInParent<ShapeBehaviour>();
        if (col.name.StartsWith(shape.shape_name + "ChangeDirection"))
        {
            shape.direction = col.GetComponent<DirChanger>().new_direction - transform.position;
        }

        if (col.name.StartsWith(shape.shape_name + "RightPosition"))
        {
            shape.isFinalPosition = true;
        }
    }

    /// <summary>
    /// Срабатывает при выходе объекта из триггера
    /// </summary>
    void OnTriggerExit2D(Collider2D col)
    {
        ShapeBehaviour shape = GetComponentInParent<ShapeBehaviour>();
        if (col.name.StartsWith(shape.shape_name + "RightPosition"))
        {
            shape.isFinalPosition = false;
        }
    }
}
