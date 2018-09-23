using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x804 上介绍了“空白页”项模板

namespace SystemCloseButton
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
       
        ContentDialog ContentDialog = new ContentDialog();
        public MainPage()
        {
            this.InitializeComponent();
            Windows.UI.Core.Preview.SystemNavigationManagerPreview.GetForCurrentView().CloseRequested +=
       async (sender, args) =>
       {
           args.Handled = true;
           var dialog = new MessageDialog("当前设置尚未保存，你确认要退出该页面吗?", "消息提示");

           dialog.Commands.Add(new UICommand("确定", cmd => { }, commandId: 0));
           dialog.Commands.Add(new UICommand("取消", cmd => { }, commandId: 1));

           //设置默认按钮，不设置的话默认的确认按钮是第一个按钮
           dialog.DefaultCommandIndex = 0;
           dialog.CancelCommandIndex = 1;

           //获取返回值
           var result = await dialog.ShowAsync();
       if((int)result.Id==0)
           {
               App.Current.Exit();
        
           }
     
           
           //var result = await ContentDialog.ShowAsync();
           //if (result == ContentDialogResult.Primary)
           //{
           //     // Save work;
           // }
           //else
           //{
           //    App.Current.Exit();
           //}
       };

        }
    }
}
