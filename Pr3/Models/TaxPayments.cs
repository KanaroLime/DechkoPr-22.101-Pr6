//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Pr3.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class TaxPayments
    {
        public int TaxPayments_code { get; set; }
        public System.DateTime Date { get; set; }
        public decimal Price { get; set; }
        public int TaxPrice_code { get; set; }
    
        public virtual TaxPrice TaxPrice { get; set; }
    }
}
