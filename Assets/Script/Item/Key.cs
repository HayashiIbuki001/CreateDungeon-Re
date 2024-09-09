using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Key : MonoBehaviour
{
    public GameObject door;
    [SerializeField] Vector3 movePosition = new Vector3(0, 3.0f, 0);
    [SerializeField] float duration = 3;

    Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        Vector3 pos = door.transform.position;
        targetPosition = new Vector3(pos.x + movePosition.x, pos.y + movePosition.y, pos.z + movePosition.z);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            Destroy(this.gameObject);
            Debug.Log("Œ®Žæ‚Á‚½");

            door.transform.DOMove(targetPosition, duration);
        }
    }
}
