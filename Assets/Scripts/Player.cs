using UnityEngine;

public class Player : MonoBehaviour
{
    public float dodgeSpeed;
    private float xInput;
    public float maxX;

    private void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
        transform.Translate(xInput * dodgeSpeed * Time.deltaTime, 0, 0);
        float limitedX = Mathf.Clamp(transform.position.x, -maxX, maxX);
        transform.position = new Vector3(limitedX, transform.position.y, transform.position.z);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            GameManager.instance.Retart();
        }
    }
}
