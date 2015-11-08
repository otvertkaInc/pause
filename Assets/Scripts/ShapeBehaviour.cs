using UnityEngine;

public class ShapeBehaviour : MonoBehaviour
{

    public float speed = 0.5f;

    public Vector3 direction;
    public string shape_name = "Shape";

    private bool isMoving = true;
    public bool isFinalPosition;
	
    /// Создает начальные условия
	void Start ()
    {
        direction = GameObject.Find(shape_name + "ChangeDirection1").GetComponent<DirChanger>().transform.position
                    - transform.position;
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
        isMoving = !isMoving;
    }
}
