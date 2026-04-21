## Player Movement (2D) - Unity

This is a simple 2D player movement system made in Unity using C#.

## Features

* WASD movement
* Run system (hold Shift)
* Roll / dodge system (press Space)
* Roll cooldown system
* Smooth movement using deltaTime

## How it works

Movement is handled using direction vectors, with normalization to prevent faster diagonal movement.

The roll system is based on:

* A timer (`RollTime`)
* A cooldown (`RollCooldown`)
* A state system (`IsRolling`)

While rolling, normal movement is temporarily disabled to ensure consistent behavior.

## Controls

* W A S D → Move
* Shift → Run
* Space → Roll / Dodge

## What I learned

* Vector-based movement and normalization
* Using deltaTime for consistent movement
* State systems (like IsRolling)
* Timers and cooldown logic
* Structuring basic gameplay systems

This is one of my first gameplay systems while learning Unity and C#.

