using System;
using System.Collections.Generic;

using Hobgoblin.Scenes.Abstract;

namespace Hobgoblin.Scenes.Concrete
{
    public class SceneManager : ISceneManager
    {
        public IScene CurrentScene { get; private set; }

        private Dictionary<String, IScene> scenes;

        public SceneManager()
        {
            scenes = new Dictionary<string, IScene>();
        }

        public void AddScene(string sceneName, IScene scene)
        {
            scenes[sceneName] = scene;
        }

        public void SwitchScene(string sceneName, IntPtr window)
        {
            var oldScene = CurrentScene;
            CurrentScene = scenes[sceneName];
            CurrentScene.Load(window);
            oldScene.UnLoad();
        }
    }
}
