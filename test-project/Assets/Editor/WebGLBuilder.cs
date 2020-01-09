using UnityEditor;

namespace UnityBuilder
{
    class WebGLBuilder
    {
        static void build()
        {
            string[] scenes =
            {
            @"Assets\Scenes\Game.unity"
        };

            BuildPipeline.BuildPlayer(scenes, "WebGL-Dist", BuildTarget.WebGL, BuildOptions.None);
        }
    }
}