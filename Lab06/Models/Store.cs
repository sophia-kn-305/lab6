using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Lab6.Models
{
    public partial class Store
    {

        public Store() { }

        public Store(int id, string store_name)
        {
            this.id = id;
        }

        public Store(string store_name)
        {
            this.name = store_name;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("id")]
        public int id { get; set; }

        [Column("name")]
        [MaxLength(25, ErrorMessage = "Name of the Store can not be longer than 25 symbols")]
        [MinLength(3, ErrorMessage = "Name of the Store can not be less than 3 symbols")]
        public string name { get; set; }

    }
}
