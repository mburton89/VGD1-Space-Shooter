using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponSwitchManager : MonoBehaviour
{
    public static WeaponSwitchManager Instance;
    public int weaponIndex;
    public AudioSource weaponSwitchSound;

    public List<WeaponIcon> weaponIcons;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        if (Input.GetAxis("Mouse ScrollWheel") > 0f) // forward
        {
            SwitchWeaponDown();
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f) // backwards
        {
            SwitchWeaponUp();
        }
    }

    void SwitchWeaponUp()
    {
        weaponIcons[weaponIndex].ShowInactiveColor();
        weaponIndex++;

        if (weaponIndex >= weaponIcons.Count)
        {
            weaponIndex = 0;
        }

        weaponIcons[weaponIndex].ShowActiveColor();

        weaponSwitchSound.pitch = 0.97f;
        weaponSwitchSound.Play();
    }
    void SwitchWeaponDown()
    {
        weaponIcons[weaponIndex].ShowInactiveColor();
        weaponIndex--;

        if (weaponIndex < 0)
        {
            weaponIndex = weaponIcons.Count - 1;
        }

        weaponIcons[weaponIndex].ShowActiveColor();

        weaponSwitchSound.pitch = 1.04f;
        weaponSwitchSound.Play();
    }
}
