using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [Tooltip("The associate portal object")]
    public GameObject ExitPortal;

    void Start()
    {

    }

    void Update()
    {

    }

    public void Collect()
    {
        Destroy(gameObject);
        ExitPortal.GetComponent<ExitPortal>().CollectCoin();
    }
}
