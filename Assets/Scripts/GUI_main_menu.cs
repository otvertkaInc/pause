using UnityEngine;
using System;
using System.IO;

public class GUI_main_menu : MonoBehaviour {

    private string window = "Otvertka"; // в зависимости от этой переменной отображается то или иное окно интерефейса

    public Texture2D main_buttom;
    public Texture2D white_background;
    public Texture2D otvertka;
    public Texture2D cube;

    public GUIStyle style_text_otvertka;

    public GUIStyle style_text_pause;
    public GUIStyle style_text_in_buttom;
    public GUIStyle style_main_buttom;

    public GUIStyle style_text_in_cubes;


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
        GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), white_background, ScaleMode.StretchToFill);

        if (window == "Otvertka")
        {        
            GUI.DrawTexture(new Rect(Screen.width / 6, 6 , Screen.width * 5 / 7, Screen.height * 11 / 17), otvertka, ScaleMode.ScaleToFit);
            GUI.Label(new Rect(Screen.width/2 - 50, Screen.height / 2 - 15, 100, 30), "Otvertka", style_text_otvertka);
            if (GUI.Button(new Rect(0, 0, Screen.width, Screen.height), "", style_text_otvertka))
            {
                window = "main_menu";
            }

        }

        if (window == "main_menu") //main_menu
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, 10, 100, Screen.height * 2 / 7), "Pause", style_text_pause);

            if (GUI.Button(new Rect(6, Screen.height * 2 / 7, Screen.width - 12, Screen.height * 1 / 7), main_buttom, style_main_buttom))
            {
                Application.LoadLevel("test_level");
            }

            if (GUI.Button(new Rect(6, Screen.height * 3 / 7, Screen.width - 12, Screen.height * 1 / 7), "Levels", style_text_in_buttom))
            {
                window = "cubes";
            }

            if (GUI.Button(new Rect(6, Screen.height * 4 / 7, Screen.width - 12, Screen.height * 1 / 7), "Options", style_text_in_buttom))
            {
                window = "options";
            }

            if (GUI.Button(new Rect(6, Screen.height * 5 / 7, Screen.width - 12, Screen.height / 7), "Shop", style_text_in_buttom))
            {

            }
            
        }

        if (window == "cubes")
        {     
            if (GUI.Button(new Rect(Screen.width / 2 - Screen.height / 7, Screen.height / 7, Screen.height * 2 / 7, Screen.height * 2 / 7), cube, style_text_in_buttom))
            {
                window = "levels_1";
            }
            GUI.Label(new Rect(Screen.width / 2 - Screen.height / 7, Screen.height / 7, Screen.height * 2 / 7, Screen.height * 2 / 7), "1", style_text_in_cubes);

            if (GUI.Button(new Rect(Screen.width / 2 - Screen.height / 7, Screen.height * 3 / 7, Screen.height * 2 / 7, Screen.height * 2 / 7), cube, style_text_in_buttom))
            {
                //this will be levels_2
            }
            GUI.Label(new Rect(Screen.width / 2 - Screen.height / 7, Screen.height * 3 / 7, Screen.height * 2 / 7, Screen.height * 2 / 7), "2", style_text_in_cubes);

            if (GUI.Button(new Rect(6, Screen.height * 5 / 7, Screen.width - 12, Screen.height * 1 / 7), "Back", style_text_in_buttom))
            {
                window = "main_menu";
            }
        }


        if (window == "levels_1") 
        {
            if (GUI.Button(new Rect(6, Screen.height / 7, Screen.width - 12, Screen.height * 1 / 7), "Level 1", style_text_in_buttom))
            {
                Application.LoadLevel(1);
            }

            if (GUI.Button(new Rect(6, Screen.height * 2 / 7, Screen.width - 12, Screen.height * 1 / 7), "Level 2", style_text_in_buttom))
            {
                Application.LoadLevel(2);
            }

            if (GUI.Button(new Rect(6, Screen.height * 3 / 7, Screen.width - 12, Screen.height * 1 / 7), "Level 3", style_text_in_buttom))
            {
                Application.LoadLevel(3);
            }

            if (GUI.Button(new Rect(6, Screen.height * 4 / 7, Screen.width - 12, Screen.height * 1 / 7), "Level 4", style_text_in_buttom))
            {
                Application.LoadLevel(4);
            }

            if (GUI.Button(new Rect(6, Screen.height * 5 / 7, Screen.width - 12, Screen.height * 1 / 7), "Back", style_text_in_buttom))
            {
                window = "cubes";
            }
        }

        if (window == "options") //options
        {
            GUI.Label(new Rect(Screen.width / 2 - 50, 10, 100, Screen.height * 2 / 7), "Pause", style_text_pause);

            if (GUI.Button(new Rect(6, Screen.height * 2 / 7, Screen.width - 12, Screen.height * 1 / 7), main_buttom, style_main_buttom))
            {
                window = "main_menu";
            }

            if (GUI.Button(new Rect(6, Screen.height * 3 / 7, Screen.width - 12, Screen.height * 1 / 7), "Language", style_text_in_buttom))
            {
                
            }

            if (GUI.Button(new Rect(6, Screen.height * 4 / 7, Screen.width - 12, Screen.height * 1 / 7), "Music", style_text_in_buttom))
            {
              
            }

            if (GUI.Button(new Rect(6, Screen.height * 5 / 7, Screen.width - 12, Screen.height / 7), "About", style_text_in_buttom))
            {

            }
        }

    }
}