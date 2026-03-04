Culture Revive is a mobile Augmented Reality (AR) application designed to reconnect Nigerian youth with their rich cultural heritage. By bridging the gap between ancient history and modern technology, the app allows users to scan physical "Culture Cards" to reveal 3D ancient artifacts, interactive characters in traditional attire, and immersive oral histories.

Project Links

GitHub Repository: https://github.com/Taiwo1105/CultureRevive/tree/main

Figma Prototype: https://www.figma.com/proto/sxmEOjqY8P9e9CJWRR5gjN/Untitled?page-id=0%3A1&node-id=14-22&p=f&viewport=224%2C256%2C0.4&t=TlJJE36wXfVOaX1b-1&scaling=scale-down&content-scaling=fixed&starting-point-node-id=1%3A2

Demo Video: https://www.loom.com/share/17062688f3ea4e48ae19713d3010622c

 Setup & Environment
 
This project is built using Unity and AR Foundation.

Prerequisites
Unity Version: 2022.3 LTS (or higher)

Global Packages: AR Foundation

ARCore XR Plugin (for Android)

Hardware: An AR-compatible mobile device (Android with ARCore or iOS with ARKit).

Installation Steps

Clone the Repo: 
git clone https://github.com/Taiwo1105/CultureRevive.git

Open in Unity: Launch Unity Hub, click Add, and select the cloned folder.

Configure Build Settings:

Go to File > Build Settings.

Switch platform to Android or iOS.

Ensure XR Plug-in Management is enabled in Project Settings for your specific platform.

Reference Image Library: Navigate to Assets/ARResources/ImageLibrary to add or view the artifact trigger images.

Download apk from play store or it can be sent to your device for a direct installation to the device

Once installed, run the app and start to scan the trigger images which will be given to you to see the 3d models of ancient arifacts of different cultures/tribes.

App link: https://drive.google.com/file/d/1dEXQOK94sVKRIKeIwUBLFpjU8cqXcN2v/view?usp=sharing 

Folder of images to scan: https://drive.google.com/drive/folders/1cG-arlyJU6L4Jz09SNhCloK39W0ZwIoD?usp=sharing 

Deployment Plan

Alpha Testing (Internal): Deploy to local devices via Unity's Build and Run to test tracking stability and audio latency.

Beta Testing (TestFlight/Google Play Console): Share with a small group of Nigerian youth for UX feedback on cultural accuracy.

Production Release: * Android: Release via .aab (Android App Bundle) on Google Play.

Physical Distribution: Print "Culture Cards" as high-quality triggers to be distributed in schools and museums.
