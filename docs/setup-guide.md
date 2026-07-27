# Setup Guide (Beginner-Friendly)

You don't need any prior experience with GitHub, code editors, or programming to get this running. Follow these steps in order.

## 1. Download the code

You don't need to install Git or know any Git commands.
1. Click the green **Code** button at the top of this repository's GitHub page.
2. Choose **Download ZIP**.
3. Find the downloaded ZIP file (usually in your Downloads folder) and unzip/extract it. You'll get a folder named `frontend_c2_cs_library-main`.

## 2. Install the tools you need

This program is written in C#, a language that runs on Microsoft's **.NET** platform.
1. Install the **.NET SDK** (free): https://dotnet.microsoft.com/download — pick the latest version for your operating system and run the installer. Version 10 or later is required, since this project runs directly from a single `.cs` file without a project file.
2. Install **Visual Studio Code** (free — this is the code editor): https://code.visualstudio.com/
3. Open Visual Studio Code, click the Extensions icon in the left sidebar (four squares), search for **"C# Dev Kit"**, and click **Install**.

## 3. Open the project

1. Open Visual Studio Code.
2. Go to **File → Open Folder…** and select the `frontend_c2_cs_library-main` folder you unzipped in Step 1.
3. In the file explorer on the left, open the `src` folder and click `Program.cs`.

## 4. Run the program

1. In Visual Studio Code: **Terminal → New Terminal**.
2. Type and press Enter:
   ```
   dotnet run src/Program.cs
   ```

A terminal panel opens inside VS Code with the program running. See the main [README](../README.md#how-to-use-it) for how to use the menu once it's up.
