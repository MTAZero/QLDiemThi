using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyDiemThi
{
    public static class DB
    {
        public static List<DiemThi> DiemThis = new List<DiemThi>();
        public static List<DoiTuongDuThi> DoiTuongDuThis = new List<DoiTuongDuThi>();
        public static List<SinhVien> SinhViens = new List<SinhVien>();
        public static int IDDoiTuongDuThi = 0;

        // sinh vien
        public static bool ImportSinhViens(string FileName, ref string Error)
        {
            List<SinhVien> temp = new List<SinhVien>();


            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(FileName))
                {
                    int n = Int32.Parse(sr.ReadLine());

                    for(int i = 1; i<=n; i++)
                    {
                        string str = sr.ReadLine();
                        SinhVien sv = new SinhVien();

                        sv.SBD = Int32.Parse(StringHelper.GetString(str, 1, 11));
                        sv.Ho = StringHelper.GetString(str, 12, 26);
                        sv.Ten = StringHelper.GetString(str, 27, 33);
                        sv.GioiTinh = Int32.Parse(StringHelper.GetString(str, 34, 35));
                        sv.NgaySinh = StringHelper.GetString(str, 36, 46);
                        sv.DTUT = Int32.Parse(StringHelper.GetString(str, 47, 49));
                        temp.Add(sv);
                    }
                }
            }
            catch (Exception e)
            {
                Error = e.Message;
                return false;
            }

            SinhViens = temp;
            return true;
        }
        public static bool SaveSinhViens(string FileName, ref string Error)
        {
            try
            {
                using (StreamWriter sr = new StreamWriter(FileName))
                {
                    int n = SinhViens.Count;

                    sr.WriteLine(n.ToString());

                    foreach(SinhVien item in SinhViens)
                    {
                        string str = "";

                        string SBD = StringHelper.StringWithLengthLeft(item.SBD.ToString(), 11);
                        string Ho = StringHelper.StringWithLengthLeft(item.Ho,15);
                        string Ten = StringHelper.StringWithLengthLeft(item.Ten, 7);
                        string GioiTinh = StringHelper.StringWithLengthLeft(item.GioiTinh.ToString(), 2);
                        string NgaySinh = StringHelper.StringWithLengthLeft(item.NgaySinh, 11);
                        string DTUT = StringHelper.StringWithLengthLeft(item.DTUT.ToString(), 3);

                        str = string.Format("{0,12}{1}{2}{3}{4}{5}", SBD, Ho, Ten, GioiTinh, NgaySinh, DTUT);                        

                        sr.WriteLine(str);
                    }
                }
            }
            catch (Exception e)
            {
                Error = e.Message;
                return false;
            }
            return true;
        }
        // Doi Tuong du thi
        public static bool ImportDoiTuongDuThi(string FileName, ref string Error)
        {
            List<DoiTuongDuThi> temp = new List<DoiTuongDuThi>();
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(FileName))
                {
                    int n = Int32.Parse(sr.ReadLine());

                    for (int i = 1; i <= n; i++)
                    {
                        string str = sr.ReadLine();
                        DoiTuongDuThi tg = new DoiTuongDuThi();

                        tg.ID = Int32.Parse(StringHelper.GetString(str, 1, 3));
                        tg.Ten = StringHelper.GetString(str, 4, 53);
                        tg.DiemUT = Int32.Parse(StringHelper.GetString(str, 54, 64));

                        temp.Add(tg);
                    }
                }
            }
            catch (Exception e)
            {
                Error = e.Message;
                return false;
            }

            DoiTuongDuThis = temp;
            return true;
        }
        public static bool SaveDoiTuongDuThi(string FileName, ref string Error)
        {
            ///
            try
            {
                using (StreamWriter sr = new StreamWriter(FileName))
                {
                    int n = DoiTuongDuThis.Count;

                    sr.WriteLine(n.ToString());

                    foreach (var item in DoiTuongDuThis)
                    {
                        string str = "";

                        string ID = StringHelper.StringWithLengthLeft(item.ID.ToString(), 3);
                        string Ten = StringHelper.StringWithLengthLeft(item.Ten, 50);
                        string DiemUT = StringHelper.StringWithLengthLeft(item.DiemUT.ToString(), 11);

                        str = string.Format("{0}{1}{2}", ID, Ten, DiemUT);

                        sr.WriteLine(str);
                    }
                }
            }
            catch (Exception e)
            {
                Error = e.Message;
                return false;
            }
            return true;
        }
        // Diem thi
        public static bool ImportDiemThi(string FileName, ref string Error)
        {
            List<DiemThi> temp = new List<DiemThi>();
            try
            {   // Open the text file using a stream reader.
                using (StreamReader sr = new StreamReader(FileName))
                {
                    int n = Int32.Parse(sr.ReadLine());

                    for (int i = 1; i <= n; i++)
                    {
                        string str = sr.ReadLine();
                        DiemThi tg = new DiemThi();

                        tg.SBD = Int32.Parse(StringHelper.GetString(str, 1, 11));
                        tg.Toan = float.Parse(StringHelper.GetString(str, 12, 24));
                        tg.Van = float.Parse(StringHelper.GetString(str, 25, 37));
                        tg.Anh = float.Parse(StringHelper.GetString(str, 37, 49));

                        temp.Add(tg);
                    }
                }
            }
            catch (Exception e)
            {
                Error = e.Message;
                return false;
            }

            DiemThis = temp;
            return true;
        }

        public static bool SaveDiemThi(string FileName, ref string Error)
        {
            ///
            try
            {
                using (StreamWriter sr = new StreamWriter(FileName))
                {
                    int n = DiemThis.Count;

                    sr.WriteLine(n.ToString());

                    foreach (var item in DiemThis)
                    {
                        string str = "";

                        string SBD = StringHelper.StringWithLengthLeft(item.SBD.ToString(), 11);
                        string Toan = StringHelper.StringWithLengthLeft(item.Toan.ToString("0.00"), 13);
                        string Van = StringHelper.StringWithLengthLeft(item.Van.ToString("0.00"), 13);
                        string Anh = StringHelper.StringWithLengthLeft(item.Anh.ToString("0.00"), 13);

                        str = string.Format("{0}{1}{2}{3}", SBD, Toan, Van, Anh);

                        sr.WriteLine(str);
                    }
                }
            }
            catch (Exception e)
            {
                Error = e.Message;
                return false;
            }
            return true;
        }

    }
}
