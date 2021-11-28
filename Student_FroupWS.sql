
Select sv.MASV, sv.HO, sv.TEN, sv.NAM , kq.DIEM
from SVIEN sv, KQUA kq, KHOA kh, MHOC mh
Where sv.MASV = kq.MASV and sv.MAKH = kh.MAKHOA and kh.MAKHOA = mh.MAKH and mh.MAMH = '%CSD%'
USE QLSVien
select * from SVIEN where MAKH = (select MAKH from MHOC where MAMH = 'CSD201')
USe QLSVien
Select sv.MASV, sv.HO, sv.TEN, sv.NAM ,kq.DIEM
From SVIEN sv, KQUA kq
where kq.MASV =(select MASV from SVIEN where)
/*Thêm Môn Học*/
insert into MHOC(TENMH, MAMH, TINCHI, MAKH) values ('Data Structures and Algorithms', 'CSD201', 3, 'SE');
insert into MHOC(TENMH, MAMH, TINCHI, MAKH) values ('.NET and C#', 'PRN292', 3, 'SE');
insert into MHOC(TENMH, MAMH, TINCHI, MAKH) values ('Object-Oriented Programming', 'PRO192', 3, 'SE');
insert into MHOC(TENMH, MAMH, TINCHI, MAKH) values ('Software Requirement', 'SWR302', 3, 'SE');
insert into MHOC(TENMH, MAMH, TINCHI, MAKH) values ('Software Testing', 'SWT301', 3, 'SE');
/*Thêm Khóa Học*/
insert into KHOA(MAKHOA, TENKHOA, NAMTHANHLAP) values ('SE', 'Software Engineer', 1950);
insert into KHOA(MAKHOA, TENKHOA, NAMTHANHLAP) values ('GD', 'Graphic Design', 1950);
insert into KHOA(MAKHOA, TENKHOA, NAMTHANHLAP) values ('IA', 'information assurance', 1950);

/*Thêm Sinh viên*/
insert into SVIEN(MASV, HO,  TEN, MAKH, NAM) values ('001', 'Pham', 'Long', 'SE', '2000');
insert into SVIEN(MASV, HO,  TEN, MAKH, NAM) values ('002', 'Luong', 'Dat', 'SE', '2000');
insert into SVIEN(MASV, HO,  TEN, MAKH, NAM) values ('003', 'Le', 'Anh', 'SE', '2000');
insert into SVIEN(MASV, HO,  TEN, MAKH, NAM) values ('004', 'Nguyen', 'Hao', 'SE', '2000');


/*Thêm Học Phần */
insert into HPHAN(MAHP, MAMH,HOCKI, NAM, GV) values (1, 'PRO192', 2, 2020, 'HoangNT');
insert into HPHAN(MAHP, MAMH,HOCKI, NAM, GV) values (2, 'CSD201', 3, 2019, 'SuTV');
insert into HPHAN(MAHP, MAMH,HOCKI, NAM, GV) values (3, 'PRN292', 5, 2021, 'TuanMT');
insert into HPHAN(MAHP, MAMH,HOCKI, NAM, GV) values (4, 'SWR302', 5, 2020, 'HungLD');
insert into HPHAN(MAHP, MAMH,HOCKI, NAM, GV) values (5, 'SWT301', 5, 2020, 'HungLD');

/*Thêm Điểm*/
insert into KQUA(MASV, MAHP, DIEM) values('001',1, 8.0);
insert into KQUA(MASV, MAHP, DIEM) values('002',1, 7.9);
insert into KQUA(MASV, MAHP, DIEM) values('003',2, 7.9);
insert into KQUA(MASV, MAHP, DIEM) values('004',2, 7.5);
insert into KQUA(MASV, MAHP, DIEM) values('001',3, 7.8);
insert into KQUA(MASV, MAHP, DIEM) values('002',3, 7.9);
insert into KQUA(MASV, MAHP, DIEM) values('003',4, 7.5);
insert into KQUA(MASV, MAHP, DIEM) values('004',4, 7.8);
insert into KQUA(MASV, MAHP, DIEM) values('001',5, 8);
insert into KQUA(MASV, MAHP, DIEM) values('002',5, 8.2);
insert into KQUA(MASV, MAHP, DIEM) values('003',5, 7.4);
insert into KQUA(MASV, MAHP, DIEM) values('004',5, 8.8);
/*Xem ràng buộc
SELECT
name, definition 
FROM
    sys.check_constraints
WHERE
    name = 'CK__SVIEN__NAM__267ABA7A'*/ 
/*Xóa ràng buộc của thầy
ALTER TABLE dbo.Members
DROP CONSTRAINT CK__SVIEN__NAM__267ABA7A*/
	