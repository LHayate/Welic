using System;

namespace UseFul.Uteis
{
    public class ProgressUpdatedEventArgs : EventArgs
    {
        public ProgressUpdatedEventArgs(int pbNum, int total, int progress, string message = "")
        {
            PbNum = pbNum;
            Total = total;
            Processed = progress;
            Message = message;
        }

        public string Message { get; private set; }
        public int PbNum { get; private set; }
        public int Processed { get; private set; }
        public int Total { get; private set; }
    }
}