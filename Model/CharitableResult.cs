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
    
    public partial class CharitableResult
    {
        public int CharitableResultID { get; set; }
        public int ActivityID { get; set; }
        public string CharitableName { get; set; }
        public string CWhereabouts { get; set; }
        public string CharitableDetails { get; set; }
    
        public virtual Activity Activity { get; set; }
    }
}
