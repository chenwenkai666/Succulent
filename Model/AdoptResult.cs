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

public partial class AdoptResult
{
    public int AdoptResultID { get; set; }
    public int UserID { get; set; }
    public int ActivityID { get; set; }
    public int GoodsID { get; set; }
    public System.DateTime AdoptTime { get; set; }

    public virtual Activity Activity { get; set; }
    public virtual Goods Goods { get; set; }
    public virtual Users Users { get; set; }
}
