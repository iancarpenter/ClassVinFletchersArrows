﻿namespace ClassVinFletchersArrows
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Arrow arrow = GetArrow();
            
            Console.WriteLine($"That arrow costs {arrow.GetCost()} gold.");

            Arrow GetArrow()
            {
                ArrowHead arrowHead = GetArrowHeadType();
                Fletching fletching = GetFletchingType();
                float length = GetLength();

                return new Arrow(arrowHead, fletching, length); 
            }
            
            ArrowHead GetArrowHeadType()
            {
                Console.WriteLine("Arrowhead type (steel, wood, obsidian): ");
                string input = Console.ReadLine();
                return input switch
                {
                    "steel"    => ArrowHead.Steel,
                    "wood"     => ArrowHead.Wood,
                    "obsidian" => ArrowHead.Obsidian
                };
            }

            Fletching GetFletchingType()
            {
                Console.WriteLine("Fletching type (plastic, turkey, goose): ");
                string input = Console.ReadLine();
                return input switch
                {
                    "plastic" => Fletching.Plastic,
                    "turkey"  => Fletching.Turkey,
                    "goose"   => Fletching.Goose
                };
            }

            float GetLength()
            {
                float length = 0;

                while(length < 60 || length > 100)
                {
                    Console.WriteLine("Arrow length between 60 and 100");
                    length = Convert.ToSingle(Console.ReadLine());
                }
                return length;
            }            
        }

        public class Arrow
        {
            private float _length;
            private ArrowHead _arrowHead;
            private Fletching _fletching;

            public float GetLength() => _length;
            public ArrowHead GetArrowHead() => _arrowHead;

            public Fletching GetFletching() => _fletching;
            public Arrow(ArrowHead arrowHead, Fletching fletching, float length)
            {
                _arrowHead = arrowHead;
                _fletching = fletching;
                _length = length;
            }

            public float GetCost()
            {
                
                float arrowHeadCost = _arrowHead switch
                {
                    ArrowHead.Steel => 10,
                    ArrowHead.Wood => 3,
                    ArrowHead.Obsidian => 5,
                    _ => throw new NotImplementedException()
                };

                float fletchingCost = _fletching switch
                {
                    Fletching.Plastic => 10,
                    Fletching.Turkey => 5,
                    Fletching.Goose => 3,
                    _ => throw new NotImplementedException()
                };

                float shaftCost = _length * 0.05f;

                return (shaftCost + arrowHeadCost + fletchingCost);
            }            
        }
        public enum ArrowHead { Steel, Wood, Obsidian };
        public enum Fletching { Plastic, Turkey, Goose };
    }
}