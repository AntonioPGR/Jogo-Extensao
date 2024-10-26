using UnityEngine;

public class movement : MonoBehaviour{

  [SerializeField] private float speed;
  [SerializeField] private float max_height;
  [SerializeField] private float lifes;

  void Awake(){
    transform.position = new Vector2(transform.position.x, max_height);
  }

  void Update(){
    moveElement();
  }

  void moveElement() {
    float new_y = transform.position.y;
    if (Input.GetKeyDown(KeyCode.DownArrow) && (new_y - speed) >= (max_height - lifes*speed)) new_y -= speed;
    if (Input.GetKeyDown(KeyCode.UpArrow) && (new_y + speed) <= max_height) new_y += speed;
    transform.position = new Vector2(transform.position.x, new_y);
  }
}
