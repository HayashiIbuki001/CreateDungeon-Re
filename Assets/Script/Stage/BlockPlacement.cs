using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class BlockPlacement : MonoBehaviour
{
    public GameObject[] blockPrefabs;   // �u���b�N��Prefab�̃��X�g
    public GameObject[] placementPreviewPrefabs; // �e�u���b�N�ɑΉ����鉼�̃u���b�NPrefab
    public Transform blockParent;       // �������ꂽ�u���b�N�̐e�I�u�W�F�N�g
    private GameObject selectedBlock;   // ���ݑI������Ă���u���b�N
    public Button[] blockButtons;       // �{�^���̔z��
    public Tilemap placementTilemap;     // �ݒu�G���A�Ƃ��Ďg��Tilemap
    public int maxBlock;

    private GameObject placementPreview; // ���̃u���b�N�̃C���X�^���X
    public Vector2 gridSize = new Vector2(1.0f, 1.0f); // �O���b�h�̃T�C�Y
    public Vector2 gridOffset = Vector2.zero; // �O���b�h�̃I�t�Z�b�g

    private List<GameObject> placedBlocks = new List<GameObject>(); // �u���ꂽ�u���b�N���Ǘ�

    void Start()
    {
        // UI�̃{�^���ɃN���b�N�C�x���g��ǉ�
        for (int i = 0; i < blockPrefabs.Length; i++)
        {
            int index = i;  // �N���[�W����������邽�߂̃C���f�b�N�X�̃R�s�[
            blockButtons[i].onClick.AddListener(() => SelectBlock(index));
        }

        // ���̃u���b�N��������
        if (placementPreviewPrefabs != null && placementPreviewPrefabs.Length > 0)
        {
            placementPreview = Instantiate(placementPreviewPrefabs[0], Vector3.zero, Quaternion.identity);
            placementPreview.SetActive(false); // ������Ԃł͔�\��
        }
    }

    void Update()
    {
        // �}�E�X�N���b�N��UI��ōs��ꂽ���ǂ����𔻒�
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            // �}�E�X�̈ʒu���擾���A�O���b�h�ɃX�i�b�v
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 snappedPosition = SnapToGrid(mousePos);

            // ���̃u���b�N��ݒu�ʒu�Ɉړ�
            if (placementPreview != null && selectedBlock != null)
            {
                placementPreview.transform.position = snappedPosition;
                if (IsPositionInTilemap(snappedPosition))
                {
                    placementPreview.SetActive(true); // ���̃u���b�N��\��
                }
                else
                {
                    placementPreview.SetActive(false); // �ݒu�G���A�O�ł͔�\��
                }
            }

            // �I�������u���b�N��ݒu����
            if (selectedBlock != null && Input.GetMouseButtonDown(0))
            {
                if (IsPositionInTilemap(snappedPosition) && CanPlaceBlock(snappedPosition))
                {
                    GameObject newBlock = Instantiate(selectedBlock, snappedPosition, Quaternion.identity, blockParent);
                    placedBlocks.Add(newBlock);

                    // �ݒu����u���b�N�̐��������𒴂����ꍇ�͌Â����̂������
                    if (placedBlocks.Count > maxBlock) // �������鐔�i��: 10�j
                    {
                        Destroy(placedBlocks[0]);
                        placedBlocks.RemoveAt(0);
                    }
                }
            }
        }
    }

    // �O���b�h�ɃX�i�b�v���郁�\�b�h
    Vector2 SnapToGrid(Vector2 originalPosition)
    {
        // �I�t�Z�b�g���l�����ăX�i�b�v
        float snappedX = Mathf.Round((originalPosition.x - gridOffset.x) / gridSize.x) * gridSize.x + gridOffset.x;
        float snappedY = Mathf.Round((originalPosition.y - gridOffset.y) / gridSize.y) * gridSize.y + gridOffset.y;
        return new Vector2(snappedX, snappedY);
    }

    // �u���b�N��I�����郁�\�b�h
    void SelectBlock(int index)
    {
        selectedBlock = blockPrefabs[index];
        // ���̃u���b�N��I�������u���b�N�ɍ��킹�čX�V
        if (placementPreview != null)
        {
            if (index < placementPreviewPrefabs.Length)
            {
                Destroy(placementPreview); // �����̉��̃u���b�N���폜
                placementPreview = Instantiate(placementPreviewPrefabs[index], Vector3.zero, Quaternion.identity);
                placementPreview.SetActive(false); // ������Ԃł͔�\��
            }
        }
    }

    // Tilemap���Ɉʒu�����邩�`�F�b�N
    bool IsPositionInTilemap(Vector2 position)
    {
        Vector3Int cellPosition = placementTilemap.WorldToCell(position);
        return placementTilemap.GetTile(cellPosition) != null;
    }

    // �u���b�N���u����������`�F�b�N���郁�\�b�h
    bool CanPlaceBlock(Vector2 position)
    {
        // �㉺���E�̈ʒu�ŏd�Ȃ���`�F�b�N���邽�߂ɏ����͈͂��L����
        Vector2 offset = new Vector2(0.5f, 0.5f);
        Collider2D[] colliders = Physics2D.OverlapBoxAll(position, new Vector2(1.0f, 1.0f) + offset, 0f);

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Obstacles"))
            {
                return false; // `Obstacles`�^�O���t�����R���C�_�[������ꏊ�ɂ͐ݒu�ł��Ȃ�
            }
        }

        return true;
    }

    // �v���C���[���ݒu�����u���b�N�����ׂď������郁�\�b�h
    public void ClearBlocks()
    {
        foreach (var block in placedBlocks)
        {
            Destroy(block);
        }
        placedBlocks.Clear();
    }
}
