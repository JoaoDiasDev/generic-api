namespace joaodias_generic.Domain.Validation
{
    /// <summary>
    /// The domain exception validation.
    /// </summary>
    public class DomainExceptionValidation : Exception
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DomainExceptionValidation"/> class.
        /// </summary>
        /// <param name="error">The error.</param>
        public DomainExceptionValidation(string error) : base(error)
        {

        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainExceptionValidation"/> class.
        /// </summary>
        public DomainExceptionValidation() : base()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DomainExceptionValidation"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public DomainExceptionValidation(string message, Exception innerException) : base(message, innerException)
        {
        }

        /// <summary>
        /// Whens the.
        /// </summary>
        /// <param name="hasError">If true, has error.</param>
        /// <param name="error">The error.</param>
        public static void When(bool hasError, string error)
        {
            if (hasError)
                throw new DomainExceptionValidation(error);
        }
    }
}
