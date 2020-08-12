using Microsoft.EntityFrameworkCore;
using Shop.Core.EF;
using Shop.Domain.Entities;
using Shop.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Core.Repositories
{
    public class NewsRepository : INewsRepository
    {
        private readonly ShopContext _context;

        public NewsRepository(ShopContext context)
        {
            _context = context;
        }

        public async Task<List<News>> GetAllAsync()
        {
            return await _context.News.ToListAsync();
        }

        public async Task<bool> UpdateAsync(News E)
        {
            News ev = await _context.News.FirstOrDefaultAsync(e => e.Id == E.Id);
            if (ev == null)
                return false;

            if (ev.Img != "/images/null.png" && ev.Img != "" && ev.Img != null)
            {
                Guid id = Guid.NewGuid();
                string base64str = ev.Img.Substring(ev.Img.IndexOf(',') + 1);
                byte[] bytes = Convert.FromBase64String(base64str);
                File.WriteAllBytes("wwwroot/images/news/" + id + ".png", bytes);

                FileInfo fileInf = new FileInfo("wwwroot" + E.Img);
                if (fileInf.Exists)
                    fileInf.Delete();
                E.Img = "/images/news/" + id + ".png";
            };

            ev.Text = E.Text;
            ev.Date = E.Date;
            ev.Link = E.Link;
            _context.News.Update(ev);
            await _context.SaveChangesAsync();
            return true;
        }


        public async Task<bool> DeleteAsync(Guid id)
        {
            News ev = await _context.News.FirstOrDefaultAsync(e => e.Id == id);
            if (ev == null)  
                return false;
            
            if (ev.Img != "/images/null.png")
            {
                FileInfo fileInf = new FileInfo("wwwroot" + ev.Img);
                if (fileInf.Exists)
                {
                    fileInf.Delete();   
                };
            };
            _context.News.Remove(ev);
            await _context.SaveChangesAsync();
            return true;
        }



        public async Task<News> CreateAsync(News news)
        {
            if (news.Img == null || news.Img == "")
                news.Img = "/images/null.png";
            else
            {
                Guid id = Guid.NewGuid();
                string base64str = news.Img.Substring(news.Img.IndexOf(',') + 1);
                byte[] bytes = System.Convert.FromBase64String(base64str);
                File.WriteAllBytes("wwwroot/images/news/" + id + ".png", bytes);
                news.Img = "/images/news/" + id + ".png";
            };
            var result = await _context.News.AddAsync(news);
            await _context.SaveChangesAsync();
            return result.Entity;
        }
    }
}
