using qvabbytesD1;
using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCP.Services
{
    public class WordleService
    {
        ConsoleOutputVisualizer visualizer = new ConsoleOutputVisualizer();
        public List<string> words = new List<string>() {
            "angle", "angry", "apart", "apple", "apply", "argue", "arise", "array", "aside", "asset", "audio", "audit", 
            "avoid", "award", "aware", "badly", "baker", "bases", "basic", "basis", "beach", "began", "begin", "being", "below", 
            "bench", "billy", "birth", "black", "blame", "blind", "block", "blood", "board", "boost", "booth", "bound", "brain", 
            "brand", "bread", "break", "breed", "brief", "bring", "broad", "broke", "brown", "build", "built", "buyer", "cable", 
            "carry", "catch", "cause", "chain", "chair", "chart", "chase", "cheap", "check", "chest", "chief", "child", "china", "chose", 
            "civil", "claim", "class", "clean", "clear", "click", "clock", "close", "coach", "coast", "could", "count", "court", "cover", 
            "craft", "crash", "cream", "crime", "cross", "crowd", "crown", "curve", "cycle", "daily", "dance", "dated", "dealt", "death", 
            "debut", "delay", "depth", "doing", "doubt", "dozen", "draft", "drama", "drawn", "dream", "dress", "drill", "drink", "drive", 
            "drove", "dying", "eager", "early", "earth", "eight", "elite", "empty", "enemy", "enjoy", "enter", "entry", "equal", "error", 
            "event", "every", "exact", "exist", "extra", "faith", "false", "fault", "fibre", "field", "fifth", "fifty", "fight", "final", 
            "first", "fixed", "flash", "fleet", "floor", "fluid", "focus", "force", "forth", "forty", "forum", "found", "frame", "frank", 
            "fraud", "fresh", "front", "fruit", "fully", "funny", "giant", "given", "glass", "globe", "going", "grace", "grade", "grand", 
            "grant", "grass", "great", "green", "gross", "group", "grown", "guard", "guest", "guide", "guess", "happy", "harry", "heart", 
            "heavy", "hence", "horse", "hotel", "house", "human", "ideal", "image", "index", "inner", "input", "issue", "joint", "judge", 
            "juice", "known", "label", "large", "laser", "later", "laugh", "layer", "learn", "lease", "least", "leave", "legal", "level", 
            "light", "limit", "local", "logic", "loose", "lower", "lucky", "lunch", "lying", "magic", "major", "maker", "march", "match", "mayor", 
            "meant", "media", "metal", "might", "minor", "minus", "mixed", "model", "money", "month", "moral", "motor", "mount", "mouse", "mouth",
            "movie", "music", "needs", "never", "newly", "night", "noise", "north", "noted", "novel", "nurse", "occur", "ocean", "offer", "often",
            "order", "other", "ought", "paint", "panel", "paper", "party", "peace", "phase", "phone", "photo", "piece", "pilot", "pitch", "place",
            "plain", "plane", "plant", "plate", "point", "pound", "power", "press", "price", "pride", "prime", "print", "prior", "prize", "proof", 
            "proud", "prove", "queen", "quick", "quiet", "quite", "radio", "raise", "range", "rapid", "ratio", "reach", "ready", "refer", "right", 
            "rival", "river", "roman", "rough", "round", "route", "royal", "rural", "scale", "scene", "scope", "score", "sense", "serve", "seven", 
            "shall", "shape", "share", "sharp", "sheet", "shelf", "shell", "shift", "shirt", "shock", "shoot", "short", "shown", "sight", "since",
            "sixty", "sized", "skill", "sleep", "slide", "small", "smart", "smile", "smith", "smoke", "solid", "solve", "sorry", "sound", "south",
            "space", "spare", "speak", "speed", "spend", "spent", "split", "spoke", "sport", "staff", "stage", "stake", "stand", "start", "state",
            "steam", "steel", "stick", "still", "stock", "stone", "stood", "store", "storm", "story", "strip", "stuck", "study", "stuff", "style",
            "sugar", "suite", "super", "sweet", "table", "taken", "taste", "taxes", "teach", "teeth", "texas", "thank", "their", "theme", "there", 
            "these", "thick", "thing", "think", "third", "those", "three", "threw", "throw", "tight", "times", "tired", "title", "today", "topic",
            "total", "touch", "tough", "tower", "track", "trade", "train", "treat", "trend", "trial", "tried", "tries", "truck", "truly", "trust",
            "truth", "twice", "under", "undue", "union", "unity", "until", "upper", "upset", "urban", "usage", "usual", "valid", "value", "video",
            "waste", "watch", "water", "wheel", "where", "which", "whole", "whose", "woman", "world", "worry", "wound", "write", "wrong", "wrote",
            "yield", "young", "aback", "abase", "abash", "abate", "abbey", "abbot", "abhor", "abide", "abled", "abode"
        };
        Random random = new Random();
        int guess_count = 0;
        public void PlayWordle()
        {
            string guess_word = words[random.Next(0, words.Count)];
            visualizer.BreakLine();
            visualizer.Qprint("Welcome to Wordle.\n", "Green", "White");
            visualizer.Qprint("You have 5 Guesses.\n", "Red");
            visualizer.Qprint("press Y to start game. N to quit.", "Yellow");
            visualizer.BreakLine(1);
            try
            {
                string c = Console.ReadLine();
                if (c.ToUpper() == "Y")
                {
                    visualizer.Qprint("Game started. Guess a 5-letter word.", "White");
                    mainEngine(guess_word);
                }
                if(c.ToUpper() == "N")
                {
                    visualizer.Qprint("Goodbye!", "Green");
                }
                else {
                    visualizer.Qprint("that's not Y.", "Red");
                    PlayWordle();
                }
            }
            catch (Exception e)
            {
                visualizer.Qdanger(e.Message);
            }
        }
        private void mainEngine(string guessword)
        {
            string guess = Console.ReadLine();
            if(guess.Count() != 5)
            {
                visualizer.Qprint("That's not a 5 letter word.", "Red");
                mainEngine(guessword);
            }
            if(guess_count == 4)
            {
                visualizer.Qprint("You lost. The word was " + guessword + ".", "Red");
                guess_count = 0;
                PlayWordle();
            }
            else
            {
                guess_count++;
                if (guess == guessword)
                {
                    visualizer.Qprint("You won in " + guess_count + " guesses.", "Green");
                    guess_count = 0;
                    PlayWordle();
                }

                for (int i = 0; i < guess.Count(); i++)
                {
                    if (guessword[i].ToString().ToLower() == guess[i].ToString().ToLower())
                    {
                        visualizer.Qprint($"{guess[i]} is in the right place.", "Green");
                        continue;
                    }
                    if (guessword.Contains(guess[i].ToString().ToLower()))
                    {
                        visualizer.Qprint($"{guess[i]} is in the word.", "Yellow");
                        continue;
                    }
                }
            }
            mainEngine(guessword);
        }
    }
}
