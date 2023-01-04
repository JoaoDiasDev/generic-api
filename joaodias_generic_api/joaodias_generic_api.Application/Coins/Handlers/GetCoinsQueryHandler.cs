using joaodias_generic.Application.Coins.Queries;
using MediatR;

namespace joaodias_generic.Application.Coins.Handlers
{
    /// <summary>
    /// The get products query handler.
    /// </summary>
    public class GetCoinsQueryHandler : IRequestHandler<GetCoinsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetCoinsQueryHandler"/> class.
        /// </summary>
        /// <param name="productRepository">The product repository.</param>
        public GetCoinsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        /// <summary>
        /// Handles the.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task.</returns>
        public Task<IEnumerable<Product>> Handle(GetCoinsQuery request,
            CancellationToken cancellationToken)
        {
            return _productRepository.GetProductsAsync();
        }
    }
}
