using System;

namespace Hobgoblin.Scenes.Abstract
{
    public interface ISceneManager
    {
        IScene CurrentScene { get; }

        void AddScene(string sceneName, IScene scene);
        void SwitchScene(string sceneName, IntPtr window);
    }
}
