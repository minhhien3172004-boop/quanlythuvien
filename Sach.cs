namespace quanlythuvien
{
    public class Sach
    {
        public int MaSach { get; set; }
        public string TenSach { get; set; }
        public string TacGia { get; set; }
        public bool DaMuon { get; set; }
        public string NguoiMuon { get; set; } = ""; // Mới: Lưu tên người mượn

        public Sach(int ma, string ten, string tg)
        {
            MaSach = ma;
            TenSach = ten;
            TacGia = tg;
            DaMuon = false;
        }

        public override string ToString()
        {
            string trangThai = DaMuon ? $"[ĐÃ MƯỢN bởi: {NguoiMuon}]" : "[CÒN SÁCH]";
            return $"Mã: {MaSach,-5} | Tên: {TenSach,-20} | TG: {TacGia,-15} | {trangThai}";
        }
    }
}
