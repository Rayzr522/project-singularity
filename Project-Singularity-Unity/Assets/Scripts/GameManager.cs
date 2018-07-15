using UnityEngine;

class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public PlayerController player;

    public int gravityMode;
    public float baseGravity = 30f;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        instance = this;
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
                Debug.Log("Down");
                break;
            case 1:
                Physics2D.gravity = new Vector2(-baseGravity, 0);
                Debug.Log("Left");
                break;
            case 2:
                Physics2D.gravity = new Vector2(0, baseGravity);
                Debug.Log("Up");
                break;
            case 3:
                Physics2D.gravity = new Vector2(baseGravity, 0);
                Debug.Log("Right");
                break;
        }
    }
}