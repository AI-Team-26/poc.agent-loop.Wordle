# TODO

# Completed

- **[feat/01_wordle_judge_cli]** Build WordleJudge — a tiny CLI that scores a Wordle guess against an answer.
  - [x] Step 1 — Scaffold: Create solution + both projects, central package management, trivial Program.cs, smoke test, .gitignore, verify.sh with build check.
  - [x] Step 2 — Core Judge() + unit tests: Implement pure Judge(answer, guess) with correct duplicate-letter handling. NUnit + Unquote tests: all-G, all-dot, basic Y, BOOKS/TOOTS = .GG.G, AAAAA/AAAAB = GGGG., PLEAS/APPLE = YY.YY.

# In Progress

**Branch:** feat/01_wordle_judge_cli
**Goal:** Build WordleJudge — a tiny CLI that scores a Wordle guess against an answer.

## Context / Mental Picture
- C# console app, .NET 10. Layout: `src/WordleJudge/` (app), `tests/WordleJudge.Tests/` (NUnit + Unquote).
- Central package management: `Directory.Build.props` with `<ManagePackageVersionsCentrally>true</ManagePackageVersionsCentrally>` and `Directory.Packages.props` holding ALL versions; project files reference packages WITHOUT a Version attribute.
- Core logic = ONE pure static function, zero IO: `Judge(string answer, string guess)` returning a 5-char pattern: `G` exact match, `Y` right letter wrong position, `.` absent. Use the standard two-pass algorithm (resolve exact matches first, then count remaining letters) so duplicate letters are scored correctly.
- Worked example: ANSWER=`BOOKS`, GUESS=`TOOTS` → `.GG.S`
- `verify.sh` (repo root, executable bash) is a RATCHET: Step 1 creates it with only the build check; every later step APPENDS checks and NEVER removes existing ones.
- All work happens on branch `feat/01_wordle_judge_cli`. Commit AND push after EVERY step.
- All dotnet commands use `-o agent_build` as output folder.

## Steps
- [x] **Step 1 — Scaffold.** Create solution + both projects per layout above, wire central package management, trivial `Program.cs` printing "hello", one smoke test. Create `.gitignore` covering at least: `bin/`, `obj/`, `agent_build/`, `loop.log`, `.LOOP_STOP`. Create `verify.sh` containing only: `set -e` + `dotnet build -o agent_build`. Run `./verify.sh` until green.
- [ ] **Step 3 — CLI wiring.** `Program.cs` takes exactly 2 args (ANSWER GUESS); validate both are 5 uppercase A-Z letters, else stderr message + exit code 2; otherwise print the single pattern line. Append to `verify.sh`: run the built binary with `BOOKS TOOTS` and assert stdout equals `.GG.S`.
- [ ] **Step 4 — Golden-file table.** Add `tests/data/golden.csv` (~15 rows: answer,guess,expected) including several duplicate-letter traps; add a test loading the file asserting `Judge` for every row. Covered by the existing `dotnet test` check in verify.sh — keep it green.
- [ ] **Step 5 — README.md.** What it does, how to run (`dotnet run --project src/WordleJudge -- ANSWER GUESS`), output legend (G/Y/.), two examples including a duplicate-letter case. Append to `verify.sh`: `[ -f README.md ]`.
- [ ] **Step 6 — Finalize & PR.** Run full `./verify.sh` (must be green), ensure `git status` clean, push branch, open PR to main via `gh` (title "WordleJudge CLI"; body: what was built + verify results). Then move this whole block from In Progress to Completed below.

**Notes:**
- BLOCKED protocol: if stuck after ONE honest attempt on a step, write `BLOCKED: <reason>` directly under that step, commit, and stop. Do not spin or retry endlessly.
- DO NOT add: GUI, colored output, word-list validation, extra arguments/options, logging libraries, DI containers. Scope is exactly the six steps above.
- Never copy an expected pattern from program output into a test — derive it by hand first.

# Backlog
(empty)
