 using System.Web;
 using Machine.Specifications;
 using Machine.Specifications.DevelopWithPassion.Rhino;
 using nothinbutdotnetstore.specs.utility;
 using nothinbutdotnetstore.web;
 using nothinbutdotnetstore.web.core;
 using Rhino.Mocks;

namespace nothinbutdotnetstore.specs.web
 {   
     public class RawHandlerSpecs
     {
         public abstract class concern : Observes<IHttpHandler,
                                             RawHandler>
         {
        
         }

         public class when_determining_if_it_can_be_reused : concern
         {
             Because b = () =>
                 result = sut.IsReusable;

             It should_always_be_reusable = () =>
                 result.ShouldBeTrue();


             static bool result;
  
         }

         [Subject(typeof(RawHandler))]
         public class when_processing_an_http_context : concern
         {
             Establish c = () =>
             {
                 http_context = ObjectMother.create_http_context();
                 front_controller = the_dependency<FrontController>();
                 request_factory = the_dependency<RequestFactory>();

                 request = an<Request>();
                 request_factory.Stub(factory => factory.create_request_from(http_context)).Return(request);

             };

             Because b = () =>
                 sut.ProcessRequest(http_context);


             It should_delegate_the_processing_of_the_request_to_the_front_controller = () =>
                 front_controller.received(controller => controller.process(request));

             static FrontController front_controller;
             static Request request;
             static HttpContext http_context;
             static RequestFactory request_factory;
         }
     }
 }
