﻿namespace WineSales.Config
{
    public class WineConfig
    {
        public static List<string> Colors = new List<string>()
                                            {"red", "white", "rose"};
        public static List<string> Sugar = new List<string>()
                                           {"dry", "semi-dry", "semi-sweet", "sweet"};

        public const double MinVolume = 0.1875;
        public const double MaxVolume = 30;

        public const double MinAlcohol = 7.5;
        public const double MaxAlcohol = 22;

        public const int MinNumber = 1;

        public const double MinPurchasePrice = 118;
        public const int MinPercent = 43;
    }
}
