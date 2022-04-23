using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace Buoi15_ADONET.Controllers
{
    public class DemoController : Controller
    {        
        public DemoController(IConfiguration configuration)
        {
            _configuration = configuration;
            ChuoiKetNoi = _configuration.GetConnectionString("EStore");
        }

        string ChuoiKetNoi = string.Empty;
        private readonly IConfiguration _configuration;

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult DocDatabase()
        {
            var sql = "SELECT * FROM Loai ORDER BY TenLoai";

            SqlConnection connection = new SqlConnection(ChuoiKetNoi);

            SqlDataAdapter da = new SqlDataAdapter(sql, connection);

            DataTable dtLoai = new DataTable();
            da.Fill(dtLoai);

            //Xử lý kết quả
            var sb = new StringBuilder();
            foreach (DataRow dr in dtLoai.Rows)
            {
                sb.AppendLine($"{dr[0]} - {dr["TenLoai"]}");
            }

            return Content(sb.ToString());
        }


        public IActionResult ThemLoai(string TenLoai, string MoTa)
        {
            try
            {
                SqlConnection con = new SqlConnection(ChuoiKetNoi);

                var sql = $"INSERT INTO Loai(TenLoai, MoTa) VALUES(N'{TenLoai}', N'{MoTa}')";

                SqlCommand cmd = new SqlCommand(sql, con);
                //cmd.Connection.Open();
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                return Content("Thêm thành công");
            }
            catch (Exception ex)
            {
                return Content($"Lỗi: {ex.Message}");
            }
        }
    }
}