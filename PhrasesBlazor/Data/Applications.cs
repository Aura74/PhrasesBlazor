using System.ComponentModel.DataAnnotations;

namespace PhrasesBlazor.Data
{
	public class Applications
	{
		[Key]
		public int ApplicationID { get; set; }
		[StringLength(100)]
		public string ApplicationName { get; set; } = String.Empty;
		public DateTime created { get; set; }

		public override string ToString() => $"ID {ApplicationID}, Name {ApplicationName}, Created {created.ToShortDateString}";
	}
}
