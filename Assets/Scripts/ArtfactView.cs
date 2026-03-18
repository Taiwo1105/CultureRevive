using UnityEngine;
using TMPro;

public class ArtifactView : MonoBehaviour
{
    [Header("UI Dependencies")]
    [SerializeField] private GameObject infoCanvas;
    [SerializeField] private TMP_Text descriptionLabel;

    [Header("Rotation Behavior")]
    [SerializeField] private bool rotateToFaceCamera = true;

    public void Configure(ArtifactData data)
    {
        if (descriptionLabel != null)
        {
            descriptionLabel.text = data.description;
        }

        Hide();
    }

    public void Show()
    {
        if (infoCanvas != null)
            infoCanvas.SetActive(true);
    }

    public void Hide()
    {
        if (infoCanvas != null)
            infoCanvas.SetActive(false);
    }

    public bool IsVisible()
    {
        return infoCanvas != null && infoCanvas.activeSelf;
    }

    private void Update()
    {
        if (rotateToFaceCamera && IsVisible())
            FaceCamera();
    }

    private void FaceCamera()
    {
        if (Camera.main == null) return;

        Vector3 camPos = Camera.main.transform.position;
        Vector3 target = new Vector3(camPos.x, infoCanvas.transform.position.y, camPos.z);

        infoCanvas.transform.LookAt(target);
        infoCanvas.transform.Rotate(0, 180, 0);
    }
}