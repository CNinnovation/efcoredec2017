using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ModelsSample
{
    [Table("MyMenus")]
    public class Menu : BindableBase
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
        private string _subtitle;
        public string Subtitle
        {
            get => _subtitle;
            set => SetProperty(ref _subtitle, value);
        }

        // EF 6
        public virtual string AnotherProperty { get; set; }

        public MenuCard MenuCard { get; set; }
    }
}
