using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UX.Testing.Core.Helpers
{
	/// <summary>
	/// Contains global settings that get applied to the process when calling.  Any method called from here
	/// will modify the behavior of HTTP across the whole process.
	/// </summary>
	public static class HttpUtilities
	{
		/// <summary>
		/// Together with the AcceptAllCertifications method right
		/// below this causes to bypass errors caused by SSL-Errors.
		/// </summary>
		public static void IgnoreInvalidCertificates()
		{
			System.Net.ServicePointManager.ServerCertificateValidationCallback = new System.Net.Security.RemoteCertificateValidationCallback(AcceptAllCertifications);
		}

		/// <summary>
		/// In Short: the Method solves the Problem of broken Certificates.
		/// Sometime when requesting Data and the sending Webserverconnection
		/// is based on a SSL Connection, an Error is caused by Servers whoes
		/// Certificate(s) have Errors. Like when the Cert is out of date
		/// and much more... So at this point when calling the method,
		/// this behaviour is prevented
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="certification"></param>
		/// <param name="chain"></param>
		/// <param name="sslPolicyErrors"></param>
		/// <returns>true</returns>
		private static bool AcceptAllCertifications(object sender, System.Security.Cryptography.X509Certificates.X509Certificate certification, System.Security.Cryptography.X509Certificates.X509Chain chain, System.Net.Security.SslPolicyErrors sslPolicyErrors)
		{
			return true;
		}

	}

}
