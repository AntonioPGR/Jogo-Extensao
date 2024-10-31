using UnityEngine;

public class Player : MonoBehaviour{

  [SerializeField] private float speed;
  [SerializeField] private float max_height;
  [SerializeField] private float lifes;

  void Awake(){
    transform.position = new Vector2(transform.position.x, max_height);
  }

  public void moveDown() {
    float new_y = transform.position.y - speed;
    if(new_y >= max_height - (lifes * speed)){
      transform.position = new Vector2(transform.position.x, new_y);
    }
  }

  public void moveUp() {
    float new_y = transform.position.y + speed;
    if(new_y <= max_height){
      transform.position = new Vector2(transform.position.x, new_y);
    }
  }

}
