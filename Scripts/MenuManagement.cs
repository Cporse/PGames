using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManagement : MonoBehaviour
{
    public static MenuManagement Instance;

    [SerializeField] private Text textTapToStart;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void functionStartButton()
    {
        Debug.Log("Oyun sahnesi yüklendi\nBaþarýlar :))");
        Time.timeScale = 0;
        SceneManager.LoadScene(1);
    }
    public void functionExitButton()
    {
        Debug.Log("Oyundan çýkýþ yapýldý.");
        Application.Quit();
    }
    public void functionContinueGame()
    {
        Time.timeScale = 1;
        textTapToStart.gameObject.SetActive(false);
        AnimatorScript.Instance.animator.SetInteger("isRunning", 1);
        MovementCharacter.Instance.GetComponent<Rigidbody>().isKinematic = false;
    }
}