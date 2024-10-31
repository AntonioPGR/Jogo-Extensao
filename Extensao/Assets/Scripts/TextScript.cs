using UnityEngine;
using UnityEngine.UI;
using TMPro;

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

  void Start(){
    changeQuestion();
  }
  void changeQuestion(){
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

  void randomNumbers(){
    int n1 = Random.Range(0, 20);
    int n2 = Random.Range(0, 20);
    greater = n1 > n2 ? n1 : n2;
    minor = n1 < n2 ? n1 : n2;
    op = Random.Range(0, 2);
  }

  void changeButtons() {
    int correct_bt = Random.Range(0, buttons.Length);
    for(int i = 0; i < buttons.Length; i++){
      if (i == correct_bt){
        SetButtonText(buttons[i], corret_answer.ToString());
        buttons[i].onClick.RemoveAllListeners();
        buttons[i].onClick.AddListener(() => { player.moveUp(); changeQuestion();});
      } else {
        int temp;
        do{
          temp = Random.Range(0, 20) + Random.Range(0, 20);
        } while (temp == corret_answer);
        SetButtonText(buttons[i], temp.ToString());
        buttons[i].onClick.RemoveAllListeners();
        buttons[i].onClick.AddListener(() => { player.moveDown(); changeQuestion();});
      }
    }
  }

  void SetButtonText(Button button, string text){
    TMP_Text buttonText = button.GetComponentInChildren<TMP_Text>();
    if (buttonText != null){
      buttonText.text = text;
    }
  }

}
