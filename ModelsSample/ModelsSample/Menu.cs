using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelsSample
{
    [Table("MyMenus")]
    public class Menu
    {
        public Menu()
        {

        }
        public Menu(string title, string subtitle, MenuCard menuCard)
        {
            _title = title;
            Subtitle = subtitle;
            MenuCard = menuCard;
        }

        public int MenuId { get; set; }  // convention

        private string _title;
        [StringLength(60)]
        [Required]
        public string Title => _title;
        public string Subtitle { get; set; }

        public MenuCard MenuCard { get; set; }
    }
}
