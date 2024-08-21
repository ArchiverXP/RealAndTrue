using BepInEx;
using BepInEx.Logging;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using HarmonyLib;

namespace RealAndTrue
{
    [BepInPlugin("com.archiverxp.nitwff", MyPluginInfo.PLUGIN_NAME, MyPluginInfo.PLUGIN_VERSION)]
    public class Plugin : BaseUnityPlugin
    {
        internal static new ManualLogSource Logger;
        Global global;
        GameObject[] entityC;
        GameObject entityI;
        Character spriteRend;
        Transform quid;
        
        private void Awake()
        {
            // Plugin startup logic
            Logger = base.Logger;
            Logger.LogInfo($"Plugin {MyPluginInfo.PLUGIN_GUID} is loaded!");

            AssetBundle mario_b2 = AssetBundle.LoadFromFile(Path.Combine(Paths.PluginPath, "RealAndTrue/Assets/mae"));
            AssetBundle bundle = AssetBundle.LoadFromFile(Path.Combine(Paths.PluginPath, "RealAndTrue/Assets/bfdi"));
            string[] scenePath = bundle.GetAllScenePaths();
            SceneManager.LoadScene(scenePath[0]);
            mario_b2.LoadAllAssets();

            var bower = GameObject.Find("CameraBlack");
            GameObject.DestroyImmediate(bower);


        }


        void Start()
        {
            Scene SML = SceneManager.GetActiveScene();
            Global.screenTransitioner.WipeLeftIn(1f);

            entityC = GameObject.FindGameObjectsWithTag("Bounds");
            foreach(GameObject test33 in entityC)
            {
                var testy = test33.AddComponent<Entity>();
                testy.type = Entity.Type.Obstruction;
                test33.layer = 9;
                testy.CollideAll(Entity.Type.Player);
                var toad = test33.AddComponent<BoxCollider>();
                var matt = new BoundingBox();
                testy.CollideBox(matt);
            }
            if (entityC.Length == 0)
            {
                Console.WriteLine("oops");
            }

            entityI = GameObject.FindGameObjectWithTag("Snowman");
            entityI.AddComponent<SceneRoot>();
            
            Global.InitScene();
            Global.InitPlayerAtSceneLink();
            RenderSettings.ambientLight = Color.white;






        }
    }
}
