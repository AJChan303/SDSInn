using System;
using System.Collections.Generic;

namespace SDSChallenge {
    class Program {
        static void Main(string[] args) {
            List<Item> Items = new List<Item> { };
            void InstItems() {

                Items.Add(new Item { Name = "+5 Dexterity Vest", SellIn = 10, Quality = 20 });
                Items.Add(new Item { Name = "Aged Brie", SellIn = 2, Quality = 0 });
                Items.Add(new Item { Name = "Elixir of the Mongoose", SellIn = 5, Quality = 7 });
                Items.Add(new Item { Name = "Sulfuras", SellIn = 0, Quality = 80 });
                Items.Add(new Item { Name = "Backstage passes", SellIn = 15, Quality = 20 });
                Items.Add(new Item { Name = "Conjured", SellIn = 3, Quality = 6 });

            }
            void QualityUpdate() {
                foreach (var item in Items) {
                    switch (item.Name) {
                        case "Aged Brie":
                                item.SellIn--;
                            if (item.SellIn >= 0 && item.Quality<50) {
                                item.Quality++;
                            }
                            if (item.SellIn < 0 && item.Quality < 50) {
                                item.Quality = item.Quality + 2;
                            }
                            break;
                       case "Sulfuras":
                            //stay beautiful
                            break;
                        case "Backstage passes":
                       
                            item.SellIn--;
                        
                            if (item.SellIn > 10 && item.Quality < 50) {
                            item.Quality++;
                            }   
                            if(item.SellIn <= 10 && item.SellIn >5 && item.Quality < 50) {
                            item.Quality = item.Quality + 2;
                            }
                            if(item.SellIn <= 5 && item.Quality < 50) {
                            item.Quality = item.Quality + 3;
                            }
                            if(item.SellIn == 0) {
                            item.Quality = 0;
                            }
                            break;
                        case "Conjured":
                            item.SellIn--;
                            if (item.Quality > 0) {
                            item.Quality = item.Quality - 2;
                            }
                            break;
                        default:
                            item.SellIn--;
                            if (item.Quality > 0) {
                            item.Quality--;
                            }
                            if(item.SellIn <= 0 && item.Quality >0) {
                            item.Quality--;
                        }
                             break;
                    }
                    
                }

            }
            void UpdateQuality() {
                for (var i = 0; i < Items.Count; i++) {
                    if (Items[i].Name != "Aged Brie" && Items[i].Name != "Backstage Passes") {
                        if (Items[i].Quality > 0) {
                            if (Items[i].Name != "Sulfuras") {
                                Items[i].Quality = Items[i].Quality - 1;
                                //Added this data validation to ensure Conjured Quality Is updating correctly
                                if (Items[i].Name == "Conjured") {
                                    if (Items[i].Quality > 0) {
                                        Items[i].Quality = Items[i].Quality - 1;
                                    }
                                }
                            }

                        }
                    }

                    else {
                        if (Items[i].Quality < 50) {
                            Items[i].Quality = Items[i].Quality + 1;
                            if (Items[i].Name == "Backstage Passes") {
                                if (Items[i].SellIn < 11) {
                                    if (Items[i].Quality < 50) {
                                        Items[i].Quality = Items[i].Quality + 1;
                                    }
                                }
                                if (Items[i].SellIn < 6) {
                                    if (Items[i].Quality < 50) {
                                        Items[i].Quality = Items[i].Quality + 1;
                                    }
                                }

                            }
                        }
                    }
                    if (Items[i].Name != "Sulfuras") {
                        Items[i].SellIn = Items[i].SellIn - 1;
                    }
                    if (Items[i].SellIn < 0) {
                        if (Items[i].Name != "Aged Brie") {
                            if (Items[i].Name != "Backstage passes") {
                                if (Items[i].Quality > 0) {
                                    if (Items[i].Name != "Sulfuras") {
                                        Items[i].Quality = Items[i].Quality - 1;
                                    }
                                }
                            }
                            else {
                                Items[i].Quality = Items[i].Quality - Items[i].Quality;
                            }
                        }
                        else {
                            if (Items[i].Quality < 50) {
                                Items[i].Quality = Items[i].Quality + 1;
                            }
                        }
                    }
                }

            }
            void Print() {
                foreach (var item in Items) {
                    Console.WriteLine($"Name= {item.Name} \n \t \t \t Item SellBy= {item.SellIn} \t Price= {item.Quality}");

                }
            }
           
            Console.WriteLine(" Did someone say");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[Thunderfury, Blessed Blade of the Windseeker] ?");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("I think I heard them mention");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("[Thunderfury, Blessed Blade of the Windseeker] ?");


            while (true) {
                InstItems();
                Console.ForegroundColor = ConsoleColor.Cyan;
                var m = Convert.ToInt32(Console.ReadLine());
                Print();
                for (int i = 0; i < m; i++) {
                   QualityUpdate();

                }

                Console.ForegroundColor = ConsoleColor.White;
                Print();
                Items.Clear();

            }
        }
    }
}

class Item {
    public string Name { get; set; }
    public int SellIn { get; set; }
    public int Quality { get; set; }
}