using UnityEngine;

public class Scenerio : MonoBehaviour{

  [SerializeField] private float speed;
  [SerializeField] private float min_x; 
  [SerializeField] private float translate_amount;  

  void Update(){
    float current_x = transform.position.x;
    float current_y = transform.position.y;

    transform.position = new Vector2(current_x - speed, current_y);
    if(current_x <= min_x) {
      transform.position = new Vector2(current_x + translate_amount, current_y);
    }
  }
}
