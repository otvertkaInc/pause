using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GUI_level_manager : MonoBehaviour
{
    public bool need_mov = true;

    void OnGUI()
    {
        List<ShapeBehaviour> shapes = new List<ShapeBehaviour>(FindObjectsOfType<ShapeBehaviour>());
        GUI.color = Color.yellow;
        GUI.backgroundColor = Color.black;
        bool b = true;
        for (int i = 0; i < shapes.Count; i++)
            if (shapes[i].isMoving)
            {
                b = !b;
                break;
            }

        if (isAllTrue(shapes) && b)
        {
            if (Application.loadedLevel == (Application.levelCount - 1))
            {
                if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 100, 200, 25), "Main menu"))
                {
                    Application.LoadLevel(0);
                }

                if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 150, 300, 300), "Game complete!"))
                {

                }
            }

            else
            {
                if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 100, 200, 25), "Next level"))
                {
                    Application.LoadLevel(Application.loadedLevel + 1);
                }

                if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 150, 300, 300), "Level complete!"))
                {

                }
            }

        }
    }
            
    /// Проверяет все ли фигуры на своих финальных позициях
    bool isAllTrue(List<ShapeBehaviour> shapes)
    {
        bool res = true;
        int i = 0;
        while (res && (i < shapes.Count))
        {
            res &= shapes[i++].isFinalPosition;
        }
        bool bol = false;
        for (int j = 0; j < shapes.Count; ++j)
            if (shapes[j].isMoving || !shapes[j].isFinalPosition)
            {
                bol = !bol;
                break;
            }
        need_mov = bol;
        return res;
    }
}
