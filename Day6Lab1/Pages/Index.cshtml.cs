using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Day6Lab1.Pages {
    public class IndexModel : PageModel {
        private readonly ILogger<IndexModel> _logger;

        private readonly Lingo _game;
        public string Hint { get; set; }
        public bool Win = false;

        public int WordLen { get;set; }
        public List<string> Tentativi { get { return _game.Tentativi; } } 
        public List<Lingo.status> Result { get; set; }
        public IndexModel(ILogger<IndexModel> logger,Lingo game) {
            _logger = logger;
            _game = game;
            WordLen = 7;
            Hint=game.Hint;
            //_game.NewWord();
            Result = new List<Lingo.status>(); 
        }

        public void OnGet() {
            _game.NewWord();
            Hint = _game.Hint;
        }

        public  void OnPost(string? word) {
            if (word != null) {
                _game.Tentativi.Add(word);
                Result = _game.TestWord(word.ToLower());
                Hint = _game.Hint;
                Win = Hint == word.ToUpper();
            }
        }
    }
}