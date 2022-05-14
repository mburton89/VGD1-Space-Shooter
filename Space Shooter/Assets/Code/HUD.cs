using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public static HUD Instance;

    public Image playerHealthBarFill;
    public TextMeshProUGUI waveText;

    public GameObject planetHealthBarContainer;
    public Image planetHealthBarFill;

    private void Awake()
    {
        Instance = this;
    }

    public void DisplayPlayerHealth(int currentArmor, int maxArmor)
    {
        float healthAmount = (float)currentArmor / (float)maxArmor;
        playerHealthBarFill.fillAmount = healthAmount;
    }

    public void DisplayPlanetHealth(int currentArmor, int maxArmor, Color color)
    {
        planetHealthBarFill.color = color;
        planetHealthBarContainer.SetActive(true);
        float healthAmount = (float)currentArmor / (float)maxArmor;
        planetHealthBarFill.fillAmount = healthAmount;
    }

    public void HidePlanetHealth()
    {
        StartCoroutine(HidePlanetHealthCo());
    }

    private IEnumerator HidePlanetHealthCo()
    {
        yield return new WaitForSeconds(1);
        planetHealthBarContainer.SetActive(false);
    }

    public void DisplayWave(int currentWave)
    {
        waveText.SetText("Wave: " + currentWave);
    }
}
