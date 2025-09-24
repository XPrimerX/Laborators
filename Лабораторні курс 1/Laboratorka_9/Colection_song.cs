using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Laboratorka_9
{
    internal class Colection_song
    {
        private List<Add_music> songs = new List<Add_music>();
        public void Add(Add_music music)
        {
            songs.Add(music);
        }
        public void Remove(Add_music music)
        {
            songs.Remove(music);
        }
        public void EditSong(int index, Add_music newSong)
        {
            if (index >= 0 && index < songs.Count)
                songs[index] = newSong;
        }

        public List<Add_music> Find_By_Name(string name)
        {
            return songs.Where(s => s.Name_music.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public List<Add_music> Find_BY_Avtor(string avtor) 
        {
            return songs.Where(s => s.Name_songer.Contains(avtor, StringComparison.OrdinalIgnoreCase)).ToList();       
        }
        public List<Add_music> Find_By_Year(int year) 
        {
            return songs.Where(s => s.Year == year).ToList();
        }
        public List<Add_music> Find_By_Text(string text)
        {
            return songs.Where(s => s.Text.Contains(text, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public List<Add_music> Find_BY_Compositor(string compositor)
        {
            return songs.Where(s => s.Komposito.Contains(compositor, StringComparison.OrdinalIgnoreCase)).ToList();
        }
        public void Save_all_song()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var song in songs)
            {
                sb.AppendLine(song.ToString());
            }
            Manager_for_file.Save_file(sb.ToString());
        }
        public void Read_file(string path)
        {
            using (StreamReader sr = File.OpenText(path))
            {
                string? line;
                while ((line = sr.ReadLine()) != null)
                {
                    var parts = line.Split('|');
                    if (parts.Length >= 6)
                    {
                        var song = new Add_music
                        {
                            Name_music = parts[0],
                            Name_songer = parts[1],
                            Komposito = parts[2],
                            Year = int.Parse(parts[3]),
                            Text = parts[4]
                        };
                        song.Mnogo_kompositorov.AddRange(parts[5].Split(','));
                        songs.Add(song);
                    }
                }
            }
        }
                        
        public List<Add_music> Find_song(string mnogo_kompositor)
        {
            return songs.Where(s => s.Mnogo_kompositorov.Contains(mnogo_kompositor)).ToList();
        }
        
    }
}