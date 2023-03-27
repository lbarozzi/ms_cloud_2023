using System.Reflection.Metadata.Ecma335;

namespace Day14Lab1PokeDex.Models {
    public class Pokemon {
        public int PokemonID { get; set; }
        public string PokemonName { get; set; } = "";
        //
        public int PokemonWeight { get; set; }      //Kg  //Categories light mediium heavy

        //Stats
        public int PokemonLevel { get; set; }
        public int PokemonXP { get; set; }
        public int PokemonAttack { get; set; }
        public int PokemonDefense { get; set; }
        public int PokemonSpecialAttack { get; set; }
        public int PokemonSpecialDefense { get; set; }
        public int PokemonSpeeed { get; set; }
        public int PokemonLifePoints { get; set; }
        //
        public int PokemonStatus { get; set; }

        //
        //Moves limit 4
        //3Th normal form of DB
        List<Move> Moves { get; set; }= new List<Move>();
        /*/Denormalization of Database (NoSql like)
        public Move? Move1 { get; set; }
        public Move? Move2 { get; set; } 
        public Move? Move3 { get; set; } 
        public Move? Move4 { get; set; } 
        //*/
        public Picture? Picture { get; set; }
        public List<Element> Elements { get; set; } = new List<Element>();
        public bool IsMale { get; set; }
        public bool IsFemale { get; set; }
        public bool IsLegendary { get; set; }
        public bool IsEgg { get; set; }
    }

    public class Move {
        public int MoveID { get; set; }
        public int MoveClass { get; set; }
        public string MoveName { get; set; } = "";
        public bool IsAttack { get; set; }

        //Stats
        public int MoveHitPoints { get; set; }
        public int MoveSpeedUp { get; set; }
        public int MoveAttackUp { get; set; }
        public int MoveDefenseUp { get; set; }
        public int MoveLifePointsUp { get; set; }
        public bool IsPriority { get; set; }
        public int MovePrecision { get; set; }
        public int MoveMaxRepeat { get; set; }
        public bool IsElementary { get; set; }
        public int ElementID { get; set; }
        public Element Element { get; set; } = new Element(); //Base Element
    }

    public class ElementSensibility{
        public int ElementSensibilityID { get; set; }
        public int ElementId { get; set; }
        public Element Element { get; set; } = new Element();
        public int ElementSensibilityPerCent { get; set; }
    }

    public class Element {
        public int ElementID { get; set; }
        public string ElementName { get; set; } = "";

        List<ElementSensibility> ElementSensibilities { get; set; } = new List<ElementSensibility>();

    }

    public class Picture {
        public int PictureID { get; set; }
        public string PictureName { get; set; } = "";
        public byte[]? RawData { get; set; }
    }

}
