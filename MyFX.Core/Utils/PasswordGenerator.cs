using System;
using System.Security.Cryptography;
using System.Text;
using MyFX.Core.Base;

namespace MyFX.Core.Utils
{
    /// <summary>
    /// 提供密码生成功能。
    /// </summary>
    /// <remarks>
    /// Thanks for Kevin Stewart, see details at http://www.codeproject.com/Articles/2393/A-C-Password-Generator .
    /// </remarks>
    public class PasswordGenerator
    {
        private const int DefaultMinimum = 8;
        private const int DefaultMaximum = 16;
        private const int UBoundDigit = 61;

        private RNGCryptoServiceProvider rng;
        private int _minSize;
        private int _maxSize;
        private bool _hasRepeating;
        private bool _hasConsecutive;
        private bool _hasSymbols;
        private string _exclusionSet;
        private readonly char[] _pwdCharArray = ("abcdefghijklmnopqrstuvwxyzABCDEFG" +
            "HIJKLMNOPQRSTUVWXYZ0123456789`~!@#$%^&*()-_=+[]{}\\|;:'\",<" +
            ".>/?").ToCharArray();

        /// <summary>
        /// 构造函数
        /// </summary>
        public PasswordGenerator()
        {
            this.MinLength = DefaultMinimum;
            this.MaxLength = DefaultMaximum;
            this.AllowsConsecutiveCharacters = false;
            this.AllowsRepeatCharacters = true;
            this.ExcludesSymbols = false;
            this.Exclusions = "oO01l<>`^'\"";
            this.SymbolPosition = PasswordSymbolsPosition.Inserted;
            this.SymbolCount = 1;

            rng = new RNGCryptoServiceProvider();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="lBound"></param>
        /// <param name="uBound"></param>
        /// <returns></returns>
        protected int GetCryptographicRandomNumber(int lBound, int uBound)
        {
            // Assumes lBound >= 0 && lBound < uBound
            // returns an int >= lBound and < uBound
            uint urndnum;
            byte[] rndnum = new Byte[4];
            if (lBound == uBound)
            {
                // test for degenerate case where only lBound can be returned
                return lBound;
            }

            uint xcludeRndBase = (uint.MaxValue -
                (uint.MaxValue % (uint)(uBound - lBound)));

            do
            {
                rng.GetBytes(rndnum);
                urndnum = System.BitConverter.ToUInt32(rndnum, 0);
            } while (urndnum >= xcludeRndBase);

            return (int)(urndnum % (uBound - lBound)) + lBound;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected char GetRandomCharacter()
        {
            int upperBound = _pwdCharArray.GetUpperBound(0);

            if (true == this.ExcludesSymbols)
            {
                upperBound = PasswordGenerator.UBoundDigit;
            }

            int randomCharPosition = GetCryptographicRandomNumber(
                _pwdCharArray.GetLowerBound(0), upperBound);

            char randomChar = _pwdCharArray[randomCharPosition];

            return randomChar;
        }

        protected bool IsSymbol(char c)
        {
            return Array.IndexOf(_pwdCharArray, c, UBoundDigit + 1) > 0;
        }

        /// <summary>
        /// 生成随机密码
        /// </summary>
        /// <returns></returns>
        public string Generate()
        {
            string password = GenerateCore();
            return password;
        }

        /// <summary>
        /// 生成密码核心
        /// </summary>
        /// <returns></returns>
        private string GenerateCore()
        {
            if (!(MinLength > 0 && MaxLength > 0 && MinLength <= MaxLength))
            {
                throw new ArgumentOutOfRangeException("指定的密码长度应该大于0，且最小长度应该小于等于最大长度，实际值：{0} {1}".FormatString(MinLength, MaxLength));
            }

            // Pick random length between minimum and maximum   
            int pwdLength = GetCryptographicRandomNumber(this.MinLength,
                this.MaxLength);
            int symbolCount = 0;

            StringBuilder pwdBuffer = new StringBuilder();
            pwdBuffer.Capacity = this.MaxLength;

            // Generate random characters
            char lastCharacter, nextCharacter;

            // Initial dummy character flag
            lastCharacter = nextCharacter = '\n';

            for (int i = 0; i < pwdLength; i++)
            {
                nextCharacter = GetRandomCharacter();

                if (false == this.AllowsConsecutiveCharacters)
                {
                    while (lastCharacter == nextCharacter)
                    {
                        nextCharacter = GetRandomCharacter();
                    }
                }

                if (false == this.AllowsRepeatCharacters)
                {
                    string temp = pwdBuffer.ToString();
                    int duplicateIndex = temp.IndexOf(nextCharacter);
                    while (-1 != duplicateIndex)
                    {
                        nextCharacter = GetRandomCharacter();
                        duplicateIndex = temp.IndexOf(nextCharacter);
                    }
                }

                if ((null != this.Exclusions))
                {
                    while (-1 != this.Exclusions.IndexOf(nextCharacter))
                    {
                        nextCharacter = GetRandomCharacter();
                    }
                }

                if ((SymbolPosition | PasswordSymbolsPosition.Any) != 0)
                {
                    if (i == 0 &&
                        (((SymbolPosition | PasswordSymbolsPosition.Start) == 0)
                            || ((SymbolPosition | PasswordSymbolsPosition.Inserted) != 0)))
                    {
                        while (IsSymbol(nextCharacter))
                        {
                            nextCharacter = GetRandomCharacter();
                        }
                    }

                    if (i == pwdLength - 1 &&
                         (((SymbolPosition | PasswordSymbolsPosition.End) == 0)
                            || ((SymbolPosition | PasswordSymbolsPosition.Inserted) != 0)))
                    {
                        while (IsSymbol(nextCharacter))
                        {
                            nextCharacter = GetRandomCharacter();
                        }
                    }
                }

                if (IsSymbol(nextCharacter))
                {
                    if (SymbolCount != 0 && symbolCount + 1 > SymbolCount)
                    {
                        while (IsSymbol(nextCharacter))
                        {
                            nextCharacter = GetRandomCharacter();
                        }
                    }
                    else
                    {
                        symbolCount++;
                    }
                }

                pwdBuffer.Append(nextCharacter);
                lastCharacter = nextCharacter;
            }

            if (null != pwdBuffer)
            {
                return pwdBuffer.ToString();
            }
            else
            {
                return String.Empty;
            }
        }

        /// <summary>
        /// 获取或设置最小长度
        /// </summary>
        public int MinLength
        {
            get { return this._minSize; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("MinLength must be greater than zero.");
                }
                this._minSize = value;
            }
        }

        /// <summary>
        /// 获取或设置最大长度
        /// </summary>
        public int MaxLength
        {
            get { return this._maxSize; }
            set
            {
                if (value < 1)
                {
                    throw new ArgumentOutOfRangeException("MaxLength must be greater than zero.");
                }
                this._maxSize = value;
            }
        }

        /// <summary>
        /// 获取或设置是否排除标点符号。
        /// </summary>
        public bool ExcludesSymbols
        {
            get { return this._hasSymbols; }
            set { this._hasSymbols = value; }
        }

        /// <summary>
        /// 获取或设置被排除的字符集。
        /// </summary>
        public string Exclusions
        {
            get { return this._exclusionSet; }
            set { this._exclusionSet = value; }
        }

        /// <summary>
        /// 获取或设置是否允许出现重复字符
        /// </summary>
        public bool AllowsRepeatCharacters
        {
            get { return this._hasRepeating; }
            set { this._hasRepeating = value; }
        }

        /// <summary>
        /// 获取或设置是否允许出现连续字符
        /// </summary>
        public bool AllowsConsecutiveCharacters
        {
            get { return this._hasConsecutive; }
            set { this._hasConsecutive = value; }
        }

        /// <summary>
        /// 获取或设置是否排除标点符号位置。
        /// </summary>
        public PasswordSymbolsPosition SymbolPosition { get; set; }

        /// <summary>
        /// 获取或设置是否排除标点符号个数。
        /// </summary>
        public int SymbolCount { get; set; }

    }

    [Flags]
    public enum PasswordSymbolsPosition
    {
        Start = 1,
        End = 2,
        Inserted = 4,
        Any = Start | Inserted | End
    }
}
