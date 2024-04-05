using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 50f;

    private float zBound = 7.5f;
    private Rigidbody playerRb;
    
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MovePlayer();
        ConstrainPlayerPosition();
    }

    // Moves the Player based on arrow key input
    void MovePlayer()
    {
        // 유니티의 InputManager 에 설정되어 있는 키값들로 인해서 아래의 코드가 작동 가능해집니다.
        // 즉, InputManager 의 Axes 의 Horizontal, Vertical 의 설정들을 읽어와서 방향에 맞게 speed 만큼 값을 곱해서 움직이게 됩니다.
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        playerRb.AddForce(Vector3.right * speed * horizontalInput * Time.deltaTime, ForceMode.Impulse);
        playerRb.AddForce(Vector3.forward * speed * verticalInput * Time.deltaTime, ForceMode.Impulse);
    }

    // Prevent the player from leaving the top or bottom of the screen
    void ConstrainPlayerPosition()
    {
        // 상, 하 움직임 제한 코드
        if (transform.position.z < -zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zBound);
        }
        if (transform.position.z > zBound)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zBound);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Player has collided with enemy.");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PowerUp"))
        {
            Destroy(other.gameObject);
        }
    }
}
