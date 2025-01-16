# QuasoStudio_BaseArchitecture

Base architecture for an FPS project with a PSX-style aesthetic, designed to streamline game development by providing essential tools and services. This package supports scene transitions, audio management, and various gameplay systems tailored for retro-style FPS games.

---

## 🎮 Features
This package includes the following features:
- **Scene Transitions**: Simplify loading and switching between scenes.
- **Game Manager**: Centralized system for managing game state and global logic.
- **Level Service**: Tools for level-specific events and data management.
- **Spawn Service**: Handles player and NPC spawning logic.
- **Time Service**: Centralized time manipulation (slow motion, pausing, etc.).
- **UI Service**: Simplifies UI updates and interactions.
- **Update Service**: Centralized update system for improved performance.
- **FMOD Integration**: Advanced audio capabilities via FMOD for Unity.

---

## 🛠️ Requirements
To use this package, make sure your project meets the following requirements:
- **Unity Version**: 2021.3.45f1 or higher (LTS recommended).
- **Dependencies**:
  - [Cinemachine](https://docs.unity3d.com/Packages/com.unity.cinemachine@latest) - Smooth camera control.
  - [Input System](https://docs.unity3d.com/Packages/com.unity.inputsystem@latest) - Modern input handling for Unity.
  - [FMOD for Unity](https://assetstore.unity.com/packages/tools/audio/fmod-for-unity-161631) - High-quality audio solution.

---

## 📦 Installation
Follow these steps to include this package in your Unity project:

### Option 1: Recommended Installation via Git URL
To add this package via Git, follow these steps:

1. Open your Unity project.
2. Go to `Window > Package Manager`.
3. In the Package Manager, click the **+** button in the top-left corner and select `Add package from Git URL...`.
4. Enter the following Git URL for this package: https://github.com/YourUsername/QuasoStudio_BaseArchitecture.git
5. Click **Add**. Unity will download and import the package.

For more details, see Unity's guide on [Adding a package from a Git URL](https://docs.unity3d.com/2020.1/Documentation/Manual/upm-ui-giturl.html).

### Option 2: Manual Installation
1. Clone or download this repository to your local machine.
2. Copy the package folder `BaseArchitectureQuasoStudio` into your Unity project's `Packages/` folder.
3. Add the package reference to your `manifest.json` file:

  ```json
  {
      "dependencies": {
          "com.quasostudio.basearchitecture": "file:./Packages/BaseArchitectureQuasoStudio",
          "com.unity.cinemachine": "2.9.7",
          "com.unity.inputsystem": "1.5.1"
      }
  }

## 📜 License
This project is licensed under the MIT License. See the LICENSE.md file for more details.

## 📖 Documentation
Full documentation for this package can be found at:

Online Documentation (replace with the actual link)
Or in the README.md file included in the package.
## ✨ Credits
Author: Alexandre CUXAC
Studio: Quaso Studio
Contact: contact@quasostudio.com
## 🔄 Changelog
See the CHANGELOG.md file for a history of updates and improvements.

## ❤️ Contributions
Contributions are welcome! If you'd like to contribute to this project:

Fork this repository.
Create a feature branch: git checkout -b feature/my-new-feature.
Commit your changes: git commit -m "Add some feature".
Push to the branch: git push origin feature/my-new-feature.
Open a pull request.

## 🛠️ Support
If you encounter any issues or have questions about this package, feel free to open an issue in the GitHub Issues tab (replace with your GitHub issues link).
