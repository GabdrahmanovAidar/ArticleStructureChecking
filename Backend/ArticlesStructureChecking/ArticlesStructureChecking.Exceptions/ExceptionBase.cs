using Serilog;
using System.Buffers;
using System.Net;
using System.Text.Json;

namespace ArticlesStructureChecking.Exceptions
{
    public abstract class ZammeExceptionBase : Exception
	{
		private const int ControversyCapacity = 1;
		public string Error { get; }
		protected ZammeExceptionBase(string error) : base(error)
		{
			Error = error;
		}
		protected ZammeExceptionBase(string method, string responseText) : base($"method {method} is not found with responseText: {responseText}")
		{
			Error = "UnknownError";
		}

		public void Serialize(IBufferWriter<byte> output, string language, bool isProduction)
		{
			string message = Error;
			using var writer = new Utf8JsonWriter(output);
			var serializeOptions = new JsonSerializerOptions
			{
				PropertyNamingPolicy = JsonNamingPolicy.CamelCase
			};

			JsonSerializer.Serialize(writer, new ErrorMessage(controversy: new List<string>(ControversyCapacity)
			{
				isProduction ? message : ToString()
			}), serializeOptions);
			writer.Flush();
		}

		/// <summary>
		/// Gets HTTP status code associated with this exception.
		/// </summary>
		public virtual HttpStatusCode StatusCode => HttpStatusCode.InternalServerError;

		/// <summary>
		/// Writes the exception to the log.
		/// </summary>
		/// <param name="logger">The logger.</param>
		public virtual void WriteToLog(ILogger logger)
		  => logger?.Error(this, Message);
	}
}
