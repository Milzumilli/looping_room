using UnityEngine;
using TMPro;

public class RoomStateController : MonoBehaviour
{
    [Header("Loop 0 Objects (starting room)")]
    public GameObject[] loop0Objects;

    [Header("Loop 1 Objects (changed room)")]
    public GameObject[] loop1Objects;

    [Header("Loop 2 Objects (more changes)")]
    public GameObject[] loop2Objects;

    [Header("Loop 3 Objects (one more change)")]
    public GameObject[] loop3Objects;

    [Header("Loop 4 Objects (final room)")]
    public GameObject[] loop4Objects;

    [Header("Final loop")]
    public GameObject finalLoopText;

    [TextArea]
    public string finalLoopMessage = "There is no next loop, you already left.";



    private void Start()
    {

        ApplyLoop(GameManager.Instance.currentLoop);
    }

    public void ApplyLoop(int loop)
    {
        Debug.Log("ApplyLoop called, loop = " + loop);


        // piilotetaan kaikki aluksi
        SetActiveForArray(loop0Objects, false);
        SetActiveForArray(loop1Objects, false);
        SetActiveForArray(loop2Objects, false);
        SetActiveForArray(loop3Objects, false);
        SetActiveForArray(loop4Objects, false);

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
        else if (loop == 3)
        {
            SetActiveForArray(loop3Objects, true);
        }
        else if (loop == 4)
        {
            SetActiveForArray(loop4Objects, true);
        }
        else // loop >= 4
        {
            SetActiveForArray(loop4Objects, true);
            Debug.Log("FINAL LOOP REACHED ó No more changes!");
        }


        if (finalLoopText != null)
        {
            bool showFinal = (loop == 4);
            finalLoopText.SetActive(showFinal);

            if (showFinal)
                SetFinalLoopText(finalLoopMessage);
            else
                SetFinalLoopText("");
        }
        var door = Object.FindFirstObjectByType<DoorInteract>();
        if (door != null)
        {
            door.OnLoopChanged();
        }
       

    }

    private void SetFinalLoopText(string msg)
    {
        if (finalLoopText == null) return;

        TMP_Text tmp = finalLoopText.GetComponent<TMP_Text>();
        if (tmp == null)
            tmp = finalLoopText.GetComponentInChildren<TMP_Text>(true);

        if (tmp == null) return;

        tmp.text = msg;

        var c = tmp.color;
        c.a = 1f;
        tmp.color = c;
    }


    private void SetActiveForArray(GameObject[] objects, bool active)
    {
        if (objects == null) return;
        
        foreach (GameObject obj in objects)
        {
            if (obj != null)
                obj.SetActive(active);
        }
    }


}
