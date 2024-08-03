using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace _404NotFoundMidTest.Data;

public partial class HangHoa
{
    [Required]
    [Display(Name = "Mã hàng hoá")]
    public int MaHh { get; set; }

    [Required]
    [Display(Name = "Tên hàng hoá")]
    public string TenHh { get; set; } = null!;

    [Display(Name = "Tên alias")]
    public string? TenAlias { get; set; }

    [Required]
    [Display(Name = "Mã loại")]
    public int MaLoai { get; set; }

    [Display(Name = "Mô tả đơn vị")]
    public string? MoTaDonVi { get; set; }

    [Display(Name = "Đơn giá")]
    public double? DonGia { get; set; }

    [Display(Name = "Hình")]
    public string? Hinh { get; set; }

    [Required]
    [NgaySxCheck]
    [Display(Name = "Ngày sản xuất")]
    public DateTime NgaySx { get; set; }

    [Required]
    [Display(Name = "Giảm giá")]
    public double GiamGia { get; set; }

    [Required]
    [Display(Name = "Số lần xem")]
    public int SoLanXem { get; set; }

    [Display(Name = "Mô tả")]
    public string? MoTa { get; set; }

    [Required]
    [Display(Name = "Mã nhà cung cấp")]
    public string MaNcc { get; set; } = null!;

    public virtual ICollection<BanBe> BanBes { get; set; } = new List<BanBe>();

    public virtual ICollection<ChiTietHd> ChiTietHds { get; set; } = new List<ChiTietHd>();

    public virtual Loai MaLoaiNavigation { get; set; } = null!;

    public virtual NhaCungCap MaNccNavigation { get; set; } = null!;

    public virtual ICollection<YeuThich> YeuThiches { get; set; } = new List<YeuThich>();

    public class NgaySxCheckAttribute : ValidationAttribute
    {
        public NgaySxCheckAttribute() : base("Ngày sản xuất không hợp lệ")
        {
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var model = validationContext.ObjectInstance as HangHoa;
            if (model == null)
            {
                throw new ArgumentException("Tham số truyền không đúng");
            }
            if (DateTime.Now > model.NgaySx)
            {
                return new ValidationResult("Ngày sản xuất lớn hơn ngày hiện tại");
            }
            return ValidationResult.Success;
        }
    }//end class
}
