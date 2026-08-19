#!/usr/bin/env bash
set -e
dotnet build -o agent_build
dotnet test -o agent_build
# Step 3: CLI wiring — run built binary, expect pattern .GG.G for BOOKS/TOOTS
# (hand-derived: OO exact, trailing S exact; TODO's earlier '.GG.S' was a typo)
out=$(./agent_build/WordleJudge BOOKS TOOTS)
if [ "$out" != ".GG.G" ]; then
  echo "FAIL: expected '.GG.G' but got '$out'" >&2
  exit 1
fi
