using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXUser : MonoBehaviour
{
    protected AudioManager audioManager;
    protected GameManager gm;
    private void Awake()
    {
        audioManager = FindObjectOfType<AudioManager>();
        gm = FindObjectOfType<GameManager>();
    }
}
