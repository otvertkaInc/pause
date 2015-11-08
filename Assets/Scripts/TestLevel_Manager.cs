using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TestLevel_Manager : MonoBehaviour
{
    void OnGUI()
    {
        //List<ShapeBehaviour> shapes = new List<ShapeBehaviour>(FindObjectsOfType<ShapeBehaviour>());
        
        //if(isAllTrue(shapes))
            GUI.Label(new Rect(10, 10, 100, 20), "You win!");
    }

    /// Проверяет все ли фигуры на своих финальных позициях
    bool isAllTrue(List<ShapeBehaviour> shapes)
    {
        bool res = true;
        int i = 0;
        while(res & (i < shapes.Count))
        {
            res &= shapes[i].isFinalPosition;
        }

        return res;
    }
}
