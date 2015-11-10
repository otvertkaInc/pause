using UnityEngine;
using System.Collections.Generic;

public class ShapeBehaviour : MonoBehaviour
{
    public float speed = 0.5f;

    public Vector3 direction;
    public string shape_name = "Shape";

    public bool isMoving = true;
    public bool isFinalPosition;

    /// Создает начальные условия
    void Start ()
    {
        direction = GameObject.Find(shape_name + "ChangeDirection1").GetComponent<DirChanger>().transform.position - transform.position;

        isFinalPosition = false;
    }

    /// Обновляется несколько раз за кадр
    void FixedUpdate () {
        if(isMoving)
            transform.Translate(direction * Time.deltaTime * speed);
	}

    /// Срабатывает, когда на объект кликают мышкой
    void OnMouseDown()
    {
        TestLevel_Manager ts = GameObject.FindObjectOfType<TestLevel_Manager>();
        if (ts.need_mov)
            isMoving = !isMoving;
    }
}