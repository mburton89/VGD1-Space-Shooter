using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashWhite : MonoBehaviour
{
    [SerializeField] SpriteRenderer spriteRenderer;
    Material initialMaterial;
    [SerializeField] Material whiteMaterial;

    void Awake()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
        initialMaterial = spriteRenderer.material;
    }

    public void Flash()
    {
        StartCoroutine(FlashCo());
    }

    private IEnumerator FlashCo()
    {
        spriteRenderer.material = whiteMaterial;
        yield return new WaitForSeconds(.01f);
        spriteRenderer.material = initialMaterial;
    }
}
