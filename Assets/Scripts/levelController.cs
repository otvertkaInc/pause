using UnityEngine;
using System.Collections.Generic;

public class levelController : MonoBehaviour
{
    /// <summary>
    /// Массив ChangeDirection'ов для треугольника
    /// </summary>
    private List<DirChanger> triangle_changes;

    /// <summary>
    /// Массив ChangeDirection'ов для окружности
    /// </summary>
    private List<DirChanger> circle_changes;

    private string shape;

    /// <summary>
    /// Движение всех фигур к своим финальным позициям (уровень пройден)
    /// </summary>
    public void moveToFinalPos(List<ShapeMovement> shapes)
    {
        for (int i = 0; i < shapes.Count; ++i)
        {
            shapes[i].isMoving = true;
            Vector3 direction = (GameObject.Find(shapes[i].shape_name + "RightPosition").transform.position - shapes[i].transform.position).normalized;
            shapes[i].direction = direction;
            //shapes[i].GetComponent<Rigidbody2D>().velocity = direction * 0.5f;
            //shapes[i].isMoving = false;

                /*
                if (shapes[i].GetComponent<ShapeRotation>() != null) 
                {
                    List<ShapeRotation> rotates = new List<ShapeRotation>(GameObject.Find(shapes[i].shape_name + "RightPosition").GetComponentsInChildren<ShapeRotation>());
                    for (int j = 0; j < rotates.Count; ++j)
                    {
                        //shapes[i].GetComponent
                    }
                }
                */
        }
    }

    void Start()
    {
        // для triangle
        shape = GameObject.Find("red_triangle").GetComponent<ShapeBehaviour>().shape_name;
        triangle_changes = new List<DirChanger>(GameObject.Find(shape + "_changes").GetComponentsInChildren<DirChanger>()); // создается массив точек отталкивания фигуры triangle
        int count_triangle = triangle_changes.Count;
        for (int i = 0; i < count_triangle; ++i)          // инициализация направления движения
        {
            triangle_changes[i].new_direction = triangle_changes[(i + 1) % count_triangle].transform.position;
        }

        // для circle
        shape = GameObject.Find("blue_circle").GetComponent<ShapeBehaviour>().shape_name;
        circle_changes = new List<DirChanger>(GameObject.Find(shape + "_changes").GetComponentsInChildren<DirChanger>()); // создается массив точек отталкивания фигуры circle
        int count_circle = circle_changes.Count;
        for (int i = 0; i < count_circle; ++i)          // инициализация направления движения
        {
            circle_changes[i].new_direction = circle_changes[(i + 1) % count_circle].transform.position;
        }

    }
}
