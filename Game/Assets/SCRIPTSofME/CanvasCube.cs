using UnityEngine;
using UnityEngine.UI;

public class DialogManager : MonoBehaviour
{
    public GameObject item;
    public GameObject dialogBox;
    public TMPro.TextMeshProUGUI dialogText;
    public Button buttonYes;
    public Button buttonNo;
    public PlayerController playerController; // Ссылка на скрипт управления персонажем

    private void Start()
    {
        dialogBox.SetActive(false);
        SetButtonVisibility(buttonYes, false);
        SetButtonVisibility(buttonNo, false);

        buttonYes.onClick.AddListener(OnYesButton);
        buttonNo.onClick.AddListener(OnNoButton);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            OpenDialog("DO YOU WANT TO INCREASE SPEED?");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            CloseDialog();
        }
    }

    public void OpenDialog(string text)
    {
        dialogBox.SetActive(true);
        dialogText.text = text;
        SetButtonVisibility(buttonYes, true);
        SetButtonVisibility(buttonNo, true);
    }

    public void OnYesButton()
    {
        Cursor.visible = false;
        Debug.Log("Button 'Yes' pressed");
        IncreasePlayerSpeed();
        CloseDialog();

    }

    public void OnNoButton()
    {
        Cursor.visible = false;
        Debug.Log("You chose 'No'");
        CloseDialog();
        // item.SetActive(false);
    }

    private void IncreasePlayerSpeed()
    {
        if (playerController != null)
        {
            playerController.runSpeed += 0.5f; // Увеличиваем скорость на 1
            item.transform.position = new Vector3(0, -100, 0);
        }

    }

    private void CloseDialog()
    {
        dialogBox.SetActive(false);
        SetButtonVisibility(buttonYes, false);
        SetButtonVisibility(buttonNo, false);
    }

    private void SetButtonVisibility(Button button, bool visible)
    {
        button.gameObject.SetActive(visible);

    }
}
