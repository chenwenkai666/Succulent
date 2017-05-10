//------------------------------------------------------------------------------
// <auto-generated>
//     此代码已从模板生成。
//
//     手动更改此文件可能导致应用程序出现意外的行为。
//     如果重新生成代码，将覆盖对此文件的手动更改。
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;

public partial class Goods
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public Goods()
    {
        this.Adopt = new HashSet<Adopt>();
        this.AdoptResult = new HashSet<AdoptResult>();
        this.GoodsComments = new HashSet<GoodsComments>();
        this.OrderItems = new HashSet<OrderItems>();
        this.ShoppingCarts = new HashSet<ShoppingCarts>();
    }

    public int GoodsID { get; set; }
    public int ShopID { get; set; }
    public string GoodsName { get; set; }
    public decimal Price { get; set; }
    public string GoodsPhoto { get; set; }
    public string GoodsDescribe { get; set; }
    public Nullable<int> LikeIt { get; set; }
    public int Flag { get; set; }
    public Nullable<System.DateTime> Time { get; set; }

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<Adopt> Adopt { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<AdoptResult> AdoptResult { get; set; }
    public virtual Shops Shops { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<GoodsComments> GoodsComments { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<OrderItems> OrderItems { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<ShoppingCarts> ShoppingCarts { get; set; }
}
