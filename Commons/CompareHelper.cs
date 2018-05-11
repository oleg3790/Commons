using System;
using System.Linq;

namespace Commons
{
    public static class CompareHelper
    {
        public static bool ContainsType( this Type obj, params Type[] args)
        {
            return args.Contains(obj);
        }
    }
}
