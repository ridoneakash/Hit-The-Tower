using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LivesUI : MonoBehaviour
{
    public TextMeshProUGUI livesText;
    void Update()
    {
        livesText.text = PlayerStats.lives.ToString() + "LIVES";
    }
}
