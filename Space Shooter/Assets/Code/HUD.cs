using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class HUD : MonoBehaviour
{
    public static HUD Instance;

    public Image playerHealthBarFill;
    public TextMeshProUGUI waveText;

    // Image for the character speaking (potentially animated between a few images). - KR
    public Image speakingCharacterPortrait;
    public Image dialogueBackgroundImage;

    // Text boxs where a name, and the character's dialogue will go. - KR
    public TextMeshProUGUI speakingCharacterName;
    public TextMeshProUGUI dialogueText;

    /* Variables for a timer to measure dialogue speaking length (potentially can be used to implent char typing for
       dialogue). - KR */
    public float dialogueSpeakingTimer;
    public float dialogueCloseTimer;

    public List<Sprite> portraits;

    public GameObject jeebus;
    public GameObject weenorz;

    // Lists for selecting random dialogue options for different pilot types at the start of a wave.
    public List<string> pirateDialogueList;
    public List<string> hiveDialogueList;
    public List<string> defenderDialogueList;

    public enum CharacterEnum
    {
        grace,
        pirateMuscleMan,
        vic,
        parrotPirate,
        captainPerry,
        flowerPeople,
        queenBee,
        francois,
        police,
        admiralHwhat,
        jimothy,
        platta,
        queen,
        laboulangerie,
        hwhat,
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
        //WaveStartDialouge(1);
    }

    // Update has been added to use a timer to determine if a character is speaking. - KR
    public void Update()
    {
        // Checks the Speaking Timer. Counts down timer for delay to close the dialogue window. - KR
        if (dialogueSpeakingTimer > 0)
        {
            dialogueSpeakingTimer -= Time.deltaTime;
        }
        else if (dialogueSpeakingTimer <= 0 && dialogueCloseTimer < 0)
        {
            dialogueCloseTimer = 5;
        }

        // Checks the Closing Timer. Counts down timer for delay to close the dialogue window. - KR
        if (dialogueCloseTimer > 0)
        {
            dialogueCloseTimer -= Time.deltaTime;
        }
        else if (dialogueCloseTimer <= 0)
        {
            //StartCoroutine(CloseDialogue); TODO - Need to decide on how to write CloseDialogue Method. - KR
        }
    }

    public void DisplayPlayerHealth(int currentArmor, int maxArmor)
    {
        float healthAmount = (float)currentArmor / (float)maxArmor;
        playerHealthBarFill.fillAmount = healthAmount;
    }

    public void DisplayWave(int currentWave)
    {
        waveText.SetText("Wave: " + currentWave);
        //WaveStartDialouge(currentWave);
    }

    // Should cause a dialogue box with a pilot speaking or taunting the player at the start of a new enemy wave. - KR
    public void WaveStartDialouge(int currentWave)
    {
        /* Currently in the game waves 1-4 and 6-9 should have pirates, wave 5 is Vic Locus, wave 10 is Plata Perry, waves 11-14 have hive drones,
           wave 15 is Queen Bee, waves 16-19 have ESDF pilots, wave 20 is Admiral Hwhat, and the final wave at 21, is Jimothy. - KR*/
        if(currentWave <= 4 || currentWave >= 6 && currentWave <= 9)
        {
            // A variable to store the random number from the randomizer method. - KR
            int speakingPilot = Randomizer(0, 1);

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
            string dialogueChosen = pirateDialogueList[Randomizer(0, pirateDialogueList.Count)];
            dialogueText.SetText(dialogueChosen);
        }
        else if (currentWave == 5)
        {
            speakingCharacterPortrait.sprite = portraits[(int)CharacterEnum.vic];
            speakingCharacterName.SetText("Vic Lokus");
            dialogueText.SetText("S*** is goin' down!");// TODO: Get actual dialogue. -KR
        }
        else if (currentWave == 10)
        {
            speakingCharacterPortrait.sprite = portraits[(int)CharacterEnum.platta];
            speakingCharacterName.SetText("Platta Perry");
            dialogueText.SetText("Hand over the goods, and only you get hurt!"); // TODO: Get actual dialogue. - KR
        }
        else if(currentWave >= 11 && currentWave <= 14)
        {
            // A variable to store the random number from the randomizer method. - KR
            int speakingPilot = Randomizer(0, 1);

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
            string dialogueChosen = hiveDialogueList[Randomizer(0, hiveDialogueList.Count)];
            dialogueText.SetText(dialogueChosen);
        }
        else if (currentWave == 15)
        {
            speakingCharacterPortrait.sprite = portraits[(int)CharacterEnum.queen];
            speakingCharacterName.SetText("The Queen Bee");
            dialogueText.SetText("You should hive minded your own beeswax!"); // TODO: Get actual dialogue. -KR
        }
        else if (currentWave == 16)
        {
            speakingCharacterPortrait.sprite = portraits[(int)CharacterEnum.laboulangerie];
            speakingCharacterName.SetText("La Boulangerie");
            dialogueText.SetText("Hon! Hon! Hon!!"); // TODO: Get actual dialogue. -KR
        }
        else if (currentWave >= 17 && currentWave <= 19)
        {
            // A variable to store the random number from the randomizer method. - KR
            int speakingPilot = Randomizer(0, 1);

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
            string dialogueChosen = defenderDialogueList[Randomizer(0, defenderDialogueList.Count)];
            dialogueText.SetText(dialogueChosen);
        }
        else if (currentWave == 20)
        {
            speakingCharacterPortrait.sprite = portraits[(int)CharacterEnum.hwhat];
            speakingCharacterName.SetText("Admiral Hwhat");
            dialogueText.SetText("Hwhat, you say?!"); // TODO: Get actual dialogue. -KR
        }
        else if (currentWave == 21)
        {
            speakingCharacterPortrait.sprite = portraits[(int)CharacterEnum.jimothy];
            speakingCharacterName.SetText("Jimothy Jamboree");
            dialogueText.SetText("HERE'S JIMMY!!!"); // TODO: Get actual dialogue. - KR
        }
    }

    // Method that updates the HUD with a character image, character name label, and character dialogue. - KR
    public void DisplayDialogue(CharacterEnum speakingCharacter, string speakingCharacterNameDisplay, string spokenDialogue, float speakingTime)
    {
        dialogueSpeakingTimer = speakingTime;


        //dialogueBackgroundImage.sprite = ; TODO - Potential to change dialogue box depending on who is speaking. - KR
        speakingCharacterPortrait.sprite = portraits[(int)speakingCharacter];
        speakingCharacterName.SetText(speakingCharacterNameDisplay);
        dialogueText.SetText(spokenDialogue);
    }

    // Method used to randomize a number between the two int variables passed into the argument.
    private int Randomizer(int minNumber, int maxNumber)
    {
        int randomNumber = Random.Range(minNumber, maxNumber);
        return randomNumber;
    }

    /* IEnumerator Method that closes the HUD when dialogueCloseWindow timer expires. - KR
    public IEnumerator CloseDialogue()
    {
        //return;
    }
    */ //TODO - Finish with a count to close the dialogue box. - KR


    public void Restart()
    {
        StartCoroutine(RestartCo());
    }

    private IEnumerator RestartCo()
    {
        yield return new WaitForSeconds(2);
        jeebus.SetActive(true);
        yield return new WaitForSeconds(.01f);
        SceneManager.LoadScene(1);
    }

    public void HandleWin()
    {
        StartCoroutine(HandleWinCo());
    }

    private IEnumerator HandleWinCo()
    {
        yield return new WaitForSeconds(2);
        weenorz.SetActive(true);
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }
}