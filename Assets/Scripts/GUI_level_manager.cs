using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class GUI_level_manager : MonoBehaviour
{
    public bool need_mov = true;

    public bool rotateMode;
    public bool moveMode;
    public Texture2D StarTexture2D; // Переименовал
    public Texture2D Background_btw_lvl;
    public Texture2D Next_lvl;

    /// <summary>
    /// Аналогия isAllTrue(...)
    /// </summary>
    bool flag;

    void Start()
    {
        rotateMode = false;
        moveMode = true;

        flag = false;
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2, 3 * Screen.height / 10 * 3, 100, 25), "MoveMode"))
        {
            moveMode = true;
            rotateMode = false;
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 105, 3 * Screen.height / 10 * 3, 100, 25), "RoatateMode"))
        {
            moveMode = false;
            rotateMode = true;
        }

        List<ShapeMovement> shapes = new List<ShapeMovement>(FindObjectsOfType<ShapeMovement>());
        List<ShapeRotation> Sh_r = new List<ShapeRotation>(FindObjectsOfType<ShapeRotation>());
        GUI.color = Color.yellow;
        GUI.backgroundColor = Color.black;

        bool fl = true; // флаг для запуска задержки

        if (FindObjectOfType<levelController>().flagForGUI_level_manager) // Переменной flag переприсваиваем значение flag1 хотя бы один раз,
            flag = true;                                                  // т. к. неизвестно что там будет дальше с переменной flag1, которая совсем из другого скрипта

        if (/*isAllTrue(shapes, Sh_r) && */flag) // Теперь проверка условия будет такой. В этом флаге скрывается isAllTrue,
        {                                        // но зато эта огромная фигня не вызывается по сто раз.
                                                 // А свидетельство того, что это равносильно isAllTrue, написано в скрипте levelController.cs
            if (fl)
            {
                System.Threading.Thread.Sleep(120);
                fl = !fl;
            }

            GUI.DrawTexture(new Rect(Screen.width / 35, Screen.height / 3, Screen.width, Screen.height * 11 / 25), Background_btw_lvl, ScaleMode.StretchToFill);
            GUI.DrawTexture(new Rect(Screen.width / 12 * 4, Screen.height / 7 * 3, Screen.width / 7 * 2, Screen.height * 5 / 30), StarTexture2D, ScaleMode.StretchToFill);
            if (Application.loadedLevel == (Application.levelCount - 1))
            {
                if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 100, Screen.width / 10, Screen.height / 25), "Main menu"))
                {
                    Application.LoadLevel(0);
                }

                if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 150, Screen.width / 20, Screen.height / 25), "Game complete!"))
                {

                }
            }
            else
                GUI.DrawTexture(new Rect(Screen.width / 20 * 3, Screen.height / 32 * 20, Screen.width / 4, Screen.height / 18), Next_lvl, ScaleMode.StretchToFill);

            if (GUI.Button(new Rect(Screen.width / 20 * 3, Screen.height / 32 * 20, Screen.width / 4, Screen.height / 18), "Next level"))
            {
                Application.LoadLevel(Application.loadedLevel + 1);
            }
            GUI.DrawTexture(new Rect(Screen.width / 6 * 3, Screen.height / 32 * 20, Screen.width / 5 * 2, Screen.height / 18), Next_lvl, ScaleMode.StretchToFill);
            if (GUI.Button(new Rect(Screen.width / 6 * 3, Screen.height / 32 * 20, Screen.width / 5 * 2, Screen.height / 18), "Level complete!"))
            {

            }
        }
    }

    /// <summary>
    /// Проверяет все ли фигуры на своих финальных позициях
    /// </summary>
    public bool isAllTrue(List<ShapeMovement> shapes, List<ShapeRotation> sh_r)
    {
        bool bol = false;
        for (int j = 0; j < shapes.Count; ++j)
        {
            if (shapes[j].isMoving || !shapes[j].isFinalPosition)
            {
                bol = !bol;
                break;
            }
        }
        if (!bol)
        {
            for (int i = 0; i < sh_r.Count; ++i)
            {
                if (!sh_r[i].isFinalRotation || sh_r[i].isRotate)
                {
                    bol = !bol;
                    break;
                }
            }
        }
        need_mov = bol;
        return !bol;
    }
}
