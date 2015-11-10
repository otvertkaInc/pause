using UnityEngine;
using System.Collections;

public class GUI_test : MonoBehaviour {

    private int window;

    public Texture2D main_buttom;

    void OnGUI()
    {

        if (window == 0)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 75, Screen.height / 2 - 50, 150, 100), main_buttom))
            {
                window = 1;
            }

            
        }

        if (window == 1)
        {
            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 - 25, 200, 25), "Level 1"))
            {
                Application.LoadLevel("test_level");
            }

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 5, 200, 25), "Level 2"))
            {

            }

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 35, 200, 25), "Level n"))
            {

            }

            if (GUI.Button(new Rect(Screen.width / 2 - 100, Screen.height / 2 + 85, 200, 25), "Back"))
            {
                window = 0;
            }
        }
    }
}
