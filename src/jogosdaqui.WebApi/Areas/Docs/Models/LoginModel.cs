using System.ComponentModel.DataAnnotations;

namespace jogosdaqui.WebApi.Areas.Docs.Models
{
	/// <summary>
	/// Modelo para login.
	/// </summary>
	public class LoginModel
	{
		/// <summary>
		/// Obtém ou define o token de requisição.
		/// </summary>
		public string RequestToken { get; set; }

		/// <summary>
		/// Obtém ou define o client id.
		/// </summary>
		[Required]
		public string ClientId { get; set; }

		/// <summary>
		/// Obtém ou define client secret.
		/// </summary>
		[Required]
		public string ClientSecret { get; set; }

		/// <summary>
		/// Obtém ou define a mensagem de erro.
		/// </summary>
		public string ErrorMessage { get; set; }

		/// <summary>
		/// Obtém ou define a url de retorno após o login com sucesso.
		/// </summary>
		public string ReturnUrl { get; set; }
	}
}