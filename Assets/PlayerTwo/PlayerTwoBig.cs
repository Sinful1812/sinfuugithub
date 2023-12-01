using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PLAYERTwoBig : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 MoveAmount;
    public GameObject PlayerTwo;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Harezota"), Input.GetAxisRaw("Virati"));
        MoveAmount = moveInput.normalized * speed;
        if (moveInput != Vector2.zero)
        {
            anim.SetBool("walking", true);
        }
        else
        {
            anim.SetBool("walking", false);
            {
                transform.Translate(Vector2.zero);
            }
        }
        if (Input.GetKey(KeyCode.Keypad0))
        {
            PlayerTwo.SetActive(true);
            Instantiate(PlayerTwo, transform.position, Quaternion.identity);
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
            SceneManager.LoadScene("PlayerOneWin");
        }

    }
}