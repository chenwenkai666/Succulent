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
    
    public partial class Posts
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Posts()
        {
            this.PostComments = new HashSet<PostComments>();
        }
    
        public int PostID { get; set; }
        public int UserID { get; set; }
        public int SectionID { get; set; }
        public string PostTitle { get; set; }
        public string PostContent { get; set; }
        public System.DateTime PublishTime { get; set; }
        public Nullable<int> PostFlag { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostComments> PostComments { get; set; }
        public virtual Sections Sections { get; set; }
        public virtual Users Users { get; set; }
    }
}
