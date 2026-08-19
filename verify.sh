#!/usr/bin/env bash
set -e
dotnet build -o agent_build
dotnet test -o agent_build
