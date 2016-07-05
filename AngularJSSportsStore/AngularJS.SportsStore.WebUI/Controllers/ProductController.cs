using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AngularJS.SportsStore.Domain.Abstract;
using AngularJS.SportsStore.WebUI.Infrastructure.Core;
using AngularJS.SportsStore.Domain.Entities;

namespace AngularJS.SportsStore.WebUI.Controllers
{
    [RoutePrefix("api/Products")]
    public class ProductController : ApiControllerBase
    {
        private readonly IProductRepository repository;

        public ProductController(IProductRepository productRepository, IErrorRepository errorRepository, IUnitOfWork unitOfWork) : base(errorRepository, unitOfWork)
        {
            this.repository = productRepository;
        }

        [Route("{page:int=1}/{pageSize=3}/{category?}")]
        public HttpResponseMessage Get(HttpRequestMessage request, int? page, int? pageSize, string category = null)
        {
            int currentPage = page.Value;
            int currentPageSize = pageSize.Value;

            return CreateHttpResponse(request, () => {
                HttpResponseMessage response = null;
                IEnumerable<Product> productQuery = repository.Products.Where(p => category == null || p.Category == category);

                int totalProducts = productQuery.Count();
                var products = productQuery.Skip((currentPage -1) * currentPageSize)
                                           .Take(currentPageSize)
                                           .ToList();

                PaginationSet<Product> pagedSet = new PaginationSet<Product>
                {
                    Page = currentPage,
                    TotalCount = totalProducts,
                    TotalPages = (int)Math.Ceiling((decimal)totalProducts / currentPageSize),
                    Items = products
                };

                response = request.CreateResponse<PaginationSet<Product>>(HttpStatusCode.OK, pagedSet);

                return response;
            });
        }
    }
}
