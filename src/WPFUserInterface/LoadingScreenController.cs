using System;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace WPFUserInterface
{
    public class LoadingScreenController
    {
        private readonly Frame mainFrame;
        private readonly PleaseWaitPage pleaseWaitPage = new PleaseWaitPage();

        public LoadingScreenController(Frame mainFrame)
        {
            this.mainFrame = mainFrame;
        }

        public async Task DoActionWhileLoadingScreenAsync(Action action)
        {
            mainFrame.Navigate(pleaseWaitPage);
            await Task.Run(() => action());
            mainFrame.GoBack();
        }
    }
}