using System;
using ReturnHome.Utilities;

namespace ReturnHome.Server.EntityObject
{
    public partial class Entity
    {
    
        //Implies if object is visible or not
        public bool Invisible = false;

        private int _level;
        private uint _objectID;
        private long _killTime;
        private ushort _npcType;

        public byte chatMode = 0; //Default to 0, say = 0, Shout = 3 NPC's can technically talk in chat too?

        //Store latest character update directly to character for other characters to pull
        //Doesn't seem right? But we can trigger each session to serialize to this array and distribute to other client's this way
        public Memory<byte> ObjectUpdate = new Memory<byte> ( new byte[0xC8]);
        public Memory<byte> StatUpdate = new Memory<byte>(new byte[0xEB]);

        /* These are all values for character creation, likely don't need to be attributes of the character object at all*/
        //Default character data should probably be stored in script's to generate from on client's request, saving that to the database
        /*CONSIDER REMOVING IN FAVOR OF ABOVE IN TIME?*/
        public string TestCharName;
        public int StartingClass;
        public int Gender;
        //Note this is for holding the HumType from the client that is an int and base Character has a string HumType
        public int HumTypeNum;
        //Addxxxx attributes of the class are to hold a new characters initial allocated stat points in each category
        public int AddStrength;
        public int AddStamina;
        public int AddAgility;
        public int AddDexterity;
        public int AddWisdom;
        public int AddIntelligence;
        public int AddCharisma;
        //Defaultxxx attributes of the class pulled from the defaultClass table in the DB for new character creation
        public int DefaultStrength;
        public int DefaultStamina;
        public int DefaultAgility;
        public int DefaultDexterity;
        public int DefaultWisdom;
        public int DefaultIntelligence;
        public int DefaultCharisma;

        public bool isPlayer;

        #region ObjectUpdate
        public int Level
        {
            get { return _level; }
            set
            {
                if (isPlayer)
                {
                    if (value >= 1 && value <= 61)
                    {
                        _level = value;
                        ObjectUpdateLevel();
                    }

                    else
                        Logger.Err($"Error setting Level {value} for {_charName}");
                }
                else
                {
                    if (value >= 1 && value <= 100)
                    {
                        _level = value;
                        ObjectUpdateLevel();
                    }
                }
            }
        }

        public uint ObjectID
        {
            get { return _objectID; }
            set
            {
                if (true)
                {
                    _objectID = value;
                    ObjectUpdateObjectID();
                }

                else
                    Logger.Err($"Error setting ObjectID {value} for {_charName}");
            }
        }

        public long KillTime
        {
            get { return _killTime; }
            set
            {
                //I think kill time only applies to npc's?
                if(!isPlayer)
                {
                    _killTime = value;
                    ObjectUpdateKillTime();
                }
            }
        }

        public ushort NPCType
        {
            get { return _npcType; }
            set
            {
                if(true)
                {
                    _npcType = value;
                    ObjectUpdateNPCType();
                }
            }
        }
        #endregion
        public Entity(bool isplayer)
        {
            isPlayer = isplayer;
            ObjectUpdateEntity();
            ObjectUpdateVanillaColors();
            ObjectUpdateEnd();
            ObjectUpdateNameColor();
            ObjectUpdateNamePlate();
            ObjectUpdateUnknown();
            ObjectUpdatePattern();
            //Set armour to defaults
            HelmColor = 0xFFFFFFFF;
            ChestColor = 0xFFFFFFFF;
            BracerColor = 0xFFFFFFFF;
            GloveColor = 0xFFFFFFFF;
            LegColor = 0xFFFFFFFF;
            BootsColor = 0xFFFFFFFF;
            RobeColor = 0xFFFFFFFF;
            Robe = -1;
            ModelSize = 1.0f;
            Movement = 1;
        }
    }
}
