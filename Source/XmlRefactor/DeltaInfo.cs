using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Reflection;

namespace XmlRefactor
{
    public class DeltaInfo
    {
        public int StartPos;
        public int EndPosAfter;
        public int EndPosBefore;

        public static DeltaInfo Construct(string before, string after)
        {
            if (before == after)
                return null;
                        
            char[] beforeArray = before.ToCharArray();
            char[] afterArray = after.ToCharArray();
          

            int startPos = beforeArray.TakeWhile((x, i) => x == afterArray[i]).Count();
            int endPosBefore = beforeArray.TakeWhile((x, i) => i <= startPos || x != '\n').Count();
            int endPosAfter  =  afterArray.TakeWhile((x, i) => i <= startPos || x != '\n').Count();

            DeltaInfo deltaInfo = new DeltaInfo();
            deltaInfo.StartPos = startPos;
            deltaInfo.EndPosAfter = endPosAfter;
            deltaInfo.EndPosBefore = endPosBefore;

            return deltaInfo;
        }
    }
}