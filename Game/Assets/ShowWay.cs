using UnityEngine;
using UnityEngine.UI;

public class ShowWay : MonoBehaviour
{
    public GameObject item;
    public GameObject dialogBox;
    public TMPro.TextMeshProUGUI dialogText;
 
    public PlayerController playerController; // —сылка на скрипт управлени€ персонажем

    private void Start()
    {
        dialogBox.SetActive(false);
  
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Cursor.lockState = CursorLockMode.Confined;
            Cursor.visible = true;
            OpenDialog("Tuch the rock");
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

    }


    private void CloseDialog()
    {
        dialogBox.SetActive(false);

    }


}
