using ASPCore.ADONETLab.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Buoi15_ADONET.Models
{
    public class LoaiDataAccessLayer
    {
        public static List<Loai> GetAll()
        {
            var dtLoai = DataProvider.SelectData("spLayTatCaLoai", CommandType.StoredProcedure, null);
            var result = new List<Loai>();

            foreach (DataRow dr in dtLoai.Rows)
            {
                result.Add(new Loai
                {
                    MaLoai = int.Parse(dr["MaLoai"].ToString()),
                    TenLoai = dr["TenLoai"].ToString(),
                    MoTa = dr["MoTa"].ToString(),
                    Hinh = dr["Hinh"].ToString()
                });
            }

            return result;
        }

        public static Loai GetById(int id)
        {
            var pa = new SqlParameter[1]
            {
                new SqlParameter("MaLoai", id)
            };
            var loai = DataProvider.SelectData("spLayLoai", CommandType.StoredProcedure, pa);
            if(loai.Rows.Count == 0)
            {
                return null;
            }
            var dr = loai.Rows[0];
            return new Loai
            {
                MaLoai = int.Parse(dr["MaLoai"].ToString()),
                TenLoai = dr["TenLoai"].ToString(),
                MoTa = dr["MoTa"].ToString(),
                Hinh = dr["Hinh"].ToString()
            };
        }

        public static Loai Add(Loai loai)
        {
            try
            {
                var pa = new SqlParameter[4]
                {
                new SqlParameter("MaLoai", SqlDbType.Int),
                new SqlParameter("TenLoai", loai.TenLoai),
                new SqlParameter("MoTa", loai.MoTa),
                new SqlParameter("Hinh", loai.Hinh)
                };
                pa[0].Direction = ParameterDirection.Output;

                DataProvider.ExcuteNonQuery("spThemLoai", CommandType.StoredProcedure, pa);

                loai.MaLoai = int.Parse(pa[0].Value.ToString());
                return loai;
            }
            catch { return null; }
        }

        //public static Loai Update(Loai loai)
        //{

        //}

        //public static bool Delete(int id)
        //{ }
    }
}
