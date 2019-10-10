using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//継承
// 派生クラス : 基底クラス
public class ExtendCube : BaseCube
{
   //オーバーライド
   public override void AddColor()
    {
        GetRenderer().color = Color.blue;
    }

}
