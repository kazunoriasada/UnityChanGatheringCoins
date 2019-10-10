using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private GameManager manager;

    public void SetGameManager(GameManager manager)
    {
        this.manager = manager;
    }

    void OnCollisionEnter(Collision other)
    {
        this.manager.GetPoint();
        Destroy(gameObject);
    }
}
