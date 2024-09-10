using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Key : MonoBehaviour
{
    public GameObject door;
    private Vector3 pos;
    public Vector3 door_pos;
    [SerializeField] float movePositionY = 5.0f;
    [SerializeField] float duration = 3;
    private bool getKey;

    public AudioClip soundEffect;
    private AudioSource audioSource;

    Vector3 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody rb = GetComponent<Rigidbody>();

        door_pos = door.transform.position;
        pos = this.transform.position;
        targetPosition = new Vector3(door_pos.x, door_pos.y - movePositionY, door_pos.z);

        getKey = false;

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            this.transform.position = pos;
            if (getKey) 
            {
                door.transform.DOMove( door_pos, 0.1f);

                getKey = false;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            transform.position = new Vector3(door_pos.x + -100, door_pos.y - 100, door_pos.z - 100);
            
            Debug.Log("Œ®Žæ‚Á‚½");

            door.transform.DOMove(targetPosition, duration);
            audioSource.PlayOneShot(soundEffect);

            getKey = true;
        }
    }
}
