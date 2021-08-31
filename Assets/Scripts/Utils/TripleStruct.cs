using UnityEngine;

namespace Utils
{
    public struct TripleStruct
    {
        public readonly string A;
        public readonly string B;
        public readonly string C;

        public TripleStruct(string a, string b, string c)
        {
            A = a;
            B = b;
            C = c;
        }

        public override int GetHashCode()
        {
            var hash = A.GetHashCode() + B.GetHashCode();
            return hash;
        }
    }
}
