using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FuckingDanceScript : MonoBehaviour
{
    public float secondsToMoveLeft;
    public float secondsToMoveRight;
    public float secondsToStayStill;
    public float tiltAngle;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DanceCo());
    }

    private IEnumerator DanceCo()
    {
        transform.DOLocalRotate(new Vector3(0, 0, tiltAngle), secondsToMoveLeft, RotateMode.Fast);
        yield return new WaitForSeconds(secondsToMoveLeft);

        yield return new WaitForSeconds(secondsToStayStill);

        transform.DOLocalRotate(new Vector3(0, 0, -tiltAngle), secondsToMoveRight, RotateMode.Fast);
        yield return new WaitForSeconds(secondsToMoveRight);

        yield return new WaitForSeconds(secondsToStayStill);

        StartCoroutine(DanceCo());
    }
}
