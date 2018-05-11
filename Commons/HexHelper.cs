namespace Commons
{
    public static class HexHelper
    {
        private static readonly char[] _chars = { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'A', 'B', 'C', 'D', 'E', 'F' };

        public static string ToHexString( byte[] data )
        {
            char[] chars = new char[data.Length * 2];

            for (int i = 0; i < data.Length; i++)
            {
                int x = data[i];
                chars[i * 2] = _chars[x >> 4];
                chars[i * 2 + 1] = _chars[x & 0xF];
            }
            return new string(chars);
        }
    }
}
