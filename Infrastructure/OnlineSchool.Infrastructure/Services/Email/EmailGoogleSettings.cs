using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineSchool.Infrastructure.Services.Email
{
	public class EmailGoogleSettings
	{
		public const string SectionName = "EmailSettings";

		public string Address { get; init; } = null!;
		public string GmailPassword { get; init; } = null!;
		public string From { get; init; } = null!;

	}
}
