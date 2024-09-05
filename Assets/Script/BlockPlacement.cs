using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BlockPlacement : MonoBehaviour
{
    public GameObject[] blockPrefabs;   // ブロックのPrefabのリスト
    public GameObject[] placementPreviewPrefabs; // 各ブロックに対応する仮のブロックPrefab
    public Transform blockParent;       // 生成されたブロックの親オブジェクト
    private GameObject selectedBlock;   // 現在選択されているブロック
    public Button[] blockButtons;       // ボタンの配列
    public Collider2D[] placementAreas; // 設置エリアのコライダーの配列

    private GameObject placementPreview; // 仮のブロックのインスタンス
    public Vector2 gridSize = new Vector2(1.0f, 1.0f); // グリッドのサイズ
    public Vector2 gridOffset = Vector2.zero; // グリッドのオフセット

    void Start()
    {
        // UIのボタンにクリックイベントを追加
        for (int i = 0; i < blockPrefabs.Length; i++)
        {
            int index = i;  // クロージャ問題を避けるためのインデックスのコピー
            blockButtons[i].onClick.AddListener(() => SelectBlock(index));
        }

        // 仮のブロックを初期化
        if (placementPreviewPrefabs != null && placementPreviewPrefabs.Length > 0)
        {
            placementPreview = Instantiate(placementPreviewPrefabs[0], Vector3.zero, Quaternion.identity);
            placementPreview.SetActive(false); // 初期状態では非表示
        }
    }

    void Update()
    {
        // マウスクリックがUI上で行われたかどうかを判定
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            // マウスの位置を取得し、グリッドにスナップ
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 snappedPosition = SnapToGrid(mousePos);

            // 仮のブロックを設置位置に移動
            if (placementPreview != null)
            {
                placementPreview.transform.position = snappedPosition;
                if (IsPositionInAnyPlacementArea(snappedPosition))
                {
                    if (CanPlaceBlock(snappedPosition))
                    {
                        //placementPreview.GetComponent<SpriteRenderer>().color = Color.green; // 設置可能
                    }
                    else
                    {
                        //placementPreview.GetComponent<SpriteRenderer>().color = Color.red; // 設置不可
                    }
                    placementPreview.SetActive(true); // 仮のブロックを表示
                }
                else
                {
                    placementPreview.SetActive(false); // 設置エリア外では非表示
                }
            }

            // 選択したブロックを設置する
            if (selectedBlock != null && Input.GetMouseButtonDown(0))
            {
                if (IsPositionInAnyPlacementArea(snappedPosition) && CanPlaceBlock(snappedPosition))
                {
                    Instantiate(selectedBlock, snappedPosition, Quaternion.identity, blockParent);
                }
            }
        }
    }

    // グリッドにスナップするメソッド
    Vector2 SnapToGrid(Vector2 originalPosition)
    {
        // オフセットを考慮してスナップ
        float snappedX = Mathf.Round((originalPosition.x - gridOffset.x) / gridSize.x) * gridSize.x + gridOffset.x;
        float snappedY = Mathf.Round((originalPosition.y - gridOffset.y) / gridSize.y) * gridSize.y + gridOffset.y;
        return new Vector2(snappedX, snappedY);
    }

    // ブロックを選択するメソッド
    void SelectBlock(int index)
    {
        selectedBlock = blockPrefabs[index];
        // 仮のブロックを選択したブロックに合わせて更新
        if (placementPreview != null)
        {
            if (index < placementPreviewPrefabs.Length)
            {
                Destroy(placementPreview); // 既存の仮のブロックを削除
                placementPreview = Instantiate(placementPreviewPrefabs[index], Vector3.zero, Quaternion.identity);
                placementPreview.SetActive(false); // 初期状態では非表示
            }
        }
    }

    // ブロックが設置できるエリアにあるかチェック
    bool IsPositionInAnyPlacementArea(Vector2 position)
    {
        foreach (var area in placementAreas)
        {
            if (area.OverlapPoint(position))
            {
                return true; // 任意の設置エリアに位置が含まれている場合
            }
        }
        return false; // どの設置エリアにも位置が含まれていない場合
    }

    // ブロックが置ける条件をチェックするメソッド
    bool CanPlaceBlock(Vector2 position)
    {
        // 上下左右の位置で重なりをチェックするために少し範囲を広げる
        Vector2 offset = new Vector2(0.5f, 0.5f);
        Collider2D[] colliders = Physics2D.OverlapBoxAll(position, new Vector2(1.0f, 1.0f) + offset, 0f);

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Obstacles"))
            {
                return false; // `Obstacles`タグが付いたコライダーがある場所には設置できない
            }
        }

        return true;
    }
}
