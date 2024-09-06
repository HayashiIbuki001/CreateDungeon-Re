using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamController : MonoBehaviour
{
    public GameObject beamPrefab;        // ビームのプレハブ
    public Transform beamSpawnPoint;     // ビームの発射位置
    public float beamSpeed = 10f;        // ビームの速度
    public float maxBeamDistance = 20f;  // ビームの最大距離

    private GameObject currentBeam;      // 現在のビーム

    void Start()
    {
        FireBeam();  // 最初にビームを発射
    }

    void Update()
    {
        // ビームが存在しない場合、新たに発射
        if (currentBeam == null)
        {
            FireBeam();
        }
    }

    void FireBeam()
    {
        // ビームを生成し、初期位置と向きを設定
        currentBeam = Instantiate(beamPrefab, beamSpawnPoint.position, beamSpawnPoint.rotation);

        // 発射方向を beamSpawnPoint の向きに合わせる
        Vector2 fireDirection = beamSpawnPoint.up; // up方向を使用する
        currentBeam.GetComponent<Rigidbody2D>().velocity = fireDirection * beamSpeed;

        // 一定距離を超えたらビームを削除
        Destroy(currentBeam, maxBeamDistance / beamSpeed);
    }
}
