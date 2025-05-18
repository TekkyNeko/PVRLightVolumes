**PVR Light Volumes** | [How to Use](/Documentation/HowToUse.md) | [Best Practices](/Documentation/BestPractices.md) | [Udon Sharp API](/Documentation/UdonSharpAPI.md) | [For Shader Developers](/Documentation/ForShaderDevelopers.md) | [Compatible Shaders](/Documentation/CompatibleShaders.md)
# PVR Light Volumes
PVR Light Volumes is a nextgen voxel based light probes replacement for PoligonVR, which is a fork of VRC Light Volumes. It still retains support for VRC and supports standard Unity!

This is a free open-source asset, so if you like it, **[Support RED_SIM on Patreon](https://www.patreon.com/red_sim/ "Support RED_SIM on Patreon")**.
There is a bunch of other cool assets you will get there!

Check how it works in the demo VRChat world: **[Japanese Alley - VRC Light Volumes Test](https://vrchat.com/home/launch?worldId=wrld_af756ca8-30ee-41a4-b304-2207ebf79db9)**

![](/Documentation/Preview_0.png)

## Use Cases
- Baked partial avatars and dynamic props lighting
- Baked seamless lightmaps for small static objects
- Baked dynamic light sources
- Any Volumetric light effects

## Main Features
- Baked per-pixel voxel based lighting
- Affects avatars and dynamic props (shader integration required)
- Fast and performant
- Can change color in runtime
- Can create cheap dynamic light sources that can be moved in runtime
- Works with dynamic batching, which potentially increases performance
- Works with Bakery or the default Unity Lightmapper
- Very easy and fast to setup
- It just looks beautiful!

## Attribution

It would be greatly appreciated if you include a small note in your VRChat world mentioning that VRC Light Volumes are supported there. This helps users know they can use avatars with Light Volumes compatible shaders and also learn more about the system.

For example, you can include a message like this:

```
This world supports VRC Light Volumes. Use avatar shaders with VRC Light Volumes support for an enhanced visual experience.
VRC Light Volumes by RED_SIM — GitHub: https://github.com/REDSIM/VRCLightVolumes/
```

You're not required to include this message — it's entirely optional. But if you do, it helps spread the word and supports the growth of this asset in the VRChat community.

## Installation with a unity package
1. Make sure you are using the correct unity version for your platform (2022.3.22f1 for VRChat, 2022.3.60f1 for PoligonVR)
2. Go to my Github releases page: https://github.com/TekkyNeko/PVRLightVolumes/releases
3. Download the .unitypackage file of the latest build
4. Drag and drop the file into your Unity project
