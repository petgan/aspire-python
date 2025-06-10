# from django.utils.deprecation import MiddlewareMixin
# from opentelemetry import trace

# tracer = trace.get_tracer(__name__)

# class OpenTelemetryMiddleware(MiddlewareMixin):
#     def process_request(self, request):
#         with tracer.start_as_current_span("middleware_request") as span:
#             span.set_attribute("path", request.path)
#             span.set_attribute("method", request.method)
    
#     def process_response(self, request, response):
#         return response