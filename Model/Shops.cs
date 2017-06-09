//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

namespace Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Shops
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Shops()
        {
            this.Goods = new HashSet<Goods>();
        }

        public int ShopID { get; set; }
        public int UserID { get; set; }
        [Required(ErrorMessage = "请输入商店名")]
        [RegularExpression(@"^[\\u4e00-\u9fa5_a-zA-Z0-9-\\w]{1,12}$", ErrorMessage = "限12个字符")]
        public string ShopName { get; set; }
        public string ShopDescription { get; set; }
        public Nullable<int> SalesTotal { get; set; }
        //[Required]
        public string ShopPhoto { get; set; }
        //[Required]
        public string TopImage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Goods> Goods { get; set; }
        public virtual Users Users { get; set; }
    }
}
