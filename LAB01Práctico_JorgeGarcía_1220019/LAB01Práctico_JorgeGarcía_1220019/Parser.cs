using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAB01Práctico_JorgeGarcía_1220019
{
    public class Parser
    {
        Token ttoken;
        float tnum;
        string tstring;
        Scanner _scanner;
        Token _token;

        private float S()
        {
            return A();
        }

        private float A()
        {
            switch (_token.Tag)
            {
                case TokenType.Minus:
                case TokenType.LParen:
                case TokenType.Symbol:
                    return B() + AP();
                    
                default:
                    return 0;
                  
            }
        }


        private float AP()
        {
            switch (_token.Tag)
            {
                case TokenType.Plus:
                    Match(_token.Tag);
                    return B() + AP();
                        break;
                case TokenType.Minus:
                    Match(_token.Tag);
                    return -B() + AP();
                    break;
                case TokenType.Empty:
                default:
                    return 0;
                    break;
            }
        }

        private float B()
        {
            switch (_token.Tag)
            {
                case TokenType.Minus:
                case TokenType.LParen:
                case TokenType.Symbol:
                    return C() * BP();
                    break;
                default:
                    return 0;
                    break;
            }
        }

        private float BP()
        {
            switch (_token.Tag)
            {
                case TokenType.Star:
                    Match(_token.Tag);
                    return C() * BP();
                    break;
                case TokenType.Division:
                    Match(_token.Tag);
                    return 1 / (C() * BP());
                    break;
                default:
                    return 1;
                    break;
            }
        }

        private float C()
        {
            switch (_token.Tag)
            {
                case TokenType.Minus:
                    Match(_token.Tag);
                    return -C();
                case TokenType.LParen:
                case TokenType.Symbol:
                    return D();
                    break;
                default:
                    return 1;
                    break;
            }
        }

        private float D()
        {
            switch (_token.Tag)
            {
                case TokenType.LParen:
                    Match(_token.Tag);
                    tnum = A();
                    Match(_token.Tag);
                    return tnum;
                    break;
                case TokenType.Symbol:
                    ttoken = _token;
                    Match(_token.Tag);
                    tstring = Convert.ToString(ttoken.Value) + Convert.ToString(DP());
                    return float.Parse(tstring);
                    break;
                default:
                    return 1;
                    break;
            }
        }

        private string DP()
        {
            switch (_token.Tag)
            {
                case TokenType.Symbol:
                    ttoken = _token;
                    Match(_token.Tag);
                    return Convert.ToString(ttoken.Value) + Convert.ToString(DP());
                    break;
                default:
                    return "";
                    break;
            }
        }
 
        private void Match(TokenType tag)
        {
            if (_token.Tag == tag)
            {
                _token = _scanner.GetToken();
            }
            else
            {
                throw new Exception("Error de Sintaxis");
            }
        }

        public float Parse(string regexp)
        {
            _scanner = new Scanner(regexp + (char)TokenType.EOF);
            _token = _scanner.GetToken();
            switch (_token.Tag)
            {
                case TokenType.LParen:
                case TokenType.Minus:
                case TokenType.Symbol:
                    return A();
                    break;
                default:
                   return 0;
                    break;
            }
            Match(TokenType.EOF);
        } // PARSE

    } //PARSER
}

