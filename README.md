# Nyctophy

Nyctophy is a serious game that integrates VR and smartwatch technology to address nyctophobia (fear of darkness). It provides an alternative to conventional exposure methods by immersing users in controlled dark environments while using real-time heart rate monitoring (via devices like the Xiaomi Mi Band) to adapt the experience. Built in Unity, the game supports Meta Quest 2 and keyboard-mouse inputs, maintaining strong performance (71.9 FPS avg.). User tests (34 participants) revealed longer completion times in VR (8:12 min) compared to desktop (3:54 min), highlighting its immersive nature. As an open-source project, Nyctophy serves as a research tool for exploring VR-based interventions, with room for future improvements in graphics, compatibility, and clinical studies.
## Table of Contents

* [Requirements](#requirements)
* [How to Run the App](#how-to-run-the-app)
* [License](#license)
##
![alt text](https://github.com/ElshadRyan/Nyctophy/blob/VR-Develop/Framework_of_Application.png?raw=true)

Framework of Nyctophy Application

## Requirements

To run **Nyctophy**, you will need the following:

### Software Requirements:

* Unity 2022.3.17f1 or later.
* Meta Quest Link App (for Meta VR device users).
* Smartwatch integration libraries if testing heart rate monitoring.
* HypeRate (to record the heartbeat to the game)
* Zepp Life (connecting the smartwatch and HypeRate app to send the heartbeat data)

### Hardware Requirements:

* VR Device: Tested on Meta Quest 2.
* A VR-ready PC to open and run the app through Meta Quest Link.
* Tested on Xiaomi Mi Band 7.
* Keyboard and mouse (for non-VR mode).

## How to Run the App

To run **Nyctophy**, follow these steps:

### Set up VR Device:

* Ensure your VR headset is properly configured and paired with your PC.
* Install the Meta Quest Link app if using Meta devices.
* Enable developer mode on your VR device for sideloading and testing.

### Connect the VR Device to Your PC:

* Connect via cable or Wi-Fi.
* Ensure the Meta Quest Link detects the device.

### Build the App from Unity:

1. Open the **Nyctophy** project in Unity.
2. Go to `File > Build Settings`.
3. Select the **Android** platform for VR build.
4. Ensure your VR headset is detected by Unity.
5. Click **Build and Run** to deploy the project to the VR headset.

### Run in Non-VR Mode (Keyboard-Mouse):

1. Switch platform to **PC, Mac & Linux Standalone** in Build Settings.
2. Build and run the application for desktop use.
3. Navigate using keyboard and mouse inputs.

### Contact
elshad.ardiyanto@binus.ac.id

## License

This project is licensed under the **Unlicense** — see the [Unlicense Website](https://unlicense.org/) or the UNLICENSE file for details.
