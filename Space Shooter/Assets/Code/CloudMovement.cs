using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CloudMovement : MonoBehaviour
{
    public float secondsBetweenShift;
    public float minOpacity;
    public float maxOpacity;
    SpriteRenderer spriteRenderer;

    Vector3 initialPosition;
    public float randomness;
    float randX;
    float randY;
    
    // Start is called before the first frame update
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        initialPosition = transform.localPosition;
        StartCoroutine(Shiftco());

    }

    private IEnumerator Shiftco ()
    {
        randX = Random.Range(-randomness, randomness);
        randY = Random.Range(-randomness, randomness);

        spriteRenderer.DOFade(minOpacity, secondsBetweenShift).SetEase(Ease.InOutQuad);
        transform.DOLocalMove(new Vector3(initialPosition.x + randX, initialPosition.y + randY, initialPosition.z), secondsBetweenShift).SetEase(Ease.InOutQuad);
            yield return new WaitForSeconds(secondsBetweenShift);

        spriteRenderer.DOFade(maxOpacity, secondsBetweenShift).SetEase(Ease.InOutQuad);
        transform.DOLocalMove(initialPosition, secondsBetweenShift).SetEase(Ease.InOutQuad);
        yield return new WaitForSeconds(secondsBetweenShift);

        StartCoroutine(Shiftco());
    }

}
