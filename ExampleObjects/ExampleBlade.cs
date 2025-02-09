﻿using FTKAPI.Managers;
using FTKAPI.Objects;
using GridEditor;
using UnityEngine;


namespace FTKModLib.Example {
    using ProficiencyManager = FTKAPI.Managers.ProficiencyManager;
    public class ExampleBlade : CustomItem {
        public ExampleBlade() {
            int customProf = ProficiencyManager.AddProficiency(new ExampleProficiency());

            ID = "CustomBlade1";
            Name = new("Example Blade");
            Prefab = ExampleMod.assetBundle.LoadAsset<GameObject>("Assets/customBlade.prefab");
            ObjectSlot = FTK_itembase.ObjectSlot.oneHand;
            ObjectType = FTK_itembase.ObjectType.weapon; // This is required for the item to be registered as a weapon
            SkillType = FTK_weaponStats2.SkillType.toughness;
            WeaponType = Weapon.WeaponType.bladed;
            ProficiencyEffects = new() { // these are the weapon attacks/skills for this custom item
                [(FTK_proficiencyTable.ID)customProf] = FTK_hitEffect.ID.defaultBlade,
                [FTK_proficiencyTable.ID.bladeDamage] = FTK_hitEffect.ID.defaultBlade,
                [FTK_proficiencyTable.ID.fire1] = FTK_hitEffect.ID.defaultBlade,
                [FTK_proficiencyTable.ID.firestorm1] = FTK_hitEffect.ID.defaultBlade,
            };
            AnimationController = AssetManager.GetAnimationControllers<Weapon>().Find(i => i.name == "player_1H_Bladed_Combat");
            Slots = 2;
            MaxDmg = 10;
            ShopStock = 1;
            TownMarket = true;
            ItemRarity = FTK_itemRarityLevel.ID.rare;
        }
    }
}
