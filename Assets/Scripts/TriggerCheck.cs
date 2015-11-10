using UnityEngine;

public class TriggerCheck : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// Срабатывает при входе объекта в триггер
    void OnTriggerEnter2D(Collider2D col)
    {
        ShapeBehaviour shape = GetComponentInParent<ShapeBehaviour>();
        if (col.name.StartsWith(shape.shape_name + "ChangeDirection"))
        {
            shape.direction = col.GetComponent<DirChanger>().new_direction - transform.position;
        }

        if (col.name.StartsWith(shape.shape_name + "RightPosition"))
        {
            shape.isFinalPosition = true;
        }
    }

    /// Срабатывает при выходе объекта в триггер
    void OnTriggerExit2D(Collider2D col)
    {
        ShapeBehaviour shape = GetComponentInParent<ShapeBehaviour>();
        if (col.name.StartsWith(shape.shape_name + "RightPosition"))
        {
            shape.isFinalPosition = false;
        }
    }
}
