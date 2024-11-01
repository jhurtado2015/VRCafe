using UnityEngine;
using UnityEngine.EventSystems;


public class GazeDetection : MonoBehaviour
{
    public GameObject _player;

    public Material InactiveMaterial;

    public Transform TargetPosition;

    private Renderer _myRenderer;
    /// <summary>
    /// The material to use when this object is active (gazed at).
    /// </summary>
    public Material GazedAtMaterial;
    void Start()
    {
        _myRenderer = GetComponent<Renderer>();
        SetMaterial(false);
    }
    public void OnPointerEnter()
    {
        SetMaterial(true);


        _player.transform.position = TargetPosition.position;

        Debug.Log("GAZE THIS MF");
    }

    public void OnPointerExit()
    {
        SetMaterial(false);
        Debug.Log("GAZE THIS MF");
    }

    private void SetMaterial(bool gazedAt)
    {
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
            _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
        }
    }
}