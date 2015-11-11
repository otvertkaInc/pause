using UnityEngine;
using System;
using System.IO;

public class GUI_main_menu : MonoBehaviour {

    public string window = "main_menu"; // в зависимости от этой переменной отображается то или иное окно интерефейса

    public Texture2D main_buttom;

    void Start()
    {
       /* if (!Directory.Exists("LevelsData")) //заготовка для файла со списком пройденных уровней
        {
            Directory.CreateDirectory("LevelsData");
        }

        if (!File.Exists("LevelsData/Data.txt"))
        {
            File.Create("LevelsData/Data.txt");
        }*/
    }

    void OnGUI()
    {

        if (window == "main_menu") //main_menu
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 - 50, 100, 50), main_buttom))
            {
                Application.LoadLevel("test_level");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 10, 100, 25), "Levels"))
            {
                window = "levels";
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 50, Screen.height / 2 + 45, 100, 25), "Options"))
            {
                window = "options";
            }
            
        }

        if (window == "levels") //levels
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 25, 200, 25), "Level 1"))
            {
                Application.LoadLevel(1);
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 5, 200, 25), "Level 2"))
            {
                Application.LoadLevel(2);
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 35, 200, 25), "Level 3"))
            {
                Application.LoadLevel(3);
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 65, 200, 25), "Level 4"))
            {
                Application.LoadLevel(4);
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 100, 200, 25), "Back"))
            {
                window = "main_menu";
            }
        }

        if (window == "options") //options
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 25, 200, 25), "Language"))
            {

            }

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 5, 200, 25), "Sound"))
            {
               
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 100, 200, 25), "Back"))
            {
                window = "main_menu";
            }
        }

    }
}