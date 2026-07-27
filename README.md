# Library Management System — Console App

A C# console application for managing a small library's book collection: add books, remove them, search by title, and check books in and out — all from a simple text menu, capped at three books borrowed at once.

## What is this project?

A console-based library management system, built as the Course 2 capstone for the Coursera Microsoft Front-End Developer Professional Certificate. It tracks up to five books in memory and lets a user add, remove, search, and check out/check in books through a text menu, with input validation and a borrowing limit enforced throughout.

New to coding or GitHub? [`docs/setup-guide.md`](docs/setup-guide.md) walks through downloading, installing, and running this program from scratch — no prior experience assumed.

## How to Use It

Once running, you'll see:

```
Would you like to add or remove a book? (add/remove/exit)
```

Type an action and press **Enter**:

| Type | Action | What happens |
|---|---|---|
| `add` | **Add** | Enter a title to add it to the first open slot (up to 5 books). |
| `remove` | **Remove** | Enter a title to remove it from the collection. |
| `search` | **Search** | Enter a title to check whether it's in the collection. |
| `checkout` | **Check out / check in** | Enter a title — checks it out if available (max 3 borrowed at once), or checks it back in if it's already out. |
| `exit` | **Exit** | End the program. |

The program re-prints the current book list after every action, and gives a plain-language message instead of crashing on a blank title, a full library, or exceeding the 3-book borrowing limit.

## Tech Stack

- **Language:** C#
- **Platform:** .NET (console application, file-based execution — no `.csproj`)
- **Editor used for development:** Visual Studio Code
- **AI coding assistant used for development (per assignment requirements):** Microsoft Copilot

## Documentation

- [`docs/setup-guide.md`](docs/setup-guide.md) — beginner walkthrough: download, install, run.
- [`docs/project-plan.md`](docs/project-plan.md) — requirements, objectives, design outline.
- [`docs/grading-criteria.md`](docs/grading-criteria.md) — how each of the 15 grading points is satisfied in the code.
- [`docs/Course2-LibraryManagementSystem-Flowchart.md`](docs/Course2-LibraryManagementSystem-Flowchart.md) — preliminary design flowchart (a final, code-verified flowchart image is a planned follow-up).

## Course Attribution

Built as the Course 2 capstone project for the Coursera **Microsoft Front-End Developer** Professional Certificate. Per the assignment's own instructions, Microsoft Copilot was used as the AI coding assistant for writing, debugging, and optimizing the code.
