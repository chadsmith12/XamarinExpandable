﻿namespace ExpandableTest.Models
{
    public class Item
    {
        public int ItemId { get; set; }
        public string ItemTitle { get; set; }

        public Category Category { get; set; }
    }
}
