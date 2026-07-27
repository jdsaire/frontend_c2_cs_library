# Plan: C2 Library System Build

## Goal

Build the Course 2 (C#) capstone — a library management system — in `frontend_c2_cs_library`, strictly following the Master Assignment Report's four Parts, one approved gate per Part: baseline (Part 1), debug (Part 2), refactor (Part 3), then the three graded features — search, a 3-book borrowing limit, and a toggling check-out/check-in flag (Part 4). The repo already existed (created earlier, holding only the preliminary flowchart doc) rather than being created fresh this run; it was adopted as the build target rather than recreated.

## Target structure

```
frontend_c2_cs_library/
├── README.md
├── src/
│   └── Program.cs
├── docs/
│   ├── project-plan.md
│   ├── setup-guide.md
│   ├── grading-criteria.md
│   └── Course2-LibraryManagementSystem-Flowchart.md
└── handoff/
    ├── Plan-C2LibrarySystemBuild.md
    └── c2-library-system-build-completion-report.md
```

## Approach

1. Confirm GitHub access, .NET file-based `dotnet run` support, and all required attachments (Master Assignment Report, Syllabus, preliminary flowchart) before writing anything.
2. Confirm `frontend_c2_cs_library` already existed rather than being greenfield; adopt it rather than recreate it, keeping its one pre-existing commit as history predating the gate workflow.
3. Build Part 1 (five string variables, add/remove/display/loop, invalid-action handling) from the report's own steps — no verbatim starter code exists for this Part. Commit, explain, stop for approval.
4. Build Part 2 from the report's verbatim "Starting Code with Errors," fixing exactly its three documented bugs: fullness check before add, null-safe display, case-insensitive action. Commit, explain, stop for approval.
5. Build Part 3 from the report's verbatim "Starting Code to Input into Copilot," refactoring the five variables into a `string[5]` array, extracting helper methods for the repeated scan/display logic, keeping case-insensitive action handling, improving input validation. Commit, explain, stop for approval.
6. Build Part 4 using the design confirmed in `Course2-LibraryManagementSystem-Flowchart.md`: add `search` and a single toggling `checkout` action (checks a book out if available and under the 3-book cap, checks it back in if already out), with a parallel `checkedOut` array and a `borrowedCount` counter. Commit, explain, stop for approval.
7. Verify with `dotnet run src/Program.cs` (zero errors/warnings) and manual walkthroughs of search, the borrow-limit cap, and the check-in/re-checkout toggle.
8. Add explanatory comments across `Program.cs` — deferred until after all four gates, per direct instruction — then commit separately.
9. Write and commit documentation mirroring `frontend_c1_cs_stock`'s live doc shape: root `README.md`; `docs/project-plan.md`, `docs/setup-guide.md`, `docs/grading-criteria.md`; relocate the existing root-level flowchart doc into `docs/`.
10. Archive this plan and a completion report into `handoff/`.

## Constraints held throughout

- Module 2 scope ceiling: no custom classes beyond `LibraryManager`, no `List<T>`/generics, no LINQ, no async, no persistence.
- No `LICENSE`, no `.gitignore`, no `.csproj` — mirrors `frontend_c1_cs_stock`'s current live state deliberately.
- Single author on every commit (`Juan Diego S.`, matching this repo's own established identity), no co-author trailers, no AI-tool attribution in any commit message or file.
- Pushed directly to `main` on every gate, no pull request, no subagents.
- No later Part's code drafted before its preceding gate was explicitly approved.
