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
    
    public partial class Succulent
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Succulent()
        {
            this.Collection = new HashSet<Collection>();
        }
    
        public int SucculentID { get; set; }
        public string SucculentName { get; set; }
        public int CategoryID { get; set; }
        public string Photo { get; set; }
        public string Feature { get; set; }
        public string Application { get; set; }
        public string BreedMode { get; set; }
        public Nullable<int> CollectedTotal { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Collection> Collection { get; set; }
        public virtual SucculentCategory SucculentCategory { get; set; }
    }
}
