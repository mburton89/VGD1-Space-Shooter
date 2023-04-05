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

    public enum CharacterEnum
    {
        grace,
        jeffery
    }

    // TODO - May need to add colors to choose from depending on who is speaking for dialogue background. - KR

    private void Awake()
    {
        Instance = this;
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

    /* IEnumerator Method that closes the HUD when dialogueCloseWindow timer expires. - KR
    public IEnumerator CloseDialogue()
    {
        //return;
    }
    */ //TODO - Finish with a count to close the dialogue box. - KR
}