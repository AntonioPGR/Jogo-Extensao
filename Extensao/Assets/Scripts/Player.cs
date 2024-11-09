using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour{

  [SerializeField] private float move_up_multiplier;
  [SerializeField] private float move_down_multiplier;
  [SerializeField] private int move_times;
  [SerializeField] private float fall_speed;
  [SerializeField] private float max_height;
  [SerializeField] private float min_height;

  private bool moving_up;
  private int move_up_count;

  private bool moving_down;
  private int move_down_count;


  void Awake(){
    transform.position = new Vector2(transform.position.x, max_height);
  }

  void Update() {
    fall();
    if(moving_up) moveUp();
    if(moving_down) moveDown();
  }

  public void fall(int multiplier = 1) {
    if(transform.position.y <= min_height){
      SceneManager.LoadScene("GameOver");
      return;
    } 
    changeYPositionBy(-fall_speed);
  }

  public void moveDown() {
    if(moving_down == false) {
      moving_down = true;
      move_down_count = move_times;
    }
    if(move_down_count >= 0) {
      move_down_count--;
      changeYPositionBy((-fall_speed) * move_down_multiplier);
      if(move_down_count < 0) moving_down = false;
    }
  }

  public void moveUp() {
    if(moving_up == false) {
      moving_up = true;
      move_up_count = move_times;
    }
    if(move_up_count >= 0){
      move_up_count--;
      changeYPositionBy(fall_speed* move_up_multiplier);
      if(move_up_count < 0) moving_up = false;
    }
  }

  private void changeYPositionBy(float number) {
    float new_y = transform.position.y + number;
    transform.position = new Vector2(transform.position.x, new_y < max_height? new_y : max_height);
  }

}
