using UnityEngine;

public class Shield : MonoBehaviour {
    public float speed = 1.0f;
    public float stopTime = 10.0f;

    private void Start() {
        stopTime += Time.timeSinceLevelLoad; 
    }

    private void Update() {
        transform.position = FindObjectOfType<Paddle>().transform.position;

        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, speed * Time.fixedDeltaTime);

        if (Time.timeSinceLevelLoad >= stopTime) { //5 or more seconds has past
            Destroy(gameObject);
        }
    }
}