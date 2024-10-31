using UnityEngine;

public class Player : MonoBehaviour{

  public float speed;
  public float max_height;
  public float lifes;

  private float min_height;

  void Awake(){
    transform.position = new Vector2(transform.position.x, max_height);
    min_height = max_height - (lifes * speed);
  }

  public void moveDown() {
    if(transform.position.y > min_height){
      changeYPositionBy(-speed);
    }
  }

  public void moveUp() {
    if(transform.position.y < max_height) {
      changeYPositionBy(speed);
    }
  }

  private void changeYPositionBy(float number) {
    transform.position = new Vector2(transform.position.x, transform.position.y + number);
  }

}
