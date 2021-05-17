using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace CC_Sports.Models
{
    [Table("Order")]
    public partial class TblOrder
    {
        ////////////// ADDED - MUST RE-ENABLE FOR CART CHECKOUT /////////// ADDED - MUST RE-ENABLE FOR CART CHECKOUT ///////////
        public TblOrder()
        {
            Invoices = new HashSet<Invoice>();
        }

        //////////////////// ORIGINAL //////////////////// ORIGINAL //////////////////// ORIGINAL ////////////////////
        //[Key]
        //[Column("OrderPK")]
        //public int OrderPk { get; set; }
        //[Column(TypeName = "datetime")]
        //public DateTime? OrderDate { get; set; }
        //[Column("CustomerFK")]
        //public int CustomerFk { get; set; }

        ////////////// ADDED - MUST RE-ENABLE FOR CART CHECKOUT /////////// ADDED - MUST RE-ENABLE FOR CART CHECKOUT ///////////

        [Key]
        [Column("OrderID")]
        public int OrderID { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime? OrderDate { get; set; }

        [Column("UserID")]
        public int CustomerFk { get; set; }


        //[ForeignKey(nameof(CustomerFk))]
        ////[InverseProperty(nameof(LoginInput.TableOrders))]
        //[InverseProperty(nameof(LoginInput.TblOrders))]
        //public virtual LoginInput CustomerFkNavigation { get; set; }
        //[InverseProperty(nameof(Invoice.OrderIdfkNavigation))]
        public virtual ICollection<Invoice> Invoices { get; set; }
    }


}
