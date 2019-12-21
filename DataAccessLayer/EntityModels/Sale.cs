using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace DataAccessLayer.EntityModels
{
    public class Sale
    {
        public int Id { get; set; }

        [Required]
        public double Sum { get; set; }

        [Required]
        public DateTime dateTime { get; set; }

        public int? ManagerId { get; set; }

        public int? CustomerId { get; set; }

        public int? ProductId { get; set; }


        public virtual Manager Manager { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Product Product { get; set; }

    }
}
