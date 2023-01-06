using System.ComponentModel.DataAnnotations;

namespace PhrasesBlazor.Data
{
	public class EditVM
	{
		public int? PhraseID { get; set; }
		[StringLength(100)]
		public string Element { get; set; } = String.Empty;
		public string Phrase { get; set; } = String.Empty;
		public int ApplicationID { get; set; }
		public int? PageID { get; set; }
		[StringLength(5)]
		public string Culture { get; set; } = String.Empty;
		public string? OrginalPhrase { get; set; }
		public string? PhraseDescription { get; set; }
		public DateTime created { get; set; }
	}
}
