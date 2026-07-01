# ⬡ IL2CPP Recovery Studio

> **A futuristic neon-themed desktop tool for extracting, analysing and reverse-engineering Unity Android APK / XAPK files.**

---

## 🖥️ What does this app do?

You drop an APK or XAPK file into the app, tick the operations you want, press **Run** — and everything happens automatically:

| Operation | What it does |
|---|---|
| Extract APK/XAPK | Unzips the package into raw folders |
| Extract Unity Assets | Exports textures, audio, scenes using UnityPy |
| Parse IL2CPP Metadata | Copies `global-metadata.dat` + `libil2cpp.so` for further analysis |
| Decompile to Smali | Runs `apktool` to produce readable Smali source code |
| Generate HTML Report | Creates a pretty `report.html` summary of all outputs |

Files that already exist are **automatically skipped** — so re-runs are safe and fast.

---

## ✅ Requirements

| Tool | Version | Download |
|---|---|---|
| **Python** | 3.10 or newer | https://www.python.org/downloads/ |
| **Git** *(optional)* | any | https://git-scm.com/ |
| **apktool** *(optional)* | any | https://apktool.org |

All Python libraries (customtkinter, UnityPy, Pillow, requests) are installed **automatically** when you launch the app.

---

## 🚀 Step-by-Step: Run from Source (No EXE needed)

### Step 1 — Install Python

1. Open https://www.python.org/downloads/
2. Download the latest **Python 3.10+** installer for Windows
3. Run the installer — **tick "Add Python to PATH"** before clicking Install
4. Open a terminal (`Win + R` → type `cmd` → Enter) and run:
   ```
   python --version
   ```
   You should see `Python 3.10.x` or higher.

### Step 2 — Download this repository

**Option A — with Git (recommended):**
```bash
git clone https://github.com/mo7amedabdulahad-bit/APK-reconstruction.git
cd APK-reconstruction
```

**Option B — without Git:**
1. Click the green **Code** button on GitHub → **Download ZIP**
2. Extract the ZIP anywhere on your PC
3. Open the extracted folder

### Step 3 — Launch the app

Double-click `launch.bat`  
*or* open a terminal inside the folder and run:
```bash
python launch.py
```

The launcher will:
- Check your Python version
- Auto-install all required packages
- Open the futuristic neon GUI

> **First launch may take 30–60 seconds** while packages download.

### Step 4 — Use the app

1. **Click the purple drop zone** and select your `.apk` or `.xapk` file
2. (Optional) Click **Browse Output…** to choose where results are saved
3. **Tick the operations** you want — each one has a description
4. Click **▶ RUN ANALYSIS**
5. Watch the live log on the right — green = success, yellow = warning, red = error
6. When complete, read the **Results & Next Steps** panel
7. Click **📁 Open Output Folder** to see all extracted files

---

## 🛠️ Build a standalone .EXE (Windows)

If you want a double-clickable `.exe` that works **without Python installed**:

```bash
python build_exe.py
```

This script:
1. Installs PyInstaller automatically
2. Builds the EXE into `dist/IL2CPP_Recovery_Studio.exe`
3. Tells you exactly where the file is

> Building takes 1–3 minutes. The output EXE is portable — just copy it.

---

## 🔄 Auto-update

To pull the latest changes from GitHub before launching:
```bash
python launch.py --update
```

---

## 📁 Output folder structure

After running, your output folder contains:

```
your_app_output/
├── raw/                  ← Unzipped APK contents
│   └── base_extracted/   ← (XAPK only) inner APK contents
├── unity_assets/
│   ├── Texture2D/        ← PNG textures
│   ├── AudioClip/        ← Audio files
│   └── TextAsset/        ← Text / JSON data
├── il2cpp_meta/
│   ├── global-metadata.dat
│   └── libil2cpp.so
├── smali/                ← (if apktool used)
└── report.html           ← Open this in your browser!
```

---

## ❓ Troubleshooting

| Problem | Solution |
|---|---|
| `python` not recognised | Re-install Python with "Add to PATH" ticked |
| `ModuleNotFoundError` | Run `pip install customtkinter UnityPy Pillow requests` |
| `apktool` not found | Download from https://apktool.org and add to PATH |
| App opens but GUI is blank | Make sure you have Python 3.10+ (not 3.9 or below) |
| XAPK says no APK inside | Some XAPK files use split APKs — check the `raw/` folder |

---

## 📜 Licence

This project is for educational and research purposes only.  
Do not use it to reverse-engineer apps you do not own or have permission to analyse.

---

*Made with ⬡ by IL2CPP Recovery Studio contributors*
