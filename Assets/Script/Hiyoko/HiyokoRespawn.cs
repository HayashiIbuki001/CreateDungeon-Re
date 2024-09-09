using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HiyokoRespawn : MonoBehaviour
{
    public GameObject hiyokoPrefab; // ひよこのプレハブ
    public Transform respawnPoint;  // チェックポイントの位置

    public void Respawn()
    {
        // 現在のひよこを削除または非表示にする
        Destroy(gameObject);

        // 新しいひよこをインスタンス化する
        GameObject newHiyoko = Instantiate(hiyokoPrefab, respawnPoint.position, respawnPoint.rotation);

        // 必要に応じて初期の移動方向を設定
        HiyokoMove hiyokoMove = newHiyoko.GetComponent<HiyokoMove>();
        if (hiyokoMove != null)
        {
            //hiyokoMove.SetInitialDirection(Vector2.right); // 右方向に歩くように設定
        }
    }
}