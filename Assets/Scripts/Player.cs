using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{

    public float thrustForce = 100f;
    public float rotationSpeed = 120f;

    public GameObject gun;

    private Rigidbody2D _rigid;

    private float xBorder;
    private float yBorder;

    public static int SCORE;
    // Start is called before the first frame update
    void Start()
    {
        SCORE = 0;
        _rigid = GetComponent<Rigidbody2D>();

        yBorder = Camera.main.orthographicSize + 1;
        xBorder = Camera.main.aspect * yBorder;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;
        
        if (currentPosition.x > xBorder)
            currentPosition.x = -xBorder + 1;
        else if (currentPosition.x < -xBorder)
            currentPosition.x = xBorder - 1;
        else if (currentPosition.y > yBorder)
            currentPosition.y = -yBorder + 1;
        else if (currentPosition.y < -yBorder)
            currentPosition.y = yBorder - 1;
        transform.position = currentPosition;
        
        float rotation = Input.GetAxis("Rotate") * Time.deltaTime;
        float thrust = Input.GetAxis("Thrust") * Time.deltaTime;

        Vector3 thrustDirection = transform.right;

        _rigid.AddForce(thrustDirection * thrust * thrustForce);

        transform.Rotate(Vector3.forward, -rotation * rotationSpeed);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject bullet = BulletPool.SharedBulletInstance.GetPooledBullet();
            if (bullet != null)
            {
                bullet.transform.position = gun.transform.position;
                Bullet bulletScript = bullet.GetComponent<Bullet>();
                bulletScript.targetVector = transform.right;
            }
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
        else
        {
            Debug.Log("He colisionado con otra cosa");
        }
    }
}
