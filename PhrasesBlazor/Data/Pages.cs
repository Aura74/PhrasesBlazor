using System.ComponentModel.DataAnnotations;

namespace PhrasesBlazor.Data
{
	public class Pages
	{
		[Key]
		public int ID { get; set; }
		[StringLength(100)]
		public string PageName { get; set; } = String.Empty;
		public int ApplicationID { get; set; }
		public DateTime created { get; set; }

		public override string ToString() => $"ID {ID} PageName {PageName} ApplicationID {ApplicationID} Created {created.ToShortDateString()}";
	}
}
