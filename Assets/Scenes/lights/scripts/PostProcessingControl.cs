using UnityEngine;
using System.Collections;
using UnityEngine.Rendering.PostProcessing;
public class PostEffects: MonoBehaviour {
  public float moveSpeed = 0.15f;
  PostProcessVolume m_Volume;

  LensDistortion lensDistortion;
  ChromaticAberration chromaticAberration;

  void Start() {
    lensDistortion = ScriptableObject.CreateInstance < LensDistortion > ();
    lensDistortion.enabled.Override(true);
    lensDistortion.intensity.Override(-10.0f);
    lensDistortion.intensityX.Override(1.0f);
    lensDistortion.intensityY.Override(1.0f);

    m_Volume = PostProcessManager.instance.QuickVolume(gameObject.layer, 100f, lensDistortion);
  }

  void Update() {
    lensDistortion.centerX.Override(moveSpeed * Mathf.Sin(Time.realtimeSinceStartup));
  }

  void OnDestroy() {
    RuntimeUtilities.DestroyVolume(m_Volume, true, true);
  }
}