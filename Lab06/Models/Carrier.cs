
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab6.Models
{
    public partial class Carrier
    {
        public Carrier()
        {
        }

        public Carrier(string name)
        {
            this.id = id;
            this.name = name;
        }

        public Carrier(int id, string name)
        {
            this.id = id;
            this.name = name;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int id { get; set; }

        [Column("carrierName")]
        [MaxLength(25, ErrorMessage = "Name of the Carrier can not be longer than 25 symbols")]
        [MinLength(3, ErrorMessage = "Name of the Carrier can not be less than 3 symbols")]
        public string name { get; set; }

        public List<int> store_ids { get; set; }

    }
}
