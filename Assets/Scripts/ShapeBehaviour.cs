using UnityEngine;

public class ShapeBehaviour : MonoBehaviour
{

    public float speed = 0.5f;

    public Vector3 direction;
    public string shape_name = "Shape";

    private bool isMoving = true;
	
    /// Создает начальные условия
	void Start ()
    {
        direction = GameObject.Find(shape_name + "ChangeDirection1").GetComponent<DirChanger>().transform.position
                    - transform.position;
    }
	
    /// Обновляется несколько раз за кадр
	void FixedUpdate () {
        if(isMoving)
            transform.Translate(direction * Time.deltaTime * speed);
	}

    /// Срабатывает при входе объекта в триггер
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == shape_name + "ChangeDirection")
        {
            direction = col.GetComponent<DirChanger>().new_direction - transform.position;
        }
    }

    // Срабатывает, когда на объект кликают мышкой
    void OnMouseDown()
    {
        isMoving = !isMoving;
    }
}
