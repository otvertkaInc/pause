using UnityEngine;
using System.Collections.Generic;

public class levelController : MonoBehaviour
{
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
    /// Функция сравнения чисел типа float (точность = 0.01f)
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
        int countOfRightRotSh = 0;
        float finalRotSpeed = 9f;
        foreach (ShapeMovement sh in shapes)
        {
            Vector3 rightPos = GameObject.Find(sh.shape_name + "RightPosition").transform.position;
            Vector3 direction = rightPos - sh.transform.position; // Здесь как раз таки не нужно использовать .normalized
            sh.GetComponent<Rigidbody2D>().velocity = direction * 2.5f;
            if (sh.GetComponent<ShapeRotation>() != null)
            {
                // Условия для замедления скорости вращения
                if (Mathf.Abs(sh.GetComponent<Rigidbody2D>().rotation) < 30f)
                    finalRotSpeed = 2f;
                if (Mathf.Abs(sh.GetComponent<Rigidbody2D>().rotation) < 15f)
                    finalRotSpeed = 1f;
                if (Mathf.Abs(sh.GetComponent<Rigidbody2D>().rotation) < 5f)
                    finalRotSpeed = 0.2f;
                
                if (!compareFloat(sh.GetComponent<Rigidbody2D>().rotation, 0f))
                {
                    sh.transform.RotateAround(sh.transform.position, Vector3.forward, finalRotSpeed);
                }                                                                        // без else
                if (compareFloat(sh.GetComponent<Rigidbody2D>().rotation, 0f))
                {
                    countOfRightRotSh++;
                }
            }
            if (compareFloat(sh.transform.position.x, rightPos.x) && compareFloat(sh.transform.position.y, rightPos.y))
            {
                sh.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
                countOfRightSh++;
            }
        }
        if (countOfRightSh == shapes.Count && countOfRightRotSh == 1)
        {
            inCycle = false; // Ограничение на вход в цикл
            flagForGUI_level_manager = true; // для проверки в скрипте GUI_level_manager.cs
        }
    }

    void Start()
    {
        List<ShapeMovement> shapes = new List<ShapeMovement>(FindObjectsOfType<ShapeMovement>()); // создается список всех фигур
        foreach (ShapeMovement sh in shapes)
        {
            shape = sh.GetComponent<ShapeBehaviour>().shape_name;
            List<DirChanger> changes = new List<DirChanger>(GameObject.Find(shape + "_changes").GetComponentsInChildren<DirChanger>()); // создается список точек отталкивания очередной фигуры
            int count = changes.Count;
            for (int i = 0; i < count; ++i)          // инициализация направления движения
            {
                changes[i].new_direction = changes[(i + 1) % count].transform.position;
            }
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
