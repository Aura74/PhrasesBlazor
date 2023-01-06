using System.ComponentModel.DataAnnotations;

namespace PhrasesBlazor.Data
{
	public class Cultures
	{
		[Key]
		public int CultureID { get; set; }
		[StringLength(50)]
		public string? Culture { get; set; }
		public DateTime? created { get; set; }

		public override string ToString() => $"CultureID: {CultureID}, Culture: {Culture}, Created: {created.ToString}";
	}
}
