using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameShare.Data
{
    public enum Console
    {
        [Display(Name = "Sega Genesis")]
        Sega_Genesis,
        [Display(Name = "Sega CD")]
        Sega_CD,
        [Display(Name = "Sega Saturn")]
        Sega_Saturn,
        GameBoy,
        [Display(Name = "GameBoy Color")]
        GBC,
        [Display(Name = "GameBoy Advance")]
        GameBoy_Advance,
        [Display(Name = "Nintendo DS")]
        DS,
        [Display(Name = "Nintendo 3DS")]
        Nintendo_3DS,
        [Display(Name = "NES (Nintendo Entertainment System)")]
        NES,
        [Display(Name = "SNES (Super Nintendo Entertainment System)")]
        SNES,
        [Display(Name = "Nintendo 64")]
        N64,
        GameCube,
        Wii,
        [Display(Name = "Wii U")]
        WiiU,
        Switch,
        PSP,
        [Display(Name = "PlayStaion Vita")]
        PSP_Vita,
        PlayStation,
        PlayStation2,
        PlayStation3,
        PlayStation4,
        PlayStation5,
        Xbox,
        [Display(Name = "Xbox One")]
        XboxOne,
        [Display(Name = "Xbox Series")]
        Xbox_Series
    }
    public class Game
    {
        [Key]
        public int GameId { get; set; }
        public Guid OwnerId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Console GameConsole { get; set; }
        [Required]
        public bool ForRent { get; set; }
        [ForeignKey(nameof(Inventory))]
        public int InventoryId { get; set; }
        public virtual Inventory Inventory { get; set; }
    }
}