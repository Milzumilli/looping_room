using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public int currentLoop = 0;
    public bool hasKey = false;
    public bool hasReadNote = false;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        Debug.Log("GameManager Awake, currentLoop = " + currentLoop);
    }

    public void ResetLoop()
    {
        currentLoop = 0;
        PlayerPrefs.SetInt("LoopNumber", currentLoop);
    }
    public void GoToNextLoop()
    {
        if (currentLoop < 4)
            currentLoop++;

            PlayerPrefs.SetInt("LoopNumber", currentLoop);
        
            Debug.Log("Next loop: " + currentLoop);

            var room = FindFirstObjectByType<RoomStateController>();
        
        if (room != null)
        
            room.ApplyLoop(currentLoop);
        }
    }



