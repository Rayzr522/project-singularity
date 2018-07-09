using UnityEngine;

class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public PlayerController player;

    /// <summary>
    /// Awake is called when the script instance is being loaded.
    /// </summary>
    void Awake()
    {
        instance = this;
    }    
}