using UnityEngine;

public class RoomStateController : MonoBehaviour
{
    [Header("Loop 0 Objects (starting room)")]
    public GameObject[] loop0Objects;

    [Header("Loop 1 Objects (changed room)")]
    public GameObject[] loop1Objects;

    [Header("Loop 2 Objects (more changes)")]
    public GameObject[] loop2Objects;

    [Header("Loop 3 Objects (final room)")]
    public GameObject[] loop3Objects;

    private void Start()
    {
        int loop = GameManager.Instance.currentLoop;
        Debug.Log("RoomStateController Start ñ loop = " + loop);

        // piilotetaan kaikki aluksi
        SetActiveForArray(loop0Objects, false);
        SetActiveForArray(loop1Objects, false);
        SetActiveForArray(loop2Objects, false);
        SetActiveForArray(loop3Objects, false);

        // n‰ytet‰‰n vain oikean loopin tavarat
        if (loop <= 0)
        {
            SetActiveForArray(loop0Objects, true);
        }
        else if (loop == 1)
        {
            SetActiveForArray(loop1Objects, true);
        }
        else if (loop == 2)
        {
            SetActiveForArray(loop2Objects, true);
        }
        else // loop >= 3
        {
            SetActiveForArray(loop3Objects, true);
            Debug.Log("FINAL LOOP REACHED ó No more changes!");
        }
    }


    private void SetActiveForArray(GameObject[] objects, bool active)
    {
        foreach (GameObject obj in objects)
        {
            if (obj != null)
                obj.SetActive(active);
        }
    }


}
