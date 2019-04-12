This is text I missed on intial on configuration:


Configure your client application
CONNECT AN EXISTING APP

If using Xamarin Studio, right-click your project, select 'Add' and then 'Add NuGet Packages.' Search for the Microsoft.Azure.Mobile.Client package, and then click 'Add Package.'
If using Visual Studio, right-click your project and select 'Manage NuGet Packages' search for the Microsoft.Azure.Mobile.Client package, and click 'Install.'
In your main Activity file, add a 'using Microsoft.WindowsAzure.MobileServices;' statement. Then copy and paste in the following code:

public static MobileServiceClient MobileService =
    new MobileServiceClient(
    "https://contact-beta.azurewebsites.net"
);

Add a sample TodoItem class to your project:

public class TodoItem
{
    public string Id { get; set; }
    public string Text { get; set; }
}


Finally, use the client library to start working with the TodoItem table in your server project. In your project, find a place where this interaction would make sense and add the following:

CurrentPlatform.Init();
TodoItem item = new TodoItem { Text = "Awesome item" };
await MobileService.GetTable<TodoItem>().InsertAsync(item);

Run the Xamarin project to start working with data in your mobile backend.

