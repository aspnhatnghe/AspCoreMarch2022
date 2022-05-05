using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Buoi17_EFCore_DbFirst.Entities;
using Microsoft.AspNetCore.Http;
using Buoi17_EFCore_DbFirst.Models;
using Buoi17_EFCore_DbFirst.ViewModels;

namespace Buoi17_EFCore_DbFirst.Controllers
{
    public class HangHoasController : Controller
    {
        private readonly eStore20Context _context;

        public HangHoasController(eStore20Context context)
        {
            _context = context;
        }


        #region Tìm kiếm
        public IActionResult TimKiem()
        {
            return View();
        }

        [HttpPost]
        public IActionResult TimKiem(string Keyword, double? FromPrice, double? ToPrice)
        {
            var dsHangHoa = _context.HangHoa.AsQueryable();
            /*
             .ToList(): translate sql statement và trả về danh sách
             .AsQueryable(): vẫn còn query được, tức chưa có dịch ra câu lệnh SQL dể vào database lấy
             */
            if (!string.IsNullOrEmpty(Keyword))
            {
                dsHangHoa = dsHangHoa.Where(hh => hh.TenHh.Contains(Keyword));
            }
            if (FromPrice.HasValue)
            {
                dsHangHoa = dsHangHoa.Where(hh => hh.DonGia >= FromPrice.Value);
            }
            if (ToPrice.HasValue)
            {
                dsHangHoa = dsHangHoa.Where(hh => hh.DonGia <= ToPrice.Value);
            }

            var data = dsHangHoa.Select(hh => new KetQuaTimKiemVM
            {
                MaHh = hh.MaHh,
                TenHh = hh.TenHh,
                DonGia = hh.DonGia.Value,
                NgaySX = hh.NgaySx,
                Loai = hh.MaLoaiNavigation.TenLoai
            }).ToList();
            return View(data);
        }
        #endregion



        // GET: HangHoas
        public async Task<IActionResult> Index()
        {
            var eStore20Context = _context.HangHoa
                .Include(h => h.MaLoaiNavigation)
                .Include(h => h.MaNccNavigation);
            return View(await eStore20Context.ToListAsync());
        }

        // GET: HangHoas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangHoa = await _context.HangHoa
                .Include(h => h.MaLoaiNavigation)
                .Include(h => h.MaNccNavigation)
                .FirstOrDefaultAsync(m => m.MaHh == id);
            if (hangHoa == null)
            {
                return NotFound();
            }

            return View(hangHoa);
        }

        // GET: HangHoas/Create
        public IActionResult Create()
        {
            ViewData["MaLoai"] = new SelectList(_context.Loai, "MaLoai", "TenLoai");
            ViewData["MaNcc"] = new SelectList(_context.NhaCungCap, "MaNcc", "MaNcc");
            return View();
        }

        // POST: HangHoas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MaHh,TenHh,MaLoai,MoTaDonVi,DonGia,Hinh,NgaySx,GiamGia,SoLanXem,MoTa,MaNcc")] HangHoa hangHoa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(hangHoa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLoai"] = new SelectList(_context.Loai, "MaLoai", "TenLoai", hangHoa.MaLoai);
            ViewData["MaNcc"] = new SelectList(_context.NhaCungCap, "MaNcc", "MaNcc", hangHoa.MaNcc);
            return View(hangHoa);
        }

        // GET: HangHoas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangHoa = await _context.HangHoa.FindAsync(id);
            if (hangHoa == null)
            {
                return NotFound();
            }
            ViewData["MaLoai"] = new SelectList(_context.Loai, "MaLoai", "TenLoai", hangHoa.MaLoai);
            ViewData["MaNcc"] = new SelectList(_context.NhaCungCap, "MaNcc", "MaNcc", hangHoa.MaNcc);
            return View(hangHoa);
        }

        // POST: HangHoas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MaHh,TenHh,MaLoai,MoTaDonVi,DonGia,Hinh,NgaySx,GiamGia,SoLanXem,MoTa,MaNcc")] HangHoa hangHoa, IFormFile HinhUpdate)
        {
            if (id != hangHoa.MaHh)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                if (HinhUpdate != null)
                {
                    var newImageUrl = MyTool.UploadFileToFolder(HinhUpdate, "HangHoa");
                    if (!string.IsNullOrEmpty(newImageUrl))
                    {
                        hangHoa.Hinh = newImageUrl;
                        //xóa hình cũ
                    }
                }
                try
                {
                    _context.Update(hangHoa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!HangHoaExists(hangHoa.MaHh))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["MaLoai"] = new SelectList(_context.Loai, "MaLoai", "TenLoai", hangHoa.MaLoai);
            ViewData["MaNcc"] = new SelectList(_context.NhaCungCap, "MaNcc", "MaNcc", hangHoa.MaNcc);
            return View(hangHoa);
        }

        // GET: HangHoas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var hangHoa = await _context.HangHoa
                .Include(h => h.MaLoaiNavigation)
                .Include(h => h.MaNccNavigation)
                .FirstOrDefaultAsync(m => m.MaHh == id);
            if (hangHoa == null)
            {
                return NotFound();
            }

            return View(hangHoa);
        }

        // POST: HangHoas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var hangHoa = await _context.HangHoa.FindAsync(id);
            _context.HangHoa.Remove(hangHoa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool HangHoaExists(int id)
        {
            return _context.HangHoa.Any(e => e.MaHh == id);
        }
    }
}
