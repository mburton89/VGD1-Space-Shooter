using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleShield : MonoBehaviour
{
    public GameObject deflectLetterPrefab;
    public GameObject spaceRageLetterPrefab;
    public float secondsBetweenLetters;
    // Start is called before the first frame update
    public void Init(string sentence, bool isGoodGuy)
    {
        StartCoroutine(SpawnSentenceCircleCo(sentence, isGoodGuy));
    }

    private IEnumerator SpawnSentenceCircleCo(string sentence, bool isGoodGuy)
    {
        string newSentence = sentence;
        print(transform.rotation.z);
        if (transform.rotation.z < 0)
        {
            char[] stringArray = newSentence.ToCharArray();
            //Array.Reverse(stringArray);
            newSentence = new string(stringArray);
        }

        foreach (char character in newSentence)
        {
            GameObject circleLetter;

            if (isGoodGuy)
            {
                circleLetter = Instantiate(deflectLetterPrefab, transform.position, transform.rotation, transform);
            }
            else
            {
                circleLetter = Instantiate(spaceRageLetterPrefab, transform.position, transform.rotation, transform);
            }

            circleLetter.GetComponent<CircleLetter>().letter.SetText(character.ToString());
            circleLetter.transform.eulerAngles = Vector3.zero;
            yield return new WaitForSeconds(secondsBetweenLetters);
        }
    }
}
