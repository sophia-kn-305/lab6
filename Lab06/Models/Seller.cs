using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab6.Models
{
    public partial class Seller
    {
        public Seller() { }

        public Seller(string name)
        {
            this.name = name;
        }

        public Seller(int id, string name)
        {
            this.id = id;
            this.name = name;
        }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int id { get; set; }

        [Column("name")]
        [MaxLength(25, ErrorMessage = "Name of the Seller can not be longer than 25 symbols")]
        [MinLength(3, ErrorMessage = "Name of the Seller can not be less than 3 symbols")]

        public string name { get; set; }

        [Column("rate")]
        public double rate { get; set; }

    }
}
