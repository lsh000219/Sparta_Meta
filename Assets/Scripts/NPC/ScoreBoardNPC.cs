using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreBoardNPC : BaseNPC
{
    [SerializeField] public TextMeshProUGUI bestWaveText;
    [SerializeField] public TextMeshProUGUI beststageText;


    private void Update()
    {
        bestWaveText.text = PlayerPrefs.GetInt("BestWave", 0).ToString();
        beststageText.text = PlayerPrefs.GetInt("Beststage", 0).ToString();
    }
}
