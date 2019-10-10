using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseCube : MonoBehaviour
{
    float speed = 80f;

    void Start()
    {
        AddColor();
    }

    //virtual = オーバーライドするために必要
    //派生クラスではoverrideを修飾子として活用している
    public virtual void AddColor()
    {
        GetRenderer().color = Color.red;
    }

   public Material GetRenderer()
    {
        return this.GetComponent<Renderer>().material;
    }

     void Update()
     {
         float step = speed * Time.deltaTime;
         //GetComponent = 先に宣言されているものしか呼べない（Addコンポーネントしているものしか呼べない）
         //var 
         var transform = this.GetComponent<Transform>();
        transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(0, 180f, 0), step);
     }
}
