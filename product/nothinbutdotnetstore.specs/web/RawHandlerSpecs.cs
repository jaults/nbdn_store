 using System.Web;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;

namespace nothinbutdotnetstore.specs.web
 {   
     public class RawHandlerSpecs
     {
         public abstract class concern : Observes<IHttpHandler,
                                             RawHandler>
         {
        
         }

         [Subject(typeof(RawHandler))]
         public class when_observation_name : concern
         {
        
             It first_observation = () =>        
                 
         }
     }
 }
