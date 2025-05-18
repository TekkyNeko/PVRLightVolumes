﻿using UnityEngine;
#if PVR_CCK_WORLDS
using PVR.PSharp;
#endif

namespace VRCLightVolumes {
#if PVR_CCK_WORLDS
    public class LightVolumeInstance : PSharpBehaviour {
#else
    public class LightVolumeInstance : MonoBehaviour { 
#endif
        [Tooltip("Changing the color is useful for animating Additive volumes. You can even control the R, G, B channels separately this way.")]
        [ColorUsage(showAlpha: false, hdr: true)]
        public Color Color = Color.white;
        [Tooltip("Defines whether this volume can be moved in runtime. Disabling this option slightly improves performance. You can even change it in runtime.")]
        public bool IsDynamic = false;
        [Tooltip("Additive volumes apply their light on top of others as an overlay. Useful for movable lights like flashlights, projectors, disco balls, etc. They can also project light onto static lightmapped objects if the surface shader supports it.")]
        public bool IsAdditive = false;
        [Tooltip("Inverse rotation of the pose the volume was baked in. Automatically recalculated for dynamic volumes with auto-update, or manually via the UpdateRotation() method.")]
        public Quaternion InvBakedRotation = Quaternion.identity;
        [Space]
        [Tooltip("Min bounds of Texture0 in 3D atlas space.")]
        public Vector4 BoundsUvwMin0 = new Vector4();
        [Tooltip("Min bounds of Texture1 in 3D atlas space.")]
        public Vector4 BoundsUvwMin1 = new Vector4();
        [Tooltip("Min bounds of Texture2 in 3D atlas space.")]
        public Vector4 BoundsUvwMin2 = new Vector4();
        [Space]
        [Tooltip("Max bounds of Texture0 in 3D atlas space.")]
        public Vector4 BoundsUvwMax0 = new Vector4();
        [Tooltip("Max bounds of Texture1 in 3D atlas space.")]
        public Vector4 BoundsUvwMax1 = new Vector4();
        [Tooltip("Max bounds of Texture2 in 3D atlas space.")]
        public Vector4 BoundsUvwMax2 = new Vector4();
        [Space]
        [Tooltip("Inversed edge smoothing in 3D atlas space. Recalculates via SetSmoothBlending(float radius) method.")]
        public Vector4 InvLocalEdgeSmoothing = new Vector4();
        [Tooltip("Inversed TRS matrix of this volume that transforms it into the 1x1x1 cube. Recalculates via the UpdateRotation() method.")]
        public Matrix4x4 InvWorldMatrix = Matrix4x4.identity;
        [Tooltip("Current volume's rotation matrix row 0 relative to the rotation it was baked with. Mandatory for dynamic volumes. Recalculates via the UpdateRotation() method.")]
        public Vector3 RelativeRotationRow0 = Vector3.zero;
        [Tooltip("Current volume's rotation matrix row 1 relative to the rotation it was baked with. Mandatory for dynamic volumes. Recalculates via the UpdateRotation() method.")]
        public Vector3 RelativeRotationRow1 = Vector3.zero;
        [Tooltip("True if there is any relative rotation. No relative rotation improves performance. Recalculated via the UpdateRotation() method.")]
        public bool IsRotated = false;

        // Calculates and sets invLocalEdgeBlending
        public void SetSmoothBlending(float radius) {
            Vector3 scl = transform.lossyScale;
            InvLocalEdgeSmoothing = new Vector4(scl.x, scl.y, scl.z, 0) / Mathf.Max(radius, 0.00001f);
        }
        // Recalculates inv TRS matrix and Relative L1 rotation
        public void UpdateRotation() {
            InvWorldMatrix = Matrix4x4.TRS(transform.position, transform.rotation, transform.lossyScale).inverse;
            Quaternion rot = transform.rotation * InvBakedRotation;
            IsRotated = Quaternion.Dot(rot, Quaternion.identity) < 0.999999f;

            Matrix4x4 m = Matrix4x4.Rotate(rot);

            RelativeRotationRow0 = new Vector4(m.m00, m.m01, m.m02, 0f);
            RelativeRotationRow1 = new Vector4(m.m10, m.m11, m.m12, 0f);

        }

    }
}