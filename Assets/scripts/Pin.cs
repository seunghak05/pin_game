
using UnityEngine;

public class Pin : MonoBehaviour
{
    [SerializeField]

    private float moveSpeed = 1f;
    private bool Ispinned = false;
    private bool IsLaunchered = false;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void FixedUpdate()
    {
        if (Ispinned == false && IsLaunchered == true)
        {
            transform.position += Vector3.up * moveSpeed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Ispinned = true;
        IsLaunchered = false;
        if (collision.gameObject.tag == "TargetCircle")
        {
            Debug.Log("안녕");
            GameObject childObject = transform.Find("Square").gameObject;
            childObject.GetComponent<SpriteRenderer>().enabled = true;
            transform.SetParent(collision.gameObject.transform);
            GameManager.instance.DecreaseGoal();
        }
        else if (collision.gameObject.tag == "Pin")
        {
           //Destroy(collision.gameObject);
            GameManager.instance.SetGameOver(false);
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.gravityScale = 1f;
                transform.localScale *= 1.2f;
            }

            Rigidbody2D otherRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (otherRb != null)
            {
                otherRb.gravityScale = 1f;
                collision.gameObject.transform.localScale *= 1.2f;  
            }

        }
    }
    // Update is called once per frame
    public void Launch()
    {
        IsLaunchered = true;       
    }
}
