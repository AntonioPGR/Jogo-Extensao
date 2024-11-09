using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public enum MoveOptions {
  UP,
  DOWN
}

public class TextScript : MonoBehaviour{

  [SerializeField] private TMP_Text question_text;
  [SerializeField] private TMP_Text points_text;
  [SerializeField] private Button[] buttons;
  [SerializeField] private Player player;
  [SerializeField] private int max_value;
  [SerializeField] private int min_value;

  private int greater;
  private int minor;
  private int op;
  private int corret_answer;
  private List<int> buttons_value_list = new List<int>();
  private int points;

  void Awake(){
    points = 0;
    points_text.text = points.ToString();
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
    int n1 = Random.Range(min_value, max_value);
    int n2 = Random.Range(min_value, max_value);
    greater = n1 > n2 ? n1 : n2;
    minor = n1 < n2 ? n1 : n2;
    op = Random.Range(0, 2);
  }

  private void changeButtons() {
    buttons_value_list.Clear();
    buttons_value_list.Add(corret_answer);
    int correct_bt = Random.Range(0, buttons.Length);
    for(int i = 0; i < buttons.Length; i++){
      buttons[i].onClick.RemoveAllListeners();
      if (i == correct_bt){
        SetButtonText(buttons[i], corret_answer.ToString());
        buttons[i].onClick.AddListener(() => {answeredRight();});
        continue;
      }
      string v = getRandomOption().ToString();
      SetButtonText(buttons[i], v);
      buttons[i].onClick.AddListener(answeredWrong);
    }
  }

  private void answeredRight() {
    increasePoints(); 
    changeQuestion();
    movePlayer(MoveOptions.UP);
  }

  private void answeredWrong() {
    movePlayer(MoveOptions.DOWN);
  }

  private int getRandomOption() {
    int result;
    do {
      int increment = Random.Range(1, 6);
      int operation = Random.Range(0, 2);
      if(operation == 1) result = corret_answer + increment;
      else result = corret_answer - increment;
      if(result < 0) result *= -1;
    } while(buttons_value_list.Contains(result));
    buttons_value_list.Add(result);
    return result;
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

  private void increasePoints() {
    points++;
    points_text.text = points.ToString();
    if(points >= 15) {
      SceneManager.LoadScene("Win");
    }
  }

}
