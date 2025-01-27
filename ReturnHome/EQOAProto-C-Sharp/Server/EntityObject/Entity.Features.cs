using System;
using System.Collections.Generic;
using ReturnHome.Server.EntityObject.Player;
using ReturnHome.Server.Network;
using ReturnHome.Utilities;

namespace ReturnHome.Server.EntityObject
{
    public partial class Entity
    {
        private int _race;
        private int _class;
        public string HumType;

        private string _charName;

        private int _hairColor;
        private int _hairLength;
        private int _hairStyle;
        private int _faceOption;

        private byte _helm;
        private byte _chest;
        private byte _gloves;
        private byte _bracers;
        private byte _legs;
        private byte _boots;

        //default is 0xFFFFFFFF, means no robe
        private int _robe;
        private int _primary;
        private int _secondary;
        private int _shield;

        private int _modelID;
        private float _modelSize;

        ///Armor color
        private uint _helmColor;
        private uint _chestColor;
        private uint _glovesColor;
        private uint _bracerColor;
        private uint _legsColor;
        private uint _bootsColor;
        private uint _robeColor;

        #region Objext Update Properties

        public int Race
        {
            get { return _race; }
            set
            {
                if (value >= 0 && value <= 9)
                {
                    _race = value;
                    ObjectUpdateRace();
                }

                else
                    Logger.Err($"Error setting Race value {value} for {_charName}");
            }
        }

        public int Class
        {
            get { return _class; }
            set
            {
                if (value >= 0 && value <= 15)
                {
                    _class = value;
                    ObjectUpdateClass();
                }

                else
                    Logger.Err($"Error setting Class value {value} for {_charName}");
            }
        }

        public string CharName
        {
            get { return _charName; }
            set
            {
                if (value.Length >= 2 && value.Length <= 25)
                {
                    _charName = value;
                    ObjectUpdateName();
                }

                else
                    Logger.Err($"Error setting Name {value} for {_charName}");
            }
        }

        public int HairColor
        {
            get { return _hairColor; }
            set
            {
                if (value >= 0 && value <= 9)
                {
                    _hairColor = value;
                    ObjectUpdateHairColor();
                }

                else
                    Logger.Err($"Error setting HairColor {value} for {_charName}");
            }
        }

        public int HairLength
        {
            get { return _hairLength; }
            set
            {
                if (value >= 0 && value <= 4)
                {
                    _hairLength = value;
                    ObjectUpdateHairLength();
                }

                else
                    Logger.Err($"Error setting Hair lengtb {_hairLength} for {_charName}");
            }
        }

        public int HairStyle
        {
            get { return _hairStyle; }
            set
            {
                if (value >= 0 && value <= 4)
                {
                    _hairStyle = value;
                    ObjectUpdateHairStyle();
                }

                else
                    Logger.Err($"Error setting Hair Style {value} for {_charName}");
            }
        }

        public int FaceOption
        {
            get { return _faceOption; }
            set
            {
                if (value >= 0 && value <= 4)
                {
                    _faceOption = value;
                    ObjectUpdateFaceOption();
                }

                else
                    Logger.Err($"Error setting Face {value} for {_charName}");
            }
        }

        public int Robe
        {
            get { return _robe; }
            set
            {
                if (value >= -1 && value <= 4)
                {
                    _robe = value;
                    ObjectUpdateRobe();
                }

                else
                    Logger.Err($"Error setting Robe {value} for {_charName}");
            }
        }

        public int Primary
        {
            get { return _primary; }
            set
            {
                if (true)
                {
                    _primary = value;
                    ObjectUpdatePrimary();
                }

                else
                    Logger.Err($"Error setting Primary {_primary} for {_charName}");
            }
        }

        public int Secondary
        {
            get { return _secondary; }
            set
            {
                if (true)
                {
                    _secondary = value;
                    ObjectUpdateSecondary();
                }

                else
                    Logger.Err($"Error setting Secondary {value} for {_charName}");
            }
        }

        public int Shield
        {
            get { return _shield; }
            set
            {
                if (true)
                {
                    _shield = value;
                    ObjectUpdateShield();
                }

                else
                    Logger.Err($"Error setting Shield {value} for {_charName}");
            }
        }

        public byte Helm
        {
            get { return _helm; }
            set
            {
                if (value >= 0 && value <= 8)
                {
                    _helm = value;
                    ObjectUpdateHelm();
                }

                else
                    Logger.Err($"Error setting Helm {value} for {_charName}");
            }
        }

        public byte Chest
        {
            get { return _chest; }
            set
            {
                if(value >= 0 && value <= 8)
                {
                    _chest = value;
                    ObjectUpdateChest();
                }
            }
        }

        public byte Gloves
        {
            get { return _gloves; }
            set
            {
                if ( value >= 0 && value <= 8)
                {
                    _gloves = value;
                    ObjectUpdateGloves();
                }
            }
        }

        public byte Bracer
        {
            get { return _bracers; }
            set
            {
                if( value >= 0 && value <= 8)
                {
                    _bracers = value;
                    ObjectUpdateBracer();
                }
            }
        }

        public byte Legs
        {
            get { return _legs; }
            set
            {
                if( value >= 0 && value <= 8)
                {
                    _legs = value;
                    ObjectUpdateLegs();
                }
            }
        }

        public byte Boots
        {
            get { return _boots; }
            set
            {
                if( value >= 0 && value <= 8)
                {
                    _boots = value;
                    ObjectUpdateBoots();
                }
            }
        }

        public uint HelmColor
        {
            get { return _helmColor; }
            set
            {
                if (true)
                {
                    _helmColor = value;
                    ObjectUpdateHelmColor();
                }
            }
        }

        public uint ChestColor 
        {
            get { return _chestColor; }
            set
            {
                if (true)
                {
                    _chestColor = value;
                    ObjectUpdateChestColor();
                }
            }
        }

        public uint GloveColor
        {
            get { return _glovesColor; }
            set
            {
                if (true)
                {
                    _glovesColor = value;
                    ObjectUpdateGloveColor();
                }
            }
        }

        public uint BracerColor
        {
            get { return _bracerColor; }
            set
            {
                if (true)
                {
                    _bracerColor = value;
                    ObjectUpdateBracerColor();
                }
            }
        }

        public uint LegColor
        {
            get { return _legsColor; }
            set
            {
                if (true)
                {
                    _legsColor = value;
                    ObjectUpdateLegColor();
                }
            }
        }

        public uint BootsColor
        {
            get { return _bootsColor; }
            set
            {
                if (true)
                {
                    _bootsColor = value;
                    ObjectUpdateBootsColor();
                }
            }
        }

        public uint RobeColor
        {
            get { return _robeColor; }
            set
            {
                if (true)
                {
                    _robeColor = value;
                    ObjectUpdateRobeColor();
                }
            }
        }

        public int ModelID
        {
            get { return _modelID; }
            set
            {
                if(true)
                {
                    _modelID = value;
                    ObjectUpdateModelID();
                }
            }
        }

        public float ModelSize
        {
            get { return _modelSize; }
            set
            {
                if(value >= .025f && value <= 10.0f)
                {
                    _modelSize = value;
                    ObjectUpdateModelSize();
                }
            }
        }
        #endregion

        //This provides us with the proper gear and gear type for visual display on character
        public void EquipGear(Character character)
        {
            ///Start processing MyItem
            foreach (Item MyItem in character.Inventory.itemContainer.Values)
            {
                ///Use a switch to sift through MyItem and add them properly
                switch (MyItem.EquipLocation)
                {
                    ///Helm
                    case 1:
                        Helm = (byte)MyItem.Model;
                        HelmColor = MyItem.Color;
                        break;

                    ///Robe
                    case 2:
                        Robe = (byte)MyItem.Model;
                        RobeColor = MyItem.Color;
                        break;

                    ///Gloves
                    case 19:
                        Gloves = (byte)MyItem.Model;
                        GloveColor = MyItem.Color;
                        break;

                    ///Chest
                    case 5:
                        Chest = (byte)MyItem.Model;
                        ChestColor = MyItem.Color;
                        break;

                    ///Bracers
                    case 8:
                        Bracer = (byte)MyItem.Model;
                        BracerColor = MyItem.Color;
                        break;

                    ///Legs
                    case 10:
                        Legs = (byte)MyItem.Model;
                        LegColor = MyItem.Color;
                        break;

                    ///Feet
                    case 11:
                        Boots = (byte)MyItem.Model;
                        BootsColor = MyItem.Color;
                        break;

                    ///Primary
                    case 12:
                        Primary = MyItem.Model;
                        break;

                    ///Secondary
                    case 14:

                        ///If we have a secondary equipped already, puts next secondary into primary slot
                        if (Secondary > 0)
                        {
                            Primary = MyItem.Model;
                        }

                        ///If no secondary, add to secondary slot
                        else
                        {
                            Secondary = MyItem.Model;
                        }
                        break;

                    ///2 Hand
                    case 15:
                        Primary = MyItem.Model;
                        break;

                    ///Shield
                    case 13:
                        Shield = MyItem.Model;
                        break;

                    ///Bow
                    case 16:
                        Primary = MyItem.Model;
                        break;

                    ///Thrown
                    case 17:
                        Primary = MyItem.Model;
                        break;

                    ///Held
                    case 18:
                        ///If we have a secondary equipped already, puts next secondary into primary slot
                        if (Secondary > 0)
                        {
                            Primary = MyItem.Model;
                        }

                        ///If no secondary, add to secondary slot
                        else
                        {
                            Secondary = MyItem.Model;
                        }
                        break;

                    default:
                        Logger.Err("Equipment not in list, this may need to be changed");
                        break;
                }
            }
        }
    }
}
