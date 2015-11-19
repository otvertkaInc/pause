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

    public int click_count = 0; //считает, сколько кликов было сделано
    public int min_level_click = 4; //АХТУНГ! для каждого уровня переменная будет инициализироваться по разному. 
                                     //она символизирует , сколько минимально кликов нужно сделать в худшем случае, чтобы закончить уровень.
    public int max3_level_click = 8;//соответственно, крайнее количество кликов на 3 звезды ;)
    public int min2_level_click = 12;//...на 2 звезды...
    public int min3_level_click = 15;//..на 1 звезду...
    //что будет , если пользователь окажется крайним уникумом и не поймет что от него требуется, потратив дохера кликов вустую, мы решим потом. Пока что я этот вариант исключил 
    //что касается очков, они храниться будут ... в файле
    public int max_points = 250; // это максимальное количество очков, которое юзер получит за min_level_click кликов. Для каждого левела он разный...наверное.
    //за каждый лишний клик мы будем отнимать какое то кол-во очков, и это будет делать переменная
    public int point_waste_click = 12;
    //я считаю, это оптимальная система, правда потом можно будет учитывать и время, за которое пользователь прошел левел

    /// <summary>
    /// Аналогия isAllTrue(...)
    /// </summary>
    bool flag;


    void Awake()
    {
        if (!Directory.Exists("Assets/Textfiles"))
        {
            Directory.CreateDirectory("Assets/Textfiles");
        }

        if (!File.Exists("Assets/Textfiles/levelscores.ini"))
        {
            Debug.Log("create file");
            File.Create("Assets/Textfiles/levelscores.ini");
        }

        if (!File.Exists("Assets/Textfiles/totalscore.ini")) //для всех уровней сумма очков
        {
            Debug.Log("create file");
            File.Create("Assets/Textfiles/totalscore.ini");
        }

    }

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
            
            //тут начинается код, связанный с очками
            int waste_click = click_count - min_level_click; //сколько лишних кликов
            int score = max_points - waste_click * point_waste_click;
            if (score < 0)
                score = 0;
            List<string> sc = new List<string>(File.ReadAllLines("Assets/Textfiles/levelscores.ini"));
            sc.Add(score.ToString());
            File.WriteAllLines("Assets/Textfiles/levelscores.ini", sc.ToArray());

            List<string> t_s = new List<string>(File.ReadAllLines("Assets/Textfiles/totalscore.ini"));
            int ss = score;
            if (t_s.Count != 0)
            {
                Debug.Log("ts != null");
                ss = int.Parse(t_s[0]);
                ss += score;
            }
      
            sc.Add(ss.ToString());
            File.WriteAllLines("Assets/Textfiles/totalscore.ini", sc.ToArray());

            //тут он заканчивается

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
