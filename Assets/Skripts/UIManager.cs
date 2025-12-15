using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    [Header("UI Elements")]
    public TextMeshProUGUI InteractionText;
    public GameObject NotePanel;
    public TextMeshProUGUI NoteText;

    void Awake()
    {
        Instance = this;

        if (NotePanel != null)
            NotePanel.SetActive(false);  // piilota note alussa

        if (InteractionText != null)
            InteractionText.text = "";   // tyhjennä teksti
    }

    public void ShowInteraction(string msg)
    {
        if (InteractionText == null) return;
        InteractionText.text = msg;
    }

    public void HideInteraction()
    {
        if (InteractionText == null) return;
        InteractionText.text = "";
    }

    public void ShowNote(string msg)
    {
        if (NotePanel != null)
            NotePanel.SetActive(true);
        if (NoteText != null)
            NoteText.text = msg;
    }

    public void HideNote()
    {
        if (NotePanel != null)
            NotePanel.SetActive(false);
    }
}
