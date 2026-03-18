using UnityEngine;
using UnityEngine.EventSystems;

// CONTROLLER: Coordinates Input (User), Model (Data), and View (UI).
[RequireComponent(typeof(ArtifactView))]
public class ArtifactController : MonoBehaviour
{
    [Header("Model (The Data)")]
    // This connects to your ArtifactData script
    [SerializeField] private ArtifactData artifactData;

    // Reference to the View
    private ArtifactView _view;

    private void Awake()
    {
        _view = GetComponent<ArtifactView>();
    }

    private void Start()
    {
        // Pass the entire Data Object to the View
        if (artifactData != null)
        {
            _view.Configure(artifactData);
        }
    }

    private void Update()
    {
        HandleInput();
    }

    private void HandleInput()
    {
        // 1. Check for Touch
        if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began)
        {
            // 2. UI Blocking Check (Protects Scrolling)
            if (IsPointerOverUI())
            {
                Debug.Log("AR LOG: User touched UI. Ignoring Artifact.");
                return;
            }

            // 3. Raycast Logic
            PerformRaycast();
        }
    }

    private void PerformRaycast()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit))
        {
            // Check if we hit THIS object or its children
            if (hit.transform == transform || hit.transform.IsChildOf(transform))
            {
                // COMMAND: Tell the View to show itself
                _view.Show();
            }
        }
    }

    // Public method for the Close Button to call
    public void CloseArtifact()
    {
        _view.Hide();
    }

    private bool IsPointerOverUI()
    {
        if (Input.touchCount > 0)
        {
            if (EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId))
                return true;
        }
        return false;
    }
} 