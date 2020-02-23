using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharSel : MonoBehaviour {
    public GameObject[] SelMenu = new GameObject[5];

    public GameManager gm;

    public Text[] DescStuff = new Text[5];
    public Image DescPort;

    public Image[] SelPort = new Image[8];

    public Image[] SubPort = new Image[3];
    public Text[] SubText = new Text[3];

    public int[] PlayerSel = new int[3];

    private int MemNum;

    private int SelScreen;

    public string[,] ClassDesc = new string[8, 8];

    // Start is called before the first frame update
    void Start () {
        SelScreen = 0;
        SelMenu[0].SetActive(true);
        //Vetran
        ClassDesc[0, 0] = "Vetran";
        ClassDesc[0, 1] = "A broken being, composed entirely of ethanol and regrets. A once proud member of their nation's corp of engineers, the thunder of hooves and the bite of a bullet ended a promising military career. Fresh from the heat of combat, the iron of this one still glows red-hot, or atleast thats what the drink says. What they've seen in combat will follow them to the grave, but nothing scares them more than starting anew.";
        ClassDesc[0, 2] = "The Vetran comes with the unique ability to stare so surely into the abyss, the abyss blinks. In times of trouble the Vetran can remind themselves that they've already been to hell once before, helping find them new will to carry on. And for when the worst case senario comes to pass? Liquid courage to calm the nerves";
        ClassDesc[0, 3] = "MIG +2                                  WIL, PER +1                                KNO, CHR -1";
        ClassDesc[0, 4] = "Armour: Military Uniform, Combat Boots Weapons: Dynamite, Sharpened Spade Gear: Flask, 10 special ammo";
        ClassDesc[0, 5] = "Solider";
        ClassDesc[0, 6] = "Officer";
        ClassDesc[0, 7] = "Engineer";
        //Cultist
        ClassDesc[1, 0] = "Ex-Cultist";
        ClassDesc[1, 1] = "A self-serving and corrupt specialist. Not long ago they served under a man they once thought to be god on earth, commiting any act to satisfy that man's every whim. One day, that man harmed someone they shouldn't have, and now that man and all his followers lie within the earth. Only the one responsible still stands. They now aid their former foes, trading eldrich experience for cash.";
        ClassDesc[1, 2] = "The Cultist has intimate knowlege of the workings of the acrane, even for just a simple initiate. Unlike most other dispellers of darkness, the Cultist has no issue tapping into the domain of the dammned to acheive their goals, allowing them acess to the spells and incantations of various dieties without concern for their soul due to their various safegaurds";
        ClassDesc[1, 3] = "DEX +2                                  KNO, AGI +1                                MIG, WIL -1";
        ClassDesc[1, 4] = "Armour: Old Robes, Old Hood       Weapon: Rusted Kris Knife           Gear: Novice's Notes";
        ClassDesc[1, 5] = "Pyscho";
        ClassDesc[1, 6] = "Occultist";
        ClassDesc[1, 7] = "Faceless";
        //Gambler
        ClassDesc[2, 0] = "Gambler";
        ClassDesc[2, 1] = "A creature well aquainted with the fact that reality isn't always as concrete as it first appears. This avatar of fortune has spent a liftime survivng off the ill-luck of others, and augurs no end to their almost unnatural hot streak. After perfecting the art of sleight of hand and the science of card counting, acclimating to the world of the occult and the abhorrent should pose no challenge.";
        ClassDesc[2, 2] = "The Gambler class comes equipt with the abiity to gamble with potential sources of inforation, possibly affording easier oppurtunities to aquire knowlege of both the arcane and mundane. Be careful though, as you play a dangerous game when you gamble for more than simply money.";
        ClassDesc[2, 3] = "LUCK +2                                DEX, CHR +1                                KNO, WIL -1";
        ClassDesc[2, 4] = "Armour: Old Suit, Bowler Hat     Weapons: Ornate Throwing Knives    Gear: Deck of Cards, 50 ammo";
        ClassDesc[2, 5] = "Cardshark";
        ClassDesc[2, 6] = "Mathematicain";
        ClassDesc[2, 7] = "Cursed";
        //Ghoul
        ClassDesc[3, 0] = "Ghoul";
        ClassDesc[3, 1] = "DESC";
        ClassDesc[3, 2] = "PERK";
        ClassDesc[3, 3] = "KNO +2                                  LUCK, PER  +1                              WIL, MIG -1";
        ClassDesc[3, 4] = "Armour: Old Suit, Bowler Hat      Weapon: Aged Walking Stick          Gear: Random Language Book";
        ClassDesc[3, 5] = "Hound-Blooded";
        ClassDesc[3, 6] = "Wendigo-Blooded";
        ClassDesc[3, 7] = "Bat-Blooded";
        //Priest
        ClassDesc[4, 0] = "Priest";
        ClassDesc[4, 1] = "A selfless paragon of virtue, a true christian knight. Aged like fine wine and with all the wisdom a church education can afford, this one lived comfortably tending to the spirituality of their flock. This wouldn't last, as after a violent struggle with an emergent cult forced them to adopt the mantle of the holy men of ages past if they wish to prevent such a slaughter from repeating.";
        ClassDesc[4, 2] = "The Priest has the power of prayer. In addition to thier endless supply of holy water, the Priest shuns the arcane and alcohol in favour of faith. As a warrior of the faith, God grants the ability to preform miraculous feats of strength or wisdom. These powers extend to those the performer finds worthy to share in their blessings.";
        ClassDesc[4, 3] = "KNO +2                                  CHR, WIL +1                                DEX, PER -1";
        ClassDesc[4, 4] = "Armour: Old Robes, Old Hood       Weapon: Holy Water, Aged Walking Stick Gear: Bible, Flask";
        ClassDesc[4, 5] = "Padre";
        ClassDesc[4, 6] = "Heretic";
        ClassDesc[4, 7] = "Inquisitor";
        //Proffesor
        ClassDesc[5, 0] = "Professor";
        ClassDesc[5, 1] = "DESC";
        ClassDesc[5, 2] = "PERK";
        ClassDesc[5, 3] = "PER +2                                  KNO, WIL  +1                               DEX, AGI -1";
        ClassDesc[5, 4] = "Armour: Worn Lab Coat, Safety Glasses Weapon: Scapel                        Gear: Test Tube, Syringe";
        ClassDesc[5, 5] = "Chemist";
        ClassDesc[5, 6] = "Archeologist";
        ClassDesc[5, 7] = "Mad Scientist";
        //Writer
        ClassDesc[6, 0] = "Writer";
        ClassDesc[6, 1] = "DESC";
        ClassDesc[6, 2] = "PERK";
        ClassDesc[6, 3] = "CHR +2                                  DEX, AGI  +1                               LUCK, PER -1";
        ClassDesc[6, 4] = "Armour: Old Suit                   Weapon: Deringer                     Gear: Collection of Short Stories,     50 Ammo";
        ClassDesc[6, 5] = "Secrete Keeper";
        ClassDesc[6, 6] = "Journalist";
        ClassDesc[6, 7] = "Antique Dealer";
        //Zombie
        ClassDesc[7, 0] = "Zombie";
        ClassDesc[7, 1] = "DESC";
        ClassDesc[7, 2] = "PERK";
        ClassDesc[7, 3] = "CHR +2                                  DEX, AGI  +1                               LUCK, PER -1";
        ClassDesc[7, 4] = "Armour: Old Suit                   Weapon: Deringer                     Gear: Collection of Short Stories,     50 Ammo";
        ClassDesc[7, 5] = "Zombie";
        ClassDesc[7, 6] = "Skeleton";
        ClassDesc[7, 7] = "Reaper";
    }

    public void Back () {
        if (SelScreen >= 1) {
            SelMenu[SelScreen].SetActive(false);
            SelScreen--;
            SelMenu[SelScreen].SetActive(true);
        } else {
            gm.MainMenu();
        }
    }

    public void Next () {
        SelMenu[SelScreen].SetActive(false);
        SelScreen = 0;
        SelMenu[SelScreen].SetActive(true);

        SelPort[PlayerSel[1]].color = Color.red;

       // PartySheet.ClassSelect(MemNum, DescStuff[0].text);
    }

    public void Race (int Member) {
        SelMenu[SelScreen].SetActive(false);
        SelScreen = 1;
        SelMenu[SelScreen].SetActive(true);

        MemNum = Member;



    }

    public void Class (int Race) {
        SelMenu[SelScreen].SetActive(false);
        SelScreen = 2;
        SelMenu[SelScreen].SetActive(true);

        PlayerSel[0] = Race;
    }

    public void Sub (int Class) {
        SelMenu[SelScreen].SetActive(false);
        SelScreen = 3;
        SelMenu[SelScreen].SetActive(true);

        PlayerSel[1] = Class;

        SubPort[0].sprite = SelPort[PlayerSel[1]].sprite;
        SubPort[1].sprite = SelPort[PlayerSel[1]].sprite;
        SubPort[2].sprite = SelPort[PlayerSel[1]].sprite;

        SubText[0].text = ClassDesc[PlayerSel[1], 5];
        SubText[1].text = ClassDesc[PlayerSel[1], 6];
        SubText[2].text = ClassDesc[PlayerSel[1], 7];

    }

    public void Desc (int Sub) {
        SelMenu[SelScreen].SetActive(false);
        SelScreen = 4;
        SelMenu[SelScreen].SetActive(true);

        PlayerSel[2] = Sub;

        DescStuff[0].text = ClassDesc[PlayerSel[1], 0];
        DescStuff[1].text = ClassDesc[PlayerSel[1], 1];
        DescStuff[2].text = ClassDesc[PlayerSel[1], 2];
        DescStuff[3].text = ClassDesc[PlayerSel[1], 3];
        DescStuff[4].text = ClassDesc[PlayerSel[1], 4];
        DescPort.sprite = SelPort[PlayerSel[1]].sprite;

    }
}
