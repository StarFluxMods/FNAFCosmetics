using System.IO;
using KitchenLib;
using KitchenLib.Logging;
using KitchenLib.Logging.Exceptions;
using KitchenMods;
using System.Linq;
using System.Reflection;
using Kitchen;
using KitchenData;
using KitchenFNAFCosmetics.Customs.Cosmetics;
using KitchenLib.Interfaces;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenFNAFCosmetics
{
    public class Mod : BaseMod, IAutoRegisterAll
    {
        public const string MOD_GUID = "com.starfluxgames.fnafcosmetics";
        public const string MOD_NAME = "FNAF Cosmetics";
        public const string MOD_VERSION = "0.1.0";
        public const string MOD_AUTHOR = "StarFluxGames";
        public const string MOD_GAMEVERSION = ">=1.1.4";

        public static AssetBundle Bundle;
        public static KitchenLogger Logger;

        public Mod() : base(MOD_GUID, MOD_NAME, MOD_AUTHOR, MOD_VERSION, MOD_GAMEVERSION, Assembly.GetExecutingAssembly()) { }

        protected override void OnInitialise()
        {
            Logger.LogWarning($"{MOD_GUID} v{MOD_VERSION} in use!");
            x(PrefabSnapshot.GetCosmeticSnapshot(GDOUtils.GetCustomGameDataObject<BonnieHat>().GameDataObject as PlayerCosmetic), "BonnieHat");
            x(PrefabSnapshot.GetCosmeticSnapshot(GDOUtils.GetCustomGameDataObject<ChicaHat>().GameDataObject as PlayerCosmetic), "ChicaHat");
            x(PrefabSnapshot.GetCosmeticSnapshot(GDOUtils.GetCustomGameDataObject<CupcakeHat>().GameDataObject as PlayerCosmetic), "CupcakeHat");
            x(PrefabSnapshot.GetCosmeticSnapshot(GDOUtils.GetCustomGameDataObject<FoxyHat>().GameDataObject as PlayerCosmetic), "FoxyHat");
            x(PrefabSnapshot.GetCosmeticSnapshot(GDOUtils.GetCustomGameDataObject<FreddyHat>().GameDataObject as PlayerCosmetic), "FreddyHat");
        }

        protected override void OnUpdate()
        {
        }

        protected override void OnPostActivate(KitchenMods.Mod mod)
        {
            Bundle = mod.GetPacks<AssetBundleModPack>().SelectMany(e => e.AssetBundles).FirstOrDefault() ?? throw new MissingAssetBundleException(MOD_GUID);
            Logger = InitLogger();
        }

        private void x(Texture2D texture, string name)
        {
            byte[] bytes = texture.EncodeToPNG();
            var dirPath = Application.dataPath + "/../SaveImages/";
            if(!Directory.Exists(dirPath)) {
                Directory.CreateDirectory(dirPath);
            }
            File.WriteAllBytes(dirPath + name + ".png", bytes);
        }
    }
}

