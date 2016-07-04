using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using AngularJS.SportsStore.Domain.Abstract;
using AngularJS.SportsStore.WebUI.Infrastructure.Core;

namespace AngularJS.SportsStore.WebUI.Controllers
{
    [RoutePrefix("api/Products")]
    public class ProductController : ApiControllerBase
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository, IErrorRepository errorRepository, IUnitOfWork unitOfWork) : base(errorRepository, unitOfWork)
        {
            this.productRepository = productRepository;
        }

        [Route("")]
        public HttpResponseMessage Get(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () => {
                HttpResponseMessage response = null;
                var products = productRepository.Products;

                response = request.CreateResponse(HttpStatusCode.OK, products);

                return response;
            });
        }
    }
}
