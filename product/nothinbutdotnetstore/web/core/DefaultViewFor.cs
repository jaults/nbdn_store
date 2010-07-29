using System.Web.UI;

namespace nothinbutdotnetstore.web.core
{
    public class DefaultViewFor<ViewModel> :Page,View<ViewModel>
    {
        public ViewModel display_model { get; set; }

        public LinkBuilder<T> Link<T>()
        {
            return new LinkBuilder<T>();
        }
    }
}