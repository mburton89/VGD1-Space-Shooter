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

    // Gameobject variable to store Dialoguebox gameobject to toggle activity.
    public GameObject canvasDialoguebox;

    // Image for the character speaking (potentially animated between a few images). - KR
    public Image speakingCharacterPortrait;
    public Image dialogueBackgroundImage;

    // Text boxs where a name, and the character's dialogue will go. - KR
    public TextMeshProUGUI speakingCharacterName;
    public TextMeshProUGUI dialogueText;

    public List<Sprite> portraits;

    public AudioSource dialogueSound;

    // Lists for selecting random dialogue options for different pilot types at the start of a wave.
    public List<string> pirateDialogueList;
    public List<string> hiveDialogueList;
    public List<string> defenderDialogueList;

    public string vicDialogue = "S*** is goin' down!";
    public string plattaDialogue = "Hand over the goods, and only you get hurt!";
    public string queenDialogue = "You should hive minded your own beeswax!";
    public string laboulangerieDialogue = "Hon! Hon! Hon!!";
    public string hwhatDialogue = "Hwhat, you say?!";
    public string jimothyDialogue = "HERE'S JIMMY!!!";

    public enum CharacterEnum
    {
        grace,
        vic,
        platta,
        queen,
        laboulangerie,
        hwhat,
        jimothy,
        pirate1,
        pirate2,
        drone1,
        drone2,
        pilot1,
        pilot2
    }

    // TODO - May need to add colors to choose from depending on who is speaking for dialogue background. - KR

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        WaveStartDialouge(1);
    }

    public void DisplayPlayerHealth(int currentArmor, int maxArmor)
    {
        float healthAmount = (float)currentArmor / (float)maxArmor;
        playerHealthBarFill.fillAmount = healthAmount;
    }

    public void DisplayWave(int currentWave)
    {
        waveText.SetText("Wave: " + currentWave);
        WaveStartDialouge(currentWave);
    }

    // Should cause a dialogue box with a pilot speaking or taunting the player at the start of a new enemy wave. - KR
    public void WaveStartDialouge(int currentWave)
    {
        canvasDialoguebox.SetActive(true);

        /* Currently in the game waves 1-4 and 6-9 should have pirates, wave 5 is Vic Locus, wave 10 is Plata Perry, waves 11-14 have hive drones,
           wave 15 is Queen Bee, waves 16-19 have ESDF pilots, wave 20 is Admiral Hwhat, and the final wave at 21, is Jimothy. - KR*/
        if (currentWave <= 4 || currentWave >= 6 && currentWave <= 9)
        {
            // A variable to store the random number from the randomizer method. - KR
            int speakingPilot = IntRandomizer(0, 1);

            // Conditional statement that checks the random number and assigns a pilot to the portrait. - KR
            if (speakingPilot <= 0)
            {
                speakingCharacterPortrait.sprite = portraits[(int)CharacterEnum.pirate1];
            }
            else if (speakingPilot > 0)
            {
                speakingCharacterPortrait.sprite = portraits[(int)CharacterEnum.pirate2];
            }
            else
            {
                Debug.Log("Something messed up horribly with the randomizer!");
            }

            speakingCharacterName.SetText("Space Pirate");

            // Randomize the sentence chosen to be displayed at the start, then set the text.
            string dialogueChosen = pirateDialogueList[IntRandomizer(0, pirateDialogueList.Count)];
            StartCoroutine(TypeChars(dialogueChosen,0.9f,1.1f));
        }
        else if (currentWave == 5)
        {
            speakingCharacterPortrait.sprite = portraits[(int)CharacterEnum.vic];
            speakingCharacterName.SetText("Vic Lokus");
            StartCoroutine(TypeChars(vicDialogue,0.4f,0.55f));
        }
        else if (currentWave == 10)
        {
            speakingCharacterPortrait.sprite = portraits[(int)CharacterEnum.platta];
            speakingCharacterName.SetText("Platta Perry");
            StartCoroutine(TypeChars(plattaDialogue,0.55f,.65f));
        }
        else if(currentWave >= 11 && currentWave <= 14)
        {
            // A variable to store the random number from the randomizer method. - KR
            int speakingPilot = IntRandomizer(0, 1);

            // Conditional statement that checks the random number and assigns a pilot to the portrait. - KR
            if (speakingPilot <= 0)
            {
                speakingCharacterPortrait.sprite = portraits[(int)CharacterEnum.drone1];
            }
            else if (speakingPilot > 0)
            {
                speakingCharacterPortrait.sprite = portraits[(int)CharacterEnum.drone2];
            }
            else
            {
                Debug.Log("Something messed up horribly with the randomizer!");
            }

            speakingCharacterName.SetText("Hive Drone");

            // Randomize the sentence chosen to be displayed at the start, then set the text.
            string dialogueChosen = hiveDialogueList[IntRandomizer(0, hiveDialogueList.Count)];
            StartCoroutine(TypeChars(dialogueChosen,1.4f,1.6f));
        }
        else if (currentWave == 15)
        {
            speakingCharacterPortrait.sprite = portraits[(int)CharacterEnum.queen];
            speakingCharacterName.SetText("The Queen Bee");
            StartCoroutine(TypeChars(queenDialogue,1.2f,1.4f));
        }
        else if (currentWave == 16)
        {
            speakingCharacterPortrait.sprite = portraits[(int)CharacterEnum.laboulangerie];
            speakingCharacterName.SetText("La Boulangerie");
            StartCoroutine(TypeChars(laboulangerieDialogue,.2f,.4f));
        }
        else if (currentWave >= 17 && currentWave <= 19)
        {
            // A variable to store the random number from the randomizer method. - KR
            int speakingPilot = IntRandomizer(0, 1);

            // Conditional statement that checks the random number and assigns a pilot to the portrait. - KR
            if (speakingPilot <= 0)
            {
                speakingCharacterPortrait.sprite = portraits[(int)CharacterEnum.pilot1];
            }
            else if (speakingPilot > 0)
            {
                speakingCharacterPortrait.sprite = portraits[(int)CharacterEnum.pilot2];
            }
            else
            {
                Debug.Log("Something messed up horribly with the randomizer!");
            }

            speakingCharacterName.SetText("ESDF Pilot");

            // Randomize the sentence chosen to be displayed at the start, then set the text.
            string dialogueChosen = defenderDialogueList[IntRandomizer(0, defenderDialogueList.Count)];
            StartCoroutine(TypeChars(dialogueChosen,0.65f,0.8f)); ;
        }
        else if (currentWave == 20)
        {
            speakingCharacterPortrait.sprite = portraits[(int)CharacterEnum.hwhat];
            speakingCharacterName.SetText("Admiral Hwhat");
            StartCoroutine(TypeChars(hwhatDialogue,.5f,.7f));
        }
        else if (currentWave == 21)
        {
            speakingCharacterPortrait.sprite = portraits[(int)CharacterEnum.jimothy];
            speakingCharacterName.SetText("Jimothy Jamboree");
            StartCoroutine(TypeChars(jimothyDialogue,.85f,1.15f));
        }
    }

    IEnumerator TypeChars(string dialogue, float minPitch, float maxPitch)
    {
        for(int i =0; i < dialogue.Length; i++)
        {
            dialogueSound.pitch = FloatRandomizer(minPitch, maxPitch);
            dialogueSound.Play();
            dialogueText.SetText(dialogue.Substring(0, i));
            yield return new WaitForSeconds(0.1f);
        }
        StartCoroutine(CloseDialogue());
    }

    // Method used to randomize a number between the two int variables passed into the argument.
    private int IntRandomizer(int minNumber, int maxNumber)
    {
        int randomInteger = Random.Range(minNumber, maxNumber);
        return randomInteger;
    }

    private float FloatRandomizer(float minPitch, float maxPitch)
    {
        float randomFloat = Random.Range(minPitch, maxPitch);
        return randomFloat;
    }

    //IEnumerator Method that closes the HUD when dialogueCloseWindow timer expires. - KR
    public IEnumerator CloseDialogue()
    {
        yield return new WaitForSeconds(3);
        canvasDialoguebox.SetActive(false);
    }
}