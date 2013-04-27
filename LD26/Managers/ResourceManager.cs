using System;
using System.Collections.Generic;
using System.IO;
using SFML.Audio;
using SFML.Graphics;

namespace LD26.Managers
{
    class ResourceManager
    {
        #region Singlation
        private static ResourceManager instance;

        public static ResourceManager Instance
        {
            get
            {
                return instance ?? (instance = new ResourceManager());
            }
        }

        private ResourceManager()
        {
        }
        #endregion
        private readonly Dictionary<string, Image> loadedImages = new Dictionary<string, Image>();
        private readonly Dictionary<string, Texture> loadedTextures = new Dictionary<string, Texture>();
        private readonly Dictionary<string, Font> loadedFonts = new Dictionary<string, Font>();
        private readonly Dictionary<string, Music> loadedMusic = new Dictionary<string, Music>();
        private readonly Dictionary<string, Sound> loadedSounds = new Dictionary<string, Sound>();
        private readonly Dictionary<string, SoundBuffer> loadedBuffers = new Dictionary<string, SoundBuffer>();
        private readonly Dictionary<string, string> loadedFiles = new Dictionary<string, string>();

        public IEnumerable<float> LoadAll()
        {
            var resources = new List<IEnumerable<float>>
            {
                Load<Texture>(@"Resources\Textures"),
                Load<Font>(@"Resources\Fonts"),
                Load<Music>(@"Resources\Music"),
                Load<Sound>(@"Resources\Sounds"),
                Load<string>(@"Resources\Textfiles"),
            };

            float progress = 0;
            foreach (var resource in resources)
            {
                foreach (var percent in resource)
                {
                    yield return progress + percent / resources.Count;
                }
                progress += 1f / resources.Count;
            }
        }

        private IEnumerable<float> Load<T>(string path)
        {
            var files = Directory.GetFiles(path);
            for (var i = 0; i < files.Length; i++)
            {
                var file = files[i];
                var name = Path.GetFileName(file);
                if (name == null)
                    throw new Exception("Invalid filename " + file);
                if (typeof(T) == typeof(Image) || typeof(T) == typeof(Texture))
                {
                    if (!loadedImages.ContainsKey(name) && !loadedTextures.ContainsKey(name))
                    {
                        loadedImages.Add(name, new Image(file));
                        loadedTextures.Add(name, new Texture(loadedImages[name]));
                    }
                }
                else if (typeof(T) == typeof(Font))
                {
                    if (!loadedFonts.ContainsKey(name))
                    {
                        Font font = new Font(file);
                        loadedFonts.Add(name, font);
                    }
                }
                else if (typeof(T) == typeof(Music))
                {
                    if (!loadedMusic.ContainsKey(name))
                    {
                        Music mus = new Music(file);
                        loadedMusic.Add(name, mus);
                    }
                }
                else if (typeof(T) == typeof(SoundBuffer) || typeof(T) == typeof(Sound))
                {
                    if (!loadedBuffers.ContainsKey(name) && !loadedSounds.ContainsKey(name))
                    {
                        SoundBuffer sb = new SoundBuffer(file);
                        Sound s = new Sound(sb);
                        loadedBuffers.Add(name, sb);
                        loadedSounds.Add(name, s);
                    }
                }
                else if(typeof(T) == typeof(string))
                {
                    using (StreamReader reader = new StreamReader(file))
                    {
                        var str = reader.ReadToEnd();
                        loadedFiles.Add(name, str);
                    }
                }
                else
                {
                    throw new ArgumentException(String.Format("{0} is not a valid resource type", typeof(T)));
                }
                yield return (float)(i + 1) / files.Length;
            }
        }

        public T Get<T>(string name) where T : class
        {
            if (typeof(T) == typeof(Image) && loadedImages.ContainsKey(name))
                return loadedImages[name] as T;
            if (typeof(T) == typeof(Texture) && loadedTextures.ContainsKey(name))
                return loadedTextures[name] as T;
            if (typeof(T) == typeof(Font) && loadedFonts.ContainsKey(name))
                return loadedFonts[name] as T;
            if (typeof(T) == typeof(Music) && loadedMusic.ContainsKey(name))
                return loadedMusic[name] as T;
            if (typeof(T) == typeof(Sound) && loadedSounds.ContainsKey(name))
                return loadedSounds[name] as T;
            if (typeof(T) == typeof(SoundBuffer) && loadedBuffers.ContainsKey(name))
                return loadedBuffers[name] as T;
            if(typeof(T) == typeof(string) && loadedFiles.ContainsKey(name))
                return loadedFiles[name] as T;

            throw new ArgumentException(String.Format("{0} is not a valid resource type", typeof(T)));
        }
    }
}
