using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB01Práctico_JorgeGarcía_1220019
{
    public enum TokenType
    {
        Plus = '+',
        Star = '*',
        Division = '/',
        Minus = '-',
        LParen = '(',
        RParen = ')',
        EOF = (char)0,
        Empty = (char)1,
        Null = (char)2,
        Symbol = (char)3
    }
}
