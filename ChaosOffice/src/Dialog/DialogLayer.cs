using System.Collections.Generic;

namespace ChaosOffice
{
    public class DialogLayer
    {
        public string Opening;
        public DialogOption[] DialogOptions;

        public List<DialogOption> GetAvailableDialogOptions()
        {
            List<DialogOption> result = new List<DialogOption>();
            foreach (DialogOption dialogOption in DialogOptions)
            {
                if (dialogOption.IsSelectable())
                {
                    result.Add(dialogOption);
                }
            }
            return result;
        }
    }
}