using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Spin : MonoBehaviour
{
    public float spinSpeed = 100f;

    private Vector2 canvasSize;

    private void Start()
    {
        canvasSize = transform.parent.GetComponent<RectTransform>().sizeDelta;
    }

    private void Update()
    {
        transform.Rotate(Vector3.forward, spinSpeed * Time.deltaTime);

        // Clamp the position of the Image GameObject within the canvas bounds
        Vector2 pos = (Vector2)transform.localPosition + canvasSize / 2f;
        pos.x = Mathf.Clamp(pos.x, 0f, canvasSize.x);
        pos.y = Mathf.Clamp(pos.y, 0f, canvasSize.y);
        transform.localPosition = pos - canvasSize / 2f;
    }
}
