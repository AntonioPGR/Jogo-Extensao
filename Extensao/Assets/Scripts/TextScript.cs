using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TextScript : MonoBehaviour{

  public TMP_Text question_text;
  public Button button1;
  public Button button2;
  public Button button3;
  public Button button4;

  void Start(){
    changeText();
    button1.onClick.AddListener(changeText);
    button2.onClick.AddListener(changeText);
    button3.onClick.AddListener(changeText);
    button4.onClick.AddListener(changeText);
  }

  void Update() {
  }

  void changeText(){
    int n1 = Random.Range(0, 20);
    int n2 = Random.Range(0, 20);
    int op = Random.Range(0, 2);
    if(op == 0) question_text.text = n1 + " + " + n2 + " = ?"; 
    else question_text.text = n1 + " - " + n2 + " = ?";
    SetButtonText(button1, "Option 1");
    SetButtonText(button2, "Option 2");
    SetButtonText(button3, "Option 3");
    SetButtonText(button4, "Option 4");
  }

  void SetButtonText(Button button, string text){
    TMP_Text buttonText = button.GetComponentInChildren<TMP_Text>();
    if (buttonText != null){
      buttonText.text = text;
    }
  }

}
