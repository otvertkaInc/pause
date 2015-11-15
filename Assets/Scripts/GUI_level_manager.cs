using UnityEngine;
using System.Collections.Generic;

public class GUI_level_manager : MonoBehaviour
{
    public bool need_mov = true;

    public bool rotateMode;
    public bool moveMode;
    public Texture2D StarTexture2D; // Переименовал

    private bool flag; // флаг

    void Start()
    {
        rotateMode = false;
        moveMode = true;

        flag = true;
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 4, 3*Screen.height / 4, 100, 25), "MoveMode"))
        {
            moveMode = true;
            rotateMode = false;
        }

        if (GUI.Button(new Rect(Screen.width / 4 - 105, 3*Screen.height / 4, 100, 25), "RoatateMode"))
        {
            moveMode = false;
            rotateMode = true;
        }

        List<ShapeMovement> shapes = new List<ShapeMovement>(FindObjectsOfType<ShapeMovement>());
        List<ShapeRotation> Sh_r = new List<ShapeRotation>(FindObjectsOfType<ShapeRotation>());
        GUI.color = Color.yellow;
        GUI.backgroundColor = Color.black;
        if (isAllTrue(shapes, Sh_r))
        {
            if (flag)
            {
                flag = false;
                //FindObjectOfType<levelController>().moveToFinalPos(shapes); // Движение всех фигур к своим финальным позициям
            }

            GUI.Label(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 115, 200, 100), StarTexture2D);
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
                if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 150, 200, 25), "Next level"))
                {
                    Application.LoadLevel(Application.loadedLevel + 1);
                }
            
                if (GUI.Button(new Rect(Screen.width / 2 - 150, Screen.height / 2 - 250, 200, 50), "Level complete!"))
                {
                
                }
            }
        }
    }

    /// Проверяет все ли фигуры на своих финальных позициях
    bool isAllTrue(List<ShapeMovement> shapes, List<ShapeRotation> sh_r)
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
