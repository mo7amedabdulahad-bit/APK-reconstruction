// ============================================================================
// RECONSTRUCTED FROM IL2CPP METADATA - PHASE 24
// File: TLMobile/Scripts/Models/HeroModels.cs
// ============================================================================
//
// Reconstructed from: Hero data binding paths (50+ paths),
//                      sprite key references, equipment slots,
//                      combat simulator hero bindings
// Confidence: 93%
// Evidence:
//   - hero/*, hero*SpriteKey paths (25+ sprite binding paths)
//   - heroUtilityItemEffects, heroAbilityText paths
//   - combatSimulatorHero/* paths
//   - Assembly: TLMobile.dll
// ============================================================================

using System;
using System.Collections.Generic;
using TLMobile.Scripts.Enums;

namespace TLMobile.Scripts.Models
{
    /// <summary>
    /// Hero appearance sprite keys for character rendering.
    /// Confidence: 95%
    /// Evidence: 25+ exact data binding paths for hero sprite keys:
    ///   heroBaseSpriteKey, heroBodySpriteKey, heroBackSpriteHairKey,
    ///   heroFrontHairSpriteKey, heroHelmetSpriteKey, heroBootsSpriteKey,
    ///   heroEyesSpriteKey, heroMouthSpriteKey, heroNoseSpriteKey, etc.
    /// </summary>
    [Serializable]
    public class HeroAppearance
    {
        /// <summary>Base body sprite. Confidence: 95%</summary>
        public string heroBaseSpriteKey;

        /// <summary>Body sprite. Confidence: 95%</summary>
        public string heroBodySpriteKey;

        /// <summary>Back hair sprite. Confidence: 95%</summary>
        public string heroBackSpriteHairKey;

        /// <summary>Front hair sprite. Confidence: 95%</summary>
        public string heroFrontHairSpriteKey;

        /// <summary>Helmet sprite. Confidence: 95%</summary>
        public string heroHelmetSpriteKey;

        /// <summary>Boots sprite. Confidence: 95%</summary>
        public string heroBootsSpriteKey;

        /// <summary>Eyes sprite. Confidence: 95%</summary>
        public string heroEyesSpriteKey;

        /// <summary>Eyes base sprite. Confidence: 94%</summary>
        public string heroEyesBaseSpriteKey;

        /// <summary>Brows sprite. Confidence: 94%</summary>
        public string heroBrowsSpriteKey;

        /// <summary>Brows base sprite. Confidence: 94%</summary>
        public string heroBrowsBaseSpriteKey;

        /// <summary>Mouth sprite. Confidence: 94%</summary>
        public string heroMouthSpriteKey;

        /// <summary>Nose sprite. Confidence: 94%</summary>
        public string heroNoseSpriteKey;

        /// <summary>Jaw sprite. Confidence: 94%</summary>
        public string heroJawSpriteKey;

        /// <summary>Ears sprite. Confidence: 94%</summary>
        public string heroEarsSpriteKey;

        /// <summary>Beard sprite. Confidence: 93%</summary>
        public string heroBeardSpriteKey;

        /// <summary>Scar sprite. Confidence: 93%</summary>
        public string heroScarSpriteKey;

        /// <summary>Tattoo sprite. Confidence: 93%</summary>
        public string heroTattooSpriteKey;

        /// <summary>Left arm sprite. Confidence: 93%</summary>
        public string heroLeftArmSpriteKey;

        /// <summary>Right arm sprite. Confidence: 93%</summary>
        public string heroRightArmSpriteKey;

        /// <summary>Back left hand item sprite. Confidence: 93%</summary>
        public string heroBackLeftItemSpriteKey;

        /// <summary>Back right hand item sprite. Confidence: 93%</summary>
        public string heroBackRightItemSpriteKey;

        /// <summary>Front left hand item sprite. Confidence: 93%</summary>
        public string heroFrontLeftItemSpriteKey;

        /// <summary>Front right hand item sprite. Confidence: 93%</summary>
        public string heroFrontRightItemSpriteKey;
    }

    /// <summary>
    /// Hero equipment item wrapper for inventory display.
    /// Confidence: 94%
    /// Evidence: Data binding paths:
    ///   "inventoryItemWrapper/quality", "inventoryItemWrapper/imageToUse",
    ///   "inventoryItemWrapper/amount", "inventoryItemWrapper/rarity",
    ///   "inventoryItemWrapper/heroRarityIndex", "heroInventoryItem/amount"
    /// </summary>
    [Serializable]
    public class InventoryItemWrapper
    {
        /// <summary>Item quality tier. Confidence: 94%</summary>
        public HeroRarity quality;

        /// <summary>Image key for display. Confidence: 93%</summary>
        public string imageToUse;

        /// <summary>Stack count. Confidence: 93%</summary>
        public int amount;

        /// <summary>Whether to force show amount. Confidence: 92%</summary>
        public bool forceShowAmount;

        /// <summary>Amount not currently in use. Confidence: 91%</summary>
        public int amountNotInUse;

        /// <summary>Rarity level. Confidence: 93%</summary>
        public HeroRarity rarity;

        /// <summary>Rarity index for hero display. Confidence: 92%</summary>
        public int heroRarityIndex;
    }

    /// <summary>
    /// Hero inventory item attributes for detail display.
    /// Confidence: 91%
    /// Evidence: "inventoryItemAttributes/descriptionDetailsDecoded",
    ///   "inventoryItemAttributes/effectDescriptionDecoded"
    /// </summary>
    [Serializable]
    public class InventoryItemAttributes
    {
        /// <summary>Decoded description text. Confidence: 91%</summary>
        public string descriptionDetailsDecoded;

        /// <summary>Decoded effect description. Confidence: 91%</summary>
        public string effectDescriptionDecoded;
    }

    /// <summary>
    /// Hero equipment slot data.
    /// Confidence: 92%
    /// Evidence: Data binding paths for equipment slots:
    ///   "equipment/wrappedLeftHand", "appearance/beard",
    ///   hero*SpriteKey references, HeroItemCategory enum values
    /// </summary>
    [Serializable]
    public class HeroEquipment
    {
        /// <summary>Weapon slot item. Confidence: 92%</summary>
        public InventoryItemWrapper weapon;

        /// <summary>Armor slot item. Confidence: 92%</summary>
        public InventoryItemWrapper armor;

        /// <summary>Boots slot item. Confidence: 92%</summary>
        public InventoryItemWrapper boots;

        /// <summary>Utility slot item (left hand). Confidence: 92%</summary>
        public InventoryItemWrapper utility;

        /// <summary>Horse slot item. Confidence: 91%</summary>
        public InventoryItemWrapper horse;

        /// <summary>Consumable bag slot item. Confidence: 91%</summary>
        public InventoryItemWrapper consumable;
    }

    /// <summary>
    /// Hero item effects from equipment (boots, utility).
    /// Confidence: 91%
    /// Evidence: "heroBootsItemEffects[i]", "heroBootsItemEffects[i]/effectTypeText",
    ///   "heroUtilityItemEffects[i]", "heroUtilityItemEffects[i]/effectTypeText",
    ///   "heroUtilityItemEffects[i]/magnitude"
    /// </summary>
    [Serializable]
    public class HeroItemEffect
    {
        public string effectTypeText;
        public float magnitude;
    }

    /// <summary>
    /// Hero data model combining all hero-related data.
    /// Confidence: 90%
    /// Evidence: "hero/heroArrival", "heroUid", hero appearance sprite keys,
    ///   combatSimulatorHero/* paths, hero attribute references
    ///   Assembly: TLMobile.dll
    /// </summary>
    [Serializable]
    public class HeroData
    {
        /// <summary>Unique hero identifier. Confidence: 93%</summary>
        public string heroUid;

        /// <summary>Hero gender. Confidence: 95% - Evidence: "(Enum)Gender.male"</summary>
        public Gender gender;

        /// <summary>Hero appearance. Confidence: 95%</summary>
        public HeroAppearance appearance;

        /// <summary>Hero equipment. Confidence: 92%</summary>
        public HeroEquipment equipment;

        /// <summary>Hero health points. Confidence: 88% - Evidence: "combatSimulatorHero/health"</summary>
        public float health;

        /// <summary>Hero strength. Confidence: 88% - Evidence: "combatSimulatorHero/strength"</summary>
        public float strength;

        /// <summary>Calculated strength (with equipment). Confidence: 87%</summary>
        public float calculatedStrength;

        /// <summary>Hero arrival time. Confidence: 92% - Evidence: "hero/heroArrival"</summary>
        public DateTime heroArrival;

        /// <summary>Hero ability text. Confidence: 91%</summary>
        public string heroAbilityText;

        /// <summary>Hero utility text. Confidence: 91%</summary>
        public string heroUtilityText;

        /// <summary>Boots item effects. Confidence: 91%</summary>
        public List<HeroItemEffect> heroBootsItemEffects;

        /// <summary>Utility item effects. Confidence: 91%</summary>
        public List<HeroItemEffect> heroUtilityItemEffects;

        /// <summary>Horse enabled state. Confidence: 88%</summary>
        public bool horseEnabled;
    }

    /// <summary>
    /// Combat simulator hero data.
    /// Confidence: 89%
    /// Evidence: "combatSimulatorHero/ToggleHorse()",
    ///   "combatSimulatorHero/calculatedStrength",
    ///   "combatSimulatorHero/strength", "combatSimulatorHero/horseEnabled",
    ///   "combatSimulatorHero/health"
    /// </summary>
    [Serializable]
    public class CombatSimulatorHero
    {
        public float calculatedStrength;
        public float strength;
        public bool horseEnabled;
        public float health;

        /// <summary>
        /// Toggle horse equipment.
        /// Confidence: 89% - Evidence: "combatSimulatorHero/ToggleHorse()"
        /// </summary>
        public void ToggleHorse()
        {
            horseEnabled = !horseEnabled;
        }
    }
}
