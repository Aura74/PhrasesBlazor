using Microsoft.EntityFrameworkCore;
using PhrasesBlazor.Data;

namespace PhrasesBlazor.Services
{
    public class PhrasesRepo
    {
        PhrasesDbContext _db { get; set; }
        public PhrasesRepo(PhrasesDbContext db)
        {
            _db = db;
        }

        #region Get Total Phrases Count
        // Count av alla phrases
        public async Task<int> GetTotalCountAsync() => await _db.Phrases.CountAsync();
		public async Task<int> GetTotalCountAsync(int appid) => await _db.Phrases
            .Where(phrase => phrase.ApplicationID == appid)
            .CountAsync();
		public async Task<int> GetTotalCountAsync(int appid, int pageid) => await _db.Phrases
            .Where(phrase => phrase.ApplicationID == appid && phrase.PageID == pageid)
            .CountAsync();
		public async Task<int> GetTotalCountAsync(int appid, int pageid, string culture) => await _db.Phrases
            .Where(phrase => phrase.ApplicationID == appid && phrase.PageID == pageid && phrase.Culture == culture)
            .CountAsync();
        #endregion

        #region Get Cultures
        // Alla Cultures
        public async Task<List<Cultures>> GetCulturesAsync() => await _db.Cultures.ToListAsync();
        #endregion

        #region Get Pages
        // Lista över alla pages
        public async Task<List<Data.Pages>> GetPagesAsync() => await _db.Pages.ToListAsync();

        // Lista över alla pages med en specifik AppID
		public async Task<List<Data.Pages>> GetPagesAsync(int appid) => await _db.Pages
            .Where(page => page.ApplicationID == appid)
            .ToListAsync();
        #endregion

        #region Get Phrases
        // Alla phrases från AppID och PageID
        public async Task<List<Phrases>> GetPhrasesAsync(int appid, int pageid) =>
            await _db.Phrases
            .Where(phrase => phrase.ApplicationID == appid && phrase.PageID == pageid)
            .ToListAsync();

        // Alla phrases från AppID, PageID och en Culture
		public async Task<List<Phrases>> GetPhrasesAsync(int appid, int pageid, string culture) =>
	        await _db.Phrases
	        .Where(phrase => phrase.ApplicationID == appid && phrase.PageID == pageid && phrase.Culture == culture)
	        .ToListAsync();

        // En specifik phrase från AppID, PageID, Culture och ett Element
        public async Task<Phrases?> GetPhraseByAppPageElementCultureAsync(int appid, int pageid, string element, string culture) => await _db.Phrases
            .Where(phrase => phrase.ApplicationID == appid && phrase.PageID == pageid && phrase.Culture == culture && phrase.Element == element)
            .FirstOrDefaultAsync();

        // En specifik phrase från PhraseID
        public async Task<Phrases?> GetPhraseById(int phraseid) =>
            await _db.Phrases.Where(phrase => phrase.PhraseID== phraseid).FirstOrDefaultAsync();
        #endregion

        #region Get Applications
        // Alla Applications
        public async Task<List<Applications>> GetApplicationsAsync() => await _db.Applications.ToListAsync();
        #endregion

        // Alla elements från AppID och PageID, Sorterad efter Element
        public async Task<List<string>> GetDistinctElementsAsync(int appid, int pageid) => await _db.Phrases
            .Where(phrase => phrase.ApplicationID == appid && phrase.PageID == pageid)
            .Select(phrase => phrase.Element)
            .Distinct()
            .OrderBy(o => o)
            .ToListAsync();

        public async Task<bool> UpdatePhraseAsync(Phrases? phrase)
        {
            if (phrase is null)
                return false;

            if (phrase.PhraseID == 0)
                return false;

            var updateItem = await _db.Phrases.FirstOrDefaultAsync(o => o.PhraseID == phrase.PhraseID);

            if (updateItem is not null)
            {
                updateItem.PhraseDescription = phrase.PhraseDescription;
                updateItem.Phrase = phrase.Phrase;
                updateItem.Element = phrase.Element;
                updateItem.OrginalPhrase = phrase.OrginalPhrase;

                await _db.SaveChangesAsync();
                return true;
            }

            return false;
        }

        public async Task<bool> CreatePhraseAsync(Phrases phrase)
        {
            await _db.AddAsync(phrase);
            var success = await _db.SaveChangesAsync();

            if (success > 0)
                return true;

            else
                return false;
        }

        public async Task<bool> DeletePhrase(int phraseid)
        {
            var phrase = await GetPhraseById(phraseid);

            if (phrase is not null)
            {
                _db.Remove(phrase);
                await _db.SaveChangesAsync();
                return true;
            }

            else
            {
                return false;
            }
        }
    }
}
