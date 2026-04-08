using System.Text;
using System.Text.Json;
using quanlythuvien;

Console.OutputEncoding = Encoding.UTF8;
Console.InputEncoding = Encoding.UTF8;
string path = "data.json";
List<Sach> danhSachSach = new List<Sach>();

// --- ĐĂNG NHẬP ---
Console.Clear();
Console.WriteLine("====================================");
Console.WriteLine("   HỆ THỐNG QUẢN LÝ THƯ VIỆN C#");
Console.WriteLine("====================================");
Console.Write(" Nhập mật khẩu Admin: ");
if (Console.ReadLine() != "123") {
    Console.WriteLine(" Sai mật khẩu! Nhấn phím bất kỳ để thoát...");
    Console.ReadKey(); return;
}

// Tải dữ liệu
if (File.Exists(path)) {
    try {
        string dataCu = File.ReadAllText(path);
        danhSachSach = JsonSerializer.Deserialize<List<Sach>>(dataCu) ?? new List<Sach>();
    } catch { }
}

while (true)
{
    Console.Clear();
    Console.WriteLine("====================================================");
    Console.WriteLine($" TỔNG SỐ SÁCH: {danhSachSach.Count} | ĐANG CHO MƯỢN: {danhSachSach.Count(s => s.DaMuon)}");
    Console.WriteLine("====================================================");
    Console.WriteLine(" 1. Xem danh sách sách");
    Console.WriteLine(" 2. Thêm sách mới (Chống trùng mã)");
    Console.WriteLine(" 3. Tìm kiếm sách");
    Console.WriteLine(" 4. Mượn sách");
    Console.WriteLine(" 5. Trả sách");
    Console.WriteLine(" 6. Sửa thông tin sách (Update)");
    Console.WriteLine(" 7. Xóa sách khỏi hệ thống");
    Console.WriteLine(" 8. Thoát");
    Console.WriteLine("----------------------------------------------------");
    Console.Write(" Chọn chức năng (1-8): ");

    string chon = Console.ReadLine() ?? "";

    if (chon == "1") {
        Console.WriteLine("\n--- DANH SÁCH CHI TIẾT ---");
        if (danhSachSach.Count == 0) Console.WriteLine("Thư viện trống!");
        else danhSachSach.ForEach(s => Console.WriteLine(s.ToString()));
    }
    else if (chon == "2") {
        try {
            Console.Write("Nhập mã sách: "); 
            int ma = int.Parse(Console.ReadLine()!);
            // Kiểm tra trùng mã
            if (danhSachSach.Any(x => x.MaSach == ma)) {
                Console.WriteLine("=> Lỗi: Mã sách này đã tồn tại!");
            } else {
                Console.Write("Tên sách: "); string ten = Console.ReadLine()!;
                Console.Write("Tác giả: "); string tg = Console.ReadLine()!;
                danhSachSach.Add(new Sach(ma, ten, tg));
                LuuFile();
                Console.WriteLine("=> Đã thêm thành công!");
            }
        } catch { Console.WriteLine("Lỗi: Mã sách phải là số!"); }
    }
    else if (chon == "3") {
        Console.Write("Tìm theo tên: ");
        string tk = Console.ReadLine()?.ToLower() ?? "";
        var kq = danhSachSach.Where(s => s.TenSach.ToLower().Contains(tk)).ToList();
        if (kq.Count == 0) Console.WriteLine("Không tìm thấy!");
        else kq.ForEach(s => Console.WriteLine(s.ToString()));
    }
    else if (chon == "4") {
        Console.Write("Mã sách muốn mượn: ");
        if (int.TryParse(Console.ReadLine(), out int ma)) {
            var s = danhSachSach.Find(x => x.MaSach == ma);
            if (s != null && !s.DaMuon) {
                Console.Write("Tên người mượn: ");
                s.NguoiMuon = Console.ReadLine()!;
                s.DaMuon = true; LuuFile();
                Console.WriteLine("=> Đã cho mượn!");
            } else Console.WriteLine("=> Sách không có sẵn!");
        }
    }
    else if (chon == "5") {
        Console.Write("Mã sách trả: ");
        if (int.TryParse(Console.ReadLine(), out int ma)) {
            var s = danhSachSach.Find(x => x.MaSach == ma);
            if (s != null && s.DaMuon) {
                s.DaMuon = false; s.NguoiMuon = ""; LuuFile();
                Console.WriteLine("=> Đã trả xong!");
            }
        }
    }
    else if (chon == "6") { // CHỨC NĂNG SỬA (MỚI)
        Console.Write("Nhập mã sách cần sửa: ");
        if (int.TryParse(Console.ReadLine(), out int ma)) {
            var s = danhSachSach.Find(x => x.MaSach == ma);
            if (s != null) {
                Console.WriteLine($"Đang sửa: {s.TenSach}");
                Console.Write("Tên mới (bỏ trống nếu giữ cũ): ");
                string tMoi = Console.ReadLine()!;
                if (!string.IsNullOrEmpty(tMoi)) s.TenSach = tMoi;

                Console.Write("Tác giả mới (bỏ trống nếu giữ cũ): ");
                string tgMoi = Console.ReadLine()!;
                if (!string.IsNullOrEmpty(tgMoi)) s.TacGia = tgMoi;

                LuuFile();
                Console.WriteLine("=> Đã cập nhật thông tin!");
            } else Console.WriteLine("=> Không tìm thấy!");
        }
    }
    else if (chon == "7") {
        Console.Write("Mã sách cần xóa: ");
        if (int.TryParse(Console.ReadLine(), out int ma)) {
            var s = danhSachSach.Find(x => x.MaSach == ma);
            if (s != null) {
                danhSachSach.Remove(s); LuuFile();
                Console.WriteLine("=> Đã xóa!");
            }
        }
    }
    else if (chon == "8") break;

    Console.WriteLine("\nBấm phím bất kỳ để quay lại Menu...");
    Console.ReadKey();
}

void LuuFile() {
    File.WriteAllText(path, JsonSerializer.Serialize(danhSachSach));
}
