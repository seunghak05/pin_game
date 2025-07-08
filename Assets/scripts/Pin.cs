
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
            Destroy(collision.gameObject);
            GameManager.instance.SetGameOver(false);
        }
    }
    // Update is called once per frame
    public void Launch()
    {
        IsLaunchered = true;       
    }
}
