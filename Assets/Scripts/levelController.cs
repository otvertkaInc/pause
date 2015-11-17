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
    /// Ограничение на вход в цикл
    /// </summary>
    bool inCycle;

    /// <summary>
    /// Флаг для проверки в скрипте GUI_level_manager.cs
    /// </summary>
    public bool flagForGUI_level_manager;

    /// <summary>
    /// Аналогия isAllTrue(...) из скрипта GUI_level_manager.cs
    /// </summary>
    bool allTrue;

    /// <summary>
    /// Функция сравнения цисел типа float (точность = 0.01f)
    /// </summary>
    bool compareFloat(float x, float y, float eps = 0.01f)
    {
        return Mathf.Abs(x - y) < eps;
    }

    /// <summary>
    /// Движение всех фигур к своим финальным позициям (уровень пройден)
    /// </summary>
    public void moveToFinalPos(ref bool inCycle, ref bool flagForGUI_level_manager)
    {
        List<ShapeMovement> shapes = new List<ShapeMovement>(FindObjectsOfType<ShapeMovement>());
        int countOfRightSh = 0;
        foreach (ShapeMovement sh in shapes)
        {
            Vector3 rightPos = GameObject.Find(sh.shape_name + "RightPosition").transform.position;
            Vector3 direction = rightPos - sh.transform.position; // Здесь как раз таки не нужно использовать .normalized
            sh.GetComponent<Rigidbody2D>().velocity = direction * 2.5f;
            if (sh.GetComponent<ShapeRotation>() != null)
                //sh.transform.eulerAngles = new Vector3(0.0f, sh.transform.rotation.y, sh.transform.rotation.z);
                sh.transform.eulerAngles = new Vector3(Mathf.LerpAngle(sh.transform.rotation.x, 0.0f, 5 * Time.fixedDeltaTime), sh.transform.rotation.y, sh.transform.rotation.z);
            if (compareFloat(sh.transform.position.x, rightPos.x) && compareFloat(sh.transform.position.y, rightPos.y))
            {
                sh.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                countOfRightSh++;
            }
        }
        if (countOfRightSh == shapes.Count)
        {
            inCycle = false; // Ограничение на вход в цикл
            flagForGUI_level_manager = true; // для проверки в скрипте GUI_level_manager.cs
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

        inCycle = true;
        flagForGUI_level_manager = false;
        allTrue = false;
    }

    void FixedUpdate()
    {
        List<ShapeMovement> shapes = new List<ShapeMovement>(FindObjectsOfType<ShapeMovement>());
        List<ShapeRotation> Sh_r = new List<ShapeRotation>(FindObjectsOfType<ShapeRotation>());

        if (!allTrue && FindObjectOfType<GUI_level_manager>().isAllTrue(shapes, Sh_r)) // Усложнили код, зато isAllTrue уже будет не нужен (намного эффективнее)
            allTrue = !allTrue;

        if (allTrue && inCycle)
            moveToFinalPos(ref inCycle, ref flagForGUI_level_manager);
    }
}
