using Microsoft.AspNetCore.Http;
using New.Data;
using New.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using New.Utility;
using System.Security.Cryptography;
using System.Data.SqlClient;

namespace New.Repositories
{
    public class ServiceUser
    {
        private readonly ApplicationDbContext _db;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public ServiceUser(ApplicationDbContext db, IHttpContextAccessor httpContextAccessor)
        {
            _db = db;
            _httpContextAccessor = httpContextAccessor;
        }


        public string GetUser()
        {
            return _session.GetString(SD.ssNip);
        }

        public void SetPeriode(string idPeriode)
        {

            var nip = GetUser();
            var rList = _db.ApplicationUser.Where(u => u.NIP == nip).FirstOrDefault();
            if (rList != null)
            {
                rList.IdPeriode = idPeriode;
                _db.Update(rList);
                _db.SaveChanges();
            }

        }

        public string GetPeriode()
        {
            var nip = GetUser();
            var retVal = "";
            var rList = _db.ApplicationUser.Where(u => u.NIP == nip).FirstOrDefault();
            if (rList != null)
            {
                retVal = rList.IdPeriode;

            }
            return retVal;
        }


        public void SetToday(DateTime tanggal)
        {

            var nip = GetUser();
            var rList = _db.ApplicationUser.Where(u => u.NIP == nip).FirstOrDefault();
            if (rList != null)
            {
                rList.Tanggal = tanggal;
                _db.Update(rList);
                _db.SaveChanges();
            }

        }


        public DateTime GetToday()
        {
            var nip = GetUser();
            DateTime retVal = DateTime.Now.Date;
            var rList = _db.ApplicationUser.Where(u => u.NIP == nip).FirstOrDefault();
            if (rList != null)
            {
                if (rList.Tanggal != null)
                {
                    retVal = rList.Tanggal.Value;
                }
                else
                {
                    //DateTime tanggal = new DateTime(2017, 1, 18);

                    rList.Tanggal = retVal;
                    _db.Update(rList);
                    _db.SaveChanges();

                }
            }
            return retVal;
        }

        public int GetBulanByPeriode(string idperiode)
        {
            int retVal = 0;
            var rList = _db.Periode.Where(u => u.Id == idperiode).FirstOrDefault();
            if (rList != null)
            {
                retVal = rList.Bulan.Value;
            }
            return retVal;
        }

        public int GetTahunByPeriode(string idperiode)
        {
            int retVal = 0;
            var rList = _db.Periode.Where(u => u.Id == idperiode).FirstOrDefault();
            if (rList != null)
            {
                retVal = rList.Tahun.Value;
            }
            return retVal;
        }

        public int GetBulan()
        {
            int retVal = 0;
            var rList = _db.Periode.Where(u => u.Id == GetPeriode()).FirstOrDefault();
            if (rList != null)
            {
                retVal = rList.Bulan.Value;
            }
            return retVal;
        }

        public int GetTahun()
        {
            int retVal = 0;
            var rList = _db.Periode.Where(u => u.Id == GetPeriode()).FirstOrDefault();
            if (rList != null)
            {
                retVal = rList.Tahun.Value;
            }
            return retVal;
        }
        public int GetIdUnitKerja()
        {

            var nip = GetUser();
            //HttpContext.Session.GetString(SD.ssNip) ;
            var rowData = _db.ApplicationUser.Where(u => u.NIP == nip).FirstOrDefault();
            if (rowData != null)
            {
                return rowData.UnitKerja;
            }
            else
            {
                return 0;
            }

        }

        public string GetUnitKerja(int id)
        {

            var _id = id;
            //HttpContext.Session.GetString(SD.ssNip) ;
            var rowData = _db.UnitKerja.Where(u => u.Id == _id).FirstOrDefault();
            if (rowData != null)
            {
                return rowData.Uraian;
            }
            else
            {
                return "";
            }

        }

        public bool PeriodeDalamTanggal(string idPeriode, DateTime tgl)
        {
            bool retVal = false;
            var rList = _db.Periode.Where(u => u.Id == idPeriode).FirstOrDefault();
            if (rList != null)
            {
                if (tgl.Month == rList.Bulan && tgl.Year == rList.Tahun)
                {
                    retVal = true;
                }
            }
            return retVal;
        }


        public bool CekPeriodeTanggal()
        {
            bool retVal = false;

            var idPeriode = GetPeriode();
            var tgl = GetToday();
            if (PeriodeDalamTanggal(idPeriode, tgl))
            {
                retVal = true;
            }


            return retVal;
        }

        public string GetUserNama()
        {
            string retVal = "";
            var nip = GetUser();
            var rList = _db.ApplicationUser.Where(u => u.NIP == nip).FirstOrDefault();
            if (rList != null)
            {
                retVal = rList.Nama;
            }
            return retVal;
        }

        public string GetNamaPeg( string nip)
        {
            string retVal = "";
             
            var rList = _db.Pegawai.Where(u => u.NIP == nip).FirstOrDefault();
            if (rList != null)
            {
                retVal = rList.Nama;
            }
            return retVal;
        }


        public int GetHariKalender()
        {
            int rVal = 1;
            int bulan = GetBulan();
            int tahun = GetTahun();
            var row = from u in _db.HariKerja
                      where u.Tanggal.Month == bulan && u.Tanggal.Year == tahun
                      group u by new { u.Tanggal.Year, u.Tanggal.Month } into p
                      select new
                      {
                          Total = p.Count()

                      };
            if (row.Count() != 0)
            {
                rVal = row.Sum(u => u.Total);
            }

            return rVal;

        }

        public int GetHKybsJam(string idperiode, string nip)
        {


            int rVal = 0;
            int bulan = GetBulanByPeriode(idperiode);
            int tahun = GetTahunByPeriode(idperiode);


            string strSql =
                "SET DATEFIRST 1;" +
                "SELECT A.IdPeriode, A.NIP, SUM(ISNULL(DATEDIFF(minute, C.MasukA, C.KeluarA) + DATEDIFF(minute, C.MasukB, C.KeluarB), 0)) DURASI " +
                "FROM HariKerjaNip A  INNER JOIN HariKerjaStatus B on A.IdHariKerjaStatus = B.Id " +
                "INNER JOIN JamKerjaPolaDt C ON " +
                "DATEPART(weekday, A.TANGGAL) = C.IdDow AND " +
                "DBO.GetJamKerjaPolaNip(A.NIP, A.TANGGAL) = C.IdPola " +
                "WHERE A.nip = '" + @nip + "' AND A.IdPeriode = '" + @idperiode + "' and B.Libur = 0 " +
                "GROUP BY A.IdPeriode, A.NIP";

             var row = _db.HKYbsJam.FromSql(strSql).FirstOrDefault();

           // rVal = 0;

            //if (row != null)
            //{
                rVal = row.Durasi;
            //}
             
            return rVal;

        }

        public int GetHKybsJamLama(string idperiode, string nip)
        {


            int rVal = 0;
            int bulan = GetBulanByPeriode(idperiode);
            int tahun = GetTahunByPeriode(idperiode);


            var rowA = (from u in _db.HariKerjaNip.Where(u => u.IdPeriode == idperiode && u.NIP == nip)
                        join v in _db.HariKerjaStatus.Where(x => x.Libur == false)
                        on u.IdHariKerjaStatus equals v.Id

                        select new
                        {
                            u.IdPeriode,
                            u.NIP,
                            u.Tanggal,
                            u.IdHariKerjaStatus,
                            dow = (int)u.Tanggal.DayOfWeek,
                            v.Libur

                        }
                       ).ToList();

            if (rowA.Count() == 0)
            {
                return 0;
            }

            var rowB = (from u in _db.PeriodeNIP.Where(u => u.IdPeriode == idperiode && u.Nip == nip)
                        join v in _db.JamKerjaPolaDt on u.IdJamKerjaPola equals v.IdPola

                        select new
                        {
                            u.IdPeriode,
                            u.Nip,
                            u.IdJamKerjaPola,
                            v.IdDow,
                            v.MasukA,
                            v.KeluarA,
                            v.MasukB,
                            v.KeluarB,
                            Durasi = (v.KeluarA.Subtract(v.MasukA) + v.KeluarB.Subtract(v.MasukB))


                        }
                        ).ToList();

            if (rowB.Count() == 0)
            {
                return 0;
            }


            var row = (from a in rowA
                       join b in rowB on a.dow equals b.IdDow
                       group b by 0
                       into p
                       select new
                       {

                           Tot = (int)p.Sum(u => u.Durasi.TotalMinutes)

                       }).ToList();
            //.sum().ToList();



            if (row.Count() == 0)
            {
                return 0;
            }

            rVal = row[0].Tot;


            return rVal;

        }
        public int GetHKybs(string idperiode, string nip)
        {


            int rVal = 0;
            int bulan = GetBulanByPeriode(idperiode);
            int tahun = GetTahunByPeriode(idperiode);


            var row = from u in _db.HariKerjaNip
                      where u.IdPeriode == idperiode && u.NIP == nip
                      join v in _db.HariKerjaStatus on u.IdHariKerjaStatus equals v.Id
                      where v.Libur == false
                      group u by new { u.IdPeriode, u.NIP } into p
                      select new
                      {
                          Total = p.Count()

                      };

            if (row.Count() != 0)
            {
                rVal = row.Sum(u => u.Total);
            }



            return rVal;

        }

        private int CalcDuration(TimeSpan mulai, TimeSpan hingga)
        {
            int rVal = (int)hingga.Subtract(mulai).TotalMinutes;
            return rVal;
        }
        public int GetNCatHar(string idperiode, string nip)
        {
            var rVal = 0;
            var row = (from a in _db.Diary
                       where a.IdPeriode == idperiode && a.Nip == nip

                       select new
                       {
                           a.Tanggal,
                           a.WaktuMulai,
                           a.WaktuHingga,
                           Total = CalcDuration(a.WaktuMulai, a.WaktuHingga)
                       }).ToList();

            if (row.Count() != 0)
            {
                rVal = row.Count();
            }

            return rVal;

        }

        public int GetDurasiCatHar(string idperiode, string nip)
        {
            var rVal = 0;
            var row = (from a in _db.Diary
                       where a.IdPeriode == idperiode && a.Nip == nip
                       group a by 0 into r
                       select new
                       {
                           Total = (int)r.Sum(u => CalcDuration(u.WaktuMulai, u.WaktuHingga))
                       }).ToList();

            if (row.Count() != 0)
            {
                rVal = row[0].Total;
            }

            return rVal;

        }

        public List<Diary> GetCatHarMinus(string idperiode, string nip)
        {
            var row = (from a in _db.Diary
                       where a.WaktuHingga < a.WaktuMulai && a.IdPeriode == idperiode && a.Nip == nip
                       select a
                       ).ToList();

            return row;

        }

        public List<Diary> GetCatHarOverLap(string idperiode, string nip)
        {
            var rList = (from a in _db.Diary
                         where a.IdPeriode == idperiode && a.Nip == nip

                         select a
                       ).OrderBy(u => u.Tanggal).ThenBy(u => u.WaktuMulai).ToList();

            var prev = new Diary();
            var rows = new List<Diary>();
            if (rList.Count() != 0)
            {
                foreach (Diary item in rList)
                {
                    if (prev.PeriodeNIP != null)
                    {
                        if (prev.Tanggal == item.Tanggal && prev.WaktuHingga > item.WaktuMulai)
                        {
                            rows.Add(item);
                        }

                    }

                    prev = item;

                }
            }

            return rows;

        }


        public int GetDurasiAL(string idperiode, string nip)
        {
            var rVal = 0;
            var row = (from a in _db.Diary
                       where a.IdPeriode == idperiode && a.Nip == nip
                       group a by 0 into r
                       select new
                       {
                           Total = (int)r.Sum(u => u.WaktuSetuju1 ?? 0)
                       }).ToList();

            if (row.Count() != 0)
            {
                rVal = row[0].Total;
            }

            return rVal;

        }

        public int GetDurasiAAL(string idperiode, string nip)
        {
            var rVal = 0;
            var row = (from a in _db.Diary
                       where a.IdPeriode == idperiode && a.Nip == nip
                       group a by 0 into r
                       select new
                       {
                           Total = (int)r.Sum(u => u.WaktuSetuju2 ?? 0)
                       }).ToList();

            if (row.Count() != 0)
            {
                rVal = row[0].Total;
            }

            return rVal;

        }
    }
}