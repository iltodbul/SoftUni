using System;
using System.Text.RegularExpressions;


namespace P02._Song_Encryption
{
    class Program
    {
        static void Main(string[] args)
        {
            var regex = new Regex(@"^(?<artist>[A-Z][a-z' ]+):(?<song>[A-Z ]+)$");

            string line = Console.ReadLine();
            while (line != "end")
            {
                var toEncrypt = regex.Match(line);
                if (toEncrypt.Success)
                {
                    string artist = toEncrypt.Groups["artist"].Value;
                    string artistAndSong = toEncrypt.Value;
                    int kye = artist.Length;
                    string newArtistAndSong = string.Empty;

                    for (int i = 0; i < artistAndSong.Length; i++)
                    {
                        char currentChar = artistAndSong[i];
                        if (currentChar != ' ' && currentChar != '\'')
                        {
                            int newChar = 0;
                            if (currentChar > 64 && currentChar < 91)//capital letter
                            {
                                if (currentChar + kye > 90)
                                {
                                    newChar = (currentChar + kye - 91) + 65;
                                    newChar = (char)newChar;
                                    newArtistAndSong += (char)newChar;
                                }
                                else
                                {
                                    newChar = currentChar + kye;
                                    newArtistAndSong += (char)newChar;
                                }
                            }
                            else if (currentChar > 96 && currentChar < 123)//small letter
                            {
                                if (currentChar + kye > 122)
                                {
                                    newChar = (currentChar + kye - 123) + 97;
                                    newChar = (char)newChar;
                                    newArtistAndSong += (char)newChar;
                                }
                                else
                                {
                                    newChar = currentChar + kye;
                                    newArtistAndSong += (char)newChar;
                                }
                            }
                            else if (currentChar == ':')
                            {
                                newChar = '@';
                                newArtistAndSong += (char)newChar;
                            }

                        }
                        else
                        {
                            newArtistAndSong += currentChar;
                        }

                    }

                    Console.WriteLine($"Successful encryption: {newArtistAndSong}");
                }
                else
                {
                    Console.WriteLine("Invalid input!");
                }

                line = Console.ReadLine();
            }
        }
    }
}
