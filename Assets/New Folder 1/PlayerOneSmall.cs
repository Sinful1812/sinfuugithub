using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PLAYEROneSmall : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 MoveAmount;
    public GameObject PlayerOne;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        MoveAmount = moveInput.normalized * speed;
        if (moveInput != Vector2.zero)
        {
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
        }
        if (Input.GetKey(KeyCode.Space))
        {
            PlayerOne.SetActive(true);
            Instantiate(PlayerOne, transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);

        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + MoveAmount * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "RedZone")
        {
            SceneManager.LoadScene("PlayerTwoWin");
        }

    }
}
