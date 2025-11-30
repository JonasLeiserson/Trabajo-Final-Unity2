using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Rendering.PostProcessing;

public class PostProcesingScriptManagerTilin : MonoBehaviour
{
    DepthOfField depthOfField;
    Vignette vignette;
    LensDistortion lensDistortion;
    ChromaticAberration chromaticAberration;
    PostProcessVolume volume;
    public Slider sliderAgua;
    [Range(0, 100)]
    public float agua = 100;  

    void Start()
    {
        sliderAgua.value = agua;
        volume = FindObjectOfType<PostProcessVolume>();
        StartCoroutine(Sed());

        volume.profile.TryGetSettings(out depthOfField);
        volume.profile.TryGetSettings(out vignette);
        volume.profile.TryGetSettings(out lensDistortion);
        volume.profile.TryGetSettings(out chromaticAberration);
    }

    void Update()
    {
        sliderAgua.value = agua;
        float t = 1f - (agua / 100f);

      
        if (depthOfField != null)
        {
            depthOfField.aperture.value = Mathf.Lerp(16f, 0.5f, t);
            depthOfField.focusDistance.value = Mathf.Lerp(10f, 0.3f, t);
        }

      
        if (vignette != null)
        {
            vignette.intensity.value = Mathf.Lerp(0f, 0.55f, t);
        }

      
        if (lensDistortion != null)
        {
            lensDistortion.intensity.value = Mathf.Lerp(0f, -85f, t);
        }

        
        if (chromaticAberration != null)
        {
            chromaticAberration.intensity.value = Mathf.Lerp(0f, 1.2f, t);
        }
    }
    IEnumerator Sed()
    {
        while (true)
        {
            yield return new WaitForSeconds(1.5f);
            agua -= 1f;
            if (agua <= 0f)
            {
                agua = 0f;
            }
        }
    }
}
