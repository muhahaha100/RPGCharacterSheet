﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RPGCharacterManager.Models.Character
{
    public class CharacterInfo
    {
        //Character name
        public string CharName { get; set; } = "";

        //Character class
        public string Class { get; set; } = "";

        //Character level
        public int Level { get; set; } = 0;

        //Character background
        public string Background { get; set; } = "";

        //Player name
        public string PlayerName { get; set; } = "";

        //Character race
        public string Race { get; set; } = "";

        //Character alignment
        public string Alignment { get; set; } = "";

        //Character's experience points
        public int CurrentEXP { get; set; } = 0;

        //Character's experience needed to level up
        public int GoalEXP { get; set; } = 0;

        //Character's background In order:
        /* 
         * Personality Traits
         * Ideals
         * Bonds
         * Flaws
         */
        public List<string> BackgroundInfo { get; set; } = new List<string>() { "", "", "", "" };

        public void GenerateRandomCharacterInfo(Character character)
        {
            CharName = "INSERT CHARACTER NAME";
            RandomClass(character); //DONE
            Level = 1;
            RandomBackground(character); //DONE
            PlayerName = "INSERT PLAYER NAME";
            RandomRace(character); // DONE
            //CLASS WILL HAVE ALLIGNMENT
            CurrentEXP = 0;
            GoalEXP = 350;
            //BACKGROUND INFO WILL BE DONE IN BACKROUND
        }

        #region Randomization

        private void RandomRace(Character character)
        {
            bool statModUsed = false;
            Random rng = new Random();
            List<string> races = new List<string>() { "Dwarf", "Elf", "Halfling", "Human", "Dragonborn", "Gnome", "Half-Elf", "Half-Orc", "Tiefling" };
            string race = races.ElementAt(rng.Next(0, races.Count));

            switch (race)
            {

                case "Dwarf":
                    {
                        character.CharStats.Constitution += 2;
                        Race = race;
                        Alignment = "Lawful Neutral";
                        character.CharStats.Speed = 25;
                        character.Features.AddFeature("Darkvision", "Can see 60ft in dim light. Can see in darkness as if it were dim light. Cannot discern color, only shades of grey.");
                        character.Features.AddFeature("Dwarven Resilience", "Advantage on saving throws against poision and have resistance to poising damage.");
                        character.Features.AddFeature("Stonecunning", "Gain double proficiency on 'History Checks' relating to stonework.");
                        character.Proficiencies.Add("Read/Write and Speak Common");
                        character.Proficiencies.Add("Read/Write and Speak Dwarvish");
                        character.Proficiencies.Add("Battleaxe");
                        character.Proficiencies.Add("Handaxe");
                        character.Proficiencies.Add("Throwing Hammer");
                        character.Proficiencies.Add("Warhammer");

                        string[] toolProfs = { "Smith's Tools", "Brewer's Supplies", "Mason's Tools" };
                        character.Proficiencies.Add(toolProfs[rng.Next(0, 3)]);
                    }

                    break;
                case "Elf":
                    {
                        character.CharStats.Dexterity += 2;
                        Race = race;
                        Alignment = "Chaotic Good";
                        character.CharStats.Speed = 30;
                        character.Features.AddFeature("Darkvision", "Can see 60ft in dim light. Can see in darkness as if it were dim light. Cannot discern color, only shades of grey.");
                        character.Features.AddFeature("Fey Ancestry", "Advantage on saving throws against being charmed. Cannot be put to sleep by magical means.");
                        character.Features.AddFeature("Trance", "You do not need sleep, but instead must meditate in a semiconscious state for 4 hours to feel rested.");
                        character.Proficiencies.Add("Read/Write and Speak Common");
                        character.Proficiencies.Add("Read/Write and Speak Elvish");
                        character.CharSkills.CharSkills[11].IsProficient = true;
                    }

                    break;
                case "Halfling":
                    {

                        character.CharStats.Dexterity += 2;
                        Race = race;
                        Alignment = "Lawful Good";
                        character.CharStats.Speed = 25;
                        character.Features.AddFeature("Lucky", "When you roll a 1, you can reroll the die, but you must take the new number.");
                        character.Features.AddFeature("Brave", "Advantage on saving throws against being frightened.");
                        character.Features.AddFeature("Halfling Numbleness", "You may move through the space of a creature that is of a size larger than yours.");
                        character.Proficiencies.Add("Read/Write and Speak Common");
                        character.Proficiencies.Add("Read/Write and Speak Halfling");
                    }

                    break;
                case "Human":
                    {

                        character.CharStats.Strength += 1;
                        character.CharStats.Dexterity += 1;
                        character.CharStats.Constitution += 1;
                        character.CharStats.Intelligence += 1;
                        character.CharStats.Wisdom += 1;
                        character.CharStats.Charisma += 1;
                        Race = race;
                        Alignment = "Neutral";
                        character.CharStats.Speed = 30;
                        character.Proficiencies.Add("Read/Write and Speak Common");
                        character.Proficiencies.Add("Read/Write and Speak {Language of Choice}");
                    }

                    break;
                case "Dragonborn":
                    {

                        character.CharStats.Strength += 2;
                        character.CharStats.Charisma += 1;
                        Alignment = "Neutral";
                        character.CharStats.Speed = 30;

                        List<string> dragonTypes = new List<string>() { "Black ", "Blue ", "Brass ", "Bronze ", "Copper ", "Gold ", "Green ", "Red ", "Silver ", "White " };
                        string type = dragonTypes.ElementAt(rng.Next(0, dragonTypes.Count));
                        Race = type + race;

                        switch (type.Trim())
                        {
                            case "Black":
                                character.Spells.AddSpell("Acid Breath", "5x30ft line of acid damage: DC(8 + constitution + proficiency) dexterity saving throw. 2D6 damage on failed save, half on successful. Useable 1/Long Rest. Goes up 1D6 at levels: 6, 11, and 16.", 0);
                                character.Features.AddFeature("Draconic Resistance", "Resistant to: Acid Damage");
                                break;
                            case "Blue":
                                character.Spells.AddSpell("Lightning Breath", "5x30ft line of lightning damage: DC(8 + constitution + proficiency) dexterity saving throw. 2D6 damage on failed save, half on successful. Useable 1/Long Rest. Goes up 1D6 at levels: 6, 11, and 16.", 0);
                                character.Features.AddFeature("Draconic Resistance", "Resistant to: Lightning Damage");
                                break;
                            case "Brass":
                                character.Spells.AddSpell("Fire Breath", "5x30ft line of fire damage: DC(8 + constitution + proficiency) dexterity saving throw. 2D6 damage on failed save, half on successful. Useable 1/Long Rest. Goes up 1D6 at levels: 6, 11, and 16.", 0);
                                character.Features.AddFeature("Draconic Resistance", "Resistant to: Fire Damage");
                                break;
                            case "Bronze":
                                character.Spells.AddSpell("Lightning Breath", "5x30ft line of lightning damage: DC(8 + constitution + proficiency) dexterity saving throw. 2D6 damage on failed save, half on successful. Useable 1/Long Rest. Goes up 1D6 at levels: 6, 11, and 16.", 0);
                                character.Features.AddFeature("Draconic Resistance", "Resistant to: Lightning Damage");
                                break;
                            case "Copper":
                                character.Spells.AddSpell("Acid Breath", "5x30ft line of acid damage: DC(8 + constitution + proficiency) dexterity saving throw. 2D6 damage on failed save, half on successful. Useable 1/Long Rest. Goes up 1D6 at levels: 6, 11, and 16.", 0);
                                character.Features.AddFeature("Draconic Resistance", "Resistant to: Acid Damage");
                                break;
                            case "Gold":
                                character.Spells.AddSpell("Fire Breath", "15ft cone of fire damage: DC(8 + constitution + proficiency) constitution saving throw. 2D6 damage on failed save, half on successful. Useable 1/Long Rest. Goes up 1D6 at levels: 6, 11, and 16.", 0);
                                character.Features.AddFeature("Draconic Resistance", "Resistant to: Fire Damage");
                                break;
                            case "Green":
                                character.Spells.AddSpell("Poison Breath", "15ft cone of poison damage: DC(8 + constitution + proficiency) constitution saving throw. 2D6 damage on failed save, half on successful. Useable 1/Long Rest. Goes up 1D6 at levels: 6, 11, and 16.", 0);
                                character.Features.AddFeature("Draconic Resistance", "Resistant to: Poison Damage");
                                break;
                            case "Red":
                                character.Spells.AddSpell("Fire Breath", "15ft cone of fire damage: DC(8 + constitution + proficiency) constitution saving throw. 2D6 damage on failed save, half on successful. Useable 1/Long Rest. Goes up 1D6 at levels: 6, 11, and 16.", 0);
                                character.Features.AddFeature("Draconic Resistance", "Resistant to: Fire Damage");
                                break;
                            case "Silver":
                                character.Spells.AddSpell("Cold Breath", "15ft cone of cold damage: DC(8 + constitution + proficiency) constitution saving throw. 2D6 damage on failed save, half on successful. Useable 1/Long Rest. Goes up 1D6 at levels: 6, 11, and 16.", 0);
                                character.Features.AddFeature("Draconic Resistance", "Resistant to: Cold Damage");
                                break;
                            case "White":
                                character.Spells.AddSpell("Cold Breath", "15ft cone of cold damage: DC(8 + constitution + proficiency) constitution saving throw. 2D6 damage on failed save, half on successful. Useable 1/Long Rest. Goes up 1D6 at levels: 6, 11, and 16.", 0);
                                character.Features.AddFeature("Draconic Resistance", "Resistant to: Cold Damage");
                                break;
                        }
                    character.Proficiencies.Add("Read/Write and Speak Common");
                        character.Proficiencies.Add("Read/Write and Speak Draconic");
                    }

                    break;
                case "Gnome":
                    character.CharStats.Intelligence += 2;
                    {

                        Race = race;
                        Alignment = "Neutral Good";
                        character.CharStats.Speed = 25;
                        character.Features.AddFeature("Darkvision", "Can see 60ft in dim light. Can see in darkness as if it were dim light. Cannot discern color, only shades of grey.");
                        character.Features.AddFeature("Gnome Cunning", "Advantage on all: Intelligence, Wisdom, and Charisma checks against magic.");
                        character.Proficiencies.Add("Read/Write and Speak Common");
                        character.Proficiencies.Add("Read/Write and Speak Gnomish");
                    }

                    break;
                case "Half-Elf":
                    {

                        character.CharStats.Charisma += 2;
                        int rand1 = rng.Next(0, 5);
                        switch (rand1)
                        {
                            case 0:
                                character.CharStats.Strength += 1;

                                do
                                {
                                    int rand2 = rng.Next(0, 5);
                                    if (rand2 == rand1)
                                    {
                                        statModUsed = true;
                                    }
                                    else
                                    {
                                        switch (rand2)
                                        {
                                            case 0:
                                                character.CharStats.Strength += 1;
                                                break;
                                            case 1:
                                                character.CharStats.Dexterity += 1;
                                                break;
                                            case 2:
                                                character.CharStats.Constitution += 1;
                                                break;
                                            case 3:
                                                character.CharStats.Intelligence += 1;
                                                break;
                                            case 4:
                                                character.CharStats.Wisdom += 1;
                                                break;
                                        }
                                        statModUsed = false;
                                    }

                                } while (statModUsed);
                                break;
                            case 1:
                                character.CharStats.Dexterity += 1;

                                do
                                {
                                    int rand2 = rng.Next(0, 5);
                                    if (rand2 == rand1)
                                    {
                                        statModUsed = true;
                                    }
                                    else
                                    {
                                        switch (rand2)
                                        {
                                            case 0:
                                                character.CharStats.Strength += 1;
                                                break;
                                            case 1:
                                                character.CharStats.Dexterity += 1;
                                                break;
                                            case 2:
                                                character.CharStats.Constitution += 1;
                                                break;
                                            case 3:
                                                character.CharStats.Intelligence += 1;
                                                break;
                                            case 4:
                                                character.CharStats.Wisdom += 1;
                                                break;
                                        }
                                        statModUsed = false;
                                    }

                                } while (statModUsed);
                                break;
                            case 2:
                                character.CharStats.Constitution += 1;

                                do
                                {
                                    int rand2 = rng.Next(0, 5);
                                    if (rand2 == rand1)
                                    {
                                        statModUsed = true;
                                    }
                                    else
                                    {
                                        switch (rand2)
                                        {
                                            case 0:
                                                character.CharStats.Strength += 1;
                                                break;
                                            case 1:
                                                character.CharStats.Dexterity += 1;
                                                break;
                                            case 2:
                                                character.CharStats.Constitution += 1;
                                                break;
                                            case 3:
                                                character.CharStats.Intelligence += 1;
                                                break;
                                            case 4:
                                                character.CharStats.Wisdom += 1;
                                                break;
                                        }
                                        statModUsed = false;
                                    }

                                } while (statModUsed);
                                break;
                            case 3:
                                character.CharStats.Intelligence += 1;

                                do
                                {
                                    int rand2 = rng.Next(0, 5);
                                    if (rand2 == rand1)
                                    {
                                        statModUsed = true;
                                    }
                                    else
                                    {
                                        switch (rand2)
                                        {
                                            case 0:
                                                character.CharStats.Strength += 1;
                                                break;
                                            case 1:
                                                character.CharStats.Dexterity += 1;
                                                break;
                                            case 2:
                                                character.CharStats.Constitution += 1;
                                                break;
                                            case 3:
                                                character.CharStats.Intelligence += 1;
                                                break;
                                            case 4:
                                                character.CharStats.Wisdom += 1;
                                                break;
                                        }
                                        statModUsed = false;
                                    }

                                } while (statModUsed);
                                break;
                            case 4:
                                character.CharStats.Wisdom += 1;

                                do
                                {
                                    int rand2 = rng.Next(0, 5);
                                    if (rand2 == rand1)
                                    {
                                        statModUsed = true;
                                    }
                                    else
                                    {
                                        switch (rand2)
                                        {
                                            case 0:
                                                character.CharStats.Strength += 1;
                                                break;
                                            case 1:
                                                character.CharStats.Dexterity += 1;
                                                break;
                                            case 2:
                                                character.CharStats.Constitution += 1;
                                                break;
                                            case 3:
                                                character.CharStats.Intelligence += 1;
                                                break;
                                            case 4:
                                                character.CharStats.Wisdom += 1;
                                                break;
                                        }
                                        statModUsed = false;
                                    }

                                } while (statModUsed);
                                break;
                        }
                        Race = race;
                        Alignment = "Chaotic Neutral";
                        character.CharStats.Speed = 30;
                        character.Features.AddFeature("Darkvision", "Can see 60ft in dim light. Can see in darkness as if it were dim light. Cannot discern color, only shades of grey.");
                        character.Features.AddFeature("Fey Ancestry", "Advantage on saving throws against being charmed. Cannot be put to sleep by magical means.");
                        character.Proficiencies.Add("Read/Write and Speak Common");
                        character.Proficiencies.Add("Read/Write and Speak Elvish");
                        character.Proficiencies.Add("Read/Write and Speak {Language of Choice}");

                        List<string> skills = new List<string>() { "Acrobatics", "Animal Handling", "Arcana", "Athletics", "Deception", "History", "Insight", "Intimidation", "Investigation", "Medicine", "Nature", "Perception", "Performance", "Persuasion", "Religion", "Sleight of Hand", "Stealth", "Survival" };
                        bool alreadyChosen = false;
                        string firstChoice = skills.ElementAt(rng.Next(0, skills.Count));

                        //Set proficiency based on skill name
                        for(int i = 0; i < character.CharSkills.CharSkills.Length; i++)
                        {
                            if(character.CharSkills.CharSkills[i].SkillName == firstChoice)
                            {
                                character.CharSkills.CharSkills[i].IsProficient = true;
                                break;
                            }
                        }

                        do
                        {
                            //Set second proficiency based on skill name if it's not already proficient
                            string secondChoice = skills.ElementAt(rng.Next(0, skills.Count));

                            for(int i = 0; i < character.CharSkills.CharSkills.Length; i++)
                            {
                                if(character.CharSkills.CharSkills[i].SkillName == secondChoice)
                                {
                                    if (character.CharSkills.CharSkills[i].IsProficient) alreadyChosen = true;
                                    else
                                    {
                                        character.CharSkills.CharSkills[i].IsProficient = true;
                                        alreadyChosen = false;
                                        break;
                                    }
                                }
                            }
                        } while (alreadyChosen);

                    }

                    break;
                case "Half-Orc":
                    {

                        character.CharStats.Strength += 2;
                        character.CharStats.Constitution += 1;
                        Race = race;
                        Alignment = "Chaotic Evil";
                        character.CharStats.Speed = 30;
                        character.Features.AddFeature("Darkvision", "Can see 60ft in dim light. Can see in darkness as if it were dim light. Cannot discern color, only shades of grey.");
                        character.Features.AddFeature("Relentless Endurance", "When you are reduced to 0 health, it is instead reduced to 1 health. Can only use this feature 1/Long Rest.");
                        character.Features.AddFeature("Savage Attacks", "When you score a critical hit you can add 1 of the weapons damage dice one time to the critical damage.");
                        character.Proficiencies.Add("Read/Write and Speak Common");
                        character.Proficiencies.Add("Read/Write and Speak Orc");
                        character.CharSkills.CharSkills[7].IsProficient = true;
                    }

                    break;
                case "Tiefling":
                    {

                        character.CharStats.Intelligence += 1;
                        character.CharStats.Charisma += 2;
                        Race = race;
                        Alignment = "Chaotic Neutral";
                        character.CharStats.Speed = 30;
                        character.Features.AddFeature("Darkvision", "Can see 60ft in dim light. Can see in darkness as if it were dim light. Cannot discern color, only shades of grey.");
                        character.Features.AddFeature("Hellish Resistance", "Resistance to: Fire Damage");
                        character.Features.AddFeature("Infernal Legacy", "You know the cantrip: Thaumaturgy. At level 3 you learn: Hellish Rebuke; and can use it 1/Long Rest as a 2nd level spell. At level 5 you learn: Darkness; and can use it 1/Long Rest. Charisma is the spellcasting ability for these.");
                        character.Proficiencies.Add("Read/Write and Speak Common");
                        character.Proficiencies.Add("Read/Write and Speak Infernal");
                        character.Spells.AddSpell("Thaumaturgy", "Range: 30ft. Duration: Up to 1 minute. Casting Time: 1 Action. You can: Create harmless sensory effects.", 0);
                    }

                    break;
            }
        }

        private void RandomClass(Character character)
        {
            Random rng = new Random();
            List<string> classes = new List<string>() { "Barbarian", "Bard", "Cleric", "Druid", "Fighter", "Monk", "Paladin", "Ranger", "Rogue", "Sorcerer", "Warlock", "Wizard" };
            string charClass = classes.ElementAt(rng.Next(0, classes.Count));

            switch (charClass)
            {
                case "Barbarian":
                    {
                        addClassData(charClass, 12, new int[] { 0, 2 }, new List<string> { "Light Armor", "Medium Armor", "Shields" }, new List<string> { "Simple Weapons", "Martial Weapons" }, null, new int[] { 0, 2 }, new int[] { 1, 3, 7, 10, 11, 17 }, 2,
                                     new List<string> { "Choose between: A Greataxe OR Any Martial Melee Weapon", "Choose between: 2 Handaxes OR Any Simple Weapon", "Explorers Pack", "4 Javelins" }, 10 + character.CharStats.DexterityMod
                                    + character.CharStats.ConstitutionMod, 0, 0, new List<string> { "Rage", "Unarmored Defense" }, new List<string> { "In battle you can rage as a bonus action. During rage if you are not wearing heavy armor you gain the following benefits: You have advantage on Strength Checks and Strength Saving throws. " +
                                    "When you hit an enemy you gain 2 bonus rage damage (Increases by 1 at level 9 and 16). You gain resistance to bludgeoning, piercing, and slashing damage. You cannot cast spells while in rage." +
                                    " It lasts for 1 minute. You can rage 2 times per long rest (Increases at level 3, 6, 12 and 17; then unlimited at level 20)", "Your armor class is: 10 + Dexterity Modifier + Constitution Modifier. " +
                                    "You may use a shield and still gain this benefit."}, character);
                    }

                    break;
                case "Bard":
                    {
                        addClassData(charClass, 8, new int[] { 5, 1 }, new List<string> { "Light Armor" }, new List<string> { "Simple Weapons", "Hand Crossbows", "LongSwords", "Rapiers", "Shortswords" }, new List<string> { "Three Musical Instruments of Your Choice" },
                                     new int[] { 1, 5 }, new int[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17 }, 3, new List<string> { "Choose between: A Rapier, A Longsword, OR Any Simple Weapon", "Choose between: A Diplomat's Pack OR An Entertainer's Pack",
                                 "Choose between: A Lute OR Any Other Musical Instrument", "Leather Armor", "Dagger" }, 11 + character.CharStats.DexterityMod, 2, 4, new List<string> { "Bardic Inspiration" },
                                     new List<string> { "You can inspire others through stirring words or with music. You can use a bonus action to inspire one creature within 60 feet that can hear you. It gains 1D6 inspiration. " +
                                 "(Increases to 1D8 at Level 5, 1D10 at Level 10, and 1D12 at Level 15.)" }, character);

                        character.Spells.SpellAttackBonus = 10 + character.CharStats.CharismaMod;
                        character.Spells.SpellSaveDC = 2 + character.CharStats.CharismaMod;
                        character.Spells.SpellSlotsTotal = new int[9] { 2, 0, 0, 0, 0, 0, 0, 0, 0 };
                        character.Spells.SpellSlotsRemaining = new int[9] { 2, 0, 0, 0, 0, 0, 0, 0, 0 };
                    }

                    break;
                case "Cleric":
                    {
                        addClassData(charClass, 8, new int[] { 4, 2 }, new List<string> { "Light Armor", "Medium Armor", "Shields" }, new List<string> { "Simple Weapons" }, null, new int[] { 4, 5 }, new int[] { 5, 6, 9, 13, 14 }, 5, new List<string> { "Choose between: A Mace OR A Warhammer (if proficient)",
                                     "Choose between: A Light Crossbow (with 20 bolts) OR Any Simple Weapon", "Choose between: A Priest's Pack OR An Explorer's Pack", "Choose between: Scale Mail, Leather Armor, OR Chain Mail (if proficient) -- SET OWN AC",
                                     "Shield", "Holy Symbole of Your Choice"}, 0, character.CharStats.DexterityMod + Level, 3, new List<string> { "Divine Domain" },
                                     new List<string> { "Choose a Domain that is related to your Diety: Knowledge, Life, Light, Nature, Tempest, Trickery, or War. You gain spells according. READ PERSONALLY!" }, character);

                        character.Spells.SpellAttackBonus = 10 + character.CharStats.CharismaMod;
                        character.Spells.SpellSaveDC = 2 + character.CharStats.CharismaMod;
                        character.Spells.SpellSlotsTotal = new int[9] { 2, 0, 0, 0, 0, 0, 0, 0, 0 };
                        character.Spells.SpellSlotsRemaining = new int[9] { 2, 0, 0, 0, 0, 0, 0, 0, 0 };
                    }

                    break;
                case "Druid":
                    {
                        addClassData(charClass, 8, new int[] { 4, 2 }, new List<string> { "NONMETAL Light Armor", "NONMETAL Medium Armor", "NONMETAL Shields" }, new List<string> { "Clubs", "Daggers", "Darts", "Javelins", "Maces", "Quarterstaffs", "Scimitars", "Sickles", "Slings", "Spears" },
                                     new List<string> { "Herbalism Kit" }, new int[] { 3, 4 }, new int[] { 1, 2, 6, 9, 10, 11, 14, 17 }, 2, new List<string> { "Choose between: A Wooden Shield OR Any Simple Weapon", "Choose between: A Scimitar OR Any Simple Melee Weapon",
                                     "Leather Armor","Explorers Pack","Druidic Focus"}, 11 + character.CharStats.DexterityMod, character.CharStats.WisdomMod + Level,
                                     2, new List<string> { "Druidic" }, new List<string> { "You know Druidic, the secret language of the druids. You can speak the language and use it to leave behind hidden messages. Anyone who knows the language can see it. " +
                                     "If someone doesnt know the language they must make a DC15 Perception check to see it. It cannot be deciphered without the use of magic." }, character);

                        character.Spells.SpellAttackBonus = 10 + character.CharStats.WisdomMod;
                        character.Spells.SpellSaveDC = 2 + character.CharStats.WisdomMod;
                        character.Spells.SpellSlotsTotal = new int[9] { 2, 0, 0, 0, 0, 0, 0, 0, 0 };
                        character.Spells.SpellSlotsRemaining = new int[9] { 2, 0, 0, 0, 0, 0, 0, 0, 0 };
                    }

                    break;
                case "Fighter":
                    {
                        addClassData(charClass, 10, new int[] { 0, 2 }, new List<string> { "All Armor", "Shields" }, new List<string> { "Simple Weapons", "Martial Weapons" }, null, new int[] { 0, 2 }, new int[] { 0, 1, 3, 5, 6, 7, 11, 17 }, 2,
                            new List<string> { "Choose between: Chain Mail OR Leather Armor With a Longbow and 20 Arrows -- SET OWN AC", "Choose between: A Martial Weapon With a Shield OR 2 Martial Weapons", "Choose between: A Light Crossbow With 20 Bolts OR 2 Handaxes",
                            "Choose between: A Dungeoneer's Pack OR An Explorer's Pack"}, 0, 0, 0, new List<string> { "Fighting Style", "Second Wind" }, new List<string> { "Choose one Fighting Style between the following Fighting Styles: Archery - Gain +2 to Attack Rolls Made With " +
                            "Ranged Weapons, Defense - While You Are Wearing Armor You Gain +1 Bonus to AC, Dueling - While Wielding a Melee Weapon In One Hand and No Other Weapons You Gain +2 Bonus Damage With That Weapon, Great Weapon Fighting - When You Roll a 1 or 2 " +
                            "on a Damage Die For an Attack You Make With a Two Handed Weapon You May Reroll the Damage Die, But Must Take the New Roll, Protection - While Wielding a Shield; if a Creature Attacks Another Creature Within 5FT of You as a Reaction " +
                            "You Can Impose Disadvantage on The Attack Roll, Two-Weapon Fighting - When You Engage in Two Weapon Fighting You May Add Your Ability Modifier To The Second Attack.", "1/Rest You May Use a Bonus Action To Heal 1D10 + Fighter Level." }, character);

                    }

                    break;
                case "Monk":
                    {
                        addClassData(charClass, 8, new int[] { 1, 4 }, null, new List<string> { "Simple Weapons", "Shortswords" }, new List<string> { "Choose between: A Type of Artisans Tools OR A Musical Instrument" }, new int[] { 0, 1 }, new int[] { 0, 3, 5, 6, 14, 16 }, 2,
                                     new List<string> { "Choose between: A Shortsword OR Any Simple Weapon", "Choose between: A Dungeoneer's Pack OR An Explorer's Pack", "10 Darts" }, 10 + character.CharStats.DexterityMod + character.CharStats.WisdomMod,
                                     0, 0, new List<string> { "Unarmored Defense", "Martial Arts" }, new List<string> { "While Not Wearing Armor Your AC Is: 10 + Dexterity Mod + Wisdom Mod","While Unarmed or Weidling Monk Weapons And Not Wearing Armor Or Wielding a Shield You Gain The Following Benefits: " +
                                     "You Can Use Dexterity Instead of Strength For Attack and Damage Rolls, You Can Roll 1D4 In Place of The Weapons Base Damage Die (Increases to 1D6 at Level 5, 1D8 at Level 11, and 1D10 at Level 17), You Can Make on Unarmed Strike for your Bonus Action After Attacking."}, character);

                    }

                    break;
                case "Paladin":
                    {
                        addClassData(charClass, 10, new int[] { 0, 5 }, new List<string> { "All Armors", "Shields" }, new List<string> { "Simple Weapons", "Martial Weapons" }, null, new int[] { 4, 5 }, new int[] { 3, 6, 7, 9, 13, 14 }, 2, new List<string> { "Choose between: A Martial Weapon With a Shield OR 2 Martial Weapons",
                                     "Choose between: 5 Javelins OR Any Simple Melee Weapon", "Choose between: A Priest's Pack OR An Explorer's Pack", "Chain Mail", "Holy Symbol of Your Choice"}, 16, 0, 0, new List<string> { "Divine Sense", "Lay on Hands" },
                                     new List<string> { "The Presence of Strong Evil Registers on Your Senses Like a Noxious Odor and Powerful Good Rings Like Heavenly Music in Your Ears. As an Action You Can Detect Any Celestials Fiends or Undead Within 60FT, You Can Do This 1 + Charisma Modifier Times / Long Rest",
                                     "You Have a Pool of Health Equal To The Paladins Level x 5 That Restores With Each Long Rest, You can Give Health to any creature (aside from undead and constructs). Alternatively you can use 5 Health from the Pool to Cure a Target of a Disease or Poison."}, character);
                    }

                    break;
                case "Ranger":
                    {
                        addClassData(charClass, 10, new int[] { 1, 4 }, new List<string> { "Light Armor", "Medium Armor", "Shields" }, new List<string> { "Simple Weapons", "Martial Weapons" }, null, new int[] { 0, 1 }, new int[] { 1, 3, 6, 8, 10, 11, 16, 17 }, 3,
                                     new List<string> { "Choose between: Scale Mail OR Leather Armor -- SET OWN AC", "Choose between: 2 Shortswords OR 2 Simple Melee Weapons", "Choose between: A Dungeoneer's Pack OR An Explorer's Pack", "Longbow With 20 Arrows" },
                                     0, 0, 0, new List<string> { "Favored Enemy", "Natural Explorer" }, new List<string> { "Choose a type of favored enemy from: Abberations, Beasts, Celestials, Constructs, Dragons, Elementals, Fey, Fiends, Giants, Monstrosities, Oozes, Plants, or Undead." +
                                     " OR choose 2 Humanoid Races. You learn the languages, how to track, and hunt these Enemies. You have advantage on Survival Checks to track the enemy and Intelligence checks to recall information about them. (Gain another favored enemy (Or 2 humanoid races) at Level 6 and Level 14.) ",
                                     "Choose a favored Terrain from: Arctic, Coast, Desert, Forest, Grassland, Mountain, Swamp, or the Underdark. In this terrain you gain the following benefits: Your party is not slowed by difficult terrain, Your party cannot become lost unless by use of magic," +
                                     " You remain alert even while performing other actions, While traveling alone you move at normal speed while stealthing, You find twice as much food while foraging, and, while tracking creatures you learn their numbers, sizes, and how long ago it has been since they passed through the area. (Gain another Favored Terrain at Level 6 and Level 10.)" }, character);
                    }

                    break;
                case "Rogue":
                    {
                        addClassData(charClass, 8, new int[] { 1, 5 }, new List<string> { "Light Armor" }, new List<string> { "Simple Weapons", "Hand Crossbows", "Longswords", "Rapiers", "Shortswords" }, new List<string> { "Thieves' Tools" }, new int[] { 1, 3 },
                                     new int[] { 0, 3, 4, 6, 7, 8, 11, 12, 13, 15, 16 }, 4, new List<string> { "Choose between: A Rapier OR A Shortsword", "Choose between: A Shortbow with 20 Arrows OR A Shortsword", "Choose between: A Burglar's Pack, An Explorer's Pack, OR A Dungeoneer's Pack",
                                     "Leather Armor", "2 Daggers", "Thieves' Tools"}, 11 + character.CharStats.DexterityMod, 0, 0, new List<string> { "Expertise", "Sneak Attack", "Thieves' Cant" }, new List<string> { "Choose 2 of " +
                                     "your skill proficiencies (or 1 skill proficiency and proficiency with thieves' tools). Your proficiency is doubled with those proficiencies. You can choose 2 more at level 6.","Once per turn you can deal an extra 1D6 damage with an attack if you have advantage " +
                                     "on the attack, you do not need advantage if another enemy of the target is within 5 feet of it, that enemy isnt incapacitated, and you don't have disadvantage on the attack roll. (Increases to 2D6 at level 3, 3D6 " +
                                     "at level 5, 4D6 at level 7, 5D6 at level 9, 6D6 at level 11, 7D6 at level 13, 8D6 at level 15, 9D6 at level 17, 10D6 at level 19.)","A secret language known by rogues, used to hide messages in normal conversation, " +
                                     "however it takes 4 times longer to do this than it does to say it plainly. You can also understand secret signs and symbols used to convey short simple messages such as whether an area is dangerous or part of a thieves guild etc..."}, character);
                    }

                    break;
                case "Sorcerer":
                    {
                        addClassData(charClass, 6, new int[] { 5, 2 }, null, new List<string> { "Daggers", "Darts", "Slings", "Quarterstaffs", "Light Crossbows" }, null, new int[] { 2, 5 }, new int[] { 2, 4, 6, 7, 13, 14 }, 2, new List<string> { "Choose between: A Light Crossbow " +
                            "With 20 Bolts OR Any Simple Weapon", "Choose between: A Component Pouch OR An Arcane Focus", "Choose between: A Dungeoneer's Pack OR An Explorer's Pack", "2 Daggers" }, 10 + character.CharStats.DexterityMod, 2, 4, new List<string> { "Sorcerous Origin" }, new List<string> { "Choose a sorcerous origin from the book (SUBCLASS) -- DO YOURSELF" }, character);

                        character.Spells.SpellAttackBonus = 10 + character.CharStats.CharismaMod;
                        character.Spells.SpellSaveDC = 2 + character.CharStats.CharismaMod;
                        character.Spells.SpellSlotsTotal = new int[9] { 2, 0, 0, 0, 0, 0, 0, 0, 0 };
                        character.Spells.SpellSlotsRemaining = new int[9] { 2, 0, 0, 0, 0, 0, 0, 0, 0 };
                    }

                    break;
                case "Warlock":
                    {
                        addClassData(charClass, 8, new int[] { 5, 2 }, new List<string> { "Light Armor" }, new List<string> { "Simple Weapons" }, null, new int[] { 4, 5 }, new int[] { 2, 4, 5, 7, 8, 10, 14 }, 2, new List<string> { "Choose between: A Light Crossbow With 20 Bolts OR " +
                            "Any Simple Weapon", "Choose between: A Component Pouch OR An Arcane Focus", "Choose between: A Scholar's Pack OR A Dungeoneer's Pack", "Leather Armor", "Any Simple Weapon", "2 Daggers" }, 11 + character.CharStats.DexterityMod,
                            2, 2, new List<string> { "Otherworldly Patron" }, new List<string> { "Choose an otherworldly patron from the book (SUBCLASS)-- DO YOURSELF" }, character);

                        character.Spells.SpellAttackBonus = 10 + character.CharStats.CharismaMod;
                        character.Spells.SpellSaveDC = 2 + character.CharStats.CharismaMod;
                        character.Spells.SpellSlotsTotal = new int[9] { 1, 0, 0, 0, 0, 0, 0, 0, 0 };
                        character.Spells.SpellSlotsRemaining = new int[9] { 1, 0, 0, 0, 0, 0, 0, 0, 0 };
                    }

                    break;
                case "Wizard":
                    {
                        addClassData(charClass, 6, new int[] { 3, 2 }, null, new List<string> { "Daggers", "Darts", "Slings", "Quarterstaffs", "Light Crossbows" }, null, new int[] { 3, 4 }, new int[] { 2, 5, 6, 8, 9, 14 }, 2, new List<string> { "Choose between: A Quarterstaff OR A Dagger",
                                     "Choose between: A Component Pouch OR An Arcane Focus", "Choose between: A Scholar's Pack or An Explorer's Pack", "Spellbook"}, 10 + character.CharStats.DexterityMod, 0, 3, new List<string> { "Arcane Recovery" },
                                     new List<string> { "Once/Day you can choose expended spell slots to recover. The spell slots can have a combined level <= half your wizard level rounded up." }, character);

                        character.Spells.SpellAttackBonus = 10 + character.CharStats.IntelligenceMod;
                        character.Spells.SpellSaveDC = 2 + character.CharStats.IntelligenceMod;
                        character.Spells.SpellSlotsTotal = new int[9] { 2, 0, 0, 0, 0, 0, 0, 0, 0 };
                        character.Spells.SpellSlotsRemaining = new int[9] { 2, 0, 0, 0, 0, 0, 0, 0, 0 };
                    }

                    break;
            }
        }

        private void RandomBackground(Character character)
        {
            Random rng = new Random();
            List<string> backgrounds = new List<string>() { "Acolyte", "Charlatan", "Criminal", "Entertainer", "Folk Hero", "Guild Artisan", "Hermit", "Noble", "Outlander", "Sage", "Sailor", "Soldier", "Urchin" };
            string bg = backgrounds.ElementAt(rng.Next(0, backgrounds.Count));

            switch (bg)
            {
                case "Acolyte":
                    {
                        addBackgroundData(bg, new int[] { 6, 14 }, new List<string> { "{Language of Choice}", "{Language of Choice}" }, null, new List<string> { "Holy Symbol of Choice", "Prayer Book or Prayer Wheel", "5 Sticks of Incense", "Vestments", "Common Clothes" }, 15,
                                          new List<string> { "Shelter of the Faithful" }, new List<string> { "As an acolyte, you command the respect of those who share your faith, and you can perform the religious ceremonies of your deity. You and your adventuring companions can expect to receive free healing and care at a temple, shrine, or other established presence of your faith, though you must provide any material components needed for spells. Those who share your religion will support you (but only you) at a modest lifestyle. You might also have ties to a specific temple dedicated to your chosen deity or pantheon, and you have a residence there. This could be the temple where you used to serve, if you remain on good terms with it, or a temple where you have found a new home. While near your temple, you can call upon the priests for assistance, provided the assistance you ask for is not hazardous and you remain in good standing with your temple." },
                                          new List<string> { "I idolize a particular hero of my faith, and constantly refer to that person’s deeds and example.", "I can find common ground between the fiercest enemies, empathizing with them and always working towards peace.",
                                              "I see omens in every event and action. The gods try to speak to us, we just need to listen.", "Nothing can shake my optimistic attitude.", "I quote (or misquote) sacred texts and proverbs in almost every situation.",
                                              "I am tolerant (or intolerant) of other faiths and respect (or condemn) the worship of other gods.", "I've enjoyed fine food, drink, and high society among my temple’s elite. Rough living grates on me. ", "I’ve spent so long in the temple that I have little practical experience dealing with people in the outside world."},
                                          new List<string> { "Tradition. The ancient traditions of worship and sacrifice must be preserved and upheld.", "Charity. I always try to help those in need, no matter what the personal cost.", "Change. We must help bring about the changes the gods are constantly working in the world.",
                                              "Power. I hope to one day rise to the top of my faith’s religious hierarchy.", "Faith. I trust that my deity will guide my actions, I have faith that if I work hard, things will go well.", "Aspiration. I seek to prove myself worthy of my god’s favor by matching my actions against his or her teachings."},
                                          new List<string> {  "I would die to recover an ancient relic of my faith that was lost long ago.", "I will someday get revenge on the corrupt temple hierarchy who branded me a heretic.",  "I owe my life to the priest who took me in when my parents died.",  "Everything I do is for the common people.",
                                              "I will do anything to protect the temple where I served.", "I seek to preserve a sacred text that my enemies consider heretical and seek to destroy."},
                                          new List<string> { "I judge others harshly, and myself even more severely.",  "I put too much trust in those who wield power within my temple’s hierarchy.", "My piety sometimes leads me to blindly trust those that profess faith in my god.", "I am inflexible in my thinking.",
                                              "I am suspicious of strangers and expect the worst of them.", "Once I pick a goal, I become obsessed with it to the detriment of everything else in my life."}, character);
                    }
                    break;
                case "Charlatan":
                    {
                        addBackgroundData(bg, new int[] { 4, 15 }, null, new List<string> { "Disguise Kit", "Forgery Kit" }, new List<string> { "A set of fine clothes", "Disguise kit", "Tools of the con of your choice (ten stoppered bottles filled with colored liquid, a set of weighted dice, a deck of marked cards, or a signet ring of an imaginary duke)" }, 15,
                            new List<string> { "False Identity" }, new List<string> { "You have created a second identity that includes documentation, established acquaintances, and disguises that allow you to assume that persona. Additionally, you can forge documents including official papers and personal letters, as long as you have seen an example of the kind of document or the handwriting you are trying to copy." },
                            new List<string> { "I fall in and out of love easily, and am always pursuing someone.", "I have a joke for every occasion, especially occasions where humor is inappropriate.", "Flattery is my preferred trick for getting what I want.",
                                "I’m a born gambler who can't resist taking a risk for a potential payoff.", "I lie about almost everything, even when there’s no good reason to.", "Sarcasm and insults are my weapons of choice.",
                                "I keep multiple holy symbols on me and invoke whatever deity might come in useful at any given moment.", "I pocket anything I see that might have some value." },
                            new List<string> { "I am a free spirit— no one tells me what to do.", "I never target people who can’t afford to lose a few coins.", "I distribute the money I acquire to the people who really need it.",
                                "I never run the same con twice.", "Material goods come and go. Bonds of friendship last forever.", "I’m determined to make something of myself." },
                            new List<string> { "I fleeced the wrong person and must work to ensure that this individual never crosses paths with me or those I care about.", "I owe everything to my mentor—a horrible person who’s probably rotting in jail somewhere.",
                                "Somewhere out there, I have a child who doesn’t know me. I’m making the world better for him or her.", "I come from a noble family, and one day I’ll reclaim my lands and title from those who stole them from me.",
                                "A powerful person killed someone I love.Some day soon, I’ll have my revenge.", "I swindled and ruined a person who didn’t deserve it.I seek to atone for my misdeeds but might never be able to forgive myself." },
                            new List<string> { "I can’t resist a pretty face.", "I'm always in debt. I spend my ill-gotten gains on decadent luxuries faster than I bring them in.", "I’m convinced that no one could ever fool me the way I fool others.",
                                "I’m too greedy for my own good. I can’t resist taking a risk if there’s money involved.", "I can’t resist swindling people who are more powerful than me.", "I hate to admit it and will hate myself for it, but I'll run and preserve my own hide if the going gets tough." }, character);
                    }
                    break;
                case "Criminal":
                    {
                        addBackgroundData(bg, new int[] { 4, 16 }, null, new List<string> { "A Gaming set of your choice", "Thieves' Tools" }, new List<string> { "Crowbar", "Set of dark common clothes including a hood" }, 15, new List<string> { "Criminal Contact" },
                                          new List<string> { "You have a reliable and trustworthy contact who acts as your liaison to a network of other criminals. You know how to get messages to and from your contact, even over great distances; specifically, you know the local messengers, corrupt caravan masters, and seedy sailors who can deliver messages for you." },
                                          new List<string> { "I always have a plan for when things go wrong.", "I am always calm, no matter what the situation. I never raise my voice or let my emotions control me.", "The first thing I do in a place is note locations of anything valuable or where such things could be hidden.",
                                              "I would rather make a new friend than a new enemy.", "I am incredibly slow to trust. Those who seem the fairest often have the most to hide.", "I don't pay attention to the risks in a situation. Never tell me the odds.",
                                              "The best way to get me to do something is to tell me I can't do it.", "I blow up at the slightest insult."},
                                          new List<string> { "I don’t steal from others in the trade.", "Chains are meant to be broken, as are those who would forge them.", "I steal from the wealthy so that I can help people in need.", "I will do whatever it takes to become wealthy.",
                                              "I’m loyal to my friends, not to any ideals, and everyone else can take a trip down the Styx for all I care.", "There’s a spark of good in everyone." },
                                          new List<string> { "I’m trying to pay off an old debt I owe to a generous benefactor.", "My ill-gotten gains go to support my family.", "Something important was taken from me, and I aim to steal it back.", "I will become the greatest thief that ever lived.",
                                              "I’m guilty of a terrible crime. I hope I can redeem myself for it.", "Someone I loved died because of a mistake I made. That will never happen again." },
                                          new List<string> { "When I see something valuable, I can’t think about anything but how to steal it.", "When faced with a choice between money and my friends, I usually choose the money.", "If there’s a plan, I’ll forget it. If I don’t forget it, I’ll ignore it.",
                                              "I have a “tell” that reveals when I'm lying.", "I turn tail and run when things look bad.", "An innocent person is in prison for a crime that I committed. I’m okay with that." }, character);
                    }
                    break;
                case "Entertainer":
                    {
                        addBackgroundData(bg, new int[] { 0, 12 }, null, new List<string> { "Disguise Kit", "Musical instrument of your choice" }, new List<string> { "Musical instrument of your choice", "the favor of an admirer (love letter, lock of hair, or trinket)", "a costume" }, 15,
                                          new List<string> { "By Popular Demand" }, new List<string> { "You can always find a place to perform, usually in an inn or tavern but possibly with a circus, at a theater, or even in a noble’s court. At such a place, you receive free lodging and food of a modest or comfortable standard (depending on the quality of the establishment), as long as you perform each night. In addition, your performance makes you something of a local figure. When strangers recognize you in a town where you have performed, they typically take a liking to you." },
                                          new List<string> { "I know a story relevant to almost every situation.", "Whenever I come to a new place, I collect local rumors and spread gossip.", "I’m a hopeless romantic, always searching for that “special someone.”",
                                              "Nobody stays angry at me or around me for long, since I can defuse any amount of tension.", "I love a good insult, even one directed at me.", "I get bitter if I’m not the center of attention.",
                                              "I’ll settle for nothing less than perfection.", "I change my mood or my mind as quickly as I change key in a song."},
                                          new List<string> { "Beauty. When I perform, I make the world better than it was.", "The stories, legends, and songs of the past must never be forgotten, for they teach us who we are.", "The world is in need of new ideas and bold action.", ".I’m only in it for the money and fame.",
                                              "I like seeing the smiles on people’s faces when I perform. That’s all that matters.", "Art should reflect the soul; it should come from within and reveal who we really are." },
                                          new List<string> { "My instrument is my most treasured possession, and it reminds me of someone I love.", "Someone stole my precious instrument, and someday I’ll get it back.", "I want to be famous, whatever it takes.",
                                              "I idolize a hero of the old tales and measure my deeds against that person’s.", "I will do anything to prove myself superior to my hated rival.", "I would do anything for the other members of my old troupe." },
                                          new List<string> { "I’ll do anything to win fame and renown.", "I’m a sucker for a pretty face.", "A scandal prevents me from ever going home again. That kind of trouble seems to follow me around.",
                                              "I once satirized a noble who still wants my head. It was a mistake that I will likely repeat.", "I have trouble keeping my true feelings hidden. My sharp tongue lands me in trouble.", "Despite my best efforts, I am unreliable to my friends." }, character);
                    }
                    break;
                case "Folk Hero":
                    {
                        addBackgroundData(bg, new int[] { 1, 17 }, null, new List<string> { "One type of artisans tools", "Land Vehicles" }, new List<string> { "A set of artisan’s tools (one of your choice)", "Shovel", "Iron pot", "A set of common clothes" }, 10,
                                          new List<string> { "Rustic Hospitality" }, new List<string> { "Since you com e from the ranks of the common folk, you fit in among them with ease. You can find a place to hide, rest, or recuperate among other commoners, unless you have shown yourself to be a danger to them. They will shield you from the law or anyone else searching for you, though they will not risk their lives for you." },
                                          new List<string> { "I judge people by their actions, not their words.", "If someone is in trouble, I’m always ready to lend help.", "When I set my mind to something, I follow through no matter what gets in my way.",
                                              "I have a strong sense of fair play and always try to find the most equitable solution to arguments.", "I’m confident in my own abilities and do what I can to instill confidence in others.", "Thinking is for other people. I prefer action.",
                                              "I misuse long words in an attempt to sound smarter.", "I get bored easily. When am I going to get on with my destiny" },
                                          new List<string> { "Respect. People deserve to be treated with dignity and respect.", "No one should get preferential treatment before the law, and no one is above the law.", "Tyrants must not be allowed to oppress the people.",
                                              "If I become strong, I can take what I want— what I deserve.", "There’s no good in pretending to be something I’m not.", "Nothing and no one can steer me away from my higher calling." },
                                          new List<string> { "I have a family, but I have no idea where they are. One day, I hope to see them again.", "I worked the land, I love the land, and I will protect the land.", "A proud noble once gave me a horrible beating, and I will take my revenge on any bully I encounter.",
                                              "My tools are symbols of my past life, and I carry them so that I will never forget my roots.", "I protect those who cannot protect themselves.", "I wish my childhood sweetheart had come with me to pursue my destiny." },
                                          new List<string> { "The tyrant who rules my land will stop at nothing to see me killed.", "I’m convinced of the significance of my destiny, and blind to my shortcomings and the risk of failure.", "The people who knew me when I was young know my shameful secret, so I can never go home again.",
                                              "I have a weakness for the vices of the city, especially hard drink.", "Secretly, I believe that things would be better if I were a tyrant lording over the land.", "I have trouble trusting in my allies." }, character);
                    }
                    break;
                case "Guild Artisan":
                    {
                        addBackgroundData(bg, new int[] { 6, 13 }, new List<string> { "{Language of Choice}" }, new List<string> { "One type of artisans tools" }, new List<string> { "A set of artisan’s tools (one of your choice)", "A letter of introduction from your guild", "A set of traveler’s clothes" }, 15,
                                          new List<string> { "Guild Membership" }, new List<string> { "As an established and respected member of a guild, you can rely on certain benefits that membership provides. Your fellow guild members will provide you with lodging and food if necessary, and pay for your funeral if needed. In some cities and towns, a guildhall offers a central place to meet other members of your profession, which can be a good place to meet potential patrons, allies, or hirelings. Guilds often wield tremendous political power. If you are accused of a crime, your guild will support you if a good case can be made for your innocence or the crime is justifiable. You can also gain access to powerful political figures through the guild, if you are a member in good standing. Such connections might require the donation of money or magic items to the guild’s coffers. You must pay dues of 5 gp per month to the guild. If you miss payments, you must make up back dues to remain in the guild’s good graces." },
                                          new List<string> { "I believe that anything worth doing is worth doing right. I can’t help it— I’m a perfectionist.", "I’m a snob who looks down on those who can’t appreciate fine art.", "I always want to know how things work and what makes people tick.",
                                              "I’m full of witty aphorisms and have a proverb for every occasion.", "I’m rude to people who lack my commitment to hard work and fair play.", "I like to talk at length about my profession.", "I don’t part with my money easily and will haggle tirelessly to get the best deal possible.", "I’m well known for my work, and I want to make sure everyone appreciates it.I'm always taken aback when  people haven’t heard of me." },
                                          new List<string> { "It is the duty of all civilized people to strengthen the bonds of community and the security of civilization.", "My talents were given to me so that I could use them to benefit the world.",
                                              "Everyone should be free to pursue his or her own livelihood.", "I’m only in it for the money.", "I’m committed to the people I care about, not to ideals.", "I work hard to be the best there is at my craft." },
                                          new List<string> { "The workshop where I learned my trade is the most important place in the world to me.", "I created a great work for someone, and then found them unworthy to receive it. I’m still looking for someone worthy.",
                                              "I owe my guild a great debt for forging me into the person I am today.", "I pursue wealth to secure someone’s love.", "One day I will return to my guild and prove that I am the greatest artisan of them all.","I will get revenge on the evil forces that destroyed my place of business and ruined my livelihood." },
                                          new List<string> { "I’ll do anything to get my hands on something rare or priceless.", "I’m quick to assume that someone is trying to cheat me.", "No one must ever learn that I once stole money from guild coffers.",
                                              "I’m never satisfied with what I have— I always want more.", "I would kill to acquire a noble title.", "I’m horribly jealous of anyone who can outshine my handiwork. Everywhere I go, I’m surrounded by rivals." }, character);
                    }
                    break;
                case "Hermit":
                    {
                        addBackgroundData(bg, new int[] { 9, 14 }, new List<string> { "{Language of Choice}" }, new List<string> { "Herbalism Kit" }, new List<string> { " A scroll case stuffed full of notes from your studies or prayers", "A winter blanket", "A set of common clothes", "An herbalism kit" }, 5,
                                          new List<string> { "Discovery" }, new List<string> { "The quiet seclusion of your extended hermitage gave you access to a unique and powerful discovery. The exact nature of this revelation depends on the nature of your seclusion. It might be a great truth about the cosmos, the deities, the powerful beings of the outer planes, or the forces of nature. It could be a site that no one else has ever seen. You might have uncovered a fact that has long been forgotten, or unearthed som e relic of the past that could rewrite history. It might be information that would be damaging to the people who or consigned you to exile, and hence the reason for your return to society. Work with your DM to determine the details of your discovery and its impact on the campaign." },
                                          new List<string> { "I’ve been isolated for so long that I rarely speak, preferring gestures and the occasional grunt.", "I am utterly serene, even in the face of disaster.", "The leader of my community had something wise to say on every topic, and I am eager to share that wisdom.",
                                              "I feel tremendous empathy for all who suffer.", "I’m oblivious to etiquette and social expectations.", "I connect everything that happens to me to a grand, cosmic plan.", "I often get lost in my own thoughts and contemplation, becoming oblivious to my surroundings.", "I am working on a grand philosophical theory and love sharing my ideas." },
                                          new List<string> { "Greater Good. My gifts are meant to be shared with all, not used for my own benefit.", "Emotions must not cloud our sense of what is right and true, or our logical thinking.", "Inquiry and curiosity are the pillars of progress.",
                                              "Solitude and contemplation are paths toward mystical or magical power.", "Meddling in the affairs of others only causes trouble.", "If you know yourself, there’s nothing left to know." },
                                          new List<string> { "Nothing is more important than the other members of my hermitage, order, or association.", "I entered seclusion to hide from the ones who might still be hunting me. I must someday confront them.",
                                              "I’m still seeking the enlightenment I pursued in my seclusion, and it still eludes me.", "I entered seclusion because I loved someone I could not have.", "Should my discovery come to light, it could bring ruin to the world.", "My isolation gave me great insight into a great evil that only I can destroy" },
                                          new List<string> { "Now that I've returned to the world, I enjoy its delights a little too much.", "I harbor dark, bloodthirsty thoughts that my isolation and meditation failed to quell.", "I am dogmatic in my thoughts and philosophy.",
                                              "I let my need to win arguments overshadow friendships and harmony.", "I’d risk too much to uncover a lost bit of knowledge.", "I like keeping secrets and won’t share them with anyone." }, character);
                    }
                    break;
                case "Noble":
                    {
                        addBackgroundData(bg, new int[] { 5, 13 }, new List<string> { "{Language of Choice}" }, new List<string> { "One type of Gaming Set" }, new List<string> { "A set of fine clothes", "A signet ring", "A scroll of pedigree" }, 25,
                                          new List<string> { "Position of Privilege" }, new List<string> { "Thanks to your noble birth, people are inclined to think the best of you. You are welcom e in high society, and people assume you have the right to be wherever you are. The common folk make every effort to accommodate you and avoid your displeasure, and other people of high birth treat you as a member of the same social sphere. You can secure an audience with a local noble if you need to." },
                                          new List<string> { "My eloquent flattery makes everyone I talk to feel like the most wonderful and important person in the world.", "The common folk love me for my kindness and generosity.", "No one could doubt by looking at my regal bearing that I am a cut above the unwashed masses.",
                                              "I take great pains to always look my best and follow the latest fashions.", "I don’t like to get my hands dirty, and I won’t be caught dead in unsuitable accommodations.", "Despite my noble birth, I do not place myself above other folk. We all have the same blood.",
                                              "My favor, once lost, is lost forever.", "If you do me an injury, I will crush you, ruin your name, and salt your fields." },
                                          new List<string> { "Respect is due to me because of my position, but all people regardless of station deserve to be treated with dignity.", "It is my duty to respect the authority ofthose above me, just as those below me must respect mine.", "I must prove that I can handle myself without the coddling of my family.",
                                              "If I can attain more power, no one will tell me what to do.", "Blood runs thicker than water.", "It is my duty to protect and care for the people beneath me." },
                                          new List<string> { "I will face any challenge to win the approval of my family.", "My house’s alliance with another noble family must be sustained at all costs.", "Nothing is more important than the other members of my family.",
                                              "I am in love with the heir of a family that my family despises.", "My loyalty to my sovereign is unwavering.", "The common folk must see me as a hero o ft he people." },
                                          new List<string> { "I secretly believe that everyone is beneath me.", "I hide a truly scandalous secret that could ruin my family forever.", "I too often hear veiled insults and threats in every word addressed to me, and I’m quick to anger.",
                                              "I have an insatiable desire for carnal pleasures.", "In fact, the world does revolve around me.", "By my words and actions, I often bring shame to my family." }, character);
                    }
                    break;
                case "Outlander":
                    {
                        addBackgroundData(bg, new int[] { 3, 17 }, new List<string> { "{Language of Choice" }, new List<string> { "One type of musical instrument" }, new List<string> { "A staff", "A hunting trap", "A trophy from an animal you killed", "A set of traveler’s clothes" }, 10,
                                          new List<string> { "Wanderer" }, new List<string> { "You have an excellent memory for maps and geography, and you can always recall the general layout of terrain, settlements, and other features around you. In addition, you can find food and fresh water for yourself and up to five other people each day, provided that the land offers berries, small game, water, and so forth." },
                                          new List<string> { "I’m driven by a wanderlust that led me away from home.", "I watch over my friends as if they were a litter of newborn pups.", "I once ran twenty-five miles without stopping to warn to my clan of an approaching orc horde. I’d do it again if I had to.",
                                              "I have a lesson for every situation, drawn from observing nature.", "I place no stock in wealthy or well - mannered folk. Money and manners won’t save you from a hungry owlbear.", "I’m always picking things up, absently fiddling with them, and sometimes accidentally breaking them.",
                                              "I feel far more comfortable around animals than people.", "I was, in fact, raised by wolves." },
                                          new List<string> { "Life is like the seasons, in constant change, and we must change with it.", "It is each person’s responsibility to make the most happiness for the whole tribe.", "If I dishonor myself, I dishonor my whole clan.",
                                              "The strongest are meant to rule.", "The natural world is more important than all the constructs of civilization.", "I must earn glory in battle, for myself and my clan." },
                                          new List<string> { "My family, clan, or tribe is the most important thing in my life, even when they are far from me.", "An injury to the unspoiled wilderness of my home is an injury to me.", "I will bring terrible wrath down on the evildoers who destroyed my homeland.",
                                              "I am the last of my tribe, and it is up to me to ensure their names enter legend.", "I suffer awful visions of a coming disaster and will do to prevent it.", "It is my duty to provide children to sustain my tribe." },
                                          new List<string> { "I am too enamored of ale, wine, and other intoxicants.", "There’s no room for caution in a life lived to the fullest.", "I remember every insult I’ve received and nurse a silent resentment toward anyone who’s ever wronged me.",
                                              "I am slow to trust members of other races, tribes, and societies.", "Violence is my answer to almost any challenge.", "Don’t expect me to save those who can’t save themselves. It is nature’s way that the strong thrive and the weak perish."}, character);
                    }
                    break;
                case "Sage":
                    {
                        addBackgroundData(bg, new int[] { 2, 5 }, new List<string> { "{Language of Choice}", "{Language of Choice}" }, null, new List<string> { "A bottle of black ink", "A quill", "A small knife", "A letter from a dead colleague posing a question you have not yet been able to answer", "A set of common clothes" }, 10,
                                          new List<string> { "Researcher" }, new List<string> { "When you attempt to learn or recall a piece of lore, if you do not know that information, you often know where and from whom you can obtain it. Usually, this information com es from a library, scriptorium, university, or a sage or other learned person or creature. Your DM might rule that the knowledge you seek is secreted away in an almost inaccessible place, or that it simply cannot be found. Unearthing the deepest secrets of the multiverse can require an adventure or even a whole campaign." },
                                          new List<string> { "I use polysyllabic words that convey the impression of great erudition.", "I've read every book in the world’s greatest libraries—  or I like to boast that I have.", "I'm used to helping out those who aren’t as smart as  I am, and I patiently explain anything and everything to others.",
                                              "There’s nothing I like more than a good mystery.", "I’m willing to listen to every side of an argument before I make my own judgment.", "I . . . speak . . . slowly . .  . when talking . . . to idiots, . . . which . . . almost.  . . everyone . . .  is . . . compared . . . to me.",
                                              "I am horribly, horribly awkward in social situations.", "I’m convinced that people are always trying to steal my secrets." },
                                          new List<string> { "The path to power and self-improvement is through knowledge.", "What is beautiful points us beyond itself toward what is true.", "Emotions must not cloud our logical thinking.", "Nothing should fetter the infinite possibility inherent in all existence.",
                                              "Knowledge is the path to power and domination.", "The goal of a life of study is the betterment of oneself." },
                                          new List<string> { "It is my duty to protect my students.", "I have an ancient text that holds terrible secrets that must not fall into the wrong hands.", "I work to preserve a library, university, scriptorium, or monastery.", "My life’s work is a series of tomes related to a specific field of lore.",
                                              "I've been searching my whole life for the answer to a certain question.", "I sold my soul for knowledge. I hope to do great deeds and win it back." },
                                          new List<string> { "I am easily distracted by the promise of information.", "Most people scream and run when they see a demon. I stop and take notes on its anatomy.", "Unlocking an ancient mystery is worth the price of a civilization.",
                                              "I overlook obvious solutions in favor of complicated ones.", "I speak without really thinking through my words, invariably insulting others.", "I can’t keep a secret to save my life, or anyone else’s" }, character);
                    }
                    break;
                case "Sailor":
                    {
                        addBackgroundData(bg, new int[] { 3, 11 }, null, new List<string> { "Navigator's Tools", "Water Vehicles" }, new List<string> { "A belaying pin (club)", "50 feet of silk rope", "A lucky charm such as a rabbit foot or a small stone with a hole in the center (or you may roll for a random trinket on the Trinkets table in chapter 5)", "A set of common clothes" }, 10,
                                          new List<string> { "Ship's Passage" }, new List<string> { "When you need to, you can secure free passage on a sailing ship for yourself and your adventuring companions. You might sail on the ship you served on, or another ship you have good relations with (perhaps one captained by a former crewmate). Because you’re calling in a favor, you can’t be certain of a schedule or route that will meet your every need. Your Dungeon Master will determine how long it takes to get where you need to go. In return for your free passage, you and your companions are expected to assist the crew during the voyage." },
                                          new List<string> { "My friends know they can rely on me, no matter what.", "I work hard so that I can play hard when the work is done.", "I enjoy sailing into new ports and making new friends over a flagon of ale.",
                                              "I stretch the truth for the sake of a good story.", "To me, a tavern brawl is a nice way to get to know a new city.", "I never pass up a friendly wager.", "My language is as foul as an otyugh nest.", "I like a job well done, especially if I can convince someone else to do it." },
                                          new List<string> { "The thing that keeps a ship together is mutual respect between captain and crew.", "We all do the work, so we all share in the rewards.", "The sea is freedom—the freedom to go anywhere and do anything.",
                                              "I’m a predator, and the other ships on the sea are my prey.", "I’m committed to my crewmates, not to ideals.", "Someday I’ll own my own ship and chart my own destiny." },
                                          new List<string> { "I’m loyal to my captain first, everything else second.", "The ship is most important—crewmates and captains come and go.", "I’ll always remember my first ship.", "In a harbor town, I have a paramour whose eyes nearly stole me from the sea.",
                                              "I was cheated out of my fair share of the profits, and  I want to get my due.", "Ruthless pirates murdered my captain and crewmates, plundered our ship, and left me to die. Vengeance will be mine." },
                                          new List<string> { "I follow orders, even if I think they’re wrong.", "I’ll say anything to avoid having to do extra work.", "Once someone questions my courage, I never back down no matter how dangerous the situation.",
                                              "Once I start drinking, it’s hard for me to stop.", "I can’t help but pocket loose coins and other trinkets I come across.", "My pride will probably lead to my destruction." }, character);
                    }
                    break;
                case "Soldier":
                    {
                        addBackgroundData(bg, new int[] { 3, 7 }, null, new List<string> { "One type of gaming set", "Land Vehicles" }, new List<string> { "An insignia of rank", "A trophy taken from a fallen enemy (a dagger, broken blade, or piece of a banner)", "A set of bone dice or deck of cards", "A set of common clothes" }, 10,
                                          new List<string> { "Military Rank" }, new List<string> { "You have a military rank from your career as a soldier. Soldiers loyal to your former military organization still recognize your authority and influence, and they defer to you if they are of a lower rank. You can invoke your rank to exert influence over other soldiers and requisition simple equipment or horses for temporary use. You can also usually gain access to friendly military encampments and fortresses where your rank is recognized." },
                                          new List<string> { "I'm always polite and respectful.", "I’m haunted by memories of war. I can’t get the images of violence out of my mind.", "I’ve lost too many friends, and I’m slow to make new ones. ",
                                              "I’m full of inspiring and cautionary tales from my military experience relevant to almost every combat situation. ", "I can stare down a hell hound without flinching.", "I enjoy being strong and like breaking things.",
                                              "I have a crude sense of humor.", "I face problems head-on. A simple, direct solution is the best path to success." },
                                          new List<string> { "Our lot is to lay down our lives in defense of others.", "I do what I must and obey just authority.", "When people follow orders blindly, they embrace a kind of tyranny.", "In life as in war, the stronger force wins.",
                                              "Ideals aren’t worth killing over or going to war for.", "My city, nation, or people are all that matter." },
                                          new List<string> { "I would still lay down my life for the people I served with.", "Someone saved my life on the battlefield. To this day, I will never leave a friend behind.", "My honor is my life.",
                                              "I’ll never forget the crushing defeat my company suffered or the enemies who dealt it.", "Those who fight beside me are those worth dying for.", "I fight for those who cannot fight for themselves." },
                                          new List<string> { "The monstrous enemy we faced in battle still leaves me quivering with fear.", "I have little respect for anyone who is not a proven warrior.", "I made a terrible mistake in battle cost many lives— and I would do anything to keep that mistake secret.",
                                              "My hatred of my enemies is blind and unreasoning.", "I obey the law, even if the law causes misery.", "I’d rather eat my armor than admit when I’m wrong." }, character);
                    }
                    break;
                case "Urchin":
                    {
                        addBackgroundData(bg, new int[] { 15, 16 }, null, new List<string> { "Disguise Kit", "Thieves' Tools" }, new List<string> { "A small knife", "A map of the city you grew up in", "A pet mouse", "A token to remember your parents by", "A set of common clothes" }, 10,
                                          new List<string> { "City Secrets" }, new List<string> { "You know the secret patterns and flow to cities and can find passages through the urban sprawl that others would miss. When you are not in combat, you (and companions you lead) can travel between any two locations in the city twice as fast as your speed would normally allow." },
                                          new List<string> { "I hide scraps of food and trinkets away in my pockets.", "I ask a lot of questions.", "I like to squeeze into small places where no one else can get to me.", "I sleep with my back to a wall or tree, with everything I own wrapped in a bundle in my arms.",
                                              "I eat like a pig and have bad manners.", "I think anyone who’s nice to me is hiding evil intent.", "I don’t like to bathe.", "I bluntly say what other people are hinting at or hiding." },
                                          new List<string> { "All people, rich or poor, deserve respect.", "We have to take care of each other, because no one else is going to do it.", "The low are lifted up, and the high and mighty are brought down. Change is the nature of things.",
                                              "The rich need to be shown what life and death are like in the gutters.", "I help the people who help me—that’s what keeps us alive.", "I'm going to prove that I'm worthy of a better life." },
                                          new List<string> { "My town or city is my home, and I’ll fight to defend it.", "I sponsor an orphanage to keep others from enduring what I was forced to endure.", "I owe my survival to another urchin who taught me to live on the streets.",
                                              "I owe a debt I can never repay to the person who took pity on me.", "I escaped my life of poverty by robbing an important person, and I’m wanted for it.", "No one else should have to endure the hardships I’ve been through." },
                                          new List<string> { "If I'm outnumbered, I will run away from a fight.", "Gold seems like a lot of money to me, and I’ll do just about anything for more of it.", "I will never fully trust anyone other than myself.",
                                              "I’d rather kill someone in their sleep then fight fair.", "It’s not stealing if I need it more than someone else.", "People who can't take care of themselves get what they deserve." }, character);
                    }
                    break;
            }
        }

        private void addBackgroundData(string bgName, int[] skillProfs, List<string> languages, List<string> toolProfs, List<string> equipment, int gold, List<string> featureNames, List<string> featureDescs,
                                        List<string> Personalities, List<string> ideals, List<string> bonds, List<string> flaws, Character character)
        {
            Random rng = new Random();


            //Skills/BGNAME
            {
                Background = bgName;

                //Set proficient if skill number in skillProfs matches the index
                if (skillProfs != null)
                {
                    for(int i = 0; i < skillProfs.Length; i++)
                    {
                        for(int j = 0; j < character.CharSkills.CharSkills.Length; j++)
                        {
                            if (skillProfs[i] == j) character.CharSkills.CharSkills[j].IsProficient = true;
                        }                        
                    }
                }
            }

            //Languages/Tools
            {

                if (languages != null)
                {
                    foreach (string s in languages)
                    {
                        character.Proficiencies.Add("Read/Write and speak " + s);
                    }
                }

                if (toolProfs != null)
                {
                    foreach (string s in toolProfs)
                    {
                        character.Proficiencies.Add(s);
                    }
                }
            }

            //Equipment
            {
                if (equipment != null)

                {
                    foreach (string s in equipment)
                    {
                        character.CharInventory.AddItem(s, "", 0);
                    }
                }
            character.CharWallet.gold = gold;
            }


            //Features
            {

                if (featureNames != null && featureDescs != null)
                {
                    for (int i = 0; i < featureNames.Count; i++)
                    {
                        character.Features.AddFeature(featureNames[i], featureDescs[i]);
                    }
                }
            }

            //Personality/Ideals/Bonds/Flaws
            {

                if (Personalities != null && Personalities.Count != 0)
                {
                    BackgroundInfo[0] = Personalities[rng.Next(0, Personalities.Count)];
                }

                if (ideals != null && ideals.Count != 0)
                {
                    BackgroundInfo[1] = ideals[rng.Next(0, ideals.Count)];
                }

                if (bonds != null && bonds.Count != 0)
                {
                    BackgroundInfo[2] = bonds[rng.Next(0, bonds.Count)];
                }

                if (flaws != null && flaws.Count != 0)
                {
                    BackgroundInfo[3] = flaws[rng.Next(0, flaws.Count)];
                }
            }
        }

        private void addClassData(string className, int hitDie, int[] primsecStats, List<string> armorProfs, List<string> weaponProfs, List<string> toolProfs, int[] savingProfs, int[] skillProfs, int skillCount,
                                  List<string> equipment, int AC, int spellsKnown, int cantripsKnown, List<string> featureNames, List<string> featureDescs, Character character)
        {
            Random rng = new Random();
            List<int> ints = new List<int>();

            //SAVINGMODS
            {
                character.SavingThrows.CalculateSaveThrowModifiers(character);
            }

            //SKILLSMODS
            {
                character.CharSkills.CalculateSkillModifiers(character);
            }

            //PROFS/HEALTH/CLASSNAME
            {
                Class = className;
                character.CharStats.MaxHP = hitDie + character.CharStats.ConstitutionMod;
                character.CharStats.CurrentHP = hitDie + character.CharStats.ConstitutionMod;
                if (armorProfs != null) foreach (string s in armorProfs)
                    {
                        character.Proficiencies.Add(s);
                    }
                if (weaponProfs != null) foreach (string s in weaponProfs)
                    {
                        character.Proficiencies.Add(s);
                    }
                if (toolProfs != null) foreach (string s in toolProfs)
                    {
                        character.Proficiencies.Add(s);
                    }
                if (savingProfs != null) foreach (int i in savingProfs)
                    {
                        eCastingAbility prof = (eCastingAbility)i;
                        switch (prof)
                        {
                            case eCastingAbility.STRENGTH:
                                character.SavingThrows.isProficientStrengthSave = true;
                                break;
                            case eCastingAbility.DEXTERITY:
                                character.SavingThrows.isProficientDexteritySave = true;
                                break;
                            case eCastingAbility.CONSTITUTION:
                                character.SavingThrows.isProficientConstitutionSave = true;
                                break;
                            case eCastingAbility.INTELLIGENCE:
                                character.SavingThrows.isProficientIntelligenceSave = true;
                                break;
                            case eCastingAbility.WISDOM:
                                character.SavingThrows.isProficientWisdomSave = true;
                                break;
                            case eCastingAbility.CHARISMA:
                                character.SavingThrows.isProficientCharismaSave = true;
                                break;
                        }
                    }

                bool exists = false;
                int rand = 0;
                int counter = 0;

                for (int i = 0; i < skillCount; i++)
                {
                    do
                    {
                        rand = skillProfs[rng.Next(0, skillProfs.Length)];

                        //Find skill that matches skills in array
                        for (int k = 0; k < skillProfs.Length; k++)
                        {
                            for (int j = 0; j < character.CharSkills.CharSkills.Length; j++)
                            {
                                if (skillProfs[k] == j)
                                {
                                    //Continues loop if proficient
                                    if (character.CharSkills.CharSkills[j].IsProficient) exists = true;
                                    else
                                    {
                                        //Set proficient then exit loop
                                        character.CharSkills.CharSkills[j].IsProficient = true;
                                        exists = false;
                                    }
                                    for (; i < skillProfs.Count(); i++)
                                    {
                                        //Check if all skills are proficient
                                        if (character.CharSkills.CharSkills[j].IsProficient) counter++; 
                                    }

                                    //Exit loop if all skills are proficient
                                    if (counter == skillProfs.Count()) exists = false;
                                }
                            }
                        }
                    }
                    while (exists);
                }
            }

            //INVENTORY/AC
            {

                if (equipment != null) foreach (string s in equipment)
                    {
                        character.CharInventory.AddItem(s, "", 0);
                    }
            character.CharStats.ArmorClass = AC;
            }

            //SPELLS/CANTRIPS
            {
                if (spellsKnown > 0) character.Spells.AddSpell("Spells Known", "You know: " + spellsKnown + " spells.", 0);
                if (cantripsKnown > 0) character.Spells.AddSpell("Catrips Known", "You know: " + cantripsKnown + " cantrips.", 0);

            }

            //FEATURES
            {

                if (featureNames != null && featureDescs != null) for (int i = 0; i < featureNames.Count; i++)
                    {
                        character.Features.AddFeature(featureNames.ElementAt(i), featureDescs.ElementAt(i));
                    }
            }
        }
    }

    #endregion
}
