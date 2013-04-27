using System.Collections.Generic;
using SFML.Window;
using LD26.Helpers;

namespace LD26.Managers
{
    class InputManager
    {
        #region Singlation
        private static InputManager instance;

        public static InputManager Instance
        {
            get
            {
                return instance ?? (instance = new InputManager());
            }
        }

        private InputManager()
        {
            pressedButtons = new List<Mouse.Button>();
            pressedKeys = new List<Keyboard.Key>();
        }
        #endregion

        private readonly List<Mouse.Button> pressedButtons;
        private readonly List<Keyboard.Key> pressedKeys;

        public Vector2f MousePosition { get; private set; }

        public void Init()
        {
            var window = Global.Window;
            window.MouseMoved += (sender, e) =>
            {
                var pos = Mouse.GetPosition(window);
                MousePosition = new Vector2f(pos.X, pos.Y);
            };
            window.MouseButtonPressed += (sender, args) =>
            {
                if (pressedButtons.Contains(args.Button))
                {
                    pressedButtons.Remove(args.Button);
                }
                pressedButtons.Add(args.Button);
            };
            window.MouseButtonReleased += (sender, args) => pressedButtons.Remove(args.Button);
            window.KeyPressed += (sender, args) =>
            {
                if (pressedKeys.Contains(args.Code))
                {
                    pressedKeys.Remove(args.Code);
                }
                pressedKeys.Add(args.Code);
            };
            window.KeyReleased += (sender, args) => pressedKeys.Remove(args.Code);
        }

        public bool IsButtonHold(Mouse.Button button)
        {
            return pressedButtons.Contains(button);
        }

        public bool IsButtonPressed(Mouse.Button button)
        {
            if (pressedButtons.Contains(button))
            {
                pressedButtons.Remove(button);
                return true;
            }
            return false;
        }

        public bool IsKeyHold(Keyboard.Key key)
        {
            return pressedKeys.Contains(key);
        }

        public bool IsKeyPressed(Keyboard.Key key)
        {
            if (pressedKeys.Contains(key))
            {
                pressedKeys.Remove(key);
                return true;
            }
            return false;
        }
    }
}
