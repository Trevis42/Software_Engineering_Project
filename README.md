This is the backend for the contact beta app (C# / .net / ASP).
Microsoft makes it difficult, or expensive, to use anything other than ms sql server or cosmos. Unfortunately, consmos is relatively new and not very well documented. If the php solution does not work we will use custom configuration, combined with linked files, to establish connections and make queries." I was, and continue to be very hesistant about this because apis are safer. However, with sufficient protections these concerns could be mitigated, just not as well as with a .net api.
Regardless . . . I am hoping that php can be utilized.


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

