using ApplicationCore.Entities;
using ApplicationCore.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;
using Web.ViewModels;
using System;
using System.Linq.Expressions;
using ApplicationCore.Services;
using ApplicationCore.DTOs;

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
        public ProductListVm GetProductIndexViewModel()
        {
           
          
            var provider = _service.GetProvider();

            return new ProductListVm
            {
               
                Provider = new SelectList(provider)
               
            };
        }
        public void DeleteProduct(int id)
        {
            _service.DeleteProduct(id);
        }


        /*
        public MovieIndexVM GetMovieIndexViewModel(string searchString, string genre, int pageIndex = 1)
        {           
            Expression<Func<Movie, bool>> predicate = m => true;

            if (!string.IsNullOrEmpty(searchString) && !string.IsNullOrEmpty(genre))
            {
                predicate = m => m.Genre == genre && m.Title.Contains(searchString);
            }
            else if (!string.IsNullOrEmpty(searchString))
            {
                predicate = m => m.Title.Contains(searchString);
            }
            else if(!string.IsNullOrEmpty(genre))
            {
                predicate = m => m.Genre == genre;
            }

            var movies = _unitOfWork.Movies.Find(predicate);
            var genres = _unitOfWork.Movies.GetGenres();

            return new MovieIndexVM
            {
                Genres = new SelectList(genres),
                Movies = PaginatedList<Movie>.Create(movies, pageIndex, pageSize)
            };
        }

        public void DeleteMovie(int id)
        {
            var movie = _unitOfWork.Movies.GetBy(id);
            if (movie != null)
            {
                _unitOfWork.Movies.Remove(movie);
                _unitOfWork.Complete();
            }
        }
        */

    } 
}