using System;
using System.IO;
using static Retyped.dom;

//namespace BridgeGameProject
namespace game_project
{
    public class App
    {
        private static Game1 _game;

        public static void Main()
        {
            var canvas = new HTMLCanvasElement();
            canvas.width = 800;
            canvas.height = 480;
            canvas.id = "monogamecanvas";

            var button = new HTMLButtonElement();
            button.innerHTML = "Run Game";

            document.body.appendChild(canvas);
            document.body.appendChild(button);

            document.body.style.background = "#121212";

            button.onclick = (ev) =>
            {
                //window.setTimeout((e) =>
                //{
                _game = new Game1();
                _game.Run();
                //}, 1f);
            };
        }
    }
}
