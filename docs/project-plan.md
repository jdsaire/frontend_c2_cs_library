# Project Plan

Built for the **Library Management System** final project (Course 2's "You Try It!" Parts 1–4, culminating in the graded capstone).

## Requirements & Objectives

**Functional requirements**
- Store up to five book titles and let a user add a new book to the first open slot.
- Remove a book by title, clearing its slot (and its checked-out status, if any).
- Display the current list of books, skipping empty slots.
- Search for a book by title and report whether it's in the collection.
- Track how many books are currently checked out and cap it at three.
- Flag a book as checked out, and allow the same action to check it back in.
- Loop on a text menu until the user chooses to exit.
- Reject invalid actions and blank titles with a plain-language message instead of crashing.

**Non-functional requirements**
- Stay within the Module 2 scope: variables, control structures, loops, methods, and plain arrays — no classes/OOP modeling, no `List<T>` or other generics, no LINQ, no async, no persistence.
- All state lives in memory for the duration of the run; nothing is saved to disk.

**Objectives**
- Deliver a working console application that satisfies all three graded features of the Course 2 capstone (see [`grading-criteria.md`](grading-criteria.md)).
- Build it as four incremental, approved gates (baseline → debug → refactor → new features), mirroring how the assignment itself is structured across Parts 1–4.

## Design Outline

See [`Course2-LibraryManagementSystem-Flowchart.md`](Course2-LibraryManagementSystem-Flowchart.md) for the preliminary flowchart, drafted before implementation. A final, code-verified flowchart image is a planned follow-up addition, mirroring how the Course 1 capstone's flowchart was added after the fact.

At a high level, the program:
1. Initializes a 5-slot `books` array, a parallel `checkedOut` flag array, and a `borrowedCount` counter, all empty/zero.
2. Loops on a text menu until the user chooses to exit.
3. Routes the chosen action (`add`, `remove`, `search`, `checkout`, `exit`) to its own branch in `Main`, each validating its own input before touching shared state.
4. Displays the current book list after every action except exit.

Parts 1–3 established the baseline (five separate variables → debugged → refactored into an array with extracted helper methods); Part 4 added `search` and the single toggling `checkout` action on top of that base.
