using UnityEngine;
using System.Collections;
using System.Linq;

namespace CmdSys{
	public interface Command
	{
		void DO();
		void UNDO();
		void HELP();
		void LOG();
	}
}