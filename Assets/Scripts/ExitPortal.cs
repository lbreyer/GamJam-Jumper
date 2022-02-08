using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitPortal : MonoBehaviour
{
    [Tooltip("Coins to open the portal")]
    public int CoinsRequired;
    [Tooltip("Next Level Name")]
    public string NextLevel;

    private int CollectedCoins;
    private bool active;

    void Start()
    {
        active = false;
    }

    public void teleport() 
    {
        if (active) 
        {
            SceneManager.LoadScene(NextLevel);
        }
        
    }

    public void CollectCoin()
    {
        CollectedCoins++;
        if (CollectedCoins == CoinsRequired)
        {
            active = true;
        }
    }
}
