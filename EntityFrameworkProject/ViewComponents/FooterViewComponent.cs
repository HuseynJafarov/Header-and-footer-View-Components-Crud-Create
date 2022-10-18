using EntityFrameworkProject.Data;
using EntityFrameworkProject.Models;
using EntityFrameworkProject.Services;
using EntityFrameworkProject.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EntityFrameworkProject.ViewComponents
{
    public class FooterViewComponent: ViewComponent
    {
        private readonly AppDbContext _context;
        private readonly LayoutService _layout;

        public FooterViewComponent(AppDbContext context, LayoutService layout)
        {
            _context = context;
            _layout = layout;
        }


        public async Task<IViewComponentResult> InvokeAsync()
        {
            var settingData = await _layout.GetDatasFromSetting();
            string email = settingData["Email"];
            IEnumerable<Social> socials = await _context.Socials.ToListAsync();

            FooterVM footerVM = new FooterVM
            {
                Email = email,
                Socials = socials
            };

            return await Task.FromResult(View(footerVM));

        }

    }
}
