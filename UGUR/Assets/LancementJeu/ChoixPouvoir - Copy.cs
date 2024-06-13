using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoixPouvoir : MonoBehaviour
{
    public Button shootButton;
    public Button rainButton;
    public Button orbitButton;
    public GameObject character;

    void Start()
    {
        shootButton.onClick.AddListener(() => GivePower("shoot"));
        rainButton.onClick.AddListener(() => GivePower("rain"));
        orbitButton.onClick.AddListener(() => GivePower("orbit"));
    }

    void GivePower(string powerType)
    {
        CharacterController characterController = character.GetComponent<CharacterController>();
        if (characterController != null)
        {
            characterController.ActivatePower(powerType);
        }
    }
}