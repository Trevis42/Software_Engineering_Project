using Microsoft.Azure.Mobile.Server;

namespace contact_betaService.DataObjects
{
    public class TodoItem : EntityData
    {
        public string Text { get; set; }

        public bool Complete { get; set; }
    }
}