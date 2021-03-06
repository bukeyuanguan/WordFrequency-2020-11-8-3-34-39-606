﻿using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace WordFrequency
{
    public class WordFrequencyGame
    {
        private int count = 1;
        public string GetResult(string sentence)
        {
            if (Regex.Split(sentence, @"\s+").Length == 1)
            {
                return sentence + " 1";
            }
            else
            {
                //split the input string with 1 to n pieces of spaces
                string[] wordArray = Regex.Split(sentence, @"\s+");

                List<Input> inputList = new List<Input>();
                foreach (var word in wordArray)
                {
                    Input input = new Input(word, this.count);
                    inputList.Add(input);
                }

                //get the map for the next step of sizing the same word
                Dictionary<string, List<Input>> map = GetListMap(inputList);

                List<Input> wordCountList = new List<Input>();
                foreach (var entry in map)
                {
                    Input input = new Input(entry.Key, entry.Value.Count);
                    wordCountList.Add(input);
                }

                inputList = wordCountList;

                inputList.Sort((w1, w2) => w2.WordCount - w1.WordCount);

                List<string> strList = new List<string>();

                //stringJoiner joiner = new stringJoiner("\n");
                foreach (Input word in inputList)
                {
                    string frequency = word.Value + " " + word.WordCount;
                    strList.Add(frequency);
                }

                return string.Join("\n", strList.ToArray());
            }
        }

        private Dictionary<string, List<Input>> GetListMap(List<Input> inputList)
        {
            Dictionary<string, List<Input>> map = new Dictionary<string, List<Input>>();
            foreach (var input in inputList)
            {
                //       map.computeIfAbsent(input.getValue(), k -> new ArrayList<>()).add(input);
                if (!map.ContainsKey(input.Value))
                {
                    List<Input> arr = new List<Input>();
                    arr.Add(input);
                    map.Add(input.Value, arr);
                }
                else
                {
                    map[input.Value].Add(input);
                }
            }

            return map;
        }
    }
}
