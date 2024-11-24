using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

class Program
{
    static void Main(string[] args)
    {
        // Initialize scripture and reference
        Reference scriptureReference = new Reference("Proverbs", 3, 5, 6);
        Scripture scripture = new Scripture(scriptureReference, "Trust in the Lord with all your heart and lean not on your own understanding; in all your ways submit to him, and he will make your paths straight.");
        
        Console.Clear();
        Console.WriteLine("Scripture Memorization Program\n");
        
        while (!scripture.IsFullyHidden())
        {
            scripture.Display();
            Console.WriteLine("\nPress Enter to hide words or type 'quit' to exit:");
            string input = Console.ReadLine();
            
            if (input.Trim().ToLower() == "quit")
            {
                Console.WriteLine("Goodbye!");
                break;
            }
            
            scripture.HideRandomWords();
            Console.Clear();
        }

        if (scripture.IsFullyHidden())
        {
            Console.WriteLine("Scripture fully hidden! Well done!");
            scripture.Display();
        }
    }
}

// Represents the scripture reference
class Reference
{
    public string Book { get; private set; }
    public int Chapter { get; private set; }
    public int StartVerse { get; private set; }
    public int? EndVerse { get; private set; }

    public Reference(string book, int chapter, int startVerse, int? endVerse = null)
    {
        Book = book;
        Chapter = chapter;
        StartVerse = startVerse;
        EndVerse = endVerse;
    }

    public override string ToString()
    {
        return EndVerse.HasValue 
            ? $"{Book} {Chapter}:{StartVerse}-{EndVerse}" 
            : $"{Book} {Chapter}:{StartVerse}";
    }
}

// Represents an individual word in the scripture
class Word
{
    private string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public bool IsHidden => _isHidden;

    public void Hide()
    {
        _isHidden = true;
    }

    public override string ToString()
    {
        return _isHidden ? new string('_', _text.Length) : _text;
    }
}

// Represents the scripture, including the reference and text
class Scripture
{
    private Reference _reference;
    private List<Word> _words;

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text
            .Split(' ')
            .Select(word => new Word(Regex.Replace(word, @"[^\w]", ""))) // Remove punctuation
            .ToList();
    }

    public void Display()
    {
        Console.WriteLine(_reference);
        Console.WriteLine(string.Join(" ", _words));
    }

    public void HideRandomWords()
    {
        Random random = new Random();
        int wordsToHide = 3; // Number of words to hide at a time
        var visibleWords = _words.Where(w => !w.IsHidden).ToList();

        for (int i = 0; i < wordsToHide && visibleWords.Count > 0; i++)
        {
            int index = random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    public bool IsFullyHidden()
    {
        return _words.All(w => w.IsHidden);
    }
}
