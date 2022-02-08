using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitPortal : MonoBehaviour
{
    [Tooltip("Coins to open the portal")]
    public int CoinsRequired;
    [Tooltip("Next Level Name")]
    public string NextLevel;

    private int CollectedCoins;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void CollectCoin()
    {
        CollectedCoins++;
        if (CollectedCoins == CoinsRequired)
        {
            // Set the portal sprite to open
        }
    }
}
