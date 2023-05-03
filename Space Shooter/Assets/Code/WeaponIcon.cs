using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponIcon : MonoBehaviour
{
    public Color activeColor;
    public Color inactiveColor;
    Image image;

    private void Start()
    {
        image = GetComponent<Image>();
    }

    public void ShowActiveColor()
    {
        image.color = activeColor;
    }

    public void ShowInactiveColor()
    {
        image.color = inactiveColor;
    }


}
