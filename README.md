# Escape ARchives

Escape ARchives is an immersive Augmented Reality (AR) educational game developed for a museum setting. It features gamified interactions, exhibit-based challenges, and a guided sequence that ensures visitors engage with the museum's content meaningfully.

This `README.md` provides a detailed explanation of the C# scripts used in the project.

## Scripts Overview

### 1. `audioManager.cs`
Manages the game's audio system, allowing users to interact with an AR radio to play and select songs.

- **Key Features:**
  - Plays audio clips in sequence (`changeSong` method).
  - Validates the selected song and triggers the appropriate response panels (`selectSong` method).
  - Uses raycasting to detect interaction with AR objects tagged as "radio."
  - Rotates a UI element to mimic a radio knob (`imageRotateBtn` method).
  - Interfaces with the `gameManager` to manage lives and game state.

---

### 2. `imageTargetHandler.cs`
Handles interactions with AR image targets using Vuforia's tracking system.

- **Key Features:**
  - Detects when an AR image target is scanned using Vuforia's `ObserverBehaviour`.
  - Notifies the `sequenceManager` when an image is scanned (`OnTargetStatusChanged` method).
  - Determines which UI panels to display based on the current scene and scanned image (`sceneChecker` method).

---

### 3. `gameManager.cs`
Controls the overall game logic, such as lives, progress, and game state transitions.

- **Key Features:**
  - Manages lives with `deductLife` and `getLives` methods.
  - Tracks the user's progress through game steps (`progressStep` method).
  - Loads specific scenes based on the current step (`loadExhibitScene` method).
  - Displays the game-over panel when lives run out (`gameOver` method).

---

### 4. `raycastManager.cs`
Implements raycasting from the AR camera to detect user interactions with objects.

- **Key Features:**
  - Continuously casts a ray from the camera's center to check for hits.
  - Activates or deactivates the "radio" button based on raycast hits.

---

### 5. `UIManager.cs`
Manages the user interface, including exhibit panels and game state panels.

- **Key Features:**
  - Activates and deactivates UI panels based on the current step (`activatePanel` and `deactivateAllPanels` methods).
  - Interfaces with the `gameManager` to ensure the correct UI is shown.

---

### 6. `sequenceManager.cs`
Controls the sequence of interactions in the game, ensuring that exhibits are visited in the correct order.

- **Key Features:**
  - Tracks the current step and ensures sequence integrity.
  - Interfaces with the `UIManager` to display the appropriate panels for each step.
  - Validates user progress through the game.

---

## Technologies Used

- **Unity Engine**: Used for building the 3D and AR components.
- **Vuforia SDK**: Used for AR image tracking and target recognition.
- **C#**: Programming language for game logic and interactions.

## Gameplay Logic

1. **Starting the Game**:
   - Users begin with a predefined number of lives.
   - The game ensures users follow the correct sequence of exhibits.

2. **Interacting with Exhibits**:
   - Users interact with AR exhibits using the camera's viewport.
   - Correct interactions lead to progression; incorrect ones deduct lives.

3. **Audio Challenges**:
   - Users select songs on a virtual radio and are notified if the selection is correct.

4. **Game Completion**:
   - Once all steps are completed, the game concludes successfully.
   - If lives run out, the game displays a game-over panel.

---

## How to Use

1. Clone or download the project repository.
2. Open the project in Unity.
3. Ensure Vuforia AR is set up and configured with the target images.
4. Attach the scripts to their respective GameObjects in the Unity Editor.
5. Build and deploy the project to an AR-supported mobile device.

---

## Future Enhancements

- Implement AR guides to provide a virtual tour experience.
- Add more exhibits and diversify interactions.
- Optimize UI/UX for a smoother gameplay experience.

---

## Credits

Developed by Ntokozo for the **Escape ARchives** capstone project.
