using Kitchen;
using KitchenData;
using KitchenLib.Customs;
using KitchenLib.Utils;
using UnityEngine;

namespace KitchenFNAFCosmetics.Customs.Cosmetics
{
    public class ChicaHat : CustomPlayerCosmetic
    {
        public override string UniqueNameID => "ChicaHat";
        public override GameObject Visual => Mod.Bundle.LoadAsset<GameObject>("ChicaHat").AssignMaterialsByNames();
        public override CosmeticType CosmeticType => CosmeticType.Hat;
        public override void OnRegister(PlayerCosmetic gameDataObject)
        {
            base.OnRegister(gameDataObject);
            gameDataObject.HeadSize = 0.85f;
            
            PlayerOutfitComponent playerOutfitComponent = gameDataObject.Visual.AddComponent<PlayerOutfitComponent>();
            playerOutfitComponent.Renderers.Add(GameObjectUtils.GetChildObject(gameDataObject.Visual, "ChicaHat").GetComponent<SkinnedMeshRenderer>());
        }
    }
}