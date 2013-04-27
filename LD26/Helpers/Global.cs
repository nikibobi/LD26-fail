using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Window;
using SFML.Graphics;

namespace LD26.Helpers
{
    static class Global
    {
        public static RenderWindow Window { get; set; }

        public static Vector2f Screen
        {
            get { return new Vector2f(Window.Size.X, Window.Size.Y); }
        }
    }
}
