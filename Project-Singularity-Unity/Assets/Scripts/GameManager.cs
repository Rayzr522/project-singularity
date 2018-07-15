using UnityEngine;

class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public PlayerController player;

    private int gravityMode = -1;
    public float baseGravity = 30f;

    public Vector2 up;
    public Vector2 right;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        instance = this;
        SwitchGravity();
    }

    void Update()
    {
        if (Input.GetButtonDown("Gravity"))
        {
            SwitchGravity();
        }
    }

    void SwitchGravity()
    {
        gravityMode = (gravityMode + 1) % 4;

        switch (gravityMode)
        {
            case 0:
                Physics2D.gravity = new Vector2(0, -baseGravity);
                right = new Vector2(1, 0);
                Debug.Log("Down");
                break;
            case 1:
                Physics2D.gravity = new Vector2(-baseGravity, 0);
                right = new Vector2(0, -1);
                Debug.Log("Left");
                break;
            case 2:
                Physics2D.gravity = new Vector2(0, baseGravity);
                right = new Vector2(-1, 0);
                Debug.Log("Up");
                break;
            case 3:
                Physics2D.gravity = new Vector2(baseGravity, 0);
                right = new Vector2(0, 1);
                Debug.Log("Right");
                break;
        }

        up = -Physics2D.gravity.normalized;

        if (player != null)
        {
            player.transform.rotation = Quaternion.Euler(0, 0, Mathf.Atan2(right.y, right.x) * Mathf.Rad2Deg);
        }
    }
}