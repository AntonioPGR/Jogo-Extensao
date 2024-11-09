using UnityEngine;

public class Cloud : MonoBehaviour{

  [SerializeField] private int spawn_x;
  [SerializeField] private int despawn_x;
  [SerializeField] private int min_y;
  [SerializeField] private int max_y;
  [SerializeField] private float speed;

  void Awake(){
    changePosition();
  }

  void Update(){
    if(transform.position.x <= despawn_x) changePosition();
    else walk();
  }
  private int getRandomY() {
    return Random.Range(min_y, max_y);
  }

  private void changePosition() {
    transform.position = new Vector2(spawn_x, getRandomY());
  }

  private void walk() {
    transform.position = new Vector2(transform.position.x - speed, transform.position.y);
  }

}
