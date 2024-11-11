using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GazeTeleportation : MonoBehaviour
{
    /// The material to use when this object is inactive (not being gazed at).
    /// </summary>
    public Material InactiveMaterial;

    /// <summary>
    /// The material to use when this object is active (gazed at).
    /// </summary>
    public Material GazedAtMaterial;

    // The objects are about 1 meter in radius, so the min/max target distance are
    // set so that the objects are always within the room (which is about 5 meters
    // across).
    private const float _minObjectDistance = 2.5f;
    private const float _maxObjectDistance = 3.5f;
    private const float _minObjectHeight = 0.5f;
    private const float _maxObjectHeight = 3.5f;

    private Renderer _myRenderer;
    private Vector3 _startingPosition;

    public GameObject _player;

    public GameObject _target;

    public Image blackoutImage;     // UI Image that covers the screen to create a blackout effect
    public float fadeDuration = 2f;

    /// <summary>
    /// Start is called before the first frame update.
    /// </summary>
    public void Start()
    {
        _startingPosition = transform.parent.localPosition;
        _myRenderer = GetComponent<Renderer>();
        SetMaterial(false);
        InitializeTransition();
    }

    private void InitializeTransition()
    {
        // Ensure the blackout image starts transparent
        Color initialColor = blackoutImage.color;
        initialColor.a = 0;
        blackoutImage.color = initialColor;
       //TriggerFadeAndMove();
    }


    /// <summary>
    /// This method is called by the Main Camera when it starts gazing at this GameObject.
    /// </summary>
    public void OnPointerEnter()
    {
        TriggerFadeAndMove();
        SetMaterial(true);
        
        
        
    }

    /// <summary>
    /// This method is called by the Main Camera when it stops gazing at this GameObject.
    /// </summary>
    public void OnPointerExit()
    {
        SetMaterial(false);
    }

    /// <summary>
    /// This method is called by the Main Camera when it is gazing at this GameObject and the screen
    /// is touched.
    /// </summary>
    public void OnPointerClick()
    {
     
    }

    /// <summary>
    /// Sets this instance's material according to gazedAt status.
    /// </summary>
    ///
    /// <param name="gazedAt">
    /// Value `true` if this object is being gazed at, `false` otherwise.
    /// </param>
    private void SetMaterial(bool gazedAt)
    {
        if (InactiveMaterial != null && GazedAtMaterial != null)
        {
            _myRenderer.material = gazedAt ? GazedAtMaterial : InactiveMaterial;
        }
    }

    public void TriggerFadeAndMove()
    {
        StartCoroutine(FadeAndMoveCoroutine());
    }

    private IEnumerator FadeAndMoveCoroutine()
    {
        // Fade to black
        yield return StartCoroutine(FadeToBlack());

        _player.transform.position = _target.transform.position;
        

        // Fade back to clear
        yield return StartCoroutine(FadeToClear());
    }

    private IEnumerator FadeToBlack()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(0, 1, elapsedTime / fadeDuration);
            Color color = blackoutImage.color;
            color.a = alpha;
            blackoutImage.color = color;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the blackout image is fully opaque
        Color finalColor = blackoutImage.color;
        finalColor.a = 1;
        blackoutImage.color = finalColor;
    }

    private IEnumerator FadeToClear()
    {
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            float alpha = Mathf.Lerp(1, 0, elapsedTime / fadeDuration);
            Color color = blackoutImage.color;
            color.a = alpha;
            blackoutImage.color = color;
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        // Ensure the blackout image is fully transparent
        Color finalColor = blackoutImage.color;
        finalColor.a = 0;
        blackoutImage.color = finalColor;
    }

}
