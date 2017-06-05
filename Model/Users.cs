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

    public partial class Users
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Users()
        {
            this.Activity = new HashSet<Activity>();
            this.Address = new HashSet<Address>();
            this.AdoptResult = new HashSet<AdoptResult>();
            this.Attendance = new HashSet<Attendance>();
            this.Collection = new HashSet<Collection>();
            this.Donate = new HashSet<Donate>();
            this.Entries = new HashSet<Entries>();
            this.Farms = new HashSet<Farms>();
            this.GoodsComments = new HashSet<GoodsComments>();
            this.Orders = new HashSet<Orders>();
            this.PostComments = new HashSet<PostComments>();
            this.Posts = new HashSet<Posts>();
            this.Pots = new HashSet<Pots>();
            this.ReplyGoods = new HashSet<ReplyGoods>();
            this.ReplyPost = new HashSet<ReplyPost>();
            this.ShoppingCarts = new HashSet<ShoppingCarts>();
            this.Shops = new HashSet<Shops>();
        }

        public int UserID { get; set; }

        [Required(ErrorMessage = "请输入用户名")]
        [RegularExpression(@"^[\\u4e00-\u9fa5_a-zA-Z0-9-\\w]{1,10}$", ErrorMessage = "限10个字符，支持中英文、数字、减号或下划线")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "请输入密码")]
        [DataType(DataType.Password)]
        [RegularExpression(@"^([A-Z]|[a-z]|[0-9]|[`~!@#$%^&*()+=|{}':;',\\\\[\\\\].<>/?~！@#￥%……&*（）——+|{}【】‘；：”“’。，、？]){6,20}$", ErrorMessage = "密码必须为6-20 位的任意字母、数字、字符组合")]
        public string Password { get; set; }

        [Required(ErrorMessage = "请输入确认密码")]
        [Compare("Password", ErrorMessage = "与输入的密码不一致")]
        public string PasswordAgain { get; set; }
        public string Photo { get; set; }
        public string Sex { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public Nullable<System.DateTime> Birth { get; set; }

        [Required(ErrorMessage = "请输入电子邮箱")]
        [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "电子邮箱格式不正确！")]
        public string Email { get; set; }

        [Required(ErrorMessage = "请输入手机号码")]
        [RegularExpression(@"^1[3|4|5|7|8][0-9]\d{8}$", ErrorMessage = "请输入有效的手机号码")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "请输入验证码")]
        public string CheckCode { get; set; }
        public string SecretQues { get; set; }
        public string SecretAnws { get; set; }
        public int UserFlag { get; set; }
        public Nullable<bool> Lock { get; set; }
        public Nullable<int> CollectionTotal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Activity> Activity { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Address> Address { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<AdoptResult> AdoptResult { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Attendance> Attendance { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Collection> Collection { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Donate> Donate { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Entries> Entries { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Farms> Farms { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsComments> GoodsComments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Orders> Orders { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PostComments> PostComments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Posts> Posts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Pots> Pots { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReplyGoods> ReplyGoods { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ReplyPost> ReplyPost { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ShoppingCarts> ShoppingCarts { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Shops> Shops { get; set; }
    }
}
