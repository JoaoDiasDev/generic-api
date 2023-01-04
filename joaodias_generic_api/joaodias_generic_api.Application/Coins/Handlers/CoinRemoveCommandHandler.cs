using joaodias_generic.Application.Coins.Commands;
using MediatR;

namespace joaodias_generic.Application.Coins.Handlers
{
    /// <summary>
    /// The product remove command handler.
    /// </summary>
    public class CoinRemoveCommandHandler : IRequestHandler<CoinRemoveCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        /// <summary>
        /// Initializes a new instance of the <see cref="CoinRemoveCommandHandler"/> class.
        /// </summary>
        /// <param name="productRepository">The product repository.</param>
        public CoinRemoveCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ?? throw new
                ArgumentNullException(nameof(productRepository));
        }

        /// <summary>
        /// Handles the.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task.</returns>
        public async Task<Product> Handle(CoinRemoveCommand request,
            CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                var result = await _productRepository.RemoveAsync(product);
                return result;
            }
        }
    }
}
