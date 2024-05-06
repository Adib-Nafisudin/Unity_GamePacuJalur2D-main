using UnityEngine;
using UnityEngine.UI;

public class UI_Manager : MonoBehaviour
{
    [SerializeField] MovementUser movementUser;
    [SerializeField] Button boostButton;
    private void Awake() {
        // movementUser = FindObjectOfType<MovementUser>();
        // foreach (Button btn in FindObjectsOfType<Button>())
        // {
        //     btn.onClick.AddListener(() => AudioManager.instance.Play("Button"));
        // }
    }
    private void Update() {
        if (movementUser != null) {
            boostButton.interactable = movementUser.IsBoostAvaliable;
        }
    }
    public void GoHome()
    {
        GameManager.instance.HomeScene();
    }
    public void Pause()
    {
        GameManager.instance.Pause();
    }
    public void Unpause()
    {
        GameManager.instance.Unpause();
    }
    public void Restart()
    {
        GameManager.instance.Restart();
    }
    public void LoadNext()
    {
        GameManager.instance.LoadNext();
    }
    public void TriggerBoost()
    {
        movementUser.TriggerBoost();
    }
    public void RightDown()
    {
        PlayerInput.inputRightDown();
    }
    public void RightUp()
    {
        PlayerInput.inputRightUp();
    }
    public void LeftDown()
    {
        PlayerInput.inputLeftDown();
    }
    public void LeftUp()
    {
        PlayerInput.inputLeftUp();
    }
    public void ButtonClickFX()
    {
        if (AudioManager.instance != null) AudioManager.instance.Play("Button");
    }
    public void ButtonClickFX_2()
    {
        if (AudioManager.instance != null) AudioManager.instance.Play("Button Pedal");
    }

}
