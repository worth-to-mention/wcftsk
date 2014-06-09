namespace awsvclib.EntityModel
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Sales.SalesPerson")]
    public partial class SalesPerson
    {
        public SalesPerson()
        {
            SalesOrderHeaders = new HashSet<SalesOrderHeader>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int BusinessEntityID { get; set; }

        public int? TerritoryID { get; set; }

        [Column(TypeName = "money")]
        public decimal? SalesQuota { get; set; }

        [Column(TypeName = "money")]
        public decimal Bonus { get; set; }

        [Column(TypeName = "smallmoney")]
        public decimal CommissionPct { get; set; }

        [Column(TypeName = "money")]
        public decimal SalesYTD { get; set; }

        [Column(TypeName = "money")]
        public decimal SalesLastYear { get; set; }

        public Guid rowguid { get; set; }

        public DateTime ModifiedDate { get; set; }

        public virtual ICollection<SalesOrderHeader> SalesOrderHeaders { get; set; }
    }
}
