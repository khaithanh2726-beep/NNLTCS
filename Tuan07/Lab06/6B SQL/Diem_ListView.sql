
USE QLSinhVien;
GO

SELECT
    ROW_NUMBER() OVER (
        ORDER BY sv.MaSV, mh.MaMH
    ) AS STT,
    sv.HoTen AS TenSV,
    sv.NgaySinh,
    mh.TenMH,
    d.Diem
FROM dbo.Diem_ListView d
INNER JOIN dbo.SinhVien_DiemLV sv
    ON d.MaSV = sv.MaSV
INNER JOIN dbo.MonHoc_DiemLV mh
    ON d.MaMH = mh.MaMH
ORDER BY sv.MaSV, mh.MaMH;

-- Tổng điểm tất cả môn học
SELECT SUM(Diem) AS TongDiem
FROM dbo.Diem_ListView;
GO
