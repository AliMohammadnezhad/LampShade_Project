﻿using System.Collections.Generic;
using System.Linq;
using _0_FrameWork.Infrastructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Slide;
using ShopManagement.Domain.SlideAgg;

namespace ShopManagement.Infrastructure.EFCore.Repository
{
    public class SlideRepository : RepositoryBase<long, Slide>, ISlideRepository
    {
        private readonly ShopContext _context;

        public SlideRepository(ShopContext context) : base(context)
        {
            _context = context;
        }

        public List<SlideViewModel> GetList()
        {
            return _context.Slides.OrderByDescending(x => x.CreationDate).Select(x => new SlideViewModel
            {
                Heading = x.Heading,
                Id = x.Id,
                Picture = x.Picture,
                Title = x.Title,
                IsRemoved = x.IsRemoved,
                CreationDate = x.CreationDate.ToString()
            }).ToList();
        }

        public EditSlide GetDetails(long id)
        {
            return _context.Slides.Select(x => new EditSlide
            {
                Title = x.Title,
                Picture = x.Picture,
                Id = x.Id,
                Heading = x.Heading,
                PictureTitle = x.PictureTitle,
                BtnText = x.BtnText,
                PictureAlt = x.PictureAlt,
                Text = x.Text
            }).FirstOrDefault(x => x.Id == id);
        }
    }
}