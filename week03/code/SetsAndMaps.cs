using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        var pairs = new HashSet<string>();//The purpose of this set is to store the word.
        List<string> pairsArr = new List<string>(); //List of string, I choose to use this instead of static array because of unknown numbers of pairs to be discovered during the checking
        foreach (string word in words) //loop operation
        {

            //Reversing the word for checking 
            string reverseWord = new string(word.Reverse().ToArray());

            // if statement for checking the reversed word is in the set of pairs
            if (!pairs.Contains(reverseWord))
            {
                pairs.Add(word); //adding the word to the set if the word is not in the set
            }
            else // in this portion after checking if the words is in the set then it will be process and put it on the list of pairs
            {
                string statement = $"{reverseWord} & {word}"; //formatting string to be inputted in the list
                pairsArr.Add(statement);  // adding the statement to the list 
            }
        }

        return pairsArr.ToArray(); // returning the converted list into array of string.
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            var degreeId = fields[3];

            if (degrees.ContainsKey(degreeId))
            {
                degrees[degreeId]++;
            }
            else
            {
                degrees[degreeId] = 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
        bool result = true; //declaring a boolean type of variable
        word1 = word1.Replace(" ", "").ToLower(); //in this part we already process to clean the string 
        word2 = word2.Replace(" ", "").ToLower();
        var letter = new Dictionary<char, int>();

        if (word1.Length != word2.Length) //Using the first checking if the word1 and word2 is not the same lenght/size then automatic false.
        {
            return false;
        }

        foreach (var i in word1) // first loop for the word1 to check if it is inside the dictionary and increase the value
        {
            if (letter.TryGetValue(i, out int value)) // trying the TryGetValue function as suggested by the vscode. This is for checking if the dictionary contains the key and pull up the value together with the key.
            {
                letter[i] = ++value; //add 1 to the current value
            }
            else
            {
                letter[i] = 1; // it will put the new key together with the value.
            }
        }

        foreach (var j in word2) // second loop for the word2 to check if it is inside the dictionary and decrease the value
        {
            if (letter.TryGetValue(j, out int value)) //This is for checking if the dictionary contains the key and pull up the value together with the key.
            {
                letter[j] = --value;// decrease the current value value by 1
            }
            else
            {
                return false; //This will automatic return false if the key is not in the dictionary
            }

            if (letter[j] == 0) //checking if the value of the key is equal to 0. If thats the case then it will remove the element from the dictionary. Meaning the two words already match and is anagram
            {
                letter.Remove(j);
            }
        }

        if (letter.Count == 0)//checking if the size of the dictionary is empty. Then the return will be true.
        {
            result = true;
        }

        return result;
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        // TODO Problem 5:
        List<string> earthquakeSummaries = new List<string>(); // A list to store the string formatted output 

        foreach (var feature in featureCollection.Features) // Loop through the Json
        {
            var mag = feature.Properties.Mag; // retrieve the magnitude attribute
            var place = feature.Properties.Place; // retrieve the place attribute
            var time = feature.Properties.Time; // retrieve the time attribute for checking date and time

            DateTimeOffset dtf = DateTimeOffset.FromUnixTimeMilliseconds(time).DateTime; //converting milliseconds to Date and Time

            if (dtf.Date == DateTime.Today) // to check if the date in the json file is the same with the current date 
            {
                earthquakeSummaries.Add($"{place} - Mag {mag}"); //if true then add element to the list
            }

        }
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        return earthquakeSummaries.ToArray(); // return list converted into array
    }
}