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


    private bool flag; // флаг

    void Start()
    {
        rotateMode = false;
        moveMode = true;

        flag = true;
    }

    void OnGUI()
    {
        if (GUI.Button(new Rect(Screen.width / 2, 3*Screen.height / 4 + 150, 100, 25), "MoveMode"))
        {
            moveMode = true;
            rotateMode = false;
        }

        if (GUI.Button(new Rect(Screen.width / 2 - 105, 3*Screen.height / 4 + 150, 100, 25), "RoatateMode"))
        {
            moveMode = false;
            rotateMode = true;
        }

        List<ShapeMovement> shapes = new List<ShapeMovement>(FindObjectsOfType<ShapeMovement>());
        List<ShapeRotation> Sh_r = new List<ShapeRotation>(FindObjectsOfType<ShapeRotation>());
        GUI.color = Color.yellow;
        GUI.backgroundColor = Color.black;
        bool fl = true;
        if (isAllTrue(shapes, Sh_r))
        {
            if (flag)
            {
                flag = false;
                //FindObjectOfType<levelController>().moveToFinalPos(shapes); // Движение всех фигур к своим финальным позициям
            }
            if (fl)
            {
                System.Threading.Thread.Sleep(120);
                fl = !fl;
            }
            GUI.DrawTexture(new Rect(Screen.width / 35, 230, Screen.width, Screen.height * 11 / 25), Background_btw_lvl, ScaleMode.StretchToFill);
            GUI.DrawTexture(new Rect(Screen.width / 18 * 4, 310, Screen.width - 240, Screen.height * 5 / 30), StarTexture2D, ScaleMode.StretchToFill);
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
                GUI.DrawTexture(new Rect(Screen.width / 2 + 70 , Screen.height / 2 + 60, 140, 40), Next_lvl, ScaleMode.StretchToFill);
                if (GUI.Button(new Rect(Screen.width / 2 + 70, Screen.height / 2 + 60, 140, 40), "Next level"))
                 {
                     Application.LoadLevel(Application.loadedLevel + 1);
                 }
                GUI.DrawTexture(new Rect(Screen.width / 2 - 210, Screen.height / 2 + 60, 140, 40), Next_lvl, ScaleMode.StretchToFill);
                if (GUI.Button(new Rect(Screen.width / 2 - 210, Screen.height / 2 + 60, 140, 40), "Level complete!"))
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
