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

public partial class GoodsComments
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
    public GoodsComments()
    {
        this.ReplyGoods = new HashSet<ReplyGoods>();
    }

    public int GoodsCommentID { get; set; }
    public int UserID { get; set; }
    public int GoodsID { get; set; }
    public string GoodsCommentContent { get; set; }
    public System.DateTime PublishTime { get; set; }

    public virtual Goods Goods { get; set; }
    public virtual Users Users { get; set; }
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
    public virtual ICollection<ReplyGoods> ReplyGoods { get; set; }
}
