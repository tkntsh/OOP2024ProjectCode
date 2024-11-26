# Escape ARchives

Escape ARchives is an immersive Augmented Reality educational game developed for a museum setting. It features gamified interactions, exhibit-based challenges, and a guided sequence that ensures visitors engage with the museum's content.

This `README.md` provides a detailed explanation of the C# scripts used in the project.

## Scripts Overview

### 1. `audioManager.cs`
Manages the game's audio system, allowing users to interact with an AR radio to play and select songs

- **Key Features:**
  - plays audio clips in sequence (`changeSong()` method)
  - validates the selected song and triggers the appropriate response panels (`selectSong()` method)
  - uses raycasting to detect interaction with AR objects tagged as "radio"
  - rotates a UI element to mimic a radio knob (`imageRotateBtn()` method)
  - interfaces with the `gameManager` to manage lives and game state

---

### 2. `imageTargetHandler.cs`
Handles interactions with AR image targets using Vuforia's tracking system

- **Key Features:**
  - detects when an AR image target is scanned using Vuforia's `ObserverBehaviour`
  - notifies the `sequenceManager` when an image is scanned (`OnTargetStatusChanged()` method)
  - determines which UI panels to display based on the current scene and scanned image (`sceneChecker()` method)

---

### 3. `gameManager.cs`
Controls the overall game logic, such as lives, progress, and game state transitions

- **Key Features:**
  - manages lives with `deductLife()` and `getLives()` methods
  - tracks the user's progress through game steps (`progressStep()` method)
  - loads specific scenes based on the current step (`loadExhibitScene()` method)
  - displays the game-over panel when lives run out (`gameOver()` method)

---

### 4. `raycastManager.cs`
Implements raycasting from the AR camera to detect user interactions with objects

- **Key Features:**
  - continuously casts a ray from the camera's center to check for hits
  - activates or deactivates the "radio" button based on raycast hits

---

### 5. `UIManager.cs`
Manages the user interface, including exhibit panels and game state panels.

- **Key Features:**
  - activates and deactivates UI panels based on the current step (`activatePanel()` and `deactivateAllPanels()` methods)
  - interfaces with the `gameManager` to ensure the correct UI is shown

---

### 6. `sequenceManager.cs`
Controls the sequence of interactions in the game, ensuring that exhibits are visited in the correct order

- **Key Features:**
  - tracks the current step and ensures sequence integrity
  - interfaces with the `UIManager` to display the appropriate panels for each step
  - validates user progress through the game

---

## Technologies Used

- **Unity Engine**: Used for building the 3D and AR components
- **Vuforia SDK**: Used for AR image tracking and target recognition
- **C#**: Programming language for game logic and interactions
- **Autodesk 3ds Max**: Used for 3D modeling last (two flags) exhibit
- **Adobe Photoshop** Used for 2D modeling images used in UI

## Gameplay Logic

1. **Starting the Game**:
   - user begins with a predefined number of lives for each question
   - the game ensures users follow the correct sequence of exhibits

2. **Interacting with Exhibits**:
   - user interacts with AR exhibits using the camera's viewport
   - correct interactions lead to progression; incorrect ones deduct lives

3. **Audio Challenge**:
   - user chooses betweem different songs on a virtual radio and is notified if the selection is correct

4. **Game Completion**:
   - once all steps are completed, the game concludes successfully
   - if lives run out, the game displays a game-over panel and has to quit the game and start from the beginning

---

## How to Use

1. Clone or download the project repository.
2. Open the project in Unity.
3. Ensure Vuforia AR is set up and configured with the target images.
4. Attach the scripts to their respective GameObjects in the Unity Editor.
5. Build and deploy the project to an AR-supported mobile device.
6. Or download off Google Site: Link [https://sites.google.com/d/1XAjVCQZsU2lkvm7UHBmZUySEtrQVU01T/p/1le7NF10JbSwLim7dfXm3Kt4A63fdek64/edit].

---

## Future Enhancements

- implement AR virtual character (slave) to provide a faint virtual tour guide
- add more exhibits and diversify interactions
- optimize UI/UX for a smoother gameplay experience

---

## Credits

Developed by Ntokozo Ntshangase (Email: [ntokntshangase@gmail.com]) for the **Escape ARchives** capstone project.
