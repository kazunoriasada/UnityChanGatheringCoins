using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [SerializeField]
    private GameObject coin;
    private const int MAX_COIN = 10;
    private List<GameObject> coinList;

    [SerializeField]
    Text pointText;
    [SerializeField]
    Text countText;
    [SerializeField]
    Image timeUp;

    private const int POINT_VALUE = 10;
    private int point;

    private const int MAX_COUNT = 30;
    private int count;
    private int frame;
    private bool gamePlay;

    // Start is called before the first frame update
    void Start()
    {
        System.Random random = new System.Random();

        // Create Coin
        coinList = new List<GameObject>();
        for(int i = 0; i < MAX_COIN; i++)
        {
            var go = Instantiate(coin);
            go.GetComponent<Coin>().SetGameManager(this);

            // random
            int positionX = random.Next(-50, 50);
            int positionZ = random.Next(-50, 50);
            go.GetComponent<Transform>().position = new Vector3(
                positionX,
                go.GetComponent<Transform>().position.y,
                positionZ
            );

            coinList.Add(go);
        }

        count = MAX_COUNT;
        frame = 0;
        gamePlay = true;

        SetPointText();
        SetCountText();
    }

    // Update is called once per frame
    void Update()
    {
        frame++;
        if(frame >= 60)
        {
            count--;
            frame = 0;

            SetPointText();
            SetCountText();
            IsTimeUp();
        }
    }

    private void IsTimeUp()
    {
        if(count <= 0)
        {
            gamePlay = false;
            timeUp.gameObject.SetActive(true);
        }
    }

    private void SetPointText()
    {
        if(gamePlay == false) return;   // TimeOver
        this.pointText.text = point.ToString();
    }

    private void SetCountText()
    {
        if(gamePlay == false) return;   // TimeOver
        this.countText.text = count.ToString();
    }

    public void GetPoint()
    {
        if(gamePlay == false) return;   // TimeOver
        this.point += POINT_VALUE;
    }

}
