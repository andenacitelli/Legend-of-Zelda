# CSE 3902 Game Project Web Port

[live demo](https://mh15.github.io/LoZ)

This extra feature ports our MonoGame 3.7.0 codebase to a web application using [Bridge.Net](https://bridge.net/). This work draws heavily from the [MonoGame Web Demo](https://www.monogame.net/webdemo/) to patch necessary web APIs such as WebGL to the Monogame Codebase.

## Project Structure
- `game-project-web/`- contains a port of the core game, with some changes to support the web platform. An effort is made to keep the `game-project-web` tracking the main `game-project` codebase as much as possible, but no solution for 100% code reuse was found at this time.
  - `bridge.json` - configuration for Bridge.Net. You may need to change `console.enabled`.
- `MonoGame.Framework/` - contains a [heavily modified version](https://github.com/harry-cpp/MonoGame/tree/bridge/MonoGame.Framework) of the MonoGame framework with bindings for Web APIs.

See the [Readme.md](Readme.md#project-structure) for more info.

## Requirements
All requirements listed in the in [Readme.md](Readme.md#requirements), and:
- Chrome or a Chromium based browser
  - Should work in any browser that supports [WebGL 2.0](https://caniuse.com/webgl2), but was tested in Chrome as Bridge.Net provides better error handling in Chrome.

## Building
1. <kbd>right-click</kbd> on the `game-project-web` project in Visual Studio and select "Properties".
2. Navigate to the *Build* tab and add `WEB` to the *compilation symbols* box if it does not already exist. This makes sure code not compatible with the Web port is preprocessed out.
3. Open the `Game1.cs` file in the root of the project.
4. Change the [build configuration](https://docs.microsoft.com/en-us/visualstudio/ide/understanding-build-configurations?view=vs-2019) to *Release* using the menu in the top toolbar.
5. Press <kbd>Ctrl</kbd>-<kbd>B</kbd> to build the project.
6. Navigate to `game-project-web/bin/Release/net47` in the file explorer to see your build output.
7. Open a terminal and start a web server.
   - For the uninitiated: [Big list of http static server one-liners](https://gist.github.com/willurd/5720255)
8. Open your browser!

## Limitations
- Sound is currently not supported.

## References
- [MonoGame Web Demo](https://www.monogame.net/webdemo/)
- [Original forum post](https://community.monogame.net/t/monogame-inside-your-web-browser/10918)
