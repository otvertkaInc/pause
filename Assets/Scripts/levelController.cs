using UnityEngine;
using System.Collections.Generic;

public class levelController : MonoBehaviour
{
    private List<DirChanger> triangle_changes;
    private List<DirChanger> circle_changes;

    private string shape;

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
