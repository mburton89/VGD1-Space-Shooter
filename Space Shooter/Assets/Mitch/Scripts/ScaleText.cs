using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScaleText : MonoBehaviour
{
    public float minScale = 0.0f;
    public float maxScale = 1.0f;
    public float scaleSpeed = 0.1f;

    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.rectTransform.localScale = Vector3.zero;
    }

    private void Update()
    {
        float currentScale = text.rectTransform.localScale.x;
        if (currentScale < maxScale)
        {
            currentScale += scaleSpeed * Time.deltaTime;
            currentScale = Mathf.Clamp(currentScale, minScale, maxScale);
            text.rectTransform.localScale = new Vector3(currentScale, currentScale, currentScale);
        }
    }
}