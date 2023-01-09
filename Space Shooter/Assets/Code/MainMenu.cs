using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class MainMenu : MonoBehaviour
{
    public TextMeshProUGUI highestWaveText;
    public Button startButton;

    void Start()
    {
        int highestWave = PlayerPrefs.GetInt("highestWave");
        highestWaveText.SetText("Highest Wave: " + highestWave);
        startButton.onClick.AddListener(HandlePlayClicked);
    }

    void HandlePlayClicked()
    {
        SceneManager.LoadScene(1);
    }
}
