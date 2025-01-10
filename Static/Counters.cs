namespace RetailCorrector.API.Static
{
    public static class Counters
    {
        public static int SuccessCount { get; set; }
        public static int TotalCount { get; set; }

        public static void Reset() => SuccessCount = TotalCount = 0;
    }
}
