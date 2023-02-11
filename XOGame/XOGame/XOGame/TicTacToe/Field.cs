using System;
namespace XOGame
{
	public class Field
	{
        private Sign _sign;
        public Sign Sign
		{
			get { return _sign; }
			set { _sign = value; }
		}

        public Field()
		{

		}

		public bool IsEmpty()
		{
			return _sign == Sign.None;
		}

		override public string ToString() => _sign == Sign.None ? "" : _sign.ToString();
    }
}

