using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scoreboard : MonoBehaviour
{
    public static Scoreboard instance;
    private void Awake()
    {
        instance = this;
    }
    public Transform highscoreHolder;
    public GameObject entryGO;

    public void UpdateUI(Merchant[] guildData)
    {
        foreach (Transform child in highscoreHolder)
        {
            Destroy(child.gameObject);
        }
        foreach (var merchant in guildData)
        {
            Instantiate(entryGO, highscoreHolder).GetComponent<ScoreboardEntryUI>().Initialize(merchant);
        }
    }

}
