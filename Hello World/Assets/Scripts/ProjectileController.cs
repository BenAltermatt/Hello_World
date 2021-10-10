using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public Rigidbody2D rb;
    public Transform tr;
    public Camera cam;

    public float speed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tr = GetComponent<Transform>();
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        if (Input.GetMouseButton(0))
        {
            launch();
        }
    }

    /**
     * Launches the object to the coordinates the 
     * mouse is hovering over.
     */
    public void launch()
    {
        Vector3 coords = Input.mousePosition;
        coords = cam.ScreenToWorldPoint(coords);

        launch(coords.x, coords.y);
    }

    /**
     * Actually launches the object at the intended coordinates
     */
    public void launch(float aimX, float aimY)
    {
        float[] dirVector = launchDirection(aimX, aimY);
        rb.velocity = new Vector2(dirVector[0] * speed, dirVector[1] * speed);
    }

    /**
     * The point of this method is to get a unit vector
     * representation of a direction the projectile
     * is initially firing in based on coordinates
     * it is being "aimed at"
     */
    private float[] launchDirection(float aimX, float aimY)
    {
        float distX = aimX - tr.position[0];
        float distY = aimY - tr.position[1];

        float mag = Mathf.Sqrt(Mathf.Pow(distX, 2) + Mathf.Pow(distY, 2));

        float[] coords = new float[2];
        coords[0] = distX / mag;
        coords[1] = distY / mag;

        return coords;
    }

}
