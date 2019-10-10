using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class GameManagement : MonoBehaviour
{
    //SerializeField = privateフィールドをインスペクタに表示する際に付けるおまじない
    [SerializeField]
    private GameObject CoinFactory;
    //const = 変数の値を変更せず定数として宣言する際に使う修飾子
    private const int Max_COIN = 50;
    // Listを使う場合 = List構造で何かを管理したいときにList<>を活用する
    //他にも、配列やArraryList,type[]などがある。
    //Listを活用する際は、using System.Collections.Generic;の宣言がないと活用できない
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
    //bool = 変数の型名 trueまたはfalse
    private bool gamePlay;

    void Start()
    {
        //Random = 乱数を生成する際のクラス
        //System = 名前空間であり、Randomクラスとセットで使われる
        System.Random random = new System.Random();

        //Create Coin
        coinList = new List<GameObject>();
        for(int i = 0; i < MAX_COUNT; i++)
        {
            //Instantiate = ゲーム中に表示される主人公や敵キャラクターなどの動的なオブジェクトを生成する関数
            //var = メソッド内のローカル変数を宣言する際に型宣言の代わりに使用する。コンパイラが自動で型を判断してくれる
            //var = 長い型名の代わりに var を使うとコードをスッキリする
            //var = 右辺から型が明らかでない場合、var は推奨されない
            var go = Instantiate(CoinFactory);
            go.GetComponent<CoinFactory>().SetGameManagement(this);
            if(go == null)
            {
                 Debug.Log("生成できていない");

            }
            else if(go.GetComponent<CoinFactory>() == null)
            {
                Debug.Log("CoinFactoryがAddされていない");
            }

            //random
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
        if(gamePlay == false) return;
        this.pointText.text = point.ToString();
    }

    private void SetCountText()
    {
        if(gamePlay == false) return;
        this.countText.text = count.ToString();
    }

    public void GetPoint()
    {
        if(gamePlay == false) return;
        this.point += POINT_VALUE;
    }
}
