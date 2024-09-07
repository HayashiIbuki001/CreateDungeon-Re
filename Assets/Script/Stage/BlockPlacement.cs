using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class BlockPlacement : MonoBehaviour
{
    public GameObject[] blockPrefabs;   // ブロックのPrefabのリスト
    public GameObject[] placementPreviewPrefabs; // 各ブロックに対応する仮のブロックPrefab
    public Transform blockParent;       // 生成されたブロックの親オブジェクト
    private GameObject selectedBlock;   // 現在選択されているブロック
    public Button[] blockButtons;       // ボタンの配列
    public Tilemap placementTilemap;     // 設置エリアとして使うTilemap
    public int maxBlock;

    private GameObject placementPreview; // 仮のブロックのインスタンス
    public Vector2 gridSize = new Vector2(1.0f, 1.0f); // グリッドのサイズ
    public Vector2 gridOffset = Vector2.zero; // グリッドのオフセット

    private List<GameObject> placedBlocks = new List<GameObject>(); // 置かれたブロックを管理

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
            if (placementPreview != null && selectedBlock != null)
            {
                placementPreview.transform.position = snappedPosition;
                if (IsPositionInTilemap(snappedPosition))
                {
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
                if (IsPositionInTilemap(snappedPosition) && CanPlaceBlock(snappedPosition))
                {
                    GameObject newBlock = Instantiate(selectedBlock, snappedPosition, Quaternion.identity, blockParent);
                    placedBlocks.Add(newBlock);

                    // 設置するブロックの数が制限を超えた場合は古いものから消す
                    if (placedBlocks.Count > maxBlock) // 制限する数（例: 10個）
                    {
                        Destroy(placedBlocks[0]);
                        placedBlocks.RemoveAt(0);
                    }
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

    // Tilemap内に位置があるかチェック
    bool IsPositionInTilemap(Vector2 position)
    {
        Vector3Int cellPosition = placementTilemap.WorldToCell(position);
        return placementTilemap.GetTile(cellPosition) != null;
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

    // プレイヤーが設置したブロックをすべて消去するメソッド
    public void ClearBlocks()
    {
        foreach (var block in placedBlocks)
        {
            Destroy(block);
        }
        placedBlocks.Clear();
    }
}
