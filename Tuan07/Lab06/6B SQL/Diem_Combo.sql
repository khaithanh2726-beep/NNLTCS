
USE QLSinhVien;
GO

-- Xem danh sách sinh viên
SELECT * FROM dbo.SinhVien_DiemCombo;

-- Xem danh sách môn học
SELECT * FROM dbo.MonHoc_DiemCombo;

-- Xem điểm sinh viên
SELECT
    sv.MaSV,
    sv.HoTen,
    mh.MaMH,
    mh.TenMH,
    d.Diem
FROM dbo.Diem_Combo d
INNER JOIN dbo.SinhVien_DiemCombo sv
    ON d.MaSV = sv.MaSV
INNER JOIN dbo.MonHoc_DiemCombo mh
    ON d.MaMH = mh.MaMH;
GO
