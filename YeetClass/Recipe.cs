using System;
using System.Collections.Generic;
using System.Text;

namespace YeetClass
{
    public class Recipe
    {
        private String name;
        private String description;
        private String imagePath;
        private int duration;
        private int score;
        private List<String> ingredients = new List<String>();
        private List<String> instructions = new List<String>();

        public Recipe(string name, string description, string imagePath, int duration, int score, List<string> ingredients, List<string> instructions)
        {
            this.description = description;
            this.imagePath = imagePath;
            this.duration = duration;
            this.score = score;
            this.ingredients = ingredients;
            this.instructions = instructions;
        }
    }
}
