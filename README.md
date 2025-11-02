# SL - Steam Locomotive Animation

A fun C# console application that displays an animated ASCII art train moving across your terminal, inspired by the classic Unix `sl` command.

## Features

- Smooth ASCII art animation of a steam locomotive
- Automatic console window sizing (Windows)
- Interactive controls:
  - **ESC** or **Q**: Exit the animation
  - **Spacebar**: Pause/Resume
- Cross-platform compatibility (.NET 8.0)
- Centered vertical positioning
- Optimized rendering for performance

## Requirements

- [.NET 8.0 SDK](https://dotnet.net/download/dotnet/8.0) or later

## Running

```bash
cd src
dotnet run
```

## Configuration

You can customize the animation by modifying the constants in [Program.cs](src/Program.cs):

- `FrameDelay`: Animation speed in milliseconds (default: 80ms)
- `TrainWidth`: Width of the train in characters (default: 85)

## Controls

| Key | Action |
|-----|--------|
| ESC | Exit the animation |
| Q | Exit the animation |
| Spacebar | Pause (press any key to resume) |

## Technical Details

The application uses:
- Console buffer manipulation for smooth rendering
- Frame-based animation loop
- Platform-specific console sizing (Windows)
- String slicing for efficient partial rendering

## Credits

Inspired by the original `sl` (Steam Locomotive) command by Toyoda Masashi.
