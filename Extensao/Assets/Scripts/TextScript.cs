using UnityEngine;
using UnityEngine.UI;
using TMPro;

public enum MoveOptions {
  UP,
  DOWN
}

public class TextScript : MonoBehaviour{

  public TMP_Text question_text;
  public Button[] buttons;
  public Player player;
  public int max_value;
  public int min_value;

  private int greater;
  private int minor;
  private int op;
  private int corret_answer;

  void Awake(){
    changeQuestion();
  }

  private void changeQuestion(){
    randomNumbers();
    switch (op){
      case 0: 
        question_text.text = greater + " + " + minor + " = ?";
        corret_answer = greater + minor;
        break;
      case 1: 
        question_text.text = greater + " - " + minor + " = ?";
        corret_answer = greater - minor;
        break;
    }
    changeButtons();
  }

  private void randomNumbers(){
    int n1 = Random.Range(0, 20);
    int n2 = Random.Range(0, 20);
    greater = n1 > n2 ? n1 : n2;
    minor = n1 < n2 ? n1 : n2;
    op = Random.Range(0, 2);
  }

  private void changeButtons() {
    int correct_bt = Random.Range(0, buttons.Length);
    for(int i = 0; i < buttons.Length; i++){
      buttons[i].onClick.RemoveAllListeners();
      if (i == correct_bt){
        SetButtonText(buttons[i], corret_answer.ToString());
        buttons[i].onClick.AddListener(() => movePlayer(MoveOptions.UP));
      } else {
        SetButtonText(buttons[i], getRandomOption().ToString());
        buttons[i].onClick.AddListener(() => movePlayer(MoveOptions.DOWN));
      }
    }
  }

  private int getRandomOption() {
    int increment = Random.Range(1, 6);
    int operation = Random.Range(0, 2);
    return operation == 0 ? corret_answer + increment : corret_answer - increment;
  }

  private void movePlayer(MoveOptions move){
    switch(move) {
      case MoveOptions.UP: player.moveUp();
        break;
      case MoveOptions.DOWN: player.moveDown(); 
        break;
    }
    changeQuestion();
  }

  private void SetButtonText(Button button, string text){
    TMP_Text buttonText = button.GetComponentInChildren<TMP_Text>();
    if (buttonText != null){
      buttonText.text = text;
    }
  }

}
