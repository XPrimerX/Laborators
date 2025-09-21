using Laboratorka_1.Task_1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorka_1.Task_4
{
    public class Job_4
    {
        public async Task CreateDictionary(string name, string fromLang, string toLang)
        {
            var dictionaries = await Job_1.Deserilezid_by_json<Speak>("Dictionaries.json");

            if (dictionaries.Exists(d => d.Name == name))
            {
                Console.WriteLine("Словник з такою назвою вже існує!");
                return;
            }

            dictionaries.Add(new Speak
            {
                Name = name,
                LanguageFrom = fromLang,
                LanguageTo = toLang
            });

            await Job_1.Serilezid_by_json(dictionaries, "Dictionaries.json");
            Console.WriteLine($"Словник {name} ({fromLang} → {toLang}) створено!");
        }

        public async Task<Speak?> LoadDictionary(string name)
        {
            var dictionaries = await Job_1.Deserilezid_by_json<Speak>("Dictionaries.json");
            return dictionaries.Find(d => d.Name == name);
        }

        public async Task UpdateDictionary(Speak dict)
        {
            var dictionaries = await Job_1.Deserilezid_by_json<Speak>("Dictionaries.json");
            int index = dictionaries.FindIndex(d => d.Name == dict.Name);
            if (index != -1)
            {
                dictionaries[index] = dict;
                await Job_1.Serilezid_by_json(dictionaries, "Dictionaries.json");
            }
        }

        public async Task AddWord(Speak dict, string word, string translation)
        {
            if (!dict.Words.ContainsKey(word))
                dict.Words[word] = new List<string>();
            dict.Words[word].Add(translation);
            await UpdateDictionary(dict);
        }

        public async Task ReplaceWord(Speak dict, string oldWord, string newWord)
        {
            if (dict.Words.ContainsKey(oldWord))
            {
                var translations = dict.Words[oldWord];
                dict.Words.Remove(oldWord);
                dict.Words[newWord] = translations;
                await UpdateDictionary(dict);
            }
        }

        public async Task ReplaceTranslation(Speak dict, string word, string oldTranslation, string newTranslation)
        {
            if (dict.Words.ContainsKey(word) && dict.Words[word].Contains(oldTranslation))
            {
                int index = dict.Words[word].IndexOf(oldTranslation);
                dict.Words[word][index] = newTranslation;
                await UpdateDictionary(dict);
            }
        }

        public async Task DeleteWord(Speak dict, string word)
        {
            if (dict.Words.Remove(word))
                await UpdateDictionary(dict);
        }

        public async Task DeleteTranslation(Speak dict, string word, string translation)
        {
            if (dict.Words.ContainsKey(word))
            {
                if (dict.Words[word].Count > 1)
                {
                    dict.Words[word].Remove(translation);
                    await UpdateDictionary(dict);
                }
                else
                {
                    Console.WriteLine("Не можна видалити останній переклад слова!");
                }
            }
        }

        public Task SearchWordAsync(Speak dict, string word)
        {
            if (dict.Words.ContainsKey(word))
                Console.WriteLine($"{word} → {string.Join(", ", dict.Words[word])}");
            else
                Console.WriteLine("Слова не знайдено.");

            return Task.CompletedTask;
        }

        public async Task ExportWordAsync(Speak dict, string word)
        {
            if (dict.Words.ContainsKey(word))
            {
                string result = $"{word} → {string.Join(", ", dict.Words[word])}";
                await File.WriteAllTextAsync(word + "_export.txt", result);
                Console.WriteLine($"Експортовано у файл {word}_export.txt");
            }
        }
    }
}
