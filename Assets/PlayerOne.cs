using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PLAYEROne : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 MoveAmount;
    public GameObject PlayerOneBig;
    public GameObject PlayerOneSmall;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        PlayerOneBig.SetActive(false);
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
        if (Input.GetKey(KeyCode.W))
        {
            PlayerOneBig.SetActive(true);
            Instantiate(PlayerOneBig, transform.position, Quaternion.identity);
            this.gameObject.SetActive(false);
        }
        if (Input.GetKey(KeyCode.S))
        {
            PlayerOneSmall.SetActive(true);
            Instantiate(PlayerOneSmall, transform.position, Quaternion.identity);
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
