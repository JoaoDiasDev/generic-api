using joaodias_generic.Application.Coins.Commands;
using MediatR;

namespace joaodias_generic.Application.Coins.Handlers
{
    /// <summary>
    /// The product update command handler.
    /// </summary>
    public class CoinUpdateCommandHandler : IRequestHandler<CoinUpdateCommand, Product>
    {
        private readonly IProductRepository _productRepository;
        /// <summary>
        /// Initializes a new instance of the <see cref="CoinUpdateCommandHandler"/> class.
        /// </summary>
        /// <param name="productRepository">The product repository.</param>
        public CoinUpdateCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository ??
            throw new ArgumentNullException(nameof(productRepository));
        }

        /// <summary>
        /// Handles the.
        /// </summary>
        /// <param name="request">The request.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <returns>A Task.</returns>
        public async Task<Product> Handle(CoinUpdateCommand request,
            CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);

            if (product == null)
            {
                throw new ApplicationException($"Entity could not be found.");
            }
            else
            {
                product.Update(request.Name, request.Description, request.Price,
                                request.Stock, request.Image, request.CategoryId);

                return await _productRepository.UpdateAsync(product);

            }
        }
    }
}
