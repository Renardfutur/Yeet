using System;
using System.Collections.Generic;
using System.Text;

namespace YeetClass
{
    public class Recipe
    {
        private String name { get; set; }
        private String description { get; set; }
        private String imagePath { get; set; }
        private int duration { get; set; }
        private int score_positive { get; set; }
        private int score_negative { get; set; }
        private List<String> ingredients = new List<String>();
        private List<String> instructions = new List<String>();
        private List<Recipe> list_comp = new List<Recipe>();
        private int rad;

        public Recipe(string name, string description, string imagePath, int duration, int score_p, int score_n, List<string> ingredients, List<string> instructions)
        {
            this.description = description;
            this.imagePath = imagePath;
            this.duration = duration;
            this.score_positive = score_p;
            this.score_negative = score_n;
            this.ingredients = ingredients;
            this.instructions = instructions;
            this.list_comp = list_comp;
        }

        public String toString()
        {
            return this.name +
                " " + this.description +
                " " + this.imagePath +
                " " + this.duration +
                " " + this.score_positive +
                " " + this.score_negative;
        }
        public String getImage()
        {
            return this.imagePath;
        }
        public List<Recipe> getList()
        {
            return this.list_comp;
        }
    }
}
