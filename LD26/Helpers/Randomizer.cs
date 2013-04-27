using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SFML.Graphics;
using LD26.Entitys;
using LD26.Entitys.Components;
using LD26.Entitys.Components.Scripts;
using LD26.Managers;

namespace LD26.Helpers
{
    class Randomizer
    {
        public static Random Generator { get; set; }

        public static Color Color()
        {
            byte r = (byte)Generator.Next(byte.MinValue, byte.MaxValue);
            byte g = (byte)Generator.Next(byte.MinValue, byte.MaxValue);
            byte b = (byte)Generator.Next(byte.MinValue, byte.MaxValue);
            return new Color(r, g, b, 255);
        }

        public static Color ColorA()
        {
            byte a = (byte)Generator.Next(byte.MinValue, byte.MaxValue);
            var col = Color();
            return new Color(col.R, col.G, col.B, a);
        }

        public static T RandomItem<T>(IEnumerable<T> colection)
        {
            return colection.ElementAtOrDefault(Generator.Next(0, colection.Count()));
        }
    }
}
