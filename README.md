# unyrift
Basic Unity project showing how to use the Oculus Rift

## getting started
 * Install the Oculus driver: https://www3.oculus.com/en-us/setup/
 * After running the setup go to Oculus -> Settings -> General and enable "Unknown Sources" (see https://www.howtogeek.com/259404/how-to-play-steamvr-games-and-use-other-non-oculus-store-apps-on-the-oculus-rift/)
 * Start a fresh Unity project
 * Download the unity utilities: https://developer.oculus.com/downloads/package/oculus-utilities-for-unity-5/
 * Extract the file and doubleclick the OculusUtilities.unitypackage file to import it into your open Unity project
 
 * In unity create an empty game object, name it OVRManager and add the scrip OVRManager.cs (hit `Add Component` in the inspector,then type OVRManager)
 
 
### Avatar SDK
 * Download the Avatar SDK: https://developer.oculus.com/downloads/package/oculus-avatar-sdk/
 * Extract the file and import OVRAvatarSDK/Unity/OvrAvatar.unityPackage into your Unity project (may take a while)
 * Create a new App with your Oculus Account: https://dashboard.oculus.com/my-apps/838163239655810
 * Copy the APP ID to unity -> Oculus Avatars -> Edit Configuration -> Oculus Rift App Id (in the inspector window)
 
