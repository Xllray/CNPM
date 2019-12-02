using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.ViewModels;
using System;
using System.Linq.Expressions;
using ApplicationCore.Services;
using ApplicationCore.DTOs;
using System.Collections.Generic;

namespace Web.Services
{
    public class ProductListVmService 
    {
        private int pageSize = 3;
        
        private readonly ProductService _service;

        public ProductListVmService(ProductService productService)
        {
            _service = productService;
        }
        public ProductListVm GetProductIndexViewModel(string searchString, string genre, int pageIndex = 1)
        {
            var products = _service.GetProducts(searchString, genre);
            var genres = _service.GetGenres();
            var provider = _service.GetProvider();

            return new ProductListVm
            {
                Genres = new SelectList(genres),
                Provider=new SelectList(provider),
                Products = PaginatedList<ProductDto>.Create(products, pageIndex, pageSize)
            };
        }

        //lay danh sach san pham moi nhat
        public ProductListVm GetListSPMoiNhat(int slSPmoi)
        {


            var newspList = _service.GetListNewProducts();

            List<Product> spnew = new List<Product>();
            int tongsp = newspList.Count;

            for (int i=tongsp -1; i>tongsp- slSPmoi-1 ; --i)
            {
                spnew.Add( newspList[i]);
            }

            

            return new ProductListVm
            {
               
                ListProductsNew=spnew
               
            };
        }
        public void DeleteProduct(int id)
        {
            _service.DeleteProduct(id);
        }


       
    } 
}